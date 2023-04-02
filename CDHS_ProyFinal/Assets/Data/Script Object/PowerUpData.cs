using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Entity/Object/PowerUp/PowerUpData")]
public class PowerUpData : ScriptableObject
{
    [SerializeField] private string powerUpType;
    [SerializeField] private float powerUpEffect;
}
