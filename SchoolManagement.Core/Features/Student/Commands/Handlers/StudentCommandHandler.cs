using AutoMapper;
using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Student.Commands.Models;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Services.Abstraction;

namespace SchoolManagement.Core.Features.Student.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
        }



        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // mapping 
            var studentResult = _mapper.Map<Students>(request);

            // add the student 
            var ExistInDb = await _studentService.AddStudentAsync(studentResult);
            // Check Condition 

            if (ExistInDb == "Success")
            {
                return Created<string>("");
            }
            else
            {
                return BadRequest<string>();
            }

        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //checking the id 
            var ExistStudent = await _studentService.GetByIdAsync(request.Id);
            if (ExistStudent is null)
            {
                return NotFound<string>($"The Student for the id {request.Id} is not found");
            }

            var studentMapping = _mapper.Map(request, ExistStudent);

            // mapping 
            var studentUpdated = await _studentService.UpdateStudentAsync(studentMapping);

            if (studentUpdated == "Success")
            {
                return Updated<string>();
            }
            else
            {
                return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentResult = await _studentService.GetByIdAsync(request.Id);

            if (studentResult is null)
            {
                return NotFound<string>($"The Student With id = {request.Id} is not found");

            }
            else
            {

                var isDeleted = await _studentService.DeleteAsync(studentResult);

                if (isDeleted)
                {
                    return Deleted<string>();
                }
                else
                {
                    return BadRequest<string>("Unable to delete the student.");
                }
            }



        }


    }
}
