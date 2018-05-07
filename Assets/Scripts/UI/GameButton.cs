using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour {

    public void StopGame()
    {
        Time.timeScale = 0.0f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
    }

    public void PlaySpeed()
    {
        Time.timeScale = 2.0f;
    }

    public void SummonButton()
    {
        if (100 <= CGameManager.Instance.mana)
        {
            CGameManager.Instance.mana -= 100;
            CUnitManager.Instance.CreateRandomUnit();
        }
    }
}
