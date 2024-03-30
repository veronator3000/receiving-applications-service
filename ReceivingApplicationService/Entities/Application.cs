namespace Entities;

public class Application
{
    public Guid ApplicationId { get; set; }
    public Guid AuthorId { get; set; }
    public ActivityType ActivityType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Outline { get; set; }
    public DateTime? OnViewing { get; set; } 
    public DateTime? IsDraft { get; set; }  
    public DateTime? IsApproved { get; set; }  
}