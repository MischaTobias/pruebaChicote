import 'package:flutter/material.dart';
import 'package:google_sign_in/google_sign_in.dart';

class AuthProvider with ChangeNotifier {
  final GoogleSignIn _googleSignIn = GoogleSignIn();

  GoogleSignInAccount? _user;
  GoogleSignInAccount get user => _user!;

  bool get isSignedIn => _user != null;

  // Sign-in method
  Future<void> signIn() async {
    try {
      _user = await _googleSignIn.signIn();
      if (_user != null) {
        // Send the OAuth token to the backend for validation and authorization
        String? idToken =
            await _user?.authentication.then((value) => value.idToken);
        print('OAuth Token: $idToken');
        // You can send the idToken to your API for authentication here
        notifyListeners();
      }
    } catch (error) {
      print("Sign-In Error: $error");
    }
  }

  // Sign-out method
  Future<void> signOut() async {
    await _googleSignIn.signOut();
    _user = null;
    notifyListeners();
  }
}
