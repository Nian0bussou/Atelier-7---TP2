using System.Linq;
using UnityEngine;

public class MouvementVaisseau : MonoBehaviour
{
   const int NbRétrofusées = 6;
   const int NbRéacteurs = 4;
   const int RétroAvantGauche = 0;
   const int RétroAvantDroite = 1;
   const int RétroArrièreGauche = 2;
   const int RétroArrièreDroite = 3;
   const int RétroHautGauche = 4;
   const int RétroHautDroite = 5;
   const int RéacteurHautGauche = 0;
   const int RéacteurHautDroite = 1;
   const int RéacteurBasGauche = 2;
   const int RéacteurBasDroite = 3;

   [SerializeField] float forceRéacteurs = 250f;
   [SerializeField] float forceRétrofusée = 50f;

   Rigidbody CorpsVaisseau;
   TrailRenderer[] Rétrofusées;
   TrailRenderer[] Réacteurs;

   private void Awake()
   {
      CorpsVaisseau = GetComponent<Rigidbody>();
      Rétrofusées = new TrailRenderer[NbRétrofusées];
      Réacteurs = new TrailRenderer[NbRéacteurs];
      Transform[] transformDuVaisseau = GetComponentsInChildren<Transform>();
      Rétrofusées[RétroAvantGauche] = IdentifierPropulseur(transformDuVaisseau, "RétroAvantGauche");
      Rétrofusées[RétroAvantDroite] = IdentifierPropulseur(transformDuVaisseau, "RétroAvantDroite");
      Rétrofusées[RétroArrièreGauche] = IdentifierPropulseur(transformDuVaisseau, "RétroArrièreGauche");
      Rétrofusées[RétroArrièreDroite] = IdentifierPropulseur(transformDuVaisseau, "RétroArrièreDroite");
      Rétrofusées[RétroHautGauche] = IdentifierPropulseur(transformDuVaisseau, "RétroHautGauche");
      Rétrofusées[RétroHautDroite] = IdentifierPropulseur(transformDuVaisseau, "RétroHautDroite");
      Réacteurs[RéacteurHautGauche] = IdentifierPropulseur(transformDuVaisseau, "HautGauche");
      Réacteurs[RéacteurHautDroite] = IdentifierPropulseur(transformDuVaisseau, "HautDroite");
      Réacteurs[RéacteurBasGauche] = IdentifierPropulseur(transformDuVaisseau, "BasGauche");
      Réacteurs[RéacteurBasDroite] = IdentifierPropulseur(transformDuVaisseau, "BasDroite");
      ÉteindrePropulseur(Rétrofusées);
      ÉteindrePropulseur(Réacteurs);
   }

   private TrailRenderer IdentifierPropulseur(Transform[] dataTransform, string idPropulseur)
   {
      // Cette méthodes retourne la référence sur le TrailRenderer
      // lié à un propulseur (réacteur ou rétrofusée) identifié par son nom.

      return null; // Cette instruction est évidemment à modifier
   }

   private void ÉteindrePropulseur(TrailRenderer[] propulseurs)
   {
      // Cette méthode permet de parcourir un tableau de TrailRenderer pour les désactiver (les éteindre...)
   }

   public void PivoterVersLaGauche(bool commutateur)
   {
      // Cette méthode permet de faire pivoter le vaisseau vers la gauche par l'application de force (simulation physique)
      // Le paramètre commutateur permet d'allumer ou d'éteindre les rétrofusées impliqués dans la manoeuvre (simulation visuelle)
      // Indice : dans cette méthode, il est possible de "tricher" en réinitialisant la vitesse angulaire à la fin de la manoeuvre
      //          cela rendra le vaisseau plus manoeuvrable.
   }

   public void PivoterVersLaDroite(bool commutateur)
   {
      // Cette méthode permet de faire pivoter le vaisseau vers la droite par l'application de force (simulation physique)
      // Le paramètre commutateur permet d'allumer ou d'éteindre les rétrofusées impliqués dans la manoeuvre (simulation visuelle)
      // Indice : dans cette méthode, il est possible de "tricher" en réinitialisant la vitesse angulaire à la fin de la manoeuvre
      //          cela rendra le vaisseau plus manoeuvrable.
   }

   public void Avancer(bool commutateur)
   {
      // Cette méthode permet de faire avancer le vaisseau par l'application de force (simulation physique)
      // Le paramètre commutateur permet d'allumer ou d'éteindre les réacteurs impliqués dans la manoeuvre (simulation visuelle)
   }

   public void Reculer(bool commutateur)
   {
      // Cette méthode permet de faire reculer le vaisseau par l'application de force (simulation physique)
      // Le paramètre commutateur permet d'allumer ou d'éteindre les rétrofusées impliqués dans la manoeuvre (simulation visuelle)
   }

   public void GlisserVersLaGauche(bool commutateur)
   {
      // Cette méthode permet de faire glisser le vaisseau vers la gauche par l'application de force (simulation physique)
      // Le paramètre commutateur permet d'allumer ou d'éteindre les rétrofusées impliqués dans la manoeuvre (simulation visuelle)
   }

   public void GlisserVersLaDroite(bool commutateur)
   {
      // Cette méthode permet de faire glisser le vaisseau vers la droite  par l'application de force (simulation physique)
      // Le paramètre commutateur permet d'allumer ou d'éteindre les rétrofusées impliqués dans la manoeuvre (simulation visuelle)
   }
}
