﻿namespace Out_of_Office.Filters.Helpers;

public class SortFields
{
    public static KeyValuePair<string, string> FullName { get; } = new KeyValuePair<string, string>("fullname", "FullName");
    public static KeyValuePair<string, string> Subdivision { get; } = new KeyValuePair<string, string>("subdivision", "Subdivision");
    public static KeyValuePair<string, string> Position { get; } = new KeyValuePair<string, string>("position", "Position");
}