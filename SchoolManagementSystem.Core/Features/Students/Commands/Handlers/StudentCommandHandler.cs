using Mapster;
using MapsterMapper;
using MediatR;
using SchoolManagementSystem.Core.APIBases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data.Models;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : IRequestHandler<AddStudentCommand, APIResponse<string>>,
            IRequestHandler<EditStudentCommand, APIResponse<string>>,
            IRequestHandler<DeleteStudentCommand, APIResponse<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<APIResponse<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(student, cancellationToken);
            if (result.Equals("success"))
                return APIResponse<string>.Success(result);

            return APIResponse<string>.Failure(result, 400);
        }

        public async Task<APIResponse<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is exist or not
            var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);
            if (student == null)
                return APIResponse<string>.Failure("Student is Not found", 404);

            request.Adapt(student);

            var result = await _studentService.EditAsync(student);
            if (result.Equals("success", StringComparison.OrdinalIgnoreCase))
                return APIResponse<string>.Success(result);

            return APIResponse<string>.Failure(result, 400);
        }

        public async Task<APIResponse<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is exist or not
            var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);
            if (student == null)
                return APIResponse<string>.Failure("Student is Not found", 404);

            var result = await _studentService.DeleteAsync(student);
            if (result.Equals("success", StringComparison.OrdinalIgnoreCase))
                return APIResponse<string>.Success(result);

            return APIResponse<string>.Failure(result, 400);
        }
    }
}
