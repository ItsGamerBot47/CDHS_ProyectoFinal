using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Entity/Object/Item/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private int modifyPlayerLifeBy;
}
