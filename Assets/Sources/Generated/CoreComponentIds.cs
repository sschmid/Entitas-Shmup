public static class CoreComponentIds {
    public const int Position = 0;
    public const int Resource = 1;
    public const int View = 2;

    public const int TotalComponents = 3;

    public static readonly string[] componentNames = {
        "Position",
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}