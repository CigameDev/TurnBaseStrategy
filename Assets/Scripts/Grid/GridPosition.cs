
using System;
/// <summary>
/// Struct ,tọa độ của 1 ô
/// 
/// </summary>
/// 
public struct GridPosition : IEquatable<GridPosition>//interface IEquatable để tạo ra phương thức Equals so sánh hai đối tượng mà không so sánh bằng được
{   
    public int x;
    public int z;

    public GridPosition(int x,int z)
    {
        this.x = x;
        this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position &&
               x == position.x &&
               z == position.z;
    }

    public bool Equals(GridPosition other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public override string ToString()
    {
        //return "x: " + x + "; z: " + z;
        return $"x: {x}; z: {z}";
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }
}