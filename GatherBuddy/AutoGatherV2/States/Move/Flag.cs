using System.Numerics;
using ECommons.GameHelpers;
using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States.Move;

public class Flag : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter fla");
        if (Vector3.Distance(Player.Position, Vector3.One) < 3) // Flag position :sweat:
        {
            SendTrigger(Triggers.Gathering);
        }

        TaskManager.Enqueue(() => GatherBuddy.Log.Information("Moving to flag node"));
        TaskManager.DelayNext(5000);
        TaskManager.Enqueue(() => AuthoGatherV2.AutoGather.Destination = Player.Position + new Vector3(10, 10, 10));
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (Vector3.Distance(Player.Position,  Vector3.One) < 3) // Flag position :sweat:
        {
            SendTrigger(Triggers.Gathering);
        }
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit flag");
    }
}
