using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAssociate.Repositories.Repositories.Interfaces;

namespace SalesAssociate.Repositories
{
    public interface IUnitOfWork
    {
        //Repositories
        ICarRepository Cars { get; }
        //Save Method
        Task SaveAsync();

    }
}
