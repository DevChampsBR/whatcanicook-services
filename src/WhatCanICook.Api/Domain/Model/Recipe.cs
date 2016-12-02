using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatCanICook.Api.Domain.Model
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new List<RecipeIngredient>();
            Directions = new List<string>();
        }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }

        public List<string> Directions { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
    }
}
