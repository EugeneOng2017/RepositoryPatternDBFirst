using System;

namespace Repository.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
