namespace CourseProvider.Infrastructure.Models;

public class CourseUpdateRequest
{
    public string Id { get; set; } = null!;
    public string? Image { get; set; }
    public bool IsBestseller { get; set; }
    public string? Title { get; set; }
    public string? LikesPercent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public virtual List<AuthorUpdateRequest>? Authors { get; set; }
    public virtual PricesUpdateRequest? Prices { get; set; }
}

public class AuthorUpdateRequest
{
    public string? Name { get; set; }
}

public class PricesUpdateRequest
{
    public string? Price { get; set; }
    public string? Discount { get; set; }
}