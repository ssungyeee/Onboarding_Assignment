using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnemyInfo : MonoBehaviour
{
    public Enemy _enemy;

    public event Action<Enemy> OnEnemyInfo;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void EnemyInfomationPopup()
    {
        OnEnemyInfo?.Invoke(_enemy);
    }

    public void OnEnable()
    {
        
    }
}
