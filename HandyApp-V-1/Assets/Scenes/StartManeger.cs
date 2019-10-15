using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManeger : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject SliderPanel;
    public GameObject normalpanel;
    public Slider slider;
    public string scene;

    public void Update()
    {
        
    }
    public void LoadLevel()
    {
        StartCoroutine(LoadAsync());

    }
    IEnumerator LoadAsync()
    {
      
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
       
        while (operation.isDone == false)

        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }
    public void Play()
    {
        

            normalpanel.SetActive(false);
            OptionsPanel.SetActive(false);
            SliderPanel.SetActive(true);
            LoadLevel();
        
    }
    public void Options()
    {
        

            normalpanel.SetActive(false);
            SliderPanel.SetActive(false);
            OptionsPanel.SetActive(true);
        
        
    }
    public void Back()
    {

      

            normalpanel.SetActive(true);
            SliderPanel.SetActive(false);
            OptionsPanel.SetActive(false);
        
    }
}
