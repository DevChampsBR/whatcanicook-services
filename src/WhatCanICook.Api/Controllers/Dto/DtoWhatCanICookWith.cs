using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatCanICook.Api.Domain.Model;

namespace WhatCanICook.Api.Dto
{
    public class DtoWhatCanICookWithRequest
    {
        public DtoWhatCanICookWithRequest()
        {
            Ingredients = new List<string>();
        }

        public List<string> Ingredients { get; set; }
    }

    public class DtoWhatCanICookWithResponse
    {
        public DtoWhatCanICookWithResponse()
        {
            Recipes = new List<Recipe>();
            InvalidIngredients = new List<string>();
        }

        public List<Recipe> Recipes { get; set; }

        public List<string> InvalidIngredients { get; set; }
    }
}
