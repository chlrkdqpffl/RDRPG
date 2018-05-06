using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Character
{
    public float AttackRange;

    private bool isAttackWating;

	void Start () {
		
	}
	
	
	void Update ()
    {
        CheckInEnemy();
    }

    private void CheckInEnemy()
    {
        for (int i = 0; i < CCharacterManager.Instance.activeMonsterList.Count; ++i) {
            if (Vector2.Distance(transform.position, CCharacterManager.Instance.activeMonsterList[i].transform.position) <= AttackRange)
            {
                // 공격 대기중
                if(isAttackWating)
                {
                    myAnimator.Play("Battle_Figher_ready");
                }
                else
                {
                    myAnimator.Play("Battle_Figher_Attack");
                    StartCoroutine(AttackEnemy(i));
                    //여기서 부터 하자 - 공격 애니메이션ㅇ 자연스럽게 연결하자
                }
            }
        }
    }


    private IEnumerator AttackEnemy(int index)
    {
        isAttackWating = true;

//        myAnimator.Play("");



        Debug.Log(index);
        // CCharacterManager.Instance.activeMonsterList[index]

        yield return new WaitForSeconds(myStatus.AttackSpeed);

        isAttackWating = false;
    }
}
