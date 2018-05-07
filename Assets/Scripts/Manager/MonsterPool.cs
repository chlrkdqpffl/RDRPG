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
    }

    private void Start()
    {
        CreatePoolAll();
    }

    private void CreatePoolAll()
    {
        GameObject[] objects = Resources.LoadAll<GameObject>("Prefabs/Monster");

        for (int i = 0; i < objects.Length; ++i)
        {
            List<GameObject> objectList = new List<GameObject>();

            for (int j = 0; j < poolCapacity; ++j)
            {
                GameObject obj = Instantiate(objects[i], transform);
                obj.SetActive(false);

                objectList.Add(obj);
            }

            monsterPool.Add(objectList[0].GetComponent<Character>().myStatus.Name, objectList);
        }
    }

    public void PushObjectPool(string name, GameObject obj)
    {
        monsterPool[name].Add(obj);
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
        CCharacterManager.Instance.activeMonsterList.Add(objList[0]);
        objList.RemoveAt(0);
    }
}
