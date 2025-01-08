import 'package:flutter/material.dart';
import 'package:search_app/models/search_item.dart';
import 'package:search_app/services/search_service.dart'; // Adjust path if necessary

class SearchProvider extends ChangeNotifier {
  final SearchService searchService;
  List<SearchItem> _results = [];
  bool _isLoading = false;
  int _currentPage = 1;
  bool _hasMoreResults = true;
  String _currentQuery = ''; // Store the current query entered by the user

  SearchProvider({required this.searchService});

  List<SearchItem> get results => _results;
  bool get isLoading => _isLoading;
  int get currentPage => _currentPage;
  bool get hasMoreResults => _hasMoreResults;

  @override
  void dispose() {
    super.dispose();
  }

  // Method to initiate a new search with the query and page
  Future<void> search(String query, int page) async {
    _isLoading = true;
    _currentPage = page; // Set to the page passed in the method
    _currentQuery = query; // Store the query entered by the user
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

  // Method to load results for a specific page
  Future<void> loadPage(int page) async {
    if (_isLoading) return;

    _isLoading = true;
    _currentPage = page; // Update the current page
    notifyListeners();

    try {
      final response = await searchService.fetchItems(
        _currentQuery, // Pass the actual search query to the API
        _currentPage,
      );
      _results = response.results;
      _hasMoreResults = response.results.isNotEmpty;
    } catch (e) {
      _hasMoreResults = false;
    }

    _isLoading = false;
    notifyListeners();
  }
}
