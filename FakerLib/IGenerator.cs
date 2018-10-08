using System;

namespace FakerLib
{
    public interface IGenerator
    {
        object Generate();
        Type TargetType { get; }
    }
}
