using UnityEngine;
//maxime & olivier

public class ComportementMine : MonoBehaviour {
    const int LayerVaisseau = 10;

    [SerializeField] float IntensitéMax = 3f;
    [SerializeField] float DuréeVariation = 2f;
    [SerializeField] GameObject Explosion;
    [SerializeField] float ForceExplosion = 250000f;

    Light lumière { get; set; }
    float Intensité { get; set; }
    float VariationParSeconde { get; set; }
    float SensVariation { get; set; }
    float RayonExplosion { get; set; }
    FsmJeu ScriptGameManager { get; set; }

    void Awake() {
        lumière = GetComponentInChildren<Light>();
        Intensité = 0f;
        SensVariation = 1f;
        VariationParSeconde = IntensitéMax / DuréeVariation;
        RayonExplosion = GetComponent<SphereCollider>().radius * 2f;

    }

    void Update() {
        Intensité += SensVariation * VariationParSeconde * Time.deltaTime;
        if (Intensité > IntensitéMax) {
            Intensité = IntensitéMax;
            SensVariation = -1;
        } else if (Intensité < 0) {
            Intensité = 0;
            SensVariation = 1;
        }
        if (lumière != null) {
            lumière.intensity = Intensité;
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

            ScriptGameManager.DétruireMine(gameObject);
        }
    }

    public void InitialiserComportementMine(GameObject gameManager) {
        // Permet d'établir un lien entre la mine et le script "FsmJeux".
        ScriptGameManager = gameManager.GetComponent<FsmJeu>();
    }
}
