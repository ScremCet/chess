using System.Numerics;

namespace chess;

public class Coord
{
    public static (int,int) Vector((int,int) a , (int,int) b)
    {
        return(b.Item1 - a.Item1,b.Item2 - a.Item2);
    }

    public static (int, int) Add((int, int) a, (int, int) vector){
        return (a.Item1 + vector.Item1,a.Item2 + vector.Item2);
    }

    public static (int, int) Step((int, int) vector)
    {
        return (Math.Sign(vector.Item1),Math.Sign(vector.Item2));
    }
}