using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = FindObjectOfType<GameManager>();

                if (obj != null)
                {
                    _instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<GameManager>();
                    _instance = newObj;
                }
            }
            return _instance;
        }
    }

    public enum EnemyGrade
    {
        일반,
        레어,
        매직,
        전설,
        영웅
    }

    public Player Player { get; set; }
    public Enemy Enemy { get; set; }

    [SerializeField] GameObject[] enemyPrefabObj;
    public EnemyGrade enemyGrade;
    private int _index;

    private void Awake()
    {
        _index = 0;
        PlayerInitialize();
        EnemyInitialize();
        EnemySpwaning();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void PlayerInitialize()
    {
        Vector3 SpwanPosition = new Vector3(0, -4, 0);
        Quaternion SpwanRotation = Quaternion.Euler(0, 0, 0);

        var playerPrefab = Resources.Load("Prefabs/Player/Player");
        Instantiate(playerPrefab, SpwanPosition, SpwanRotation);
    }

    private void EnemyInitialize()
    {
        Object[] enemyPrefab = Resources.LoadAll("Prefabs/Enemy");
        enemyPrefabObj = new GameObject[enemyPrefab.Length];

        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            GameObject obj = enemyPrefab[i] as GameObject;
            enemyPrefabObj[i] = obj;
        }
    }

    public void EnemySpwaning()
    {
        Vector3 SpwanPosition = new Vector3(Player.transform.position.x - 5, -4, 0);
        Quaternion SpwanRotation = Quaternion.Euler(0, 0, 0);

        GameObject obj = Instantiate(enemyPrefabObj[_index], SpwanPosition, SpwanRotation);

        _index++;
        if (_index > 4) _index = 0;
    }
}
