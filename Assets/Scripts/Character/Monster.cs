using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character {

    public bool isDead;

    public void Damage(int damage)
    {
        myStatus.HP -= damage;
        StartCoroutine(DamageEffect());

        if(myStatus.HP <= 0)
        {
            if (isDead == false)
            {
                isDead = true;
                StartCoroutine(StartDeath());
            }
        }
    }

    private IEnumerator DamageEffect()
    {
        yield return null;
    }

    private IEnumerator StartDeath()
    {
        myStatus.HP = 0;
        myStatus.Speed = 0;

        myAnimator.SetBool("IsDead", true);
        CCharacterManager.Instance.DestroyObjectFromList(gameObject);

        yield return new WaitForSeconds(1.0f);

        gameObject.SetActive(false);

        MonsterPool.Instance.PushObjectPool(myStatus.Name, gameObject);
    }
    
    private void OnEnable()
    {
        myStatus.HP = CCharacterManager.Instance.monsterDic[myStatus.Name].GetComponent<Character>().myStatus.HP;
        myStatus.Speed = CCharacterManager.Instance.monsterDic[myStatus.Name].GetComponent<Character>().myStatus.Speed;

        isDead = false;
        myAnimator.SetBool("IsDead", false);
    }
}
