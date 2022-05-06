using System;

namespace TransientScopedSingleton
{
    public class OperationService : ITransient, IScoped, ISingleton
    {
        private readonly Guid _id;
        public OperationService()
        {
            _id= Guid.NewGuid();
        }
        public Guid GetOperation()
        {
            return _id;
        }
    }
}
