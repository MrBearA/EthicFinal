using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene4 : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI StoryText;
    public Button GrabBTN;
    public Button RunBTN;
    public Button RestartButton;
    public Button NextButton;

    private int currentIndex = 0;

    //change
    private string[] storyLines = {
        "The player peeks through the curtains nervously. “Is he gone?” the character asks. \r\n",
        "The killer suddenly appears at the window after you leave. ",
    };

    void Start()
    {
        UpdateText();
        StoryText.gameObject.SetActive(false);
        //change
        GrabBTN.gameObject.SetActive(false);
        //change
        RunBTN.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
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
            DialogueText.gameObject.SetActive(false);
            StoryText.gameObject.SetActive(true);
            Choices();
        }
    }

    private void Choices()
    {
        GrabBTN.gameObject.SetActive(true);
        RunBTN.gameObject.SetActive(true);
    }


    public void OnGrabClicked()//change
    {
        GrabBTN.gameObject.SetActive(false);
        RunBTN.gameObject.SetActive(false);
        StoryText.text = "You and your friend grab a kitchen knife and hide in the closet. The screen shows the killer breaking into the house.";
        StartCoroutine(LoadSceneWithDelay("Scene4", 4f));
    }


    public void OnRunClicked()//change
    {
        GrabBTN.gameObject.SetActive(false);
        RunBTN.gameObject.SetActive(false);
        StoryText.gameObject.SetActive(true);

        //change
        StoryText.text = "You and your friend bolt out the back door, but the killer is waiting outside.";
        NextButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(true);
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    private void UpdateText()
    {
        DialogueText.text = storyLines[currentIndex];
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
