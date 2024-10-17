using UnityEngine;

// Maxime

public class DeplacementCamera : MonoBehaviour {
    GameObject Vaisseau = null;
    bool EstLiéeAuVaisseau = false;

    void Update() {
        if (EstLiéeAuVaisseau) {
            var cpos = transform.position;
            var vpos = Vaisseau.transform.position;

            transform.position = new(vpos.x, cpos.y, vpos.z);
        }
    }

    public void AffecterCaméraAuVaisseau(GameObject vaisseau) {
        Vaisseau = vaisseau;
        EstLiéeAuVaisseau = true;
    }
}
