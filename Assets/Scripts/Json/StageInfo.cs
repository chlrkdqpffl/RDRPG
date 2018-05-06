using UnityEngine;

[System.Serializable]
public struct WaveInfo
{
    public int AppearCount;
    public int RepeatTime;

    public string MonsterType;
}

[System.Serializable]
public struct StageInfo 
{
	public int Stage;                       // 스테이지
    public int Wave;                        // 스테에지 웨이브 수
                                            //    public int Time;						// 게임 시간

    public WaveInfo[] WaveData;
}