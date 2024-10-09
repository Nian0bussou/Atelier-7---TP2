using System.Linq;
using UnityEngine;

public class ActionVaisseau : MonoBehaviour {
    [SerializeField] GameObject Projectile;
    [SerializeField] float ForceImpulsionProjectile = 10;
    [SerializeField] float DélaiDeRecharge = 0.2f;
    [SerializeField] int NbProjectilesMax = 3;

    // Attributs à compléter

    float timepassed = 0;

    public int nbProjectiles = 0;


    private void Awake() {
        // À compléter
    }

    private void Update() {
        // À compléter
        timepassed += Time.deltaTime;
    }

    public void Tirer() {
        InstantiateProj();
        ApplyForce();
    }

    public void DétruireProjectile(GameObject projectile) {
        if (nbProjectiles > 0)
            nbProjectiles--;
        Destroy(projectile);
    }

    void InstantiateProj() {
        if (timepassed > DélaiDeRecharge /*&& nbProjectiles < NbProjectilesMax*/) {
            Instantiate(Projectile, transform.position, transform.rotation);
            nbProjectiles++;
            timepassed = 0;
        }
    }

    private void ApplyForce() {
        Projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, ForceImpulsionProjectile), ForceMode.Impulse);
        timepassed = 0;
    }


}