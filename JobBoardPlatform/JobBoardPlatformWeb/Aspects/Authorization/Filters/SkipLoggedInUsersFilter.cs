﻿using JobBoardPlatform.BLL.Services.Authorization.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JobBoardPlatform.PL.Filters
{
    public class SkipLoggedInUsersFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (UserSessionUtils.IsLoggedIn(context.HttpContext.User))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}