using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Entity/Person/PersonData")]
public class PersonData : ScriptableObject
{
    [SerializeField] private string personName;
}
