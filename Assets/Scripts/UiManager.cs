using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject noAdsButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject shapeTool;
    [SerializeField] GameObject slider;
    [SerializeField] GameObject tutorialHand;
    [SerializeField] GameObject tutorialPnel;
    [SerializeField] GameObject gameTitle;
    Vector3 HandStartPos = Vector3.zero;

    public void OnPlayButtonClicked()
    {
        playButton.SetActive(false);
        noAdsButton.SetActive(false);
        settingsButton.SetActive(false);
        shapeTool.SetActive(true);
        slider.SetActive(true);
        gameTitle.SetActive(false);
        GameManager.managerInstance.isPlayButtonClicked = true;
    }

    public void tutorialAnimation(bool isPlaying)
    {
        tutorialHand.SetActive(!isPlaying);
        tutorialPnel.SetActive(!isPlaying);
    }

    void Start()
    {
        Vector3 desiredDestination =  new Vector3(tutorialHand.transform.localPosition.x , -120f,tutorialHand.transform.localPosition.z);
        HandStartPos = tutorialHand.transform.localPosition;
        tutorialHand.transform.DOLocalMove(desiredDestination,2f).SetLoops(-1, LoopType.Yoyo);
    }
}
