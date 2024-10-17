using Unity.Loading;
using UnityEngine;

// Maxime & Olivier

public class GestionSectionCible : MonoBehaviour {
    [SerializeField] int ValeurPointage;
    [SerializeField] int projectileLayer = 9;

    GestionCible gestioncible;
    GestionPointage _script;
    GestionPointage Script { get; set; }

    public void InitialiserSectionCible(GestionPointage scriptPointage) {
        Script = scriptPointage;
        Script.InitialiserPointage(ValeurPointage);
        gestioncible = GetComponentInParent<GestionCible>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == projectileLayer) {
            Script.ModifierPointage(ValeurPointage);
            gestioncible.DétruireCible();
        }
    }
}
