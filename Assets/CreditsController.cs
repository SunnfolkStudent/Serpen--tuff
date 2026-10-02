using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour


{
   public GameObject menuButton;
   
   
   public void Menu()
   {
      SceneManager.LoadScene("Main Menu");
   }
}
