import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../providers/search_provider.dart';

class SearchScreen extends StatelessWidget {
  const SearchScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Search')),
      body: Consumer<SearchProvider>(
        builder: (context, provider, child) {
          return Column(
            children: [
              // Search Input
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: TextField(
                  onSubmitted: (query) {
                    provider.search(
                        query, 1); // Start with page 1 for a new query
                  },
                  decoration: InputDecoration(
                    labelText: 'Search',
                    border: OutlineInputBorder(),
                  ),
                ),
              ),

              // Loading indicator
              if (provider.isLoading)
                const Center(child: CircularProgressIndicator()),

              // List of search results
              if (!provider.isLoading && provider.results.isNotEmpty)
                Expanded(
                  child: ListView.builder(
                    itemCount: provider.results.length,
                    itemBuilder: (context, index) {
                      final item = provider.results[index];
                      return ListTile(
                        title: Text(item.title),
                        subtitle: Text(item.source),
                      );
                    },
                  ),
                ),
              // Empty message
              if (!provider.isLoading && provider.results.isEmpty)
                const Center(child: Text('No results found')),

              // Pagination Controls
              if (!provider.isLoading && provider.results.isNotEmpty)
                Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      // Previous Button
                      if (provider.currentPage > 1)
                        ElevatedButton(
                          onPressed: () {
                            provider.loadPage(provider.currentPage - 1);
                          },
                          child: Text('Previous'),
                        ),

                      const SizedBox(width: 10),

                      // Next Button
                      if (provider.hasMoreResults)
                        ElevatedButton(
                          onPressed: () {
                            provider.loadPage(provider.currentPage + 1);
                          },
                          child: Text('Next'),
                        ),
                    ],
                  ),
                ),
            ],
          );
        },
      ),
    );
  }
}
