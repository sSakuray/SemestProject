using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

[CreateAssetMenu(fileName ="Achivment_Database",menuName ="Create achivment database")]
[System.Serializable]
public class AchivmentsDataSO : ScriptableObject
{
    [SerializeField] public List<Achivment> Achivments;
}
