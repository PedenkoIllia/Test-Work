using LogicLayer.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WEB.Filters
{
    public class AddCookieWithIdAttribute : Attribute, IActionFilter
    {
        int Id { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.ModelState.IsValid)
                context.HttpContext.Response.Cookies.Append("ChangRecordId", Id.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                if(context.ActionArguments.ContainsKey("record"))
                    Id = ((RecordDTO) context.ActionArguments["record"]).Id;
            }
        }
    }
}
