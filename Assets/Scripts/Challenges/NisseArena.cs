using UnityEngine;

public class NisseArena : MonoBehaviour
{

   public Transform nisseWall1;
   public Transform nisseWall2;
   public Transform nisseWall1Target;
   public Transform nisseWall2Target;
   public Transform nisseWall1TargetEnd;
   public GameObject nisseSpawner;
   
   private bool _arenaStart = false;
   public float _arenaDuration = 90;


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
         nisseSpawner.SetActive(true);
      }
      if (_arenaStart)
      {
          if (_arenaDuration > 0)
          {
             _arenaDuration -= Time.deltaTime;
          }
          else
          {
             while (!Mathf.Approximately(nisseWall1.position.y, nisseWall1TargetEnd.position.y))
             {
                nisseWall2.transform.position = Vector3.MoveTowards(nisseWall2.transform.position, nisseWall1TargetEnd.position,
                0.005f * Time.deltaTime * Screen.width);
             }
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
