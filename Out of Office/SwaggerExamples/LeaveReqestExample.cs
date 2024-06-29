using Application.Dto.LeaveRequests;
using Swashbuckle.AspNetCore.Filters;

namespace Out_of_Office.SwaggerExamples;

public class LeaveReqestExample : IExamplesProvider<CreateLeaveRequestDto>
{
    public CreateLeaveRequestDto GetExamples()
    {
        return new CreateLeaveRequestDto
        {
            UserId = "yourUserId",
            AbsenceReason = "absenceReason",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now,
            Comment = "yourComment",
            Status = "Awaiting Approval"
        };
    }
}
