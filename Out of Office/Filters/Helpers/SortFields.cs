namespace Out_of_Office.Filters.Helpers;

public class SortFields
{
    public static KeyValuePair<string, string> FullName { get; } = new KeyValuePair<string, string>("fullname", "FullName");
    public static KeyValuePair<string, string> Subdivision { get; } = new KeyValuePair<string, string>("subdivision", "Subdivision");
    public static KeyValuePair<string, string> Position { get; } = new KeyValuePair<string, string>("position", "Position");
    public static KeyValuePair<string, string> ApproverId { get; } = new KeyValuePair<string, string>("approverid", "ApproverId");
    public static KeyValuePair<string, string> Status { get; } = new KeyValuePair<string, string>("status", "Status");
    public static KeyValuePair<string, string> EmployeeId { get; } = new KeyValuePair<string, string>("employeeid", "EmployeeId");
    public static KeyValuePair<string, string> ProjectType { get; } = new KeyValuePair<string, string>("projecttype", "ProjectType");
    public static KeyValuePair<string, string> ProjectManagerId { get; } = new KeyValuePair<string, string>("projectmanagerid", "ProjectManagerId");
}
