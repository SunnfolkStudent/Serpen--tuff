using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HidingMechanic : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;
    private bool isInvincible = false;
    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;
        yield return new WaitForSeconds(5f);
        isInvincible = false;
        Debug.Log("Player is no longer invincible!");
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
