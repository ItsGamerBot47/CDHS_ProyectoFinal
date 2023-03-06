using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Entity/Person/Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int totalLife;
    [SerializeField] private int scoreToGive;
}
