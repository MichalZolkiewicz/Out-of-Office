using Out_of_Office.Filters.Helpers;

namespace Out_of_Office.Filters;

public class LeaveRequestSortingFilter
{
    public string SortField { get; set; }
    public bool Ascending { get; set; } = true;

    public LeaveRequestSortingFilter()
    {
        SortField = "Id";
    }

    public LeaveRequestSortingFilter(string sortField, bool ascending)
    {
        var sortFields = SortingHelper.GetLeaveRequestsSortFields();

        sortField = sortField.ToLower();

        if (sortFields.Select(x => x.Key).Contains(sortField.ToLower()))
            sortField = sortFields.Where(x => x.Key == sortField).Select(x => x.Value).SingleOrDefault();
        else
            sortField = "Id";

        SortField = sortField;
        Ascending = ascending;
    }
}
