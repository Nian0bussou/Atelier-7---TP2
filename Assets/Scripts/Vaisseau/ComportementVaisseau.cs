using System;
using Unity.Loading;
using UnityEngine;
public class ComportementVaisseau : MonoBehaviour {
    const int PénalitéCollision = 5;


    // constantes et attributs à compléter

    GestionPointage ScriptPointage { get; set; }
    GameObject KarenGameManager { get; set; }


    [SerializeField] int dest_layer = 8;

    FsmJeu fsmJeu = null;


    int caisselayer = 6;
    int ciblelayer = 7;

    public void InitialiserComportementVaisseau(GestionPointage scriptPointage, GameObject gameManager) {
        // à compléter

        ScriptPointage = scriptPointage;
        KarenGameManager = gameManager;

        fsmJeu = KarenGameManager.GetComponent<FsmJeu>();
    }

    private void OnCollisionEnter(Collision collision) {
        // à compléter

        // Mur -> 6 // Caisse => Mur 


        if (collision.gameObject.layer == caisselayer ||
            collision.gameObject.layer == ciblelayer) {

            ScriptPointage.ModifierPointage(-PénalitéCollision);
        }

        var conts = collision.contacts;
        foreach (var contact in conts) {
            print("contact");
            if (contact.otherCollider.gameObject.layer == dest_layer) {
                print("dest contact");
                fsmJeu.TrouverDestination();
            }
        }

    }
}
