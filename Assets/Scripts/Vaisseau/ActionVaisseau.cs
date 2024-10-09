using System.Linq;
using UnityEngine;

public class ActionVaisseau : MonoBehaviour {
    [SerializeField] GameObject Projectile;
    [SerializeField] float ForceImpulsionProjectile = 10;
    [SerializeField] float D�laiDeRecharge = 0.2f;
    [SerializeField] int NbProjectilesMax = 3;

    // Attributs � compl�ter

    float timepassed = 0;

    public int nbProjectiles = 0;


    private void Awake() {
        // � compl�ter
    }

    private void Update() {
        // � compl�ter
        timepassed += Time.deltaTime;
    }

    public void Tirer() {
        InstantiateProj();
        ApplyForce();
    }

    public void D�truireProjectile(GameObject projectile) {
        if (nbProjectiles > 0)
            nbProjectiles--;
        Destroy(projectile);
    }

    void InstantiateProj() {
        if (timepassed > D�laiDeRecharge /*&& nbProjectiles < NbProjectilesMax*/) {
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