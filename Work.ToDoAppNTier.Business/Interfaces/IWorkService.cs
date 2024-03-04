using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Common.ResponseObjects;

// IResponse
// WorkDto
// IDto

namespace ToDoAppNTier.Business.Interfaces
{
    // All databse CRUD operations are sliced different methods
    // WorkService is a unit, single work parts
    public interface IWorkService
    {
        // get all WorkDto work units
        Task<IResponse<List<WorkDto>>> GetAll();

        // get one of IDto object by its id 
        // Task<WorkDto> GetById(int id);
        Task<IResponse<IDto>> GetById<IDto>(int id);

        // create a work with WorkCreateDto model
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);

        // remove object by id
        // Task Remove(object id);
        Task<IResponse> Remove(int id);

        // // create a work with WorkUpdateDto model
        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);
    }
}
