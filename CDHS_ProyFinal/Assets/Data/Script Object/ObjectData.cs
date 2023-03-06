using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Entity/Object/ObjectData")]
public class ObjectData : ScriptableObject
{
    [SerializeField] private string objectType;
}
