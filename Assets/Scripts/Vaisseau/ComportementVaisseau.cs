using System;
using Unity.Loading;
using UnityEngine;
// Olivier


public class ComportementVaisseau : MonoBehaviour {
    const int PénalitéCollision = 5;
    GestionPointage ScriptPointage { get; set; }
    GameObject KarenGameManager { get; set; }
    [SerializeField] int dest_layer = 8;
    FsmJeu fsmJeu = null;
    readonly int caisselayer = 6;
    readonly int ciblelayer = 7;
    readonly int mineLayer = 11;

    public void InitialiserComportementVaisseau(GestionPointage scriptPointage, GameObject gameManager) {
        ScriptPointage = scriptPointage;
        KarenGameManager = gameManager;
        fsmJeu = KarenGameManager.GetComponent<FsmJeu>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == caisselayer ||
            other.gameObject.layer == ciblelayer) {
            ScriptPointage.ModifierPointage(-PénalitéCollision);
        }
        var conts = other.contacts;
        foreach (var contact in conts) {
            if (contact.otherCollider.gameObject.layer == dest_layer) {
                fsmJeu.TrouverDestination();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == mineLayer) {
            ScriptPointage.ModifierPointage(-( PénalitéCollision * 2 ));
        }
    }
}
