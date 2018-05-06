using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDataFileManager : MonoBehaviour {

	public Dictionary<int, StageInfo> stageDic;
	
//	public ScoreInfo scoreInfo;

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

        LoadDataFromFile_Stage("JsonFile/StageInfo");


      
    }

    private void LoadDataFromFile_Stage(string path)
	{
		TextAsset[] textDatas = Resources.LoadAll<TextAsset> (path);

		for(int i = 0; i < textDatas.Length; ++i) {
			StageInfo stage = JsonUtility.FromJson<StageInfo> (textDatas[i].text);
			stageDic.Add(stage.Stage, stage);
		}
	}
    
    /*
	private void LoadDataFromFile_ClearScore(string path)
	{
		TextAsset[] textDatas = Resources.LoadAll<TextAsset> (path);

		for(int i = 0; i < textDatas.Length; ++i) {
			StageScoreInfo stage = JsonUtility.FromJson<StageScoreInfo> (textDatas[i].text);
			clearScoreDic.Add(stage.Stage, stage);
		}
	}
    */

	public StageInfo GetStageInfo(int stage)
	{
		return stageDic [stage];
	}

}
