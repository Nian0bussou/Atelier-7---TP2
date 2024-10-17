using System.Linq;
using UnityEngine;

// Olivier

public class MouvementVaisseau : MonoBehaviour {
    const int NbRétrofusées = 6;
    const int NbRéacteurs = 4;

    // idxes of the retrofusees array
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

    private void Awake() {
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

    private void ÉteindrePropulseur(TrailRenderer[] propulseurs) {
        foreach (TrailRenderer t in propulseurs) t.enabled = false;
    }

    public void PivoterVersLaGauche(bool commutateur) {
        CorpsVaisseau.AddRelativeTorque(forceRétrofusée * Time.deltaTime * new Vector3(0, -1, 0), ForceMode.VelocityChange);
        Rétrofusées[RétroAvantGauche].enabled = commutateur;
        Rétrofusées[RétroArrièreDroite].enabled = commutateur;
        SetVelocityToZero();
    }

    public void PivoterVersLaDroite(bool commutateur) {
        CorpsVaisseau.AddRelativeTorque(forceRétrofusée * Time.deltaTime * new Vector3(0, 1, 0), ForceMode.VelocityChange);
        Rétrofusées[RétroAvantDroite].enabled = commutateur;
        Rétrofusées[RétroArrièreGauche].enabled = commutateur;
        SetVelocityToZero();
    }

    public void Avancer(bool commutateur) {
        CorpsVaisseau.AddRelativeForce(forceRéacteurs * Time.deltaTime * new Vector3(0, 0, 1), ForceMode.VelocityChange);
        Réacteurs[RéacteurBasDroite].enabled = commutateur;
        Réacteurs[RéacteurBasGauche].enabled = commutateur;
        Rétrofusées[RétroArrièreDroite].enabled = commutateur;
        Rétrofusées[RétroArrièreGauche].enabled = commutateur;
        SetVelocityToZero();
    }

    public void Reculer(bool commutateur) {
        CorpsVaisseau.AddRelativeForce(forceRéacteurs * Time.deltaTime * new Vector3(0, 0, -1), ForceMode.VelocityChange);
        Rétrofusées[RétroHautDroite].enabled = commutateur;
        Rétrofusées[RétroHautGauche].enabled = commutateur;
        SetVelocityToZero();
    }

    public void GlisserVersLaGauche(bool commutateur) {
        CorpsVaisseau.AddRelativeForce(forceRéacteurs * Time.deltaTime * new Vector3(-1, 0, 0), ForceMode.VelocityChange);
        Rétrofusées[RétroAvantDroite].enabled = commutateur;
        Rétrofusées[RétroArrièreDroite].enabled = commutateur;
        SetVelocityToZero();
    }

    public void GlisserVersLaDroite(bool commutateur) {
        CorpsVaisseau.AddRelativeForce(forceRéacteurs * Time.deltaTime * new Vector3(1, 0, 0), ForceMode.VelocityChange);
        Rétrofusées[RétroAvantGauche].enabled = commutateur;
        Rétrofusées[RétroArrièreGauche].enabled = commutateur;
        SetVelocityToZero();
    }

    void SetVelocityToZero() {
        CorpsVaisseau.velocity = Vector3.zero;
        CorpsVaisseau.angularVelocity = Vector3.zero;
    }

}
