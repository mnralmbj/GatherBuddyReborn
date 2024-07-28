using System;

namespace GatherBuddy.AutoGatherV2.StateMachine {
    
    public class DuplicateSubStateException(string msg) : Exception(msg);

    public class DuplicateTransitionException(string msg) : Exception(msg);

    public class InvalidTransitionException(string msg) : Exception(msg);

    public class NeglectedTriggerException(string msg) : Exception(msg);
}
