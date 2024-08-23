﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger logger, IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating restaurant with id {request.Id}...");
        var restaurant = mapper.Map<Restaurant>(request);
        await restaurantRepository.UpdateRestaurant(restaurant);
        return true;
    }
}
