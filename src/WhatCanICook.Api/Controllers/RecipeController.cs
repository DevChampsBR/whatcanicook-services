using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using WhatCanICook.Api.Dto;
using WhatCanICook.Api.Domain.Model;

namespace WhatCanICook.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {


        /// <summary>
        /// Lorem Lorem ipsum Lorem ipsum Lorem ipsum ipsum
        /// </summary>
        /// <param name="dto">Dto Lorem ipsum</param>
        /// <returns>Lorem ipsum</returns>
        [HttpGet]
        public async Task<DtoWhatCanICookWithResponse> WhatCanICookWith([FromUri]DtoWhatCanICookWithRequest dto)
        {
            var response = new DtoWhatCanICookWithResponse();

            #region Mock
            var units = new List<UnitOfMeasurement>() {
                new UnitOfMeasurement() {
                    Name = "X"
                },
                new UnitOfMeasurement() {
                    Name = "Y"
                },
                new UnitOfMeasurement() {
                    Name = "Z"
                }
            };

            var ingredients = new List<Ingredient>() {
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "B" },
                new Ingredient() { Name = "C" },
                new Ingredient() { Name = "D" },
                new Ingredient() { Name = "E" },
            };


            var recipes = new List<Recipe>
            {

                new Recipe()
                {
                    Name = "ABC",
                    Ingredients = new List<RecipeIngredient>() {
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name == "A"),
                            Quantity = 3,
                            Unit = units.FirstOrDefault(x=> x.Name == "X")
                        },
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name == "B"),
                            Quantity = 6,
                            Unit = units.FirstOrDefault(x=> x.Name == "X")
                        },
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name == "C"),
                            Quantity = 1,
                            Unit = units.FirstOrDefault(x=> x.Name == "X")
                        }
                    }
                },
                new Recipe()
                {
                    Name = "AC",
                    Ingredients = new List<RecipeIngredient>() {
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name == "A"),
                            Quantity = 3,
                            Unit = units.FirstOrDefault(x=> x.Name == "Y")
                        },
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name == "C"),
                            Quantity = 1,
                            Unit = units.FirstOrDefault(x=> x.Name == "Y")
                        }
                    }
                },
                new Recipe()
                {
                    Name = "CD",
                    Ingredients = new List<RecipeIngredient>() {
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name == "C"),
                            Quantity = 3,
                            Unit = units.FirstOrDefault(x=> x.Name == "Y")
                        },
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name == "D"),
                            Quantity = 1,
                            Unit = units.FirstOrDefault(x=> x.Name == "Y")
                        }
                    }
                }
            };
            #endregion

            response.InvalidIngredients = dto.Ingredients
                .Where(ingredient => !ingredients.Exists(y=> y.Name.Equals(ingredient)))
                .ToList();

            if (response.InvalidIngredients.Any())
            {
                Response.StatusCode = 400;
                return response;
            }

            // query para parcial match
            var query = recipes.AsQueryable();
            query = query.Where(recipe =>
                recipe.Ingredients.Exists(y =>
                    dto.Ingredients.Exists(ingredient => ingredient.Equals(y.Ingredient.Name))));

            response.Recipes = query.ToList();

            return response;
        }
    }
}
