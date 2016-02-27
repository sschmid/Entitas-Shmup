public static class InputComponentIds {
    public const int Collision = 0;
    public const int InputOwner = 1;
    public const int MoveInput = 2;
    public const int ShootInput = 3;

    public const int TotalComponents = 4;

    public static readonly string[] componentNames = {
        "Collision",
        "InputOwner",
        "MoveInput",
        "ShootInput"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(CollisionComponent),
        typeof(InputOwnerComponent),
        typeof(MoveInputComponent),
        typeof(ShootInputComponent)
    };
}