using UnityEngine;
using UnityEngine.Events;

public class ActionProjectile : MonoBehaviour {
    [SerializeField] float DuréeDeVie = 1f;
    [SerializeField] GameObject Explosion;


    [SerializeField] UnityEvent<GameObject> destroyProjectile = null;


    int vlayer = 10; // layer of the ship
    float timepassed = 0;
    GameObject Vaisseau = null;

    void Update() {
        if (timepassed > DuréeDeVie) Destroy(gameObject);
        timepassed += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer != vlayer) {
            Instantiate(Explosion);
            destroyProjectile.Invoke(gameObject);
        }
    }

    public void InscrireProjectile(GameObject vaisseau) {
        // not sure if right thing
        Vaisseau = vaisseau;
    }
}
