using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene2 : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI CharacterText;
    public TextMeshProUGUI StoryText;
    public Button AnswerCall;
    public Button DeclineCall;
    public Button RestartButton;
    public Button NextButton;

    private int currentIndex = 0;

    private string[] storyLines = {
        "I've been looking at this book for hours now.. What is this even about?",
        "Kant's Moral Theory...Interesting",
    };

    void Start()
    {
        UpdateText();
        StoryText.gameObject.SetActive(false);
        AnswerCall.gameObject.SetActive(false);
        DeclineCall.gameObject.SetActive(false);
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
            CharacterText.gameObject.SetActive(false);
            StoryText.gameObject.SetActive(true);
            Choices();
        }
    }

    private void Choices()
    {
        AnswerCall.gameObject.SetActive(true);
        DeclineCall.gameObject.SetActive(true);
    }

    public void OnAnswerCallClicked()
    {
        AnswerCall.gameObject.SetActive(false);
        DeclineCall.gameObject.SetActive(false);
        StoryText.text = "You answer, but there's only crackling on the line. A familiar voice whispers:\"Can you hear me Eli? I'm downstairs.\"";
        StartCoroutine(LoadSceneWithDelay("Scene3", 4f));
    }

    public void OnDeclineCallClicked()
    {
        AnswerCall.gameObject.SetActive(false);
        DeclineCall.gameObject.SetActive(false);
        StoryText.gameObject.SetActive(true);

        StoryText.text = "The next morning, you step outside and find your friend's lifeless body lying near your doorstep. You could've saved him. Guilt consumes you.";
        RestartButton.gameObject.SetActive(true);
        NextButton.gameObject.SetActive(false);
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
