using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatCanICook.Api.Core
{

    public class DtoResponseBase
    {
        public DtoResponseBase()
        {
            Errors = new List<ErrorDetail>();
        }

        public void AddError(string message)
        {
            Errors.Add(new ErrorDetail() { Message = message });
        }

        public void AddError(ErrorDetail error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            Errors.Add(error);
        }

        public void AddErrors(List<ErrorDetail> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }

            Errors.AddRange(errors);
        }

        public List<ErrorDetail> Errors { get; protected set; }

        public bool Success { get { return !Errors.Any(); } }
    }

    public class ErrorDetail
    {
        public string Message { get; set; }
    }
}
