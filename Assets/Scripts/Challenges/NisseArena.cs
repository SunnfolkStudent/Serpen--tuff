using UnityEngine;

public class NisseArena : MonoBehaviour
{

   public Transform nisseWall1;
   public Transform nisseWall2;
   public Transform nisseWall1Target;
   public Transform nisseWall2Target;
   
   private bool _arenaStart = false;


   private void Update()
   {
      if (_arenaStart)
      {
         while (!Mathf.Approximately(nisseWall1.position.y, nisseWall1Target.position.y))
         {
            nisseWall1.transform.position = Vector3.MoveTowards(nisseWall1.position, nisseWall1Target.position,
               0.005f * Time.deltaTime * Screen.width);
            nisseWall2.transform.position = Vector3.MoveTowards(nisseWall2.position, nisseWall2Target.position,
               0.005f * Time.deltaTime * Screen.width);
            
            return;
         }
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.transform.CompareTag("MainCamera"))
      {
         _arenaStart = true;
      }
   }
}
