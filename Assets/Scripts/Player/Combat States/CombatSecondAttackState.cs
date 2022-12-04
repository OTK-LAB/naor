using UnityEngine;

public class CombatSecondAttackState : CombatBaseState
{
    float endtime;
    public CombatSecondAttackState(PlayerController currentContext, CombatStateFactory combatStateFactory, PlayerStateFactory movementStateFactory, float damage) :
    base(currentContext, combatStateFactory, movementStateFactory, damage)
    { }
    public override void EnterState()
    {
        Ctx.ComboTriggered = false;
        Ctx.PlayerAnimator.Play("PlayerSecondAttack");
        endtime = Time.time + Ctx.PlayerAnimator.GetCurrentAnimatorStateInfo(0).length;
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
        if(Time.time >= endtime)
        {
            if(Ctx.ComboTriggered)
            {
                SwitchState(CombatFactory.ThirdAttack());
            }
            else
            {
                SwitchState(CombatFactory.Peaceful());
            }
        }
    }
}