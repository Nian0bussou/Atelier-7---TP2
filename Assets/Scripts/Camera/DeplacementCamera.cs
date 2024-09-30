using UnityEngine;

public class DeplacementCamera : MonoBehaviour {
    GameObject Vaisseau = null;
    bool EstLiéeAuVaisseau = false;

    void Update() {
        if (EstLiéeAuVaisseau) {
            transform.position = Vaisseau.transform.position;

        }
    }

    public void AffecterCaméraAuVaisseau(GameObject vaisseau) {
        Vaisseau = vaisseau;
        EstLiéeAuVaisseau = true;
    }
}
