using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Maneger : MonoBehaviour
{

    public bool joystickmode;
    public bool doublejump;
    public bool walljump;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject joystickCanvas;
    public GameObject sliderPanel;
    public Slider slider;
    public string scene;
    public GameObject player1;
    
    private void Start()
    {
        if (!joystickmode)
        {
            joystickCanvas.SetActive(false);
        }
    }
    public void doubleJump(bool answer)
    {
        doublejump = answer;
    }
    public void wallJump(bool answer)
    {
        walljump = answer;
    }
    public void Pause(bool pause)
    {
        PauseMenu.SetActive(pause);
        PauseButton.SetActive(!pause);
    }
    public void Home()
    {
        sliderPanel.SetActive(true);
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
    public void Death()
    {

    }

}
