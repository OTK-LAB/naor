using UnityEngine;

public class CombatBasicAttackState : CombatBaseState
{
    float endtime;
    public CombatBasicAttackState(PlayerController currentContext, CombatStateFactory combatStateFactory, PlayerStateFactory movementStateFactory, float damage) :
    base(currentContext, combatStateFactory, movementStateFactory, damage)
    { }
    public override void EnterState()
    {
        Ctx.IsAttackPressed = false;
        Ctx.CanMove = false;
        Ctx.PlayerAnimator.Play("PlayerBasicAttack");
        endtime = Time.time + Ctx.PlayerAnimator.GetCurrentAnimatorStateInfo(0).length/2;
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        //FIXME:
        //  Moves player forward after attacking
        //Ctx.transform.position = new Vector2(Ctx.transform.position.x + (Ctx.FacingRight ? .57f : -0.57f), Ctx.transform.position.y);
    }
    public override void CheckSwitchStates()
    {
        if(Time.time >= endtime){
            Ctx.LastAttack = 1;
            SwitchState(CombatFactory.Peaceful());
        }
        // if (Time.time >= endtime)
        // {
        //     if(Ctx.ComboTriggered)
        //     {
        //         SwitchState(CombatFactory.SecondAttack());
        //     }
        //     else
        //     {
        //         SwitchState(CombatFactory.Peaceful());
        //     }
        // }
    }
    public void OnBasicAttackEnded()
    {
        SwitchState(CombatFactory.Peaceful());
    }

}
