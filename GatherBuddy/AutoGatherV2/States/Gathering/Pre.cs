using Dalamud.Game.ClientState.Conditions;
using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States.Gathering;

public class Pre : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Pre");
        if (Dalamud.Conditions[ConditionFlag.Mounted])
        {
            TaskManager.Enqueue(() => GatherBuddy.Log.Information("Unmounting"));
        }
        // if spririt // if repair // if no space left // if any thing before gathering
        
        if (Dalamud.Targets.Target != AuthoGatherV2.AutoGather.Target)
        {
            TaskManager.Enqueue(() => GatherBuddy.Log.Information("Targeting"));
        }
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (TaskManager.NumQueuedTasks == 0)
        {
            SendTrigger(Triggers.Gather);
        }
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Pre");
    }
}
