using System;

public interface IFieldGenerator<T>
{
    void GenerateField(Field<T> field);
}
