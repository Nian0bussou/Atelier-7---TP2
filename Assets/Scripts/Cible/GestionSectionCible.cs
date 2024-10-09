using Unity.Loading;
using UnityEngine;

public class GestionSectionCible : MonoBehaviour {
    [SerializeField] int ValeurPointage;
    [SerializeField] int projectileLayer = 9;

    GestionPointage script = null;

    FsmJeu fsmJeu;

    public void InitialiserSectionCible(GestionPointage scriptPointage) {
        script = scriptPointage;
        script.InitialiserPointage(ValeurPointage);
    }

    private void OnCollisionEnter(Collision collision) {


        if (collision.gameObject.layer == projectileLayer) {
            print("passed the if"); // got here

            //script.ModifierPointage(ValeurPointage);


            var gestioncible = GetComponentInParent<GestionCible>();

            gestioncible.DétruireCible();
        }
    }
}
