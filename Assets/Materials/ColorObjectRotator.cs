using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorObjectRotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 Rotation;
    [SerializeField] float rotationDuration;
    void Start()
    {
        this.transform.DOLocalRotate (Rotation, rotationDuration, RotateMode.FastBeyond360).SetLoops (-1, LoopType.Restart).SetEase (Ease.Linear);
    }
}
