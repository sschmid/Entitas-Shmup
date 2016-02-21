public static class InputComponentIds {
    public const int InputOwner = 0;
    public const int MoveInput = 1;
    public const int ShootInput = 2;

    public const int TotalComponents = 3;

    public static readonly string[] componentNames = {
        "InputOwner",
        "MoveInput",
        "ShootInput"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(InputOwnerComponent),
        typeof(MoveInputComponent),
        typeof(ShootInputComponent)
    };
}