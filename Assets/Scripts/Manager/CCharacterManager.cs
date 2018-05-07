using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCharacterManager : MonoBehaviour {

    public Text unitCountText;
    public Text monsterCountText;

    public Dictionary<string, GameObject> unitDic;
    public Dictionary<string, GameObject> monsterDic;

    [HideInInspector] public List<GameObject> activeUnitList;
    [HideInInspector] public List<GameObject> activeMonsterList;

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
        unitDic = new Dictionary<string, GameObject>();
        monsterDic = new Dictionary<string, GameObject>();
        activeMonsterList = new List<GameObject>();
        activeUnitList = new List<GameObject>();
        
        LoadDataFromFiles("Prefabs/Unit", unitDic);
        LoadDataFromFiles("Prefabs/Monster", monsterDic);
    }

    private void Update()
    {
        if(unitCountText)
            unitCountText.text = activeUnitList.Count + " /25";

        if(monsterCountText)
            monsterCountText.text = activeMonsterList.Count.ToString();
    }

    private void LoadDataFromFiles(string path, Dictionary<string, GameObject> dic)
    {
        GameObject[] objects = Resources.LoadAll<GameObject>(path);
        
        for (int i = 0; i < objects.Length; ++i)
        {
            dic.Add(objects[i].name, objects[i]);
        }
    }

    public void DestroyObjectFromList(GameObject obj)
    {
        activeMonsterList.Remove(obj);
    }

    public void CombinationUnit()
    {
//        for()
//        activeUnitList
    }
}
