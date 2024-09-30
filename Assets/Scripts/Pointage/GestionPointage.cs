using UnityEngine;

public class GestionPointage : MonoBehaviour {
    TextMesh TableauPointage;
    public int ValeurPointage { get; private set; }
    void Awake() {
        // initialisation des attributs du script
    }

    public void InitialiserPointage(int valeurInitiale) {
        // M�thode appel�e pour donner une valeur au pointage
        ValeurPointage = valeurInitiale;
    }

    public void ModifierPointage(int modification) {
        // M�thode appel�e pour ajouter une valeur au pointage
        ValeurPointage += modification;
    }

}
