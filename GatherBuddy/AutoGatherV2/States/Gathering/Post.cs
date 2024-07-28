using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States.Gathering;

public class Post : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Post");
        // if spririt // if repair // if no space left // if any thing after gathering
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (TaskManager.NumQueuedTasks == 0)
        {
            SendTrigger(Triggers.Idle);
        }
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Post");
    }
}
