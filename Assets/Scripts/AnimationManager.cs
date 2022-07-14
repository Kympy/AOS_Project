using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationManager : SingleTon<AnimationManager>
{
    private Animator PlayerAnim;
    public Animator playerAnim { get { return PlayerAnim; } }

    private void Awake()
    {
        PlayerAnim = GameObject.FindObjectOfType<Player>().gameObject.GetComponent<Animator>();
    }
}

