
using System.Collections.Generic;
using UnityEngine;

public class ComportementElectron : MonoBehaviour {
    const float TourEnRadians = Mathf.PI * 2;
    const float RayonMin = 0.5f;
    const float RayonMax = 0.75f;

    List<GameObject> electrons;

    float angle;

    void Awake() {
        angle = 0;
        // initialisation de l'électron

        Vector3 posinit = new(520 /*what is it supposed to be ? */, 0, 0);
    }

    void Update() {

        foreach (var e in electrons) {
            angle += Time.deltaTime * Mathf.PI * 2;

            //float positionX = CentreRotation.position.x + Mathf.Cos(angle) * RayonOrbite;
            //float positionZ = CentreRotation.position.z + Mathf.Sin(angle) * RayonOrbite;
            //float positionY = CentreRotation.position.y;

            //transform.position = new Vector3(positionX, positionY, positionZ);
        }

    }
}
