using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1 : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI CharacterText;
    public TextMeshProUGUI StoryText;
    public Button TextFriend;
    public Button ContinueWalking;
    public Button RestartButton;
    public Button NextButton;

    private int currentIndex = 0;

    private string[] storyLines = {
        "The rain is getting stronger..",
        "Why did I decide to go out in this weather..",
        "I need to get home, It's getting dark outside.",
    };

    void Start()
    {
        UpdateText();
        StoryText.gameObject.SetActive(false);
        TextFriend.gameObject.SetActive(false);
        ContinueWalking.gameObject.SetActive(false);
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
        TextFriend.gameObject.SetActive(true);
        ContinueWalking.gameObject.SetActive(true);
    }

    public void OnTextFriendClicked()
    {
        StoryText.text = "You texted someone. “I think someone is following me. I’m coming over.” ";
        StartCoroutine(LoadSceneWithDelay("Scene2", 4f));
    }

    public void OnContinueWalking()
    {
        TextFriend.gameObject.SetActive(false);
        ContinueWalking.gameObject.SetActive(false);
        StoryText.gameObject.SetActive(true);

        StoryText.text = "The person that was following you was a serial killer. He caught up to you and killed you.";
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
