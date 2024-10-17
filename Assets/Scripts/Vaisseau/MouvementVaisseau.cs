using System.Linq;
using UnityEngine;

// Olivier

public class MouvementVaisseau : MonoBehaviour {
    const int NbR�trofus�es = 6;
    const int NbR�acteurs = 4;

    // idxes of the retrofusees array
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

    private void Awake() {
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

    private TrailRenderer IdentifierPropulseur(Transform[] dataTransform, string idPropulseur) {
        TrailRenderer tr = null;
        for (int i = 0;i < dataTransform.Length;i++) {
            var t = dataTransform[i];
            if (t.name == idPropulseur) {
                tr = t.GetComponent<TrailRenderer>();
                break;
            }
        }
        return tr; // not sure about that one
    }

    private void �teindrePropulseur(TrailRenderer[] propulseurs) {
        foreach (TrailRenderer t in propulseurs) t.enabled = false;
    }

    public void PivoterVersLaGauche(bool commutateur) {
        CorpsVaisseau.AddRelativeTorque(forceR�trofus�e * Time.deltaTime * new Vector3(0, -1, 0), ForceMode.VelocityChange);
        R�trofus�es[R�troAvantGauche].enabled = commutateur;
        R�trofus�es[R�troArri�reDroite].enabled = commutateur;
        SetVelocityToZero();
    }

    public void PivoterVersLaDroite(bool commutateur) {
        CorpsVaisseau.AddRelativeTorque(forceR�trofus�e * Time.deltaTime * new Vector3(0, 1, 0), ForceMode.VelocityChange);
        R�trofus�es[R�troAvantDroite].enabled = commutateur;
        R�trofus�es[R�troArri�reGauche].enabled = commutateur;
        SetVelocityToZero();
    }

    public void Avancer(bool commutateur) {
        CorpsVaisseau.AddRelativeForce(forceR�acteurs * Time.deltaTime * new Vector3(0, 0, 1), ForceMode.VelocityChange);
        R�acteurs[R�acteurBasDroite].enabled = commutateur;
        R�acteurs[R�acteurBasGauche].enabled = commutateur;
        R�trofus�es[R�troArri�reDroite].enabled = commutateur;
        R�trofus�es[R�troArri�reGauche].enabled = commutateur;
        SetVelocityToZero();
    }

    public void Reculer(bool commutateur) {
        CorpsVaisseau.AddRelativeForce(forceR�acteurs * Time.deltaTime * new Vector3(0, 0, -1), ForceMode.VelocityChange);
        R�trofus�es[R�troHautDroite].enabled = commutateur;
        R�trofus�es[R�troHautGauche].enabled = commutateur;
        SetVelocityToZero();
    }

    public void GlisserVersLaGauche(bool commutateur) {
        CorpsVaisseau.AddRelativeForce(forceR�acteurs * Time.deltaTime * new Vector3(-1, 0, 0), ForceMode.VelocityChange);
        R�trofus�es[R�troAvantDroite].enabled = commutateur;
        R�trofus�es[R�troArri�reDroite].enabled = commutateur;
        SetVelocityToZero();
    }

    public void GlisserVersLaDroite(bool commutateur) {
        CorpsVaisseau.AddRelativeForce(forceR�acteurs * Time.deltaTime * new Vector3(1, 0, 0), ForceMode.VelocityChange);
        R�trofus�es[R�troAvantGauche].enabled = commutateur;
        R�trofus�es[R�troArri�reGauche].enabled = commutateur;
        SetVelocityToZero();
    }

    void SetVelocityToZero() {
        CorpsVaisseau.velocity = Vector3.zero;
        CorpsVaisseau.angularVelocity = Vector3.zero;
    }

}
