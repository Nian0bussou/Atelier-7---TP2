﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Maxime

public class FsmJeu : MonoBehaviour {
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

    private void Awake() {
        InitialiserActionsÉtat();
        ÉtatActuel = ÉtatJeu.InitialisationJeu;
        TransitionÉtat = TransitionJeu.Activation;
    }

    private void Start() => ScriptGestionPointage = Pointage.GetComponent<GestionPointage>();

    void Update() {
        ActionsÉtat[(int) ÉtatActuel]();
    }
    private void InitialiserActionsÉtat() {
        ActionsÉtat = new ActionFSM[(int) ÉtatJeu.NbÉtatsJeu];
        ActionsÉtat[(int) ÉtatJeu.InitialisationJeu] = InitialiserJeu;
        ActionsÉtat[(int) ÉtatJeu.InitialisationNiveau] = InitialiserNiveau;
        ActionsÉtat[(int) ÉtatJeu.DéroulementNiveau] = JouerNiveau;
        ActionsÉtat[(int) ÉtatJeu.FinNiveau] = TerminerNiveau;
        ActionsÉtat[(int) ÉtatJeu.FinJeu] = TerminerJeu;
    }
    private void InitialiserJeu() {
        switch (TransitionÉtat) {
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

    private void InitialiserNiveau() {
        switch (TransitionÉtat) {
            case TransitionJeu.Activation:
                ÉlémentsNiveau = new List<GameObject>();
                CréerCaisses();
                CréerCibles();
                CréerMines();
                CréerDestination(); // was not there before making the destination not appear when creating a lever
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
    private void JouerNiveau() {
        switch (TransitionÉtat) {
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
    private void TerminerNiveau() {
        switch (TransitionÉtat) {
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

    private void TerminerJeu() {
        switch (TransitionÉtat) {
            case TransitionJeu.Activation:
                NettoyerNiveau();
                Pointage.SetActive(false);
                TexteMessage = PanneauMessage.GetComponent<TextMesh>();
                TexteMessage.text = $"Pointage finale : {ScriptGestionPointage.ValeurPointage}\nTapez <ESC> pour continuer!";
                PanneauMessage.SetActive(true);
                TransitionÉtat = TransitionJeu.EnMarche;
                break;
            case TransitionJeu.EnMarche:
                TransitionÉtat = Input.GetKey(KeyCode.Escape) ? TransitionJeu.Terminé : TransitionJeu.EnMarche;
                break;
            case TransitionJeu.Terminé:
                ÉtatActuel = ÉtatJeu.InitialisationJeu;
                TransitionÉtat = TransitionJeu.Activation;
                break;
        }
    }

    private void NettoyerNiveau() {
        foreach (var e in ÉlémentsNiveau) {
            if (e == Vaisseau) { e.SetActive(false); } else {
                Destroy(e);
            }
        }
    }

    private void CréerCibles() {
        var cibls = CarteNiveau.Cibles;
        foreach (var c in cibls) {
            var x = Instantiate(Cible, new(c.X, 0, c.Z), Quaternion.Euler(90, 0, 0));
            x.GetComponent<GestionCible>().InitialiserComportementCible(ScriptGestionPointage, gameObject);
            NbCiblesNiveau++;
        }
    }


    public void DétruireCible(GameObject cible) {
        NbCiblesNiveau--;
        Destroy(cible);
        if (NbCiblesNiveau == 0) { EstNiveauTerminé = true; }
    }

    private void CréerMines() {
        // Cette méthode est à compléter uniquement si vous faites le bonus
        // Cette méthode permet d'instancier les mines présentent dans le niveau.
        // Indice : l'objet CarteNiveau connait l'information nécessaire à la création des mines.
        var mines = CarteNiveau.Mines;
        foreach (var m in mines) {
            var x = Instantiate(Mine, new(m.X, 0, m.Z), Quaternion.Euler(0, 0, 0));
            x.GetComponent<ComportementMine>().InitialiserComportementMine(gameObject);
        }
    }

    public void DétruireMine(GameObject mine) {
        // Cette méthode est à compléter uniquement si vous faites le bonus
        // Cette méthode permet de détruire une mine. 
        // Elle est appelée lors que le vaisseau passe trop près de la mine (script ComportementMine). 
        Destroy(mine);
    }

    private void CréerCaisses() {
        var cias = CarteNiveau.Caisses;
        foreach (var c in cias) {
            Instantiate(Caisse, new(c.X, 0, c.Z), Quaternion.Euler(Vector3.zero));
        }
    }

    private void CréerDestination() {
        var pos = CarteNiveau.PositionDestination;
        Instantiate(Destination, new(pos.X, 0, pos.Z), Quaternion.Euler(Vector3.zero));
    }

    public void TrouverDestination() {
        if (NbCiblesNiveau == 0)
            EstJeuTerminé = true;
    }

    private void InitialiserVaisseau() {
        Vaisseau.transform.SetPositionAndRotation(new Vector3(CarteNiveau.PositionSource.X, 0, CarteNiveau.PositionSource.Z), Quaternion.identity);
        GameObject.Find("CameraPrincipale").GetComponent<DeplacementCamera>().AffecterCaméraAuVaisseau(Vaisseau);
        Vaisseau.GetComponent<ComportementVaisseau>().InitialiserComportementVaisseau(ScriptGestionPointage, gameObject);
        Vaisseau.SetActive(true);
    }
}
