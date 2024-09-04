namespace CourseProvider.Infrastructure.Models;

public class CourseCreateRequest
{
    public string? Image { get; set; }
    public bool IsBestseller { get; set; }
    public string? Title { get; set; }
    public string? LikesPercent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public virtual List<AuthorCreateRequest>? Authors { get; set; }
    public virtual PricesCreateRequest? Prices { get; set; }
}

public class AuthorCreateRequest
{
    public string? Name { get; set; }
}

public class PricesCreateRequest
{
    public string? Price { get; set; }
    public string? Discount { get; set; }
}
