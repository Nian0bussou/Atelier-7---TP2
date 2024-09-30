using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
   [SerializeField] KeyCode[] Touches = new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Q, KeyCode.E, KeyCode.Space };

   [SerializeField] UnityEvent<bool>[] CommandesMouvement;

   [SerializeField] UnityEvent[] CommandesAction;

   delegate bool ActionPropulseur(KeyCode touche);
   delegate bool ActionVaisseau(KeyCode touche);

   void FixedUpdate()
   {
      //G�rerActionPropulseurs(Input.GetKey, true);
      //G�rerActionPropulseurs(Input.GetKeyUp, false);
   }

   void Update()
   {
      G�rerActionPropulseurs(Input.GetKey, true);
      G�rerActionPropulseurs(Input.GetKeyUp, false);
      G�rerActionVaisseau(Input.GetKey);
   }

   private void G�rerActionPropulseurs(ActionPropulseur actionPropulseur, bool commutateurPropulseur)
   {
      for (int i = 0; i < CommandesMouvement.Length; ++i)
      {
         if (actionPropulseur(Touches[i]))
         {
            CommandesMouvement[i].Invoke(commutateurPropulseur);
         }
      }
   }

   private void G�rerActionVaisseau(ActionVaisseau actionVaisseau)
   {
      for (int i = CommandesMouvement.Length; i < Touches.Length; ++i)
      {
         if (actionVaisseau(Touches[i]))
         {
            CommandesAction[i - CommandesMouvement.Length].Invoke();
         }
      }
   }
}
