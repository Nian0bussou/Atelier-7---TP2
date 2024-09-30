using System;
using System.Collections.Generic;
using UnityEngine;

public class FsmJeu : MonoBehaviour
{
   #region Attributs modifiables dans l'éditeur
   [SerializeField] GameObject PanneauMessage;//le gameObject servant à afficher le message de fin

   [SerializeField] GameObject Pointage;//le gameObject servant à afficher le pointage

   [SerializeField] GameObject Vaisseau;//le gameObject du vaisseau

   [SerializeField] GameObject Caisse;//le prefab de la caisse

   [SerializeField] GameObject Cible;//le prefab de la cible

   [SerializeField] GameObject Mine;//le prefab de la mine

   [SerializeField] GameObject Destination;

   [SerializeField] String NomCarte = "Map0.txt";

   #endregion

   #region Attributs FSM
   enum ÉtatJeu { InitialisationJeu, InitialisationNiveau, DéroulementNiveau, FinNiveau, FinJeu, NbÉtatsJeu };
   enum TransitionJeu { Activation, EnMarche, Terminé };

   delegate void ActionFSM();
   ActionFSM[] ActionsÉtat { get; set; }
   ÉtatJeu ÉtatActuel { get; set; }
   TransitionJeu TransitionÉtat { get; set; }
   #endregion

   #region Autres attributs
   int NbCiblesNiveau { get; set; }
   List<GameObject> ÉlémentsNiveau { get; set; }
   bool EstNiveauTerminé { get; set; }
   bool EstJeuTerminé { get; set; }
   GestionPointage ScriptGestionPointage { get; set; }
   TextMesh TexteMessage { get; set; }
   Carte CarteNiveau { get; set; }
   #endregion

   private void Awake()
   {
      InitialiserActionsÉtat();
      ÉtatActuel = ÉtatJeu.InitialisationJeu;
      TransitionÉtat = TransitionJeu.Activation;
   }

   private void Start() => ScriptGestionPointage = Pointage.GetComponent<GestionPointage>();

   void Update() => ActionsÉtat[(int)ÉtatActuel]();

   private void InitialiserActionsÉtat()
   {
      ActionsÉtat = new ActionFSM[(int)ÉtatJeu.NbÉtatsJeu];
      ActionsÉtat[(int)ÉtatJeu.InitialisationJeu] = InitialiserJeu;
      ActionsÉtat[(int)ÉtatJeu.InitialisationNiveau] = InitialiserNiveau;
      ActionsÉtat[(int)ÉtatJeu.DéroulementNiveau] = JouerNiveau;
      ActionsÉtat[(int)ÉtatJeu.FinNiveau] = TerminerNiveau;
      ActionsÉtat[(int)ÉtatJeu.FinJeu] = TerminerJeu;
   }
   private void InitialiserJeu()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            Pointage.SetActive(true);
            ScriptGestionPointage.InitialiserPointage(0);
            CarteNiveau = new Carte(NomCarte);
            PanneauMessage.SetActive(false);
            TransitionÉtat = TransitionJeu.Terminé;
            break;
         case TransitionJeu.EnMarche: // Transition inutilisée pour cet état du jeu
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatJeu.InitialisationNiveau;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void InitialiserNiveau()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            ÉlémentsNiveau = new List<GameObject>();
            CréerCaisses();
            CréerCibles();
            CréerMines();
            InitialiserVaisseau();
            EstNiveauTerminé = false;
            EstJeuTerminé = false;
            TransitionÉtat = TransitionJeu.Terminé;
            break;
         case TransitionJeu.EnMarche: // Transition inutilisée pour cet état du jeu
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatJeu.DéroulementNiveau;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }
   private void JouerNiveau()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            TransitionÉtat = !EstNiveauTerminé ? TransitionJeu.EnMarche : TransitionJeu.Terminé;
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatJeu.FinNiveau;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }
   private void TerminerNiveau()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            CréerDestination();
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            TransitionÉtat = EstJeuTerminé ? TransitionJeu.Terminé : TransitionJeu.EnMarche;
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatJeu.FinJeu;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void TerminerJeu()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            NettoyerNiveau();
            Pointage.SetActive(false);
            TexteMessage = PanneauMessage.GetComponent<TextMesh>();
            TexteMessage.text = $"Pointage finale : {ScriptGestionPointage.ValeurPointage}\nTapez <ESC> pour continuer!";
            PanneauMessage.SetActive(true);
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            TransitionÉtat = Input.GetKey(KeyCode.Escape) ? TransitionJeu.Terminé:TransitionJeu.EnMarche;
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatJeu.InitialisationJeu;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void NettoyerNiveau()
   {
      // À compléter
      // Cette méthode permet de désactiver le vaisseau et de détruire tous les objets instanciés dynamiquement de la scène.
   }

   private void CréerCibles()
   {
      // Cette méthode permet d'instancier les cibles du niveau.
      // Indice 1 : l'objet CarteNiveau connait l'information nécessaire à la création des cibles.
      // Indice 2 : N'oubliez pas d'initialiser l'attribut NbCiblesNiveau qui correspondera au nombre de cible devant être détruite
      //            pour terminer le niveau.
    }

   public void DétruireCible(GameObject cible)
   {
      // Cette méthode permet de détruire une cible. 
      // Elle est appelée lors de la collision du projectile avec une section de la cible (script GestionSectionCible)
   }

   private void CréerMines() 
   {
      // Cette méthode est à compléter uniquement si vous faites le bonus
      // Cette méthode permet d'instancier les mines présentent dans le niveau.
      // Indice : l'objet CarteNiveau connait l'information nécessaire à la création des mines.
   }

   public void DétruireMine(GameObject mine)
   {
      // Cette méthode est à compléter uniquement si vous faites le bonus
      // Cette méthode permet de détruire une mine. 
      // Elle est appelée lors que le vaisseau passe trop près de la mine (script ComportementMine). 
   }

   private void CréerCaisses()
   {
      // Cette méthode permet d'instancier les caisses formant le labyrinthe du niveau.
      // Indice : l'objet CarteNiveau connait l'information nécessaire à la création des caisses.
   }

   private void CréerDestination()
   {
      // Cette méthode permet d'instancier le prefab symbolisant la destination ultime.
      // Indice : l'objet CarteNiveau connait l'information nécessaire à la création de ce GameObject.
   }

   public void TrouverDestination()
   {
      EstJeuTerminé = true;
   }

   private void InitialiserVaisseau()
   {
      Vaisseau.transform.SetPositionAndRotation(new Vector3(CarteNiveau.PositionSource.X, 0, CarteNiveau.PositionSource.Z), Quaternion.identity);
      GameObject.Find("CameraPrincipale").GetComponent<DeplacementCamera>().AffecterCaméraAuVaisseau(Vaisseau);
      Vaisseau.GetComponent<ComportementVaisseau>().InitialiserComportementVaisseau(ScriptGestionPointage, gameObject);
      Vaisseau.SetActive(true);
   }
}
