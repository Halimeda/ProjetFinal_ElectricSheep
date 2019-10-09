using System;

public static class epochTimeConverter
{
    public static long Convert()
    {
        TimeSpan calculateTime = DateTime.UtcNow - new DateTime(1970, 1, 1);
        return((long)calculateTime.TotalSeconds);
    }
}
