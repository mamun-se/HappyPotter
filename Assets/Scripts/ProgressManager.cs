using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private List<float> blendShapeValue = new List<float>();
    [SerializeField] private List<bool> isValueMatched = new List<bool>();
    [SerializeField] ModelData modelData;
    int totalPecentage = 0;
    float progressValue = 0.06666666666f;
    [SerializeField] Slider progressSlider;
    bool isModelCompleted = false;
    [SerializeField] ParticleSystem leftParticle;
    [SerializeField] ParticleSystem rightParticle;

    [SerializeField] GameObject WoodParent;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject ColorObj;
    private IEnumerator coroutine;
    void Update()
    {
        if (progressSlider.value < 1)
        {
            CheckProgress();
        }
        else
        {
            if (isModelCompleted)
            {
                return;
            }
           GameManager.managerInstance.isFirstRoundCompleted = true;
           Knife.transform.position = Vector3.zero;
           Knife.SetActive(false);
           isModelCompleted = true;
           PlayParticle();
            coroutine = OpenPolishSetUp(2.0f);
            StartCoroutine(coroutine);
        }
    }

    public float GetSliderData()
    {
        return progressSlider.value;
    }

    public void SetBlendShapeValue(int keyIndex,float weight)
    {
        if (blendShapeValue.Count >= keyIndex)
        {
            blendShapeValue[keyIndex] = weight;
        }
    }

    public void PlayParticle()
    {
            leftParticle.Play();
            rightParticle.Play();
    }

    private void OnModelComplete()
    {
        WoodParent.transform.DOScale(Vector3.zero,2f);
    }

    public void CheckProgress()
    {
        for (int i = 0; i < blendShapeValue.Count; i++)
        {
            if (blendShapeValue[i] >= modelData.shapeData[i] && !isValueMatched[i])
            {
                isValueMatched[i] = true;
                totalPecentage++;
                progressSlider.DOValue((totalPecentage * progressValue),1f);
            }
        }
    }

    public void UpdatePolishSlider(float sliderValue)
    {
        progressSlider.DOValue(sliderValue,0.5f);
    }



    IEnumerator OpenPolishSetUp(float timer)
    {
        yield return new WaitForSeconds(timer);
        WoodParent.transform.DOScale(Vector3.zero,1f).OnComplete(()=>
        {
            WoodParent.SetActive(false);
            ColorObj.SetActive(true);
            ColorObj.transform.DOScale(Vector3.one,2.0f);
            progressSlider.DOValue(0f,0.1f);
        });
    }
}
