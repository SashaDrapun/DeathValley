using System;
using System.Threading.Tasks;

namespace DeathValley
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}