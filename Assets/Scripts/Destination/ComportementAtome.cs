using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementAtome : MonoBehaviour
{
   const int Nb�lectronsMin = 4;
   const int Nb�lectronsMax = 8;
   [SerializeField] GameObject Mod�le�lectron; //le prefab de l'�lectron

   void Awake()
   {
      // Cette m�thode permet d'instancier un nombre al�atoire d'�lectrons (entre 4 et 8).

   }
}
