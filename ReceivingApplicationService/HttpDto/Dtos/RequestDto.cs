using Entities;
namespace HttpDto.Dtos;

public class RequestDto
{
    public Guid Author { get; set; }
    public ActivityType Activity { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Outline { get; set; }
}