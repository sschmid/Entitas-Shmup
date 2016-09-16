using System;

public static class GameRandom {

    public static IRandom core { get; set; }
    public static IRandom view { get; set; }
}

public interface IRandom {

    float RandomFloat();
    float RandomFloat(float min, float max);
    int RandomInt(int min, int max);
}

public class Rand : IRandom {

    Random _random;

    public Rand(int seed) {
        _random = new Random(seed);
    }

    public float RandomFloat() {
        return (float)_random.NextDouble();
    }

    public float RandomFloat(float min, float max) {
        var diff = max - min;
        return min + diff * RandomFloat();
    }

    public int RandomInt(int min, int max) {
        return _random.Next(min, max);
    }
}
