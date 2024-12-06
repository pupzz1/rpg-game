using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    private bool canCreatClone;
    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        canCreatClone = true;
        stateTimer = player.counterAttackDruation;
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetZeroVelocity();

        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

            foreach (var hit in colliders)
            {
                if (hit.GetComponent<Enemy>() != null)
                {
                    if (hit.GetComponent<Enemy>().CanBeStunned())
                    {
                        stateTimer = 10;//大于1的值
                        player.anim.SetBool("SuccessfulCounterAttack", true);

                        if (canCreatClone)
                        {
                            canCreatClone = false;
                            player.skill.clone.CreatCloneOnCounterAttack(hit.transform);
                        }
                    }

                }
            }
        }

        if (stateTimer < 0 || triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
