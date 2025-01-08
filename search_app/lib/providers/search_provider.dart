import 'package:flutter/material.dart';
import 'package:search_app/models/search_item.dart';
import 'package:search_app/services/search_service.dart'; // Adjust path if necessary

class SearchProvider extends ChangeNotifier {
  final SearchService searchService;
  List<SearchItem> _results = [];
  bool _isLoading = false;
  int _currentPage = 1;
  bool _hasMoreResults = true;
  ScrollController scrollController = ScrollController();

  SearchProvider({required this.searchService});

  List<SearchItem> get results => _results;
  bool get isLoading => _isLoading;

  @override
  void dispose() {
    scrollController.dispose();
    super.dispose();
  }

  // Method to initiate a new search with the query and page
  Future<void> search(String query, int page) async {
    _isLoading = true;
    _currentPage = 1; // Reset page to 1 for new search
    _results.clear(); // Clear previous results
    _hasMoreResults = true; // Reset pagination
    notifyListeners();

    try {
      final response = await searchService.fetchItems(query, _currentPage);
      print("API Response: ${response.results}"); // Add logging here
      _results.addAll(response.results);
      _hasMoreResults = response.results.isNotEmpty;
    } catch (e) {
      print("Error fetching data: $e"); // Catch and log any errors
      _results = [];
    }

    _isLoading = false;
    notifyListeners();
  }

  // Method to load more results when user scrolls to the bottom
  Future<void> loadMoreResults() async {
    if (!_hasMoreResults || _isLoading) return;

    _isLoading = true;
    _currentPage++;
    notifyListeners();

    try {
      final response = await searchService.fetchItems(
        'query', // Use the current search query here
        _currentPage,
      );
      _results.addAll(response.results);
      _hasMoreResults = response.results.isNotEmpty;
    } catch (e) {
      _hasMoreResults = false;
    }

    _isLoading = false;
    notifyListeners();
  }

  // Call this method to listen for scroll position
  void onScroll() {
    if (scrollController.position.pixels ==
        scrollController.position.maxScrollExtent) {
      loadMoreResults();
    }
  }
}
