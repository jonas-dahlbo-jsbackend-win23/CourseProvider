using CourseProvider.Infrastructure.Models;
using CourseProvider.Infrastructure.Services;

namespace CourseProvider.Infrastructure.GraphQL;

public class Query(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("getOneCourse")]
    public async Task<Course> GetOneCourseAsync(string id)
    {
        return await _courseService.GetOneCourseAsync(id);
    }

    [GraphQLName("getAllCourses")] 
    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _courseService.GetCoursesAsync();
    }
}
