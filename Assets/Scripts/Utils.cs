using UnityEngine;

public class Utils
{
    public static string GetHashCode(Vector3 vec)
    {
        return Vector3Int.RoundToInt(vec).ToString();
    }
}