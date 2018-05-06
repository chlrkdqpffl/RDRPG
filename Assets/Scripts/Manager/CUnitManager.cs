using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CUnitManager : MonoBehaviour {

    const int MaxGroundCount = 25;

    private List<GameObject> unitPool;
    private List<int> overlapList;

    private static CUnitManager _instance = null;
    public static CUnitManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CUnitManager>();

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
        unitPool = new List<GameObject>();
       
        overlapList = new List<int>();

        LoadUnit();   
    }

    private void LoadUnit()
    {
        object[] objects = Resources.LoadAll("Prefabs/Unit");

        for (int i = 0; i < objects.Length; ++i)
        {
            unitPool.Add((GameObject)objects[i]);
        }
    }

    public Vector2 FindTilePos(int index)
    {
        int x = index % 5;
        int y = index / 5;

        return new Vector2(-4*y + 4*x, 8 - 2*x - 2*y );
    }

    public void CreateRandomUnit()
    {
        int index = Random.Range(0, MaxGroundCount);
        if (overlapList.Count < MaxGroundCount)
        {
            while (true == overlapList.Exists(delegate (int item) { return item == index; }))
            {
                index = Random.Range(0, MaxGroundCount);
            }

            overlapList.Add(index);

            Vector3 pos = FindTilePos(index);
            pos.z = -10 - transform.position.y / 1000.0f;

            GameObject obj = Instantiate(unitPool[Random.Range(0, unitPool.Count)], pos, Quaternion.identity, transform);
            //            obj.GetComponent<Character>().myStatus = CDataFileManager.Instance.unitDic[obj.name];

            CCharacterManager.Instance.activeUnitList.Add(obj);
        }
    }
}