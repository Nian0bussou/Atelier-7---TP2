using UnityEngine;
//maxime & olivier

public class ComportementMine : MonoBehaviour {
    const int LayerVaisseau = 10;

    [SerializeField] float Intensit�Max = 3f;
    [SerializeField] float Dur�eVariation = 2f;
    [SerializeField] GameObject Explosion;
    [SerializeField] float ForceExplosion = 250000f;

    Light lumi�re { get; set; }
    float Intensit� { get; set; }
    float VariationParSeconde { get; set; }
    float SensVariation { get; set; }
    float RayonExplosion { get; set; }
    FsmJeu ScriptGameManager { get; set; }

    void Awake() {
        lumi�re = GetComponentInChildren<Light>();
        Intensit� = 0f;
        SensVariation = 1f;
        VariationParSeconde = Intensit�Max / Dur�eVariation;
        RayonExplosion = GetComponent<SphereCollider>().radius * 2f;

    }

    void Update() {
        Intensit� += SensVariation * VariationParSeconde * Time.deltaTime;
        if (Intensit� > Intensit�Max) {
            Intensit� = Intensit�Max;
            SensVariation = -1;
        } else if (Intensit� < 0) {
            Intensit� = 0;
            SensVariation = 1;
        }
        if (lumi�re != null) {
            lumi�re.intensity = Intensit�;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerVaisseau) {

            Instantiate(Explosion, transform.position, transform.rotation);

            // got here

            var vaisseau = other.gameObject;
            var rigidvaisseau = vaisseau.GetComponentInParent<Rigidbody>();
            rigidvaisseau
                .AddExplosionForce(
                    ForceExplosion,
                    gameObject.transform.position,
                    RayonExplosion
                    );

            ScriptGameManager.D�truireMine(gameObject);
        }
    }

    public void InitialiserComportementMine(GameObject gameManager) {
        // Permet d'�tablir un lien entre la mine et le script "FsmJeux".
        ScriptGameManager = gameManager.GetComponent<FsmJeu>();
    }
}
