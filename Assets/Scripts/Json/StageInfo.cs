using UnityEngine;

[System.Serializable]
public struct StageInfo 
{
	public int Stage;                       // 스테이지
    public int Wave;                        // 스테에지 웨이브 수
//    public int Time;						// 게임 시간

        /*
    public WaveInfo waveInfo1;
    public WaveInfo waveInfo2;
    public WaveInfo waveInfo3;
    public WaveInfo waveInfo4;
    */
}

public struct WaveInfo
{
    int appearCount;
    int repeatTime;

    Monster.Type monsterType;
}