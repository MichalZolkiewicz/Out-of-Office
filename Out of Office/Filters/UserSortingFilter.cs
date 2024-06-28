using Out_of_Office.Filters.Helpers;

namespace Out_of_Office.Filters;

public class UserSortingFilter
{
    public string SortField { get; set; }
    public bool Ascending { get; set; } = true;

    public UserSortingFilter()
    {
        SortField = "Id";
    }

    public UserSortingFilter(string sortField, bool ascending)
    {
        var sortFields = SortingHelper.GetUsersSortFields();

        sortField = sortField.ToLower();

        if (sortFields.Select(x => x.Key).Contains(sortField.ToLower()))
            sortField = sortFields.Where(x => x.Key == sortField).Select(x => x.Value).SingleOrDefault();
        else
            sortField = "Id";

        SortField = sortField;
        Ascending = ascending;
    }
}
