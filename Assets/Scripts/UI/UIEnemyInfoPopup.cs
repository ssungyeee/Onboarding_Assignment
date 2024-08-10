using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIEnemyInfoPopup : MonoBehaviour
{
    // 이벤트 만들어서 정보 받아오고 팝업하기
    public Enemy _enemy;
    public UIEnemyInfo uIEnemyInfo;

    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyGrade;
    public TextMeshProUGUI enemySpeed;
    public TextMeshProUGUI enemyHealth;

    private void Awake()
    {

    }

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
        uIEnemyInfo = obj.GetComponent<UIEnemyInfo>();

        uIEnemyInfo.OnEnemyInfo += OpenPopup;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {

    }

    public void ClosePopup()
    {
        //uIEnemyInfo.OnEnemyInfo -= OpenPopup;
        gameObject.SetActive(false);
    }

    public void OpenPopup(Enemy enemy)
    {
        gameObject.SetActive(true);

        enemyName.text = "Name " + enemy.Data.Name;
        enemyGrade.text = "Grade " + enemy.Data.Grade;
        enemySpeed.text = "Speed " + enemy.Data.Speed;
        enemyHealth.text = "Health " + enemy.Data.Health;
    }
}
