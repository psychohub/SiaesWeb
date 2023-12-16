using SiaesLibraryShared.Models;
using SiaesLibraryShared.Responses;


namespace SiaesLibraryShared.Contracts
{
    public interface ITanu
    {
        Task<ServiceResponse> AddTanu(Model_Tanu model);
        Task<List<Model_Tanu>> GetAllTanus(string NumeroIdentificacionRecienNacido);
    }
}
