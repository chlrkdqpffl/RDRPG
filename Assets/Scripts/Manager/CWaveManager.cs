using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWaveManager : MonoBehaviour {

    private int nowWave;

    private static CWaveManager _instance = null;
    public static CWaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CWaveManager>();

                if (_instance == null)
                {
                    Debug.LogError("Not Create Instance");
                }
            }

            return _instance;
        }
    }

    void Start () {
		
	}
	
	void Update ()
    {
		
	}

    public void StartWave(int wave)
    {
        StageInfo stage = CDataFileManager.Instance.stageDic[wave];

        

        MonsterPool.Instance.WakeUpObject(stage.WaveData[0].MonsterType);

    }

    /*
    private IEnumerator CreateRepeat(WaveInfo waveinfo)
    {


        return new WaitForSeconds(waveinfo.RepeatTime);
    }
    */
}
