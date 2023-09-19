using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image Loaded;
    public Text Percentage;

    public void Exit()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        StartCoroutine(LoadScreenAsync("Game"));
        // LoadingScreen.SetActive(true);
    }
    public void Home()
    {
        StartCoroutine(LoadScreenAsync("MainMenu"));
    }

    IEnumerator LoadScreenAsync(string SceneName)
    {
        LoadingScreen.SetActive(true);
        // AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName);

        int t = 0;

        while (t++ <= 10)
        {
            //  float ProgressValue = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            Loaded.fillAmount += .1f;
            Percentage.text = t * 10 + "%";
            yield return new WaitForSeconds(.1f);
        }

        SceneManager.LoadScene(SceneName);
        LoadingScreen.SetActive(false);

    }


}
