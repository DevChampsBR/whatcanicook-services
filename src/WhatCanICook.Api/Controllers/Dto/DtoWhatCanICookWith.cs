using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatCanICook.Api.Core;
using WhatCanICook.Api.Domain.Model;

namespace WhatCanICook.Api.Dto
{
    public class DtoWhatCanICookWithRequest
    {
        public DtoWhatCanICookWithRequest()
        {
            Ingredients = new List<string>();
        }
        /// <summary>
        /// List of available ingredients.
        /// </summary>
        public List<string> Ingredients { get; set; }
    }

    public class DtoWhatCanICookWithResponse : DtoResponseBase
    {
        public DtoWhatCanICookWithResponse()
        {
            Recipes = new List<Recipe>();
            InvalidIngredients = new List<string>();
        }

        /// <summary>
        /// Recipes according to provided ingredients 
        /// </summary>
        public List<Recipe> Recipes { get; set; }

        /// <summary>
        /// Ingredients not found on database
        /// </summary>
        public List<string> InvalidIngredients { get; set; }
    }
}
