using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteForceDoor : MonoBehaviour
{
    List<string> letters = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    int passwordLenght = 4;
    [SerializeField] string password = "5678";

    private void Start() {
        
    }

    private void GeneratePassword() {
        password = "";
        for (int i = 0; i < passwordLenght; i++) {
            password += letters[Random.Range(0, letters.Count)];
        }
    }

    public void TryBruteForce(List<EncryptionKey> keys) {
        int CalculationsCount = 0;
        //foreach (var key in keys) {
        //    CalculationsCount
        //}
    }
}
