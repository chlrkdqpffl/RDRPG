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
        if(Input.GetKeyDown(KeyCode.A))
            myAnimator.Play("Battle_Figher_Attack");
        else if (Input.GetKeyDown(KeyCode.B))
            myAnimator.Play("Battle_Figher_ready");


        CheckInEnemy();
    }

    private void CheckInEnemy()
    {
        for (int i = 0; i < CCharacterManager.Instance.activeMonsterList.Count; ++i) {
//            float dist = Vector2.Distance(transform.position, CCharacterManager.Instance.activeMonsterList[i].transform.position);
//            Debug.Log(dist);

            if (Vector2.Distance(transform.position, CCharacterManager.Instance.activeMonsterList[i].transform.position) <= AttackRange)
            {
                myAnimator.SetBool("IsRange", true);
                if (isAttackWating == false)
                {
                    StartCoroutine(AttackEnemy(i));
                    return;
                }
            }
            else
                myAnimator.SetBool("IsRange", false);
        }
    }


    private IEnumerator AttackEnemy(int index)
    {
        isAttackWating = true;
        myAnimator.Play("Battle_Figher_Attack");

        GameObject monster = CCharacterManager.Instance.activeMonsterList[index];
        monster.GetComponent<Monster>().Damage(myStatus.AP);


        yield return new WaitForSeconds(myStatus.AttackSpeed);

        isAttackWating = false;
    }
}
