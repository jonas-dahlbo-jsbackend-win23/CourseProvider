using System.ComponentModel.DataAnnotations;

namespace CourseProvider.Infrastructure.Data.Entities;

public class CourseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Image { get; set; }
    public bool IsBestseller { get; set; }
    public string? Title { get; set; }
    public string? LikesPercent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public virtual List<AuthorEntity>? Authors { get; set; }
    public virtual PricesEntity? Prices { get; set; }
}
