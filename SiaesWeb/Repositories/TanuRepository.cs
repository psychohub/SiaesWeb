using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Responses;
using SiaesServer.Data;
using System.Transactions;

namespace SiaesServer.Repositories
{
    public class TanuRepository : ITanu
    {
        private readonly AppDbContext appDbContext;

        public TanuRepository(AppDbContext appDbContext)
        {
           this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddTanu(Model_Tanu model)
        {
            if (model is null) return new ServiceResponse(false, "Model is null");
            var (flag, message) = await VerificarIdentificacionRecienNacido(model.NumeroIdentificacionRecienNacido!);
            if (flag)
            {
                appDbContext.Cuadro1_Tanu.Add(model);
                await Commit();
                return new ServiceResponse(true, "Saved");
            }
            return new ServiceResponse(flag, message);

        }

        private async Task<ServiceResponse> VerificarIdentificacionRecienNacido(string numeroIdentificacion)
        {
            var existe = await appDbContext.Cuadro1_Tanu.AnyAsync(rn => rn.NumeroIdentificacionRecienNacido == numeroIdentificacion);

            if (existe)
            {
                return new ServiceResponse(false, "Identificación del recien nacido ya existe");
            }

            // Aquí puedes retornar un ServeResponse exitoso o continuar con tu lógica de negocio.
            return new ServiceResponse(true, "Identificación del recien nacido no existe");
        }

       

        public async Task<List<Model_Tanu>> GetAllTanus(string NumeroIdentificacionRecienNacido)
        {
            var existe = await appDbContext.Cuadro1_Tanu.AnyAsync(rn => rn.NumeroIdentificacionRecienNacido == NumeroIdentificacionRecienNacido);

            if (existe)
            {
                return await appDbContext.Cuadro1_Tanu.Where(rn => rn.NumeroIdentificacionRecienNacido == NumeroIdentificacionRecienNacido).ToListAsync();
            }
            else
            {
                return await appDbContext.Cuadro1_Tanu.ToListAsync();
            }
        }




        private async Task Commit() => await appDbContext.SaveChangesAsync();

    }
}
