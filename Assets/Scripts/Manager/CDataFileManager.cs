using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDataFileManager : MonoBehaviour {

	public Dictionary<int, StageInfo> stageDic;
    public Dictionary<string, CharacterInfo> monsterDic;
    public Dictionary<string, CharacterInfo> unitDic;

    private static CDataFileManager _instance = null;
	public static CDataFileManager Instance
	{
		get
		{ 
			if (_instance == null){
				_instance = FindObjectOfType<CDataFileManager> ();

				if (_instance == null) {
					Debug.LogError ("Not Create Instance");
				}
			}

			return _instance;
		}
	}

    void Awake()
    {
        stageDic = new Dictionary<int, StageInfo>();
        monsterDic = new Dictionary<string, CharacterInfo>();
        unitDic = new Dictionary<string, CharacterInfo>();

        LoadDataFromFile_Stage("JsonFile/StageInfo");

        LoadDataFromFile_Monster("JsonFile/MonsterInfo");
        LoadDataFromFile_Unit("JsonFile/UnitInfo");
    }

    private void LoadDataFromFile_Stage(string path)
	{
		TextAsset[] textDatas = Resources.LoadAll<TextAsset> (path);

		for(int i = 0; i < textDatas.Length; ++i) {
			StageInfo stage = JsonUtility.FromJson<StageInfo> (textDatas[i].text);
			stageDic.Add(stage.Stage, stage);
		}
	}

    private void LoadDataFromFile_Monster(string path)
    {
        TextAsset[] textDatas = Resources.LoadAll<TextAsset>(path);

        for (int i = 0; i < textDatas.Length; ++i)
        {
            CharacterInfo monster = JsonUtility.FromJson<CharacterInfo>(textDatas[i].text);
            monsterDic.Add(monster.Name, monster);
        }
    }

    private void LoadDataFromFile_Unit(string path)
    {
        TextAsset[] textDatas = Resources.LoadAll<TextAsset>(path);

        for (int i = 0; i < textDatas.Length; ++i)
        {
            CharacterInfo unit = JsonUtility.FromJson<CharacterInfo>(textDatas[i].text);
            monsterDic.Add(unit.Name, unit);
        }
    }
}
