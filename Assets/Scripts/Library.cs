using UnityEngine;

public static class Library
{
    public static bool IsEquals(this LayerMask _mask, int _layer)
    {
        return _mask == (_mask | (1 << _layer));
    }
}