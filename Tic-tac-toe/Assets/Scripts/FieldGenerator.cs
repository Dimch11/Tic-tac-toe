using System;

public interface IFieldGenerator<T>
{
    Field<T> GenerateField();
}
