import 'search_item.dart';

class SearchApiResponse {
  final int totalResults;
  final int page;
  final int pageSize;
  final int totalPages;
  final List<SearchItem> results;

  SearchApiResponse({
    required this.totalResults,
    required this.page,
    required this.pageSize,
    required this.totalPages,
    required this.results,
  });

  factory SearchApiResponse.fromJson(Map<String, dynamic> json) {
    return SearchApiResponse(
      totalResults: json['totalResults'] ?? 0,
      page: json['page'] ?? 0,
      pageSize: json['pageSize'] ?? 0,
      totalPages: json['totalPages'] ?? 0,
      results: List<SearchItem>.from(
        json['results']?.map((x) => SearchItem.fromJson(x)) ?? [],
      ),
    );
  }
}
