using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public enum AnimState
    {
        Idle,
        Move,
        


        // --------------- //
        // Monster Anim
        Death,


        // Unit Anim
        Attack

//        Skill
    }

    public enum Direction
    {
        Left,
        Right
    }

    public CharacterInfo myStatus;
    public Direction nowDirecton;
    public AnimState nowAnimState;

    public Animator myAnimator;

    protected void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
}
