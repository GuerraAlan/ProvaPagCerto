using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Infrastructure
{
    public abstract class AProcessing
    {
        protected readonly ApiDbContext _dbContext;

        protected AProcessing(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected void LaunchError(string error)
        {
            Console.WriteLine(error); //Movendo os erros pra cá, facilitar o tratamento mais tarde
            //TODO: Ver uma forma de notificar
        }
    }
}
