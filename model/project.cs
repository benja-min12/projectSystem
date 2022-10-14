using System.Collections.Generic;
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public enum Status { Active, Inactive }
    public IList<Task> tasks { get; set; }
}