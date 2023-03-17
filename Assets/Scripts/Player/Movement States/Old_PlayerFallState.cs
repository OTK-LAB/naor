using UnityEngine;

public class Old_PlayerFallState : Old_PlayerBaseState
{
    public Old_PlayerFallState(PlayerController currentContext, Old_PlayerStateFactory playerStateFactory)
    :base (currentContext, playerStateFactory) {}
    public override void EnterState()
    {
        InitializeSubstate();       
    }
    public override void UpdateState()
    {   
        CheckSwitchStates();
    }
    public override void ExitState()
    {

    }
    public override void CheckSwitchStates()
    {
      //  if(Ctx.CanClimbLedge)
      //  {
      //      SwitchState(Factory.Hang());
      //  }
       
        if (Ctx.IsDashPressed && Ctx.CanDash)
        {
            SwitchState(Factory.Dash());
        }
    }
    public override void InitializeSubstate()
    {
        if(!Ctx.IsMovementPressed)
        {
            SetSubState(Factory.Idle());
        }
        if(Ctx.IsMovementPressed)
        {
            SetSubState(Factory.Run());
        }
    }
}