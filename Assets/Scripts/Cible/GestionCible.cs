using System.Linq;
using UnityEngine;

// Maxime

public class GestionCible : MonoBehaviour {
    [SerializeField] float VitesseAngulaire = 180;
    FsmJeu gameManagerScript { get; set; }

    void Update() =>
        transform.Rotate(new Vector3(0, 0, VitesseAngulaire) * Time.deltaTime);


    public void InitialiserComportementCible(GestionPointage scriptPointage, GameObject gameManager) {
        gameManagerScript = gameManager.GetComponent<FsmJeu>();
        GestionSectionCible[] cibles = GetComponentsInChildren<GestionSectionCible>();
        cibles.First<GestionSectionCible>(X => X.gameObject.name == "CibleExtérieure").InitialiserSectionCible(scriptPointage);
        cibles.First<GestionSectionCible>(X => X.gameObject.name == "CibleMédiane").InitialiserSectionCible(scriptPointage);
        cibles.First<GestionSectionCible>(X => X.gameObject.name == "CibleIntérieure").InitialiserSectionCible(scriptPointage);
    }

    public void DétruireCible() => gameManagerScript.DétruireCible(gameObject);
}
