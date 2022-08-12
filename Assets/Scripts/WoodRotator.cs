using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WoodRotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform woodLog;
    [SerializeField] Vector3 Rotation;
    [SerializeField] float rotationDuration;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] ProgressManager progressManager;
    
    void Start()
    {
        woodLog.DOLocalRotate (Rotation, rotationDuration, RotateMode.FastBeyond360).SetLoops (-1, LoopType.Restart).SetEase (Ease.Linear);
    }

    public void Hit (int keyIndex, float damage) {
      float colliderHeight = 2.75f ;
      //Skinned mesh renderer key's value is clamped between 0 & 100
      float newWeight = skinnedMeshRenderer.GetBlendShapeWeight (keyIndex) + damage * (100f / colliderHeight);
      skinnedMeshRenderer.SetBlendShapeWeight (keyIndex, newWeight);
      progressManager.SetBlendShapeValue(keyIndex, newWeight);
   }
}
