﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatCanICook.Api.Domain.Service.Contract.Dto;

namespace WhatCanICook.Api.Domain.Service.Contract.Interface
{
    public interface IRecipeService
    {
        Task<DtoWhatCanICookWithResponse> WhatCanICookWith(DtoWhatCanICookWithRequest dto);
    }
}
