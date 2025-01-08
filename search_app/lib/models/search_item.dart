class SearchItem {
  final String source;
  final String title;
  final String description;
  final String url;

  SearchItem({
    required this.source,
    required this.title,
    required this.description,
    required this.url,
  });

  factory SearchItem.fromJson(Map<String, dynamic> json) {
    return SearchItem(
      source: json['source'] ?? '',
      title: json['title'] ?? 'Unknown Title',
      description: json['description'] ?? 'No Description Available',
      url: json['url'] ?? 'No URL Available',
    );
  }
}
