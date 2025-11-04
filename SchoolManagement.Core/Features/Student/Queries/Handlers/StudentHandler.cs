using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Student.Queries.Models;
using SchoolManagement.Core.Features.Student.Queries.Results;
using SchoolManagement.Core.Wrappers;
using SchoolManagement.Core.Wrappers.Extentions;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Services.Abstraction;
using System.Linq.Expressions;

namespace SchoolManagement.Core.Features.Student.Queries.Handlers
{
    public class StudentHandler : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<IEnumerable<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetSignleStudentResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;

        public StudentHandler(IStudentService studentService, IMapper mapper,
            IStringLocalizer<SharedResources.SharedResources> stringLocalizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._stringLocalizer = stringLocalizer;
        }

        public async Task<Response<IEnumerable<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAllStudentsAsync();
            var result = _mapper.Map<IEnumerable<GetStudentListResponse>>(students);

            var resultToReturn = Success(result);
            resultToReturn.Meta = new { Count = result.Count() };

            return resultToReturn;
        }

        public async Task<Response<GetSignleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {

            var student = await _studentService.GetStudentsByIdWithIncludeAsync(request.Id);
            if (student == null)
            {
                //return NotFound<GetSignleStudentResponse>($"The Student By Id {request.Id} is not Found");
                return NotFound<GetSignleStudentResponse>(_stringLocalizer[SharedResources.SharedResourcesKeys.NotFound]);

            }

            var result = _mapper.Map<GetSignleStudentResponse>(student);

            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Students, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Id, e.GetLocalized(e.NameAr, e.Name), e.Address, e.Department.GetLocalized(e.Department.NameAr, e.Department.Name));

            //var queryable = _studentService.GetStudentsQueryable();

            var queryable = _studentService.FilterStudedntsPaginatedQueryable(request.OrderBy, request.Search);


            var paginatedResult = await queryable.Select(expression).ToPaginatedResult(request.PageIndex, request.PageSize);

            if (paginatedResult.Data!.Any())
            {
                var paginateData = PaginatedResult<GetStudentPaginatedListResponse>.Success(paginatedResult.Data!, paginatedResult.PageSize, paginatedResult.PageIndex, paginatedResult.TotalCount);

                paginateData.Meta = new { Count = paginateData.Data!.Count() };

                return paginateData;

            }
            else
            {
                var paginateNotData = PaginatedResult<GetStudentPaginatedListResponse>.Failed();
                return paginateNotData;
            }



        }
    }
}
