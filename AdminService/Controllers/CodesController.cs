﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

using AdminService.Misc;
using AdminService.Repos.Identity;
using AdminService.ViewModels.Identity;
using AdminService.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace AdminService.Controllers
{
    [Route("api/codes")]
    [Authorize]
    [ServiceFilter(typeof(TokenAuthorizationActionFilter))]
    public partial class CodesController : Controller
    {      
        private ICodesRepo _codesRepo;         

        public CodesController(ICodesRepo codesRepo)
        {           
            _codesRepo = codesRepo;                     
        }

        [HttpPost]       
        public IActionResult List()
        {
            ApiResponse response = new ApiResponse();

            try 
            {
                IEnumerable<CodesListWithUser> list = _codesRepo.List();

                if (list != null)
                {
                    response.Success = true; 
                    response.MessageCode = Enums.ApiMessageCodes.Success;
                    response.Message = "Success";
                    response.Count = list.Count();
                    response.Value = list;                    
                }
                else
                {
                    response.MessageCode = Enums.ApiMessageCodes.NoResults;
                    response.Message = "No results found";
                }
            }
            catch (Exception ex)
            {
                response.MessageCode = Enums.ApiMessageCodes.ExceptionThrown;
                response.Message = "Error getting list:" + ex.Message;
            }

            return new StandardResponseObjectResult(response, StatusCodes.Status200OK);
        }
    }
}
