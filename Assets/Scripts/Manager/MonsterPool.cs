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


        LoadDataFromFile_Prefabs("Test_Monster");
    }

    private void LoadDataFromFile_Prefabs(string path)
    {
        GameObject prefab = Resources.Load("Prefabs/" + path) as GameObject;


        List<GameObject> objectList = new List<GameObject>();
        for (int i = 0; i < poolCapacity; ++i)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);

            objectList.Add(obj);
        }

        monsterPool.Add(path, objectList);
    }

    public GameObject WakeUpObject(string name)
    {
        List<GameObject> objList = monsterPool[name];
        GameObject obj = objList[0];

        if(obj == null)
        {
            // 에러 처리가 제대로 안되네
            Debug.Log("null");
            return null;
        }

        obj.SetActive(true);

        objList.RemoveAt(0);

        return obj;
    }
}
