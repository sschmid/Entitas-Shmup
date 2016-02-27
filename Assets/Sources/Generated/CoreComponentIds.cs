public static class CoreComponentIds {
    public const int Destroy = 0;
    public const int GameObjectObjectPool = 1;
    public const int Position = 2;
    public const int Resource = 3;
    public const int Velocity = 4;
    public const int View = 5;
    public const int Health = 6;
    public const int Player = 7;

    public const int TotalComponents = 8;

    public static readonly string[] componentNames = {
        "Destroy",
        "GameObjectObjectPool",
        "Position",
        "Resource",
        "Velocity",
        "View",
        "Health",
        "Player"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DestroyComponent),
        typeof(GameObjectObjectPoolComponent),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(VelocityComponent),
        typeof(ViewComponent),
        typeof(HealthComponent),
        typeof(PlayerComponent)
    };
}