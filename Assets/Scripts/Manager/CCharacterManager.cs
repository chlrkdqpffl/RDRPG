using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterManager : MonoBehaviour {

    public List<GameObject> activeMonsterList;
    public List<GameObject> activeUnitList;

    private static CCharacterManager _instance = null;
    public static CCharacterManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CCharacterManager>();

                if (_instance == null)
                {
                    Debug.LogError("Not Create Instance");
                }
            }

            return _instance;
        }
    }


    private void Awake()
    {
        activeMonsterList = new List<GameObject>();
        activeUnitList = new List<GameObject>();
    }
    
}
