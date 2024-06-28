namespace Out_of_Office.Filters.Helpers;

public class SortingHelper
{
    public static KeyValuePair<string, string>[] GetUsersSortFields()
    {
        return new[] { SortFields.FullName, SortFields.Subdivision, SortFields.Position };
    }

    public static KeyValuePair<string, string>[] GetApprovalRequestsSortFields()
    {
        return new[] { SortFields.ApproverId, SortFields.Status };
    }

    public static KeyValuePair<string, string>[] GetLeaveRequestsSortFields()
    {
        return new[] { SortFields.EmployeeId, SortFields.Status };
    }

    public static KeyValuePair<string, string>[] GetProjectsSortFields()
    {
        return new[] { SortFields.ProjectType, SortFields.Status, SortFields.ProjectManagerId };
    }
}
