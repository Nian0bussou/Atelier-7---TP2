using UnityEngine;

public class DeplacementCamera : MonoBehaviour
{
   GameObject Vaisseau = null;
   bool EstLiéeAuVaisseau = false;
   void Update()
   {
      if (EstLiéeAuVaisseau)
      {
         // À compléter
         // Ce bout de code permet de modifier la position de la caméra de façon à ce qu'elle se soit toujours située au-dessus du vaisseau 
      }
   }

   public void AffecterCaméraAuVaisseau(GameObject vaisseau)
   {
      Vaisseau = vaisseau;
      EstLiéeAuVaisseau = true;
   }
}
