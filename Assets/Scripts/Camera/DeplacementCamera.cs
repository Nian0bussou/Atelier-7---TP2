using UnityEngine;

public class DeplacementCamera : MonoBehaviour {
    GameObject Vaisseau = null;
    bool EstLiéeAuVaisseau = false;

    void Update() {
        if (EstLiéeAuVaisseau) {
            // À compléter
            // Ce bout de code permet de modifier la position de la caméra de façon à ce qu'elle se soit toujours située au-dessus du vaisseau 

            //transform.position = Vaisseau.transform.position; 

            var pos = transform.position;
            var vpos = transform.position;


            transform.position = new(vpos.x, pos.y, vpos.z);
        }
    }

    public void AffecterCaméraAuVaisseau(GameObject vaisseau) {
        Vaisseau = vaisseau;
        EstLiéeAuVaisseau = true;
    }
}
