using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorLerpManager : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer meshRenderer;
    [SerializeField] [Range(0f,1f)] float lerpTime;
    [SerializeField] Color[] myColor;
    public List<MeshRenderer> rendererList = new List<MeshRenderer>();
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     meshRenderer.material.color = Color.Lerp(meshRenderer.material.color , myColor[0] , lerpTime);
    // }

    public void SetColor(int colorIndex)
    {
        meshRenderer.material.DOColor(myColor[colorIndex],lerpTime);
    }

    public void SetBottleHitColor()
    {
        foreach (var item in rendererList)
        {
                    item.material.DOColor(myColor[0],1f).OnComplete(() =>{
             item.material.DOColor(myColor[1],0.1f);
        });
        }
    }

    
}
