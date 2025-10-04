using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Helpers;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginedResult<GetStudentResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
