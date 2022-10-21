using System.Collections.Generic;
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public enum status { Active, Inactive , terminated} 
    public status Status { get; set; }
    public IList<Task> tasks { get; set; }
}