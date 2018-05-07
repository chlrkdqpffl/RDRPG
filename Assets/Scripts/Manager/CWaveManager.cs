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
        nowWave = wave;
        
        StartCoroutine(CreateRepeat(CDataFileManager.Instance.stageDic[wave]));
    }

    
    private IEnumerator CreateRepeat(StageInfo stage)
    {
        int createCount = 0;

        yield return new WaitForSeconds(startWatingTime);

        while (createCount < stage.WaveData[nowWave - 1].AppearCount)
        {
            createCount++;
            MonsterPool.Instance.WakeUpObject(stage.WaveData[nowWave - 1].MonsterType);

            yield return new WaitForSeconds(stage.WaveData[nowWave - 1].RepeatTime);
        }

        nowWave++;
        if (nowWave < stage.Wave)
        {
            StartCoroutine(CreateRepeat(stage));

        }
    }
    
}
