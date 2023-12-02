using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncryptionKey
{
    public List<string> Letters = new List<string>();

    public EncryptionKey(string key) {
        for (int i = 0; i < key.Length; i++) {
            Letters.Add(key[i].ToString());
        }
    }
}
