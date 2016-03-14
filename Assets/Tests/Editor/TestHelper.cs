using Entitas;

public static class TestHelper {

    public static Pool CreateCorePool() {
        return new Pool(CoreComponentIds.TotalComponents, 0, new PoolMetaData("Core Pool", CoreComponentIds.componentNames, CoreComponentIds.componentTypes));
    }

    public static Pool CreateInputPool() {
        return new Pool(InputComponentIds.TotalComponents, 0, new PoolMetaData("Input Pool", InputComponentIds.componentNames, InputComponentIds.componentTypes));
    }

    public static Pool CreateBulletsPool() {
        return new Pool(BulletsComponentIds.TotalComponents, 0, new PoolMetaData("Bullets Pool", BulletsComponentIds.componentNames, BulletsComponentIds.componentTypes));
    }
}

