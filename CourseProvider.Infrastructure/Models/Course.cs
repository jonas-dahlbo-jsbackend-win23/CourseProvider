namespace CourseProvider.Infrastructure.Models;

public class Course
{
    public string? Id { get; set; } 
    public string? ImageUri { get; set; }
    public string? ImageHeaderUri { get; set; }
    public bool IsBestseller { get; set; }
    public bool IsDigital { get; set; }
    public string[]? Categories { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public string? Rating { get; set; }
    public string? Reviews { get; set; }
    public string? LikesPercent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public virtual List<Author>? Authors { get; set; }
    public virtual Prices? Prices { get; set; }
    public virtual Content? Content { get; set; }
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

public class Content
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public virtual List<ProgramDetailsItem>? ProgramDetails { get; set; }
}

public class ProgramDetailsItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}