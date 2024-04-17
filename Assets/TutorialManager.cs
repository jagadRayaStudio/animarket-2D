using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Tutorial
{
    public Sprite sprite;
    public string text;
}
public class TutorialManager : MonoBehaviour
{
    [SerializeField] TutorialUI tutorialUI;
    [SerializeField] List<Tutorial> tutorials;

    private int currentIndex = 0;

    public void Start()
    {
        currentIndex = 0;
        UpdateTutorialUI(currentIndex);

        tutorialUI.NextBtn.onClick.AddListener(nextTutor);
        tutorialUI.PrevBtn.onClick.AddListener(backTutor);

    }

    private void UpdateTutorialUI(int index)
    {

        if (index >= 0 && index < tutorials.Count)
        {
            tutorialUI.Image.sprite = tutorials[index].sprite;
            tutorialUI.Content.text = tutorials[index].text;

            tutorialUI.NextBtn.interactable = index < tutorials.Count - 1;
            tutorialUI.PrevBtn.interactable = index > 0;
        }
    }

    private void nextTutor()
    {
        currentIndex++;
        UpdateTutorialUI(currentIndex);

    }
    private void backTutor()
    {
        currentIndex--;
        UpdateTutorialUI(currentIndex);

    }

}
