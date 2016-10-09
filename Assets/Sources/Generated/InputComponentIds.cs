//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentIndicesGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class InputComponentIds {

    public const int Collision = 0;
    public const int InputOwner = 1;
    public const int MoveInput = 2;
    public const int ShootInput = 3;
    public const int SlowMotion = 4;
    public const int Tick = 5;

    public const int TotalComponents = 6;

    public static readonly string[] componentNames = {
        "Collision",
        "InputOwner",
        "MoveInput",
        "ShootInput",
        "SlowMotion",
        "Tick"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(CollisionComponent),
        typeof(InputOwnerComponent),
        typeof(MoveInputComponent),
        typeof(ShootInputComponent),
        typeof(SlowMotionComponent),
        typeof(TickComponent)
    };
}
