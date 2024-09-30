using System.Linq;
using UnityEngine;

public class ActionVaisseau : MonoBehaviour
{
   [SerializeField] GameObject Projectile;

   [SerializeField] float ForceImpulsionProjectile = 10;

   [SerializeField] float DélaiDeRecharge = 0.2f;

   [SerializeField] int NbProjectilesMax = 3;

   // Attributs à compléter


   private void Awake()
   {
      // À compléter
   }

   private void Update()
   {
      // À compléter
   }

   public void Tirer()
   {
      // À compléter
   }

   public void DétruireProjectile(GameObject projectile)
   {
      // À compléter
   }

   // il est fort probable que vous ayiez besoin de méthodes supplémentaires
}