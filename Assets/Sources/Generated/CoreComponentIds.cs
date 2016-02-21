public static class CoreComponentIds {
    public const int Resource = 0;
    public const int View = 1;

    public const int TotalComponents = 2;

    public static readonly string[] componentNames = {
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}