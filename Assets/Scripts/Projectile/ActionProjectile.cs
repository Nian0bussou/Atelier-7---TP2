using UnityEngine;
using UnityEngine.Events;

public class ActionProjectile : MonoBehaviour {
    [SerializeField] float DuréeDeVie = 1f;
    [SerializeField] GameObject Explosion;




    const int SHIP_Layer = 10;

    ActionVaisseau av;


    float timepassed = 0f;

    private void Update() {

        if (timepassed > DuréeDeVie) {
            av.DétruireProjectile(gameObject);
        }

        timepassed += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer != SHIP_Layer) {
            Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
            av.DétruireProjectile(gameObject);
        }

    }

    public void InscrireProjectile(GameObject vaisseau) {
        av = vaisseau.GetComponent<ActionVaisseau>();
    }













































    //[SerializeField] UnityEvent<GameObject> destroyProjectile = null;





















    //int vlayer = 10; // layer of the ship
    //float timepassed = 0;
    //GameObject Vaisseau = null;

    //void Update() {
    //    if (timepassed > DuréeDeVie) Destroy(gameObject);
    //    timepassed += Time.deltaTime;
    //}

    //void OnCollisionEnter(Collision collision) {
    //    if (collision.gameObject.layer != vlayer) {
    //        Instantiate(Explosion);
    //        destroyProjectile.Invoke(gameObject);
    //    }
    //}

    //public void InscrireProjectile(GameObject vaisseau) {
    //    // not sure if right thing
    //    Vaisseau = vaisseau;
    //}
}
