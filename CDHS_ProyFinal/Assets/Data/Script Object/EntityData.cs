using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Entity/EntityData")]
public class EntityData : ScriptableObject
{
    [SerializeField] protected string entityName;
}
