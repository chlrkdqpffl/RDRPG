using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWaveManager : MonoBehaviour {

    public float startWatingTime;

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

    public void Start()
    {
        StartWave(1);
    }

    public void StartWave(int wave)
    {
        StageInfo stage = CDataFileManager.Instance.stageDic[wave];
        nowWave = 1;

      //  for(int i = 0; i < stage.WaveData.Length; ++i)
        StartCoroutine(CreateRepeat(stage.WaveData[0]));
    }

    
    private IEnumerator CreateRepeat(WaveInfo waveinfo)
    {
        int createCount = 0;

        yield return new WaitForSeconds(startWatingTime);

        while (createCount < waveinfo.AppearCount)
        {
            createCount++;
            MonsterPool.Instance.WakeUpObject(waveinfo.MonsterType);

            yield return new WaitForSeconds(waveinfo.RepeatTime);
        }
    }
    
}
