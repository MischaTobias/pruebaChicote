import 'package:flutter/material.dart';

class SearchProvider extends ChangeNotifier {
  List<Map<String, dynamic>> _results = [];
  bool _isLoading = false;

  List<Map<String, dynamic>> get results => _results;
  bool get isLoading => _isLoading;

  Future<void> search(String query) async {
    _isLoading = true;
    notifyListeners();

    try {
      // Aquí se realiza la lógica para llamar a tu API y obtener resultados.
      await Future.delayed(Duration(
          seconds: 2)); // Simula una espera por la respuesta de la API.
      _results = [
        {'title': 'Resultado 1', 'source': 'Fuente A'},
        {'title': 'Resultado 2', 'source': 'Fuente B'},
      ];
    } catch (e) {
      _results = [];
    }

    _isLoading = false;
    notifyListeners();
  }
}
