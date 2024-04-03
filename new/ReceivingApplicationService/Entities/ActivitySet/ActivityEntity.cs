using System.ComponentModel.DataAnnotations;

namespace Entities.ActivitySet;

public class ActivityEntity
{
    [Key]
    public int Id { get; set; }
    public ActivityType Type { get; set; }
    public string Description { get; set; }
}