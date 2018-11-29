using Mvc5App.Domain.Entities;
using System.Collections.Generic;

namespace Mvc5App.Domain.Repository
{
    public interface IManagerRepository
    {
        IEnumerable<Manager> Managers { get; }
    }
}
