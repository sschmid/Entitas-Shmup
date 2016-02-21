public static class BulletsComponentIds {
    public const int Position = 0;
    public const int Resource = 1;
    public const int Velocity = 2;
    public const int View = 3;
    public const int Bullet = 4;

    public const int TotalComponents = 5;

    public static readonly string[] componentNames = {
        "Position",
        "Resource",
        "Velocity",
        "View",
        "Bullet"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(VelocityComponent),
        typeof(ViewComponent),
        typeof(BulletComponent)
    };
}