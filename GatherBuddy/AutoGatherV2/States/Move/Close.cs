using System;
using System.Numerics;
using ECommons.GameHelpers;
using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States.Move;

public class Close : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Close");
        if (Vector3.Distance(Player.Position, AuthoGatherV2.AutoGather.Destination) < 3)
        {
            SendTrigger(Triggers.Gathering);
        }
        
        TaskManager.Enqueue(() => GatherBuddy.Log.Information("Moving to close node"));
        TaskManager.DelayNext(5000);
        TaskManager.Enqueue(() => AuthoGatherV2.AutoGather.Destination = Player.Position);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (Vector3.Distance(Player.Position, AuthoGatherV2.AutoGather.Destination) < 3)
        {
            SendTrigger(Triggers.Gathering);
        }
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Close");
    }
}
