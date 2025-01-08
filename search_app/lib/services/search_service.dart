import 'dart:convert';
import 'package:http/http.dart' as http;
import '../models/search_api_response.dart';

class SearchService {
  final String baseUrl;

  SearchService({required this.baseUrl});

  Future<SearchApiResponse> fetchItems(String query, int page) async {
    final response = await http.get(
      Uri.parse('$baseUrl?query=$query&page=$page'),
    );

    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      return SearchApiResponse.fromJson(jsonResponse);
    } else {
      throw Exception('Failed to load items');
    }
  }
}
