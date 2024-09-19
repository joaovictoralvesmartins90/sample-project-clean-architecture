﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper, IRestaurantsRepository restaurantRepository, UserManager<User> userManager) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new restaurant...");
        logger.LogInformation("Creating restaurant: {@Restaurant}...", request);

        var user = await userManager.FindByIdAsync(request.OwnerId);

        if (user == null)
        {
            throw new NotFoundException($"User with id {request.OwnerId} not found.");
        }

        Restaurant restaurant = mapper.Map<Restaurant>(request);
        restaurant.OwnerId = request.OwnerId;
        return await restaurantRepository.Create(restaurant);
    }
}
