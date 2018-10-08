using System;

namespace Interface
{
    public interface IGenerator
    {
        object Generate();
        Type TargetType { get; }
    }
}
