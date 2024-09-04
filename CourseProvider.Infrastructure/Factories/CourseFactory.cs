using Azure.Core;
using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CourseProvider.Infrastructure.Factories;

public static class CourseFactory
{
    public static CourseEntity Create(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            Image = request.Image,
            IsBestseller = request.IsBestseller,
            Title = request.Title,
            LikesPercent = request.LikesPercent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                Price = request.Prices.Price,
                Discount = request.Prices.Discount
            }
        };
    }

    public static CourseEntity Create(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            Image = request.Image,
            IsBestseller = request.IsBestseller,
            Title = request.Title,
            LikesPercent = request.LikesPercent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                Price = request.Prices.Price,
                Discount = request.Prices.Discount
            }
        };
    }

    public static Course Create(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            Image = entity.Image,
            IsBestseller = entity.IsBestseller,
            Title = entity.Title,
            LikesPercent = entity.LikesPercent,
            Likes = entity.Likes,
            Hours = entity.Hours,
            Authors = entity.Authors?.Select(a => new Author
            {
                Name = a.Name
            }).ToList(),
            Prices = entity.Prices == null ? null : new Prices
            {
                Price = entity.Prices.Price,
                Discount = entity.Prices.Discount
            }
        };
    }
}
