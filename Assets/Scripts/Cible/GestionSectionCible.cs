using Unity.Loading;
using UnityEngine;

public class GestionSectionCible : MonoBehaviour {
    [SerializeField] int ValeurPointage;
    [SerializeField] int projectileLayer = 9;

    GestionPointage script = null;

    public void InitialiserSectionCible(GestionPointage scriptPointage) {
        script = scriptPointage;
        script.InitialiserPointage(ValeurPointage);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == projectileLayer) {
            script.ModifierPointage(ValeurPointage);
            //FsmJeu.DétruireCible(/* not sure what to put here */);
        }
    }
}
