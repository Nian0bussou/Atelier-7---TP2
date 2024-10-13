using UnityEngine;

public class GestionPointage : MonoBehaviour {
    [SerializeField] TextMesh TableauPointage;

    public int ValeurPointage { get; private set; }
    void Awake() {
        TableauPointage.text = "000";
        ValeurPointage = 0;
    }

    public void InitialiserPointage(int valeurInitiale) {
        ValeurPointage = valeurInitiale;
        print(ValeurPointage);
    }

    public void ModifierPointage(int modification) {
        print($"Got : {modification}");
        ValeurPointage += modification;
        TableauPointage.text = $"{ValeurPointage}";

    }

}
