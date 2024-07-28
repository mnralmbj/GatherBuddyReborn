using System.Numerics;
using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States;

public class Scooting : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Scooting");
        TaskManager.DelayNext(1000);
        TaskManager.Enqueue(() => GatherBuddy.Log.Information("Yolo, i've found a node !!"));
        TaskManager.Enqueue(() => AuthoGatherV2.AutoGather.Destination = Vector3.Zero);
        TaskManager.Enqueue(() => SendTrigger(Triggers.Move));
    }

    protected override void OnUpdate()
    {
        GatherBuddy.Log.Information("Searching...");
        base.OnUpdate();
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Scooting");
    }
}
