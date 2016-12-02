using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatCanICook.Api.Domain.Model;
using WhatCanICook.Api.Domain.Service.Contract.Dto;
using WhatCanICook.Api.Domain.Service.Contract.Interface;

namespace WhatCanICook.Api.Domain.Service
{
    public class RecipeService : IRecipeService
    {
        public async Task<DtoWhatCanICookWithResponse> WhatCanICookWith(DtoWhatCanICookWithRequest dto)
        {
            var response = new DtoWhatCanICookWithResponse();

            #region Validation
            if (dto == null)
            {
                response.AddError($"Property {nameof(dto)} is required.");
                return response;
            }

            if (dto.Ingredients == null || !dto.Ingredients.Any())
            {
                response.AddError($"Property {nameof(dto.Ingredients)} is required.");
                return response;
            }
            #endregion

            #region Mock
            var units = new List<UnitOfMeasurement>() {
                new UnitOfMeasurement() {
                    Name = "Copo"
                },
                new UnitOfMeasurement() {
                    Name = "Grama"
                },
                new UnitOfMeasurement() {
                    Name = "Colher de chá"
                }
            };

            var ingredients = new List<Ingredient>() {
                new Ingredient() { Name = "água" },
                new Ingredient() { Name = "Sal" },
                new Ingredient() { Name = "Farinha" },
                new Ingredient() { Name = "carne" },
                new Ingredient() { Name = "creme de leite" },
            };


            var recipes = new List<Recipe>
            {

                new Recipe()
                {
                    Name = "Bolacha de água e sal",
                    Image = "http://crisarcangeli.com/users/jayknights/desktop/cris_arcangeli/wp-content/uploads/2014/01/biscoitoaguasal.jpg",
                    Video = "https://www.youtube.com/watch?v=5lbt9kDpDR4",
                    Ingredients = new List<RecipeIngredient>() {
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name.Equals("água", StringComparison.CurrentCultureIgnoreCase)),
                            Quantity = 3,
                            Unit = units.FirstOrDefault(x=> x.Name.Equals("copo", StringComparison.CurrentCultureIgnoreCase))
                        },
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name.Equals("Sal", StringComparison.CurrentCultureIgnoreCase)),
                            Quantity = 1,
                            Unit = units.FirstOrDefault(x=> x.Name.Equals("grama", StringComparison.CurrentCultureIgnoreCase))
                        }
                    },
                    Directions = new List<string>()
                    {
                        "Coloque em um recipiente o Sal e a água",
                        "Misture-os",
                        "Leve ao forno por 1h",
                        "Sirva ;)",
                    }
                },
                new Recipe()
                {
                    Name = "Strogonoff",
                    Image = "https://hatandapron.files.wordpress.com/2013/08/dsc_1303.jpg",
                    Video = "https://www.youtube.com/watch?v=4wCQPFCvcq8",
                    Ingredients = new List<RecipeIngredient>() {
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name.Equals("carne", StringComparison.CurrentCultureIgnoreCase)),
                            Quantity = 1000,
                            Unit = units.FirstOrDefault(x=> x.Name.Equals("grama", StringComparison.CurrentCultureIgnoreCase))
                        },
                        new RecipeIngredient() {
                            Ingredient = ingredients.FirstOrDefault(x=> x.Name.Equals("creme de leite", StringComparison.CurrentCultureIgnoreCase)),
                            Quantity = 1,
                            Unit = units.FirstOrDefault(x=> x.Name.Equals("copo", StringComparison.CurrentCultureIgnoreCase))
                        }
                    },
                    Directions = new List<string>()
                    {
                        "Corte a carne em fatias",
                        "Misture com o creme de leite",
                        "Sirva ;)",
                    }
                }

            };
            #endregion

            response.InvalidIngredients = dto.Ingredients
                .Where(ingredient => !ingredients.Exists(y => y.Name.Equals(ingredient, StringComparison.CurrentCultureIgnoreCase)))
                .ToList();

            if (response.InvalidIngredients.Any())
            {
                response.AddError("Some ingredients were not found.");
                return response;
            }

            // query para parcial match
            var query = recipes.AsQueryable();
            query = query.Where(recipe =>
                        recipe.Ingredients.Exists(y =>
                            dto.Ingredients.Exists(ingredient => ingredient.Equals(y.Ingredient.Name, StringComparison.CurrentCultureIgnoreCase))));

            response.Recipes = query.ToList();

            return response;
        }
    }
}
