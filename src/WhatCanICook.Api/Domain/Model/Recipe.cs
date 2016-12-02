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

        }

        public string Name { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
    }
}
