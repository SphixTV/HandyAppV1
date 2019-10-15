using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown GraphicsDropdown;

    public void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int curentResolutinIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].width;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                curentResolutinIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curentResolutinIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetQuality ()
    {
        QualitySettings.SetQualityLevel(GraphicsDropdown.value);
    }
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution()
    {
        
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }

}
