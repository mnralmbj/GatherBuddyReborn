using GatherBuddy.AuthoGatherV2;

namespace GatherBuddy.AutoGatherV2.States.Gathering;

public class Gather : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Gather");
        TaskManager.Enqueue(() => GatherBuddy.Log.Information("I'm gathering, i'm happy"));
        TaskManager.DelayNext(5000);
        TaskManager.Enqueue(() => GatherBuddy.Log.Information("I'm done gathering, i'm soo sad"));
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (false) // revisit mode poped up ?
        {
            SendTrigger(Triggers.Gather);
        }
        if (TaskManager.NumQueuedTasks == 0)
        {
            SendTrigger(Triggers.PostGather);
        }
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Gathering");
    }
}
