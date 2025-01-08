import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:search_app/environment.dart';
import 'services/search_service.dart';
import 'providers/search_provider.dart';
import 'screens/search_screen.dart';

void main() async {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(
          create: (_) => SearchProvider(
            searchService: SearchService(baseUrl: Environment.baseUrl),
          ),
        ),
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Search App',
        theme: ThemeData(
          primarySwatch: Colors.blue,
        ),
        home: SearchScreen(),
      ),
    );
  }
}
