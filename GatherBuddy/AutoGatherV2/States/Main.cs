using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Keys;
using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States;

public class Main : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Main");
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (Dalamud.Keys[VirtualKey.D]) // force stop for example
        {
            SendTrigger(Triggers.Idle);
        }
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Main");
    }
}
