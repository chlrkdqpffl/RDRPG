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

    void Start () {
		
	}
	
	void Update () {
		
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
}
