using System;
using Unity.Loading;
using UnityEngine;
public class ComportementVaisseau : MonoBehaviour {
    const int PénalitéCollision = 5;


    // constantes et attributs à compléter

    GestionPointage ScriptPointage { get; set; }
    GameObject KarenGameManager { get; set; }

    [SerializeField] GameObject destGameObj;

    int caisselayer = 6;
    int ciblelayer = 7;

    public void InitialiserComportementVaisseau(GestionPointage scriptPointage, GameObject gameManager) {
        // à compléter

        ScriptPointage = scriptPointage;
        KarenGameManager = gameManager;
    }

    private void OnCollisionEnter(Collision collision) {
        // à compléter

        // Mur -> 6 // Caisse => Mur 


        if (collision.gameObject.layer == caisselayer ||
            collision.gameObject.layer == ciblelayer) {

            ScriptPointage.ModifierPointage(PénalitéCollision);
        }

        var conts = collision.contacts;

        var destcoll = destGameObj.GetComponent<Collider>();

        foreach (var contact in conts) {

            if (contact.thisCollider == destcoll) {

            }
        }

    }
}
