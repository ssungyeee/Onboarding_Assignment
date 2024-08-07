using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";

    [SerializeField] private string attackParameterName = "@Attack";

    public int GroundParameterHash {  get; private set; }
    public int IdleParameterHash { get; private set; }
    public int attackParameterHash { get; private set; }

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);

        attackParameterHash = Animator.StringToHash(attackParameterName);
    }
}
