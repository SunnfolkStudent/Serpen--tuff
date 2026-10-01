using UnityEngine;

public class NisseArena : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.transform.CompareTag("MainCamera"))
      {
         
      }
   }
}
