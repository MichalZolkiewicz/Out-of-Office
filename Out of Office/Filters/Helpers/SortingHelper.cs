namespace Out_of_Office.Filters.Helpers;

public class SortingHelper
{
    public static KeyValuePair<string, string>[] GetEmployeeSortFields()
    {
        return new[] { SortFields.FullName, SortFields.Subdivision, SortFields.Position };
    }

    public static KeyValuePair<string, string>[] GetApprovalRequestsSortFields()
    {
        return new[] { SortFields.ApproverId, SortFields.Status };
    }
}
