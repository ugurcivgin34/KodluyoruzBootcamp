using System;

namespace TransientScopedSingleton
{
    public interface IScoped
    {
        Guid GetOperation();

    }
}
