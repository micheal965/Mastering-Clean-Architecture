using Mapster;
using MediatR;
using SchoolManagementSystem.Core.APIBases;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : IRequestHandler<GetStudentListQuery, APIResponse<List<GetStudentResponse>>>,
                                   IRequestHandler<GetStudentByIdQuery, APIResponse<GetStudentResponse>>
    {
        private readonly IStudentService _studentService;

        public StudentQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<APIResponse<List<GetStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var Students = await _studentService.GetStudentsListAsync(cancellationToken);
            var StudentsDto = Students.Adapt<List<GetStudentResponse>>();
            return APIResponse<List<GetStudentResponse>>.Success(StudentsDto);
        }

        public async Task<APIResponse<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);
            if (student == null) return APIResponse<GetStudentResponse>.Failure("Student not Found", 404);
            var studentDto = student.Adapt<GetStudentResponse>();
            return APIResponse<GetStudentResponse>.Success(studentDto);
        }
    }
}
