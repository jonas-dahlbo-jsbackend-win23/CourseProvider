using CourseProvider.Infrastructure.Data.Contexts;
using CourseProvider.Infrastructure.Factories;
using CourseProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Infrastructure.Services;

public interface ICourseService
{
    Task<Course> CreateCourseAsync(CourseCreateRequest request);
    Task<Course> GetOneCourseAsync(string id);
    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<Course> UpdateCourseAsync(CourseUpdateRequest request);
    Task<bool> RemoveCourseAsync(string id);

}

public class CourseService(IDbContextFactory<DataContext> contextFactory) : ICourseService
{
    private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

    public async Task<Course> CreateCourseAsync(CourseCreateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();

        var courseEntity = CourseFactory.Create(request);
        context.Courses.Add(courseEntity);
        await context.SaveChangesAsync();

        return CourseFactory.Create(courseEntity);
    }

    public async Task<Course> GetOneCourseAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();

        var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);

        if (courseEntity == null) 
        {
            return null!;
        }

        return CourseFactory.Create(courseEntity);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        await using var context = _contextFactory.CreateDbContext();

        var courseEntities = await context.Courses.ToListAsync();

        return courseEntities.Select(CourseFactory.Create);
    }


    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();
        var existingCoruse = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (existingCoruse != null)
        {
            var updatedCourseEntity = CourseFactory.Create(request);
            updatedCourseEntity.Id = existingCoruse.Id;
            context.Entry(existingCoruse).CurrentValues.SetValues(updatedCourseEntity);

            await context.SaveChangesAsync();
            return CourseFactory.Create(existingCoruse);
        }

        return null!;
    }

    public async Task<bool> RemoveCourseAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();

        var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if (courseEntity != null)
        {
            context.Courses.Remove(courseEntity);
            await context.SaveChangesAsync();
            return true;
        }

        return false;
    }


}
