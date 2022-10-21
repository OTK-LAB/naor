using UnityEngine;

public class CombatPeacefulState : CombatBaseState
{
    public CombatPeacefulState(PlayerController currentContext, CombatStateFactory combatStateFactory, PlayerStateFactory movementStateFactory):
    base(currentContext, combatStateFactory, movementStateFactory){}
    public override void EnterState()
    {

    }
    public override void UpdateState(){
        CheckSwitchStates();
    }
    public override void ExitState()
    {
   
    }
    public override void CheckSwitchStates()
    {
        if(Ctx.IsAttackPressed && (Ctx.CurrentMovementState.Query(MovementFactory.Grounded()) || Ctx.CurrentMovementState.Query(MovementFactory.Jump())))
        {
            SwitchState(CombatFactory.BasicAttack());
            Debug.Log("ben temizlemedim hala");
        }
    }
}
