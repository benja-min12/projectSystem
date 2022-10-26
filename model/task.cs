using System;
using System.Collections.Generic;
public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int progress { get; set; }
    public enum status { Active, Inactive , terminated}
    public string Status { get; set; }
    public int ProjectId { get; set; }
    public Project project { get; set; }

    public IList<materialConsume> materialConsumes { get; set; }
}           