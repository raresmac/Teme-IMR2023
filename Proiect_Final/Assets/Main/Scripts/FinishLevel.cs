using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject winMenu;

    public void ShowWinMenu(){
        Destroy(GameObject.FindGameObjectWithTag(Tags.Level));
        CanvasGroup canvasGroup = winMenu.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        winMenu.SetActive(true);
        StartCoroutine(FadeIn(canvasGroup));
    }

    public void ShowLossMenu(){
        GameObject.FindGameObjectWithTag(Tags.Loss).SetActive(true);
    }

    IEnumerator HideWinMenu(){
        yield return new WaitForSeconds(3);
        CanvasGroup canvasGroup = winMenu.GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        StartCoroutine(FadeOut(canvasGroup, 0));
    }

    private IEnumerator FadeIn(CanvasGroup canvasGroup){
        while(canvasGroup.alpha < 1){
            canvasGroup.alpha += Time.deltaTime / 5;
            yield return null;
        }
        canvasGroup.interactable = true;
        StartCoroutine(HideWinMenu());
    }
    
    private IEnumerator FadeOut(CanvasGroup canvasGroup, int newScene){
        while(canvasGroup.alpha > 0){
            canvasGroup.alpha -= Time.deltaTime / 5;
            yield return null;
        }
        LevelControl.Initialize();
        SceneManager.LoadScene(0);
    }
}
