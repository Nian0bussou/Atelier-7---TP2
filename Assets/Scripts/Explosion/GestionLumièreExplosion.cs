// Script inspiré d'un script du FX Explosion Pack

using UnityEngine;

public class GestionLumièreExplosion : MonoBehaviour {
    [SerializeField] float DuréeÉclair = 0.5f;
    [SerializeField] float TauxDiminution = 3;
    float tempsÉcoulé = 0;
    Light ÉclairExplosion;

    private void Awake() =>
        ÉclairExplosion = GetComponent<Light>();

    void Update() {
        tempsÉcoulé += Time.deltaTime;
        if (tempsÉcoulé > DuréeÉclair) {  //La luminosité du début se met à diminuer après un certain temps
            ÉclairExplosion.intensity = ÉclairExplosion.intensity > 0 ? ÉclairExplosion.intensity - Time.deltaTime * TauxDiminution : 0;
        }
    }
}
