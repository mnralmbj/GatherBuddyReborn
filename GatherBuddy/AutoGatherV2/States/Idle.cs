using System.Numerics;
using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States;

public class Idle : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Idle");
        if (false) // there is nothing to gather
        {
            SendTrigger(Triggers.Gathering);
        } 
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (true) // there is something that poped up and possible to gather for ex
        {
            AuthoGatherV2.AutoGather.Destination = Vector3.Zero;
            SendTrigger(Triggers.Scooting);
        }     
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Idle");
    }
}
