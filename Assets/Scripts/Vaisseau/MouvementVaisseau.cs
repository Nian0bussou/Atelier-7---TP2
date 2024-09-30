using System.Linq;
using UnityEngine;

public class MouvementVaisseau : MonoBehaviour
{
   const int NbR�trofus�es = 6;
   const int NbR�acteurs = 4;
   const int R�troAvantGauche = 0;
   const int R�troAvantDroite = 1;
   const int R�troArri�reGauche = 2;
   const int R�troArri�reDroite = 3;
   const int R�troHautGauche = 4;
   const int R�troHautDroite = 5;
   const int R�acteurHautGauche = 0;
   const int R�acteurHautDroite = 1;
   const int R�acteurBasGauche = 2;
   const int R�acteurBasDroite = 3;

   [SerializeField] float forceR�acteurs = 250f;
   [SerializeField] float forceR�trofus�e = 50f;

   Rigidbody CorpsVaisseau;
   TrailRenderer[] R�trofus�es;
   TrailRenderer[] R�acteurs;

   private void Awake()
   {
      CorpsVaisseau = GetComponent<Rigidbody>();
      R�trofus�es = new TrailRenderer[NbR�trofus�es];
      R�acteurs = new TrailRenderer[NbR�acteurs];
      Transform[] transformDuVaisseau = GetComponentsInChildren<Transform>();
      R�trofus�es[R�troAvantGauche] = IdentifierPropulseur(transformDuVaisseau, "R�troAvantGauche");
      R�trofus�es[R�troAvantDroite] = IdentifierPropulseur(transformDuVaisseau, "R�troAvantDroite");
      R�trofus�es[R�troArri�reGauche] = IdentifierPropulseur(transformDuVaisseau, "R�troArri�reGauche");
      R�trofus�es[R�troArri�reDroite] = IdentifierPropulseur(transformDuVaisseau, "R�troArri�reDroite");
      R�trofus�es[R�troHautGauche] = IdentifierPropulseur(transformDuVaisseau, "R�troHautGauche");
      R�trofus�es[R�troHautDroite] = IdentifierPropulseur(transformDuVaisseau, "R�troHautDroite");
      R�acteurs[R�acteurHautGauche] = IdentifierPropulseur(transformDuVaisseau, "HautGauche");
      R�acteurs[R�acteurHautDroite] = IdentifierPropulseur(transformDuVaisseau, "HautDroite");
      R�acteurs[R�acteurBasGauche] = IdentifierPropulseur(transformDuVaisseau, "BasGauche");
      R�acteurs[R�acteurBasDroite] = IdentifierPropulseur(transformDuVaisseau, "BasDroite");
      �teindrePropulseur(R�trofus�es);
      �teindrePropulseur(R�acteurs);
   }

   private TrailRenderer IdentifierPropulseur(Transform[] dataTransform, string idPropulseur)
   {
      // Cette m�thodes retourne la r�f�rence sur le TrailRenderer
      // li� � un propulseur (r�acteur ou r�trofus�e) identifi� par son nom.

      return null; // Cette instruction est �videmment � modifier
   }

   private void �teindrePropulseur(TrailRenderer[] propulseurs)
   {
      // Cette m�thode permet de parcourir un tableau de TrailRenderer pour les d�sactiver (les �teindre...)
   }

   public void PivoterVersLaGauche(bool commutateur)
   {
      // Cette m�thode permet de faire pivoter le vaisseau vers la gauche par l'application de force (simulation physique)
      // Le param�tre commutateur permet d'allumer ou d'�teindre les r�trofus�es impliqu�s dans la manoeuvre (simulation visuelle)
      // Indice : dans cette m�thode, il est possible de "tricher" en r�initialisant la vitesse angulaire � la fin de la manoeuvre
      //          cela rendra le vaisseau plus manoeuvrable.
   }

   public void PivoterVersLaDroite(bool commutateur)
   {
      // Cette m�thode permet de faire pivoter le vaisseau vers la droite par l'application de force (simulation physique)
      // Le param�tre commutateur permet d'allumer ou d'�teindre les r�trofus�es impliqu�s dans la manoeuvre (simulation visuelle)
      // Indice : dans cette m�thode, il est possible de "tricher" en r�initialisant la vitesse angulaire � la fin de la manoeuvre
      //          cela rendra le vaisseau plus manoeuvrable.
   }

   public void Avancer(bool commutateur)
   {
      // Cette m�thode permet de faire avancer le vaisseau par l'application de force (simulation physique)
      // Le param�tre commutateur permet d'allumer ou d'�teindre les r�acteurs impliqu�s dans la manoeuvre (simulation visuelle)
   }

   public void Reculer(bool commutateur)
   {
      // Cette m�thode permet de faire reculer le vaisseau par l'application de force (simulation physique)
      // Le param�tre commutateur permet d'allumer ou d'�teindre les r�trofus�es impliqu�s dans la manoeuvre (simulation visuelle)
   }

   public void GlisserVersLaGauche(bool commutateur)
   {
      // Cette m�thode permet de faire glisser le vaisseau vers la gauche par l'application de force (simulation physique)
      // Le param�tre commutateur permet d'allumer ou d'�teindre les r�trofus�es impliqu�s dans la manoeuvre (simulation visuelle)
   }

   public void GlisserVersLaDroite(bool commutateur)
   {
      // Cette m�thode permet de faire glisser le vaisseau vers la droite  par l'application de force (simulation physique)
      // Le param�tre commutateur permet d'allumer ou d'�teindre les r�trofus�es impliqu�s dans la manoeuvre (simulation visuelle)
   }
}
