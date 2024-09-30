using UnityEngine;

public class ComportementMine : MonoBehaviour
{
   const int LayerVaisseau = 10;
   [SerializeField] float IntensitéMax = 3;
   [SerializeField] float DuréeVariation = 2;
   [SerializeField] GameObject Explosion;
   [SerializeField] float ForceExplosion = 250000;
   Light lumière { get; set; }
   float Intensité { get; set; }
   float VariationParSeconde { get; set; }
   float SensVariation { get; set; }
   float RayonExplosion { get; set; }
   FsmJeu ScriptGameManager { get; set; }
   void Awake()
   {
      lumière = GetComponentInChildren<Light>();
      Intensité = 0;
      SensVariation = 1;
      VariationParSeconde = IntensitéMax / DuréeVariation;
      RayonExplosion = GetComponent<SphereCollider>().radius*2;
  }

   void Update()
   {
      // Cette méthode permet de faire fluctuer graduellement l'intensité de la lumière en deux bornes.
   }
   private void OnTriggerEnter(Collider other)
   {
      // Si le vaisseau déclenche la mine, cela entraine une explosion (visuelle et physique), en plus de provoquer la destruction de la mine.
   }

   public void InitialiserComportementMine(GameObject gameManager)
   {
      // Permet d'établir un lien entre la mine et le script "FsmJeux".
   }
}
