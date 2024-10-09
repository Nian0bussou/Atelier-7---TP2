using System.Linq;
using UnityEngine;

public class ActionVaisseau : MonoBehaviour {
    [SerializeField] GameObject Projectile;
    [SerializeField] float ForceImpulsionProjectile = 10;
    [SerializeField] float D�laiDeRecharge = 0.2f;
    [SerializeField] int NbProjectilesMax = 3;

    // Attributs � compl�ter

    float timesincelastshot = 0;

    int nbProjectiles = 0;


    Rigidbody rvaisseau;
    GameObject Canon;


    private void Awake() {
        rvaisseau = GetComponent<Rigidbody>();
        Canon = GameObject.Find("Canon");

    }

    private void Update() {
        timesincelastshot += Time.deltaTime;
    }

    public void Tirer() {
        InstantiateProj();
    }

    public void D�truireProjectile(GameObject projectile) {
        nbProjectiles--;
        Destroy(projectile);
    }

    void InstantiateProj() {
        if (timesincelastshot > D�laiDeRecharge && nbProjectiles < NbProjectilesMax) {
            var p = Instantiate(Projectile, Canon.transform.position, transform.rotation);

            nbProjectiles++;
            timesincelastshot = 0;

            var script = p.GetComponent<ActionProjectile>();

            script.InscrireProjectile(gameObject);
            ApplyForce(p);
        }
    }

    private void ApplyForce(GameObject p) {
        p.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, ForceImpulsionProjectile), ForceMode.Impulse);
        timesincelastshot = 0;
    }


}