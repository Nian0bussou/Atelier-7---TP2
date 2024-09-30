using UnityEngine;

public class FinJeu : MonoBehaviour
{
    void Update()
    {
      if (Input.GetKey(KeyCode.Escape))
      {
         Quit();
      }
   }

   void Quit()
   {
      #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
      #else
            Application.Quit();
      #endif
   }

}
