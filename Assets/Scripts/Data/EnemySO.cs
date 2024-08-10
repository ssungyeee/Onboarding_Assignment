using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Grade { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
}
