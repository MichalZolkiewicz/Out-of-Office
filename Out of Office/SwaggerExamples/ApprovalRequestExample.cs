using Application.Dto.ApprovalRequests;
using Swashbuckle.AspNetCore.Filters;

namespace Out_of_Office.SwaggerExamples;

public class ApprovalRequestExample : IExamplesProvider<CreateApprovalRequestDto>
{
    public CreateApprovalRequestDto GetExamples()
    {
        return new CreateApprovalRequestDto
        {
            LeaveRequestId = 0,
            Status = "Created",
            Comment = "insertComment"
        };
    }
}
