using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using WhatCanICook.Api.Dto;

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

            return response;
        }
    }
}
