using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController currentContext, PlayerStateFactory playerStateFactory)
    :base (currentContext, playerStateFactory) {}
    public override void EnterState()
    {
        Ctx.AppliedMovement = 0;
    }
    public override void UpdateState()
    {
        if(Ctx.CurrentCombatState == Ctx.CombatFactory.Peaceful())
        {
           if(SuperState == Factory.Standing())
            {
                Ctx.PlayerAnimator.Play("PlayerIdle");
            }
            if(SuperState == Factory.Crouch())
            {
                Ctx.PlayerAnimator.Play("PlayerCrouch");
            }
        }
        //TODO: 
        CheckSwitchStates();
    }
    public override void ExitState()
    {

    }
    public override void CheckSwitchStates()
    {
        if(Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Run());
        }
    }
    public override void InitializeSubstate()
    {

    }
}
