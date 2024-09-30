using UnityEngine;

public class GestionSectionCible : MonoBehaviour {
    [SerializeField] int ValeurPointage;

    GestionPointage script = null;

    public void InitialiserSectionCible(GestionPointage scriptPointage) {
        script = scriptPointage;

        script.InitialiserPointage(ValeurPointage);

    }

    private void OnCollisionEnter(Collision collision) {
        //if (projectile) 
        script.ModifierPointage(ValeurPointage);

    }
}
