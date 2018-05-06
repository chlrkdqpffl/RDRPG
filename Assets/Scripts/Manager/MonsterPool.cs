using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour {

    public Dictionary<string, List<GameObject>> monsterPool;
    public int poolCapacity;

    private static MonsterPool _instance = null;
    public static MonsterPool Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MonsterPool>();

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
        monsterPool = new Dictionary<string, List<GameObject>>();


        LoadDataFromFile_Monster("Monster_0001");
    }

    private void LoadDataFromFile_Monster(string path)
    {
        GameObject prefab = Resources.Load("Prefabs/Monster/" + path) as GameObject;


        List<GameObject> objectList = new List<GameObject>();
        for (int i = 0; i < poolCapacity; ++i)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);

            objectList.Add(obj);
        }

        monsterPool.Add(path, objectList);
    }

    public void WakeUpObject(string name)
    {
        List<GameObject> objList = monsterPool[name];

        /*
        if(obj == null)
        {
            // 에러 처리가 제대로 안되네
            Debug.Log("null");
          
        }
        */

        objList[0].SetActive(true);

        objList.RemoveAt(0);
    }
}
