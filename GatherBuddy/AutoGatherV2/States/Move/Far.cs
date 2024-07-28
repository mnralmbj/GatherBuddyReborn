using System.Numerics;
using ECommons.GameHelpers;
using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States.Move;

public class Far : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Far");
        if (Vector3.Distance(Player.Position, AuthoGatherV2.AutoGather.Destination) < 100)
        {
            SendTrigger(Triggers.MoveClose);
        }

        TaskManager.Enqueue(() => GatherBuddy.Log.Information("Moving to far node"));
        TaskManager.DelayNext(5000);
        TaskManager.Enqueue(() => AuthoGatherV2.AutoGather.Destination = Player.Position + new Vector3(10, 10, 10));
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (Vector3.Distance(Player.Position, AuthoGatherV2.AutoGather.Destination) > 100)
        {
            SendTrigger(Triggers.MoveClose);
        }
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Far");
    }
}
