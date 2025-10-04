using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.APIBases;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Models;
using SchoolManagementSystem.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : IRequestHandler<GetStudentListQuery, APIResponse<List<GetStudentResponse>>>,
                                   IRequestHandler<GetStudentByIdQuery, APIResponse<GetStudentResponse>>,
                                   IRequestHandler<GetStudentPaginatedListQuery, PaginedResult<GetStudentResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public StudentQueryHandler(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
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
            if (student == null) return APIResponse<GetStudentResponse>.Failure(_stringLocalizer[SharedResourcesKeys.NotFound], 404);
            var studentDto = student.Adapt<GetStudentResponse>();
            return APIResponse<GetStudentResponse>.Success(studentDto);
        }

        public async Task<PaginedResult<GetStudentResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentResponse>> expression = s => new GetStudentResponse(s.Name, s.Address, s.Phone, s.Department.Name);
            var query = _studentService.GetStudentsWithFiltrationQueryable(request.OrderBy, request.Search);
            var paginatedList = await query.Select(expression).ToPaginedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}
