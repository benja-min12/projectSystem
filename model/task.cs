using System;
using System.Collections.Generic;
public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string progress { get; set; }
    public enum Status { Active, Inactive }

    public int ProjectId { get; set; }
    public Project project { get; set; }

    public IList<materialConsume> materialConsumes { get; set; }
}