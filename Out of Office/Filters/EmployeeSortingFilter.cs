using Out_of_Office.Filters.Helpers;

namespace Out_of_Office.Filters;

public class EmployeeSortingFilter
{
    public string SortField { get; set; }
    public bool Ascending { get; set; } = true;

    public EmployeeSortingFilter()
    {
        SortField = "Id";
    }

    public EmployeeSortingFilter(string sortField, bool ascending)
    {
        var sortFields = SortingHelper.GetEmployeeSortFields();

        sortField = sortField.ToLower();

        if (sortFields.Select(x => x.Key).Contains(sortField.ToLower()))
            sortField = sortFields.Where(x => x.Key == sortField).Select(x => x.Value).SingleOrDefault();
        else
            sortField = "Id";

        SortField = sortField;
        Ascending = ascending;
    }
}
