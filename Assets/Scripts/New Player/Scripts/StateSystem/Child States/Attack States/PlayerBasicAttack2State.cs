using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAttack2State : AttackState
{
    public PlayerBasicAttack2State(Ultimate2DPlayer player, PlayerStateMachine stateMachine, Ultimate2DPlayer.StateName animEnum, PlayerData playerData) : base(player, stateMachine, animEnum, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        attackTime = playerData.AttackState.BasicAttack2.AttackTime;
        maxStateTime = playerData.AttackState.BasicAttack2.MaxStateTime;
        inputManager.Input_BasicAttack = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void PhysicsCheck()
    {
        base.PhysicsCheck();
    }

    public override void SwitchStateLogic()
    {
        base.SwitchStateLogic();
        if (localTime > attackTime)
        {
            if (localTime < maxStateTime && inputManager.Input_BasicAttack)
            {
                stateMachine.ChangeState(player.BasicAttack3State);
            }
            else if (localTime > maxStateTime)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (inputManager.Input_Walk != 0)
            {
                stateMachine.ChangeState(player.WalkState);
            }
            else if (inputManager.Input_Jump)
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (inputManager.Input_Dash)
            {
                stateMachine.ChangeState(player.DashState);
            }
            else if (inputManager.Input_Crouch)
            {
                stateMachine.ChangeState(player.CrouchState);
            }
        }
    }

    public override void Update()
    {
        base.Update();
    }
}