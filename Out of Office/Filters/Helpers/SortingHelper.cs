namespace Out_of_Office.Filters.Helpers;

public class SortingHelper
{
    public static KeyValuePair<string, string>[] GetSortFields()
    {
        return new[] { SortFields.FullName, SortFields.Subdivision, SortFields.Position };
    }
}
