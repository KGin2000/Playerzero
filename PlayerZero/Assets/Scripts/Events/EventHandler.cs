public delegate void MovementDelegate(float inputV, float inputH, bool isWalking, bool isIdle, bool isCarrying,
                                        ToolEffect toolEffect,
                                        bool idleUp, bool idleDown, bool idleRight, bool idleLeft);

                                        
public static class EventHandler
{
    //Movement Event

    public static event MovementDelegate MovementEvent;

    //Movement Event Call For Publishers

    public static void CallMovementEvent(float inputV, float inputH, bool isWalking, bool isIdle, bool isCarrying,
                                        ToolEffect toolEffect,
                                        bool idleUp, bool idleDown, bool idleRight, bool idleLeft)
    {
        if (MovementEvent != null)
            MovementEvent(inputV, inputH, isWalking, isIdle, isCarrying,
                        toolEffect,
                        idleUp, idleDown, idleRight, idleLeft);
    }
}