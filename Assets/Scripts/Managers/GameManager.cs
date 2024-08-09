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

    public Player Player { get; set; }
}
