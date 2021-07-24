using System;

public abstract class Field<T>
{
    public abstract T this[int heightPos, int widthPos]
    {
        get;
        set;
    }

    public abstract int Height { get; }
    public abstract int Width { get; }

    public abstract void Clear();
    public abstract void ClearCell(int heightPos, int widthPos);
}