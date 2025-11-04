using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Department.Query.Models;
using SchoolManagement.Core.Features.Department.Query.Result;
using SchoolManagement.Core.Wrappers.Extentions;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Services.Abstraction;
using System.Linq.Expressions;

namespace SchoolManagement.Core.Features.Department.Query.Handle
{
    public class DepartmentQueryHandler :
        ResponseHandler, IRequestHandler<DepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources.SharedResources> _localizer;

        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public DepartmentQueryHandler(IDepartmentService departmentService,
            IStringLocalizer<SharedResources.SharedResources> localizer,
            IMapper mapper,
            IStudentService studentService
            )
        {
            this._departmentService = departmentService;
            this._localizer = localizer;
            this._mapper = mapper;
            this._studentService = studentService;
        }


        public async Task<Response<GetDepartmentByIdResponse>> Handle(DepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            // Service Get By Id include st sub ins
            var department = await _departmentService.GetDepartmentById(request.Id);

            // Check not if Exist  => not found
            if (department is null)
            {
                return NotFound<GetDepartmentByIdResponse>(_localizer[SharedResources.SharedResourcesKeys.NotFound]);
            }

            // mapping 

            var departmentmapped = _mapper.Map<GetDepartmentByIdResponse>(department);


            Expression<Func<Students, StudentResponse>> expression =
                e => new StudentResponse(e.Id, e.GetLocalized(e.NameAr ?? string.Empty, e.Name));

            var studentByDepartment = _studentService.GetStudentsByDepartmentIdQuerable(request.Id);
            var paginatedlist = await studentByDepartment.Select(expression).ToPaginatedResult(request.StudentPageIndex, request.StudentPageSize);

            departmentmapped.StudentList = paginatedlist;


            // return response
            return Success(departmentmapped);

        }
    }
}
