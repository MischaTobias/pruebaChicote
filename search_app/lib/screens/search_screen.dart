import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../providers/search_provider.dart';
import '../services/search_service.dart'; // Adjust path if necessary

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
                  onChanged: (query) {
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
                    itemCount: provider.results.length +
                        1, // Extra space for loading more
                    itemBuilder: (context, index) {
                      if (index == provider.results.length) {
                        // Load more if reached end of list
                        provider.loadMoreResults();
                        return const Center(child: CircularProgressIndicator());
                      }

                      final item = provider.results[index];
                      return ListTile(
                        title: Text(item.title),
                        subtitle: Text(item.source),
                      );
                    },
                    // Listen for scroll and load more results when scrolled to the bottom
                    controller: provider.scrollController,
                  ),
                ),
              // Empty message
              if (!provider.isLoading && provider.results.isEmpty)
                const Center(child: Text('No results found')),
            ],
          );
        },
      ),
    );
  }
}
