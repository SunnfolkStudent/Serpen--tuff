using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour

{
    public GameObject startButton;
    public GameObject quitButton;
    public CanvasGroup canvasGroupStart;
    public CanvasGroup canvasGroupQuit;
    public CanvasGroup canvasGroupTitle;
    public Transform background;
    public Transform backgroundMove;
    public Transform playerSprite;
    public Transform playerSpriteMove;
    private bool _startCutscene = false;
    
    public void GameScene()
    {
       _startCutscene = true;
        StartCoroutine(FadeOutButtons());
       
        // SceneManager.LoadScene("Stage1");
    }

    private void Update()
    {
        if (_startCutscene)
        {
            while (background.position != backgroundMove.position)
            {
                background.transform.position = Vector3.MoveTowards(background.position, backgroundMove.position, 0.2f * Time.deltaTime * Screen.width);
                return;
                
            } 
            StartCoroutine(FadeOutTitle());
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   private IEnumerator FadeOutButtons()
    {
        while (canvasGroupStart.alpha  > 0)
        {
            canvasGroupStart.alpha -= 0.02f;
            canvasGroupQuit.alpha -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            yield return null;
        }
        yield return null;
        
    }
    private IEnumerator FadeOutTitle()
    {
        
        while (canvasGroupTitle.alpha  > 0)
        {
            canvasGroupTitle.alpha -= 0.001f;
            yield return new WaitForSeconds(0.01f);
            yield return null;
        }
        yield return null;
        
    }

}
