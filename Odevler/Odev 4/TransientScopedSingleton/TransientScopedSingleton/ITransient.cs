using System;

namespace TransientScopedSingleton
{
    public interface ITransient
    {
        Guid GetOperation();
    }
}
