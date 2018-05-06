using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character {


	void Start () {
		
	}
	
	
	void Update ()
    {
		
	}

    public void Damage(int damage)
    {
        myStatus.HP -= damage;
        if(myStatus.HP <= 0)
        {
            myStatus.HP = 0;
        }

        // 자기 자신이 있는 액티브 몬스터 풀에서 삭제해야함
    }
}
