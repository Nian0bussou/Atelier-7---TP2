using System.Linq;
using UnityEngine;

public class GestionCible : MonoBehaviour
{
   [SerializeField] float VitesseAngulaire = 180;
   FsmJeu gameManagerScript { get; set; }
 
   void Update()
   {
      // � compl�ter
   }

   public void InitialiserComportementCible(GestionPointage scriptPointage, GameObject gameManager)
   {
      gameManagerScript = gameManager.GetComponent<FsmJeu>();
      GestionSectionCible[] cibles = GetComponentsInChildren<GestionSectionCible>();
      cibles.First<GestionSectionCible>(X => X.gameObject.name == "CibleExt�rieure").InitialiserSectionCible(scriptPointage);
      cibles.First<GestionSectionCible>(X => X.gameObject.name == "CibleM�diane").InitialiserSectionCible(scriptPointage);
      cibles.First<GestionSectionCible>(X => X.gameObject.name == "CibleInt�rieure").InitialiserSectionCible(scriptPointage);
   }

   public void D�truireCible() => gameManagerScript.D�truireCible(gameObject);
}
