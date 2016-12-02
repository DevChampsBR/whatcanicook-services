using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using WhatCanICook.Api.Dto;
using WhatCanICook.Api.Domain.Model;
using WhatCanICook.Api.Domain.Service;

namespace WhatCanICook.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {

        /// <summary>
        /// Method used to acquire Recipes that can be made according to available ingredients provided.
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        /// <returns>Lorem ipsum</returns>
        [HttpGet]
        public async Task<DtoWhatCanICookWithResponse> WhatCanICookWith([FromUri]DtoWhatCanICookWithRequest dto)
        {
            var response = new DtoWhatCanICookWithResponse();
            if (dto == null)
            {
                Response.StatusCode = 400;
                return response;
            }

            var service = new RecipeService(); // todo: Ioc/DI/Abstract Factory
            var whatCanICookWithResponse = await service.WhatCanICookWith(new Domain.Service.Contract.Dto.DtoWhatCanICookWithRequest()
            {
                Ingredients = dto.Ingredients
            });

            if (!whatCanICookWithResponse.Success)
            {
                response.InvalidIngredients = whatCanICookWithResponse.InvalidIngredients;
                response.AddErrors(whatCanICookWithResponse.Errors);
                Response.StatusCode = 400; // todo: check for specific error to specify specific httpcode
            }
            else
            {
                response.Recipes = whatCanICookWithResponse.Recipes;
            }

            return response;
        }
    }
}
