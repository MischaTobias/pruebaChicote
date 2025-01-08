import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../providers/search_provider.dart';

class SearchScreen extends StatelessWidget {
  const SearchScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<SearchProvider>(context);

    return Scaffold(
      appBar: AppBar(
        title: Text('Búsqueda Centralizada'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: TextField(
              decoration: InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'Buscar...',
              ),
              onSubmitted: (query) {
                provider.search(query);
              },
            ),
          ),
          if (provider.isLoading)
            CircularProgressIndicator()
          else
            Expanded(
              child: ListView.builder(
                itemCount: provider.results.length,
                itemBuilder: (context, index) {
                  final result = provider.results[index];
                  return ListTile(
                    title: Text(result['title']),
                    subtitle: Text('Fuente: ${result['source']}'),
                  );
                },
              ),
            ),
        ],
      ),
    );
  }
}
