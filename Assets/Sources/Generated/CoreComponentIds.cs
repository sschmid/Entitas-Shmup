public static class CoreComponentIds {
    public const int Destroy = 0;
    public const int GameObjectObjectPool = 1;
    public const int Position = 2;
    public const int Resource = 3;
    public const int Velocity = 4;
    public const int View = 5;
    public const int Player = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "Destroy",
        "GameObjectObjectPool",
        "Position",
        "Resource",
        "Velocity",
        "View",
        "Player"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DestroyComponent),
        typeof(GameObjectObjectPoolComponent),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(VelocityComponent),
        typeof(ViewComponent),
        typeof(PlayerComponent)
    };
}