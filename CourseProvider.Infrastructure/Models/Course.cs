namespace CourseProvider.Infrastructure.Models;

public class Course
{
    public string? Id { get; set; } 
    public string? Image { get; set; }
    public bool IsBestseller { get; set; }
    public string? Title { get; set; }
    public string? LikesPercent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public virtual List<Author>? Authors { get; set; }
    public virtual Prices? Prices { get; set; }
}

public class Author
{
    public string? Name { get; set; }
}

public class Prices
{
    public string? Price { get; set; }
    public string? Discount { get; set; }
}