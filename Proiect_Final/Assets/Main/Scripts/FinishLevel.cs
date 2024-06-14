using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject lossMenu;

    void Start(){
        winMenu = GameObject.FindGameObjectWithTag(Tags.Win);
        lossMenu = GameObject.FindGameObjectWithTag(Tags.Loss);
    }

    public void ShowWinMenu(){
        Destroy(GameObject.FindGameObjectWithTag(Tags.Level));
        CanvasGroup canvasGroup = winMenu.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        winMenu.SetActive(true);
        StartCoroutine(FadeIn(canvasGroup));
    }

    public void ShowLossMenu(){
        Destroy(GameObject.FindGameObjectWithTag(Tags.Level));
        CanvasGroup canvasGroup = lossMenu.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        // StartCoroutine(Waiter());
        LevelControl.Initialize();
        SceneManager.LoadScene(0);
    }

    IEnumerator Waiter(){
        yield return new WaitForSeconds(3);
    }

    IEnumerator HideWinMenu(CanvasGroup canvasGroup){
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeOut(canvasGroup));
    }

    private IEnumerator FadeIn(CanvasGroup canvasGroup){
        while(canvasGroup.alpha < 1){
            canvasGroup.alpha += Time.deltaTime / 4;
            yield return null;
        }
        StartCoroutine(HideWinMenu(canvasGroup));
    }
    
    private IEnumerator FadeOut(CanvasGroup canvasGroup){
        while(canvasGroup.alpha > 0){
            canvasGroup.alpha -= Time.deltaTime / 4;
            yield return null;
        }
        LevelControl.Initialize();
        SceneManager.LoadScene(0);
    }

    public void FinishGame(){
        SceneManager.LoadScene("Finish");
    }
}
