using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3 : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI StoryText;
    public Button LieBTN;
    public Button truthBTN;
    public Button RestartButton;
    public Button NextButton;

    private int currentIndex = 0;

    //change
    private string[] storyLines = {
        "*knock on the door*",
        "Eli opened the door and saw Naib",
        "Act Natural. Someone’s here",
        "Eli lets Naib inside",
        "*knock on the door*",
        "Eli takes a deep breath before opening the door. The serial killer stood at the doorstep.",
        "Eli asks the serial killer: “May I help you?” to which the killer replies, “Is your friend inside?”.",
        "Kantian Moral Theory: You should not lie, even in this scenario, because truth-telling is a moral duty, and duties must be upheld universally, irrespective of the consequences.",
        "Utilitarianism: You should lie to the attacker because it leads to the best possible outcome: your friend’s survival and overall reduced harm.\n"
    };

    void Start()
    {
        UpdateText();
        StoryText.gameObject.SetActive(false);
        //change
        LieBTN.gameObject.SetActive(false);
        //change
        truthBTN.gameObject.SetActive(false);
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
        LieBTN.gameObject.SetActive(true);
        truthBTN.gameObject.SetActive(true);
    }


    public void OnLieClicked()//change
    {
        LieBTN.gameObject.SetActive(false);
        truthBTN.gameObject.SetActive(false);
        StoryText.text = "YOU SURVIVED.";
        StartCoroutine(LoadSceneWithDelay("Scene4", 4f));
    }

    
    public void OnTellTruthClicked()//change
    {
        LieBTN.gameObject.SetActive(false);
        truthBTN.gameObject.SetActive(false);
        StoryText.gameObject.SetActive(true);

        //change
        StoryText.text = "The Killer forced his way in and killed you both";
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
