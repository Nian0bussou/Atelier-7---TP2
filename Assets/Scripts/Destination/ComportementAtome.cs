using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementAtome : MonoBehaviour {
    const int Nb…lectronsMin = 4;
    const int Nb…lectronsMax = 8;
    [SerializeField] GameObject ModËle…lectron;


    List<GameObject> Electrons;
    void Awake() {
        System.Random r = new();
        var ns = r.Next(Nb…lectronsMin, Nb…lectronsMax + 1);
        for (int i = 0;i < ns;i++) {
            Electrons[i] = Instantiate(ModËle…lectron);
        }
    }
}
