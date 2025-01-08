import 'package:flutter/material.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:provider/provider.dart';
import 'services/search_service.dart';
import 'providers/search_provider.dart';
import 'screens/search_screen.dart';

void main() async {
  await dotenv.load(); // Load the .env file

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
            searchService: SearchService(baseUrl: dotenv.env['API_BASE_URL']!),
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
