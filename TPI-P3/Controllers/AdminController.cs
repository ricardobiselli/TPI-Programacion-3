using Application.Interfaces;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TPI_P3.Controllers;


namespace Api.Controllers
{
    [Route("api/Admins")]
    [ApiController]
    [Authorize(Roles = "superadmin")]
    public class AdminController : RoleCheckController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
    }
        
}
