using AutoMapper;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using ToDoAppNTier.Business.Extensions;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Common.ResponseObjects;
using ToDoAppNTier.DataAccess.UnitOfWork;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        // create class instances
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createDtoValidator;
        private readonly IValidator<WorkUpdateDto> _updateDtoValidator;

        // DI
        public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            //await _uow.GetRepository<Work>().Create(new()
            //{
            //    Definition = dto.Definition,
            //    IsCompleted = dto.IsCompleted
            //});

            // var validator = new WorkCreateDtoValidator();
            // var result = validator.Validate(dto);

            var validate = _createDtoValidator.Validate(dto);

            if (validate.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChanges();
                return new Response<WorkCreateDto>(ResponseType.Success,dto);
            }
            else 
            {
                return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, validate.ConvertToCustomVE());
            }
            
        }

        public async Task<IResponse<List<WorkDto>>> GetAll()
        {
            //var list = await _uow.GetRepository<Work>().GetAll();
            //var workList = new List<WorkDto>();

            //if (list != null && list.Count> 0)
            //{
            //    foreach (var work in list)
            //    {
            //        workList.Add(new()
            //        {
            //            Id = work.Id,
            //            Definition = work.Definition,
            //            IsCompleted = work.IsCompleted
            //        });
            //    }
            //}

            //return workList;
            
            var data = _mapper.Map<List<WorkDto>>(await _uow.GetRepository<Work>().GetAll());
            return new Response<List<WorkDto>>(ResponseType.Success, data);
        }

        //public async Task<WorkDto> GetById(int id)
        //{
        //    //var work = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);

        //    //return new() { Definition = work.Definition, IsCompleted = work.IsCompleted };

        //    return _mapper.Map<WorkDto>(await _uow.GetRepository<Work>().GetByFilter(x=> x.Id == id));
        //}
        
        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            //var work = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);

            //return new() { Definition = work.Definition, IsCompleted = work.IsCompleted };

            var data = _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x=> x.Id == id));
            
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, "Bulunamadı!!");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            // var deleted = await _uow.GetRepository<Work>().GetById(id);
            // _uow.GetRepository<Work>().Remove(id);
            // await _uow.SaveChanges();

            var deleted = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);

            if (deleted != null)
            {
                _uow.GetRepository<Work>().Remove(deleted);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, "Bulunamadı!!");
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
            //_uow.GetRepository<Work>().Update(new()
            //{
            //    Id = dto.Id,
            //    Definition = dto.Definition,
            //    IsCompleted = dto.IsCompleted
            //});

            //var validate = _updateDtoValidator.Validate(dto);

            //if (validate.IsValid)
            //{
            //    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
            //    await _uow.SaveChanges();
            //}

            var result = _updateDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var updated = await _uow.GetRepository<Work>().Find(dto.Id);
                if (updated != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updated);
                    await _uow.SaveChanges();
                    return new Response<WorkUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<WorkUpdateDto>(ResponseType.NotFound, "Bulunamadı!!");
            }
            else
            {
                return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, result.ConvertToCustomVE());
            }
        }
    }
}
