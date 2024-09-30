using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementAtome : MonoBehaviour
{
   const int NbÉlectronsMin = 4;
   const int NbÉlectronsMax = 8;
   [SerializeField] GameObject ModèleÉlectron; //le prefab de l'électron

   void Awake()
   {
      // Cette méthode permet d'instancier un nombre aléatoire d'électrons (entre 4 et 8).

   }
}
