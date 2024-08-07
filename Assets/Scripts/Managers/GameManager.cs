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
            return GetInstance();
        }
    }

    public static GameManager GetInstance()
    {
        _instance = FindObjectOfType<GameManager>();

        if (_instance == null)
        {
            var go = new GameObject("GameManager");
            _instance = go.AddComponent<GameManager>();
        }

        return _instance;
    }

    public Player player { get; set; }

    private void Start()
    {
        //GameObject gameObject = Resources.Load("Player") as GameObject;
    }
}
