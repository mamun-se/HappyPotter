using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Models")]
public class ModelData : ScriptableObject
{
    public List<float> shapeData = new List<float>();
}
