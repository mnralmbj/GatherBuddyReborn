using System.Numerics;
using Dalamud.Game.ClientState.Objects.Types;
using GatherBuddy.AutoGatherV2.StateMachine;
using GatherBuddy.AutoGatherV2.States;
using GatherBuddy.AutoGatherV2.States.Gathering;
using GatherBuddy.AutoGatherV2.States.Move;

namespace GatherBuddy.AuthoGatherV2;

public partial class AutoGather
{
    private GatherBuddy Plugin;

    internal static Vector3    Destination;
    internal static IGameObject Target;

    public AutoGather(GatherBuddy plugin)
    {
        Plugin = plugin;
        Start();
    }

    private StateMachine Main = new Main();

    StateMachine Gathering = new Gathering();
    StateMachine Gather    = new Gather();
    StateMachine Pre       = new Pre();
    StateMachine Post      = new Post();

    StateMachine Move  = new Move();
    StateMachine Close = new Close();
    StateMachine Far   = new Far();
    StateMachine Flag  = new Flag();

    StateMachine Idle = new Idle();

    StateMachine Scooting = new Scooting();

    public void Start()
    {
        Main.LoadSubState(Idle);
        Main.LoadSubState(Scooting);
        Main.LoadSubState(Move);
        Main.LoadSubState(Gathering);

        Gathering.LoadSubState(Pre);
        Gathering.LoadSubState(Gather);
        Gathering.LoadSubState(Post);

        Move.LoadSubState(Far);
        Move.LoadSubState(Close);
        Move.LoadSubState(Flag);

        Main.AddTransition(Idle,      Scooting,  Triggers.Scooting);
        Main.AddTransition(Scooting,  Move,      Triggers.Move);
        Main.AddTransition(Idle,      Gathering, Triggers.Gathering);
        Main.AddTransition(Move,      Gathering, Triggers.Gathering);
        Main.AddTransition(Move,      Idle,      Triggers.Idle);
        Main.AddTransition(Gathering, Idle,      Triggers.Idle);

        Gathering.AddTransition(Pre,    Gather, Triggers.Gather);
        Gathering.AddTransition(Gather, Post,   Triggers.PostGather);

        Move.AddTransition(Far, Close, Triggers.MoveClose);

        Main.EnterStateMachine();
    }

    public void Update()
    {
        Main.UpdateStateMachine();
    }
}

public enum Triggers
{
    Idle,
    Scooting,
    Move,
    MoveFar,
    MoveClose,
    Gather,
    PreGather,
    PostGather,
    Gathering
}
