using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBollName) : base(_player, _stateMachine, _animBollName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(player.IsWallDetected())
        {
            stateMachine.ChangeState(player.wallSlide);
        }

        if(player.IsGroundDetected())
        stateMachine.ChangeState(player.idleState);

        if(xInput !=0)
            player.SetVelocity(player.moveSpeed*xInput,rb.velocity.y);

     }
}

