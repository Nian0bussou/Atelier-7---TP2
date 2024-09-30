using UnityEngine;

public class ComportementMine : MonoBehaviour
{
   const int LayerVaisseau = 10;
   [SerializeField] float Intensit�Max = 3;
   [SerializeField] float Dur�eVariation = 2;
   [SerializeField] GameObject Explosion;
   [SerializeField] float ForceExplosion = 250000;
   Light lumi�re { get; set; }
   float Intensit� { get; set; }
   float VariationParSeconde { get; set; }
   float SensVariation { get; set; }
   float RayonExplosion { get; set; }
   FsmJeu ScriptGameManager { get; set; }
   void Awake()
   {
      lumi�re = GetComponentInChildren<Light>();
      Intensit� = 0;
      SensVariation = 1;
      VariationParSeconde = Intensit�Max / Dur�eVariation;
      RayonExplosion = GetComponent<SphereCollider>().radius*2;
  }

   void Update()
   {
      // Cette m�thode permet de faire fluctuer graduellement l'intensit� de la lumi�re en deux bornes.
   }
   private void OnTriggerEnter(Collider other)
   {
      // Si le vaisseau d�clenche la mine, cela entraine une explosion (visuelle et physique), en plus de provoquer la destruction de la mine.
   }

   public void InitialiserComportementMine(GameObject gameManager)
   {
      // Permet d'�tablir un lien entre la mine et le script "FsmJeux".
   }
}
