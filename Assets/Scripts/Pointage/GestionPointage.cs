using UnityEngine;

public class GestionPointage : MonoBehaviour {
    TextMesh TableauPointage;

    public int ValeurPointage { get; private set; }
    void Awake() {
        TableauPointage.text = "000";
        ValeurPointage = 0;
    }

    public void InitialiserPointage(int valeurInitiale) {
        ValeurPointage = valeurInitiale;
    }

    public void ModifierPointage(int modification) {
        ValeurPointage += modification;
        TableauPointage.text = $"{ValeurPointage}";
    }

}
