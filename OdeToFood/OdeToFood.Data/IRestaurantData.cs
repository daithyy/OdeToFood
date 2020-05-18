﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = Restaurant.CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = Restaurant.CuisineType.Indian },
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = Restaurant.CuisineType.Mexican }
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name))
                              .OrderBy(r => r.Name)
                              .Select(r => r);
        }
    }
}
