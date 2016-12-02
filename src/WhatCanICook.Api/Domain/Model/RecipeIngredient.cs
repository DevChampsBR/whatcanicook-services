using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatCanICook.Api.Domain.Model
{
    public class RecipeIngredient
    {
        public Ingredient Ingredient { get; set; }
        public UnitOfMeasurement Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
