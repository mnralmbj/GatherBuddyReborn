namespace GatherBuddy.AutoGatherV2.States.Gathering;

public class Gathering : StateMachine.StateMachine
{
    protected override void OnEnter()
    {
        GatherBuddy.Log.Information("Enter Gathering");
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        //GatherBuddy.Log.Information("Updating Gathering");
    }

    protected override void OnExit()
    {
        GatherBuddy.Log.Information("Exit Gathering");
    }
}
