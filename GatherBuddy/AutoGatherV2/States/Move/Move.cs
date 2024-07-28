namespace GatherBuddy.AutoGatherV2.States.Move;

public class Move : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Move");
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        GatherBuddy.Log.Information("Moving....");
        // check if we are stuck, cancel all movment and retry
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Move");
    }
}
