using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager managerInstance;
    public bool isFirstRoundCompleted = false;
    public bool isPlaying;
    public bool isPlayButtonClicked;
    [SerializeField] UiManager uiInstance;
    public int playerLevel = 0;
    void Awake()
    {
        managerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayButtonClicked)
        {
            uiInstance.tutorialAnimation(isPlaying);
        }
    }
}
