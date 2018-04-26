﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace TodoApi.Filters
{
    public class ActionFilter : Attribute, IActionFilter, IResultFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // why 2 times??????????

            // do something after the action executes
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (IsReusable)
            {
                context.HttpContext.Response.Headers.Add(
                    "Internal", new string[] { "Header Added" });
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public bool IsReusable => false;
    }
}