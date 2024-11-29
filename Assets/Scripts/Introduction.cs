using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private int currentIndex = 0;

    private string[] storyLines = {
        "Would you lie in order to protect a person you care about..?",
        "..or tell the truth as to fulfill your moral obligation to honesty?",
        "TAKE RESPONSIBILITY FOR YOUR ACTIONS."
    };

    void Start()
    {
        UpdateText();
    }

    public void OnNextButtonClicked()
    {
        if (currentIndex < storyLines.Length - 1)
        {
            currentIndex++;
            UpdateText();
        }
        else
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    private void UpdateText()
    {
        displayText.text = storyLines[currentIndex];
    }
}
