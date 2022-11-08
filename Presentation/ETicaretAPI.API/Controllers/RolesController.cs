using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;
        public RolesController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                IdentityResult result = await _roleManager.CreateAsync(new AppRole { Id = Guid.NewGuid().ToString(), Name = roleName });
                if (result.Succeeded)
                {
                    return Ok($"Role {roleName} added successfully");
                }

                throw new Exception($"Issue adding the new {roleName} role");
            }
            throw new Exception("Role already exist");
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> RoleAssign(string id, string roleName)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await _userManager.AddToRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    return Ok($"User {user.UserName} added to the {roleName} role");
                }
                throw new Exception($"Error: Unable to add user {user.Email} to the {roleName} role");
            }
            throw new Exception("Unable to find user");
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserRoles(string id)
        {
            var user = await _userManager.FindByEmailAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveUserFromRole(string id, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(id);

            if (user != null)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);

                if (result.Succeeded)
                {
                    return Ok($"User {user.Email} removed from the {roleName} role");
                }
                else
                {
                    throw new Exception($"Error: Unable to removed user {user.UserName} from the {roleName} role");
                }
            }
            throw new Exception("Unable to find user" );
        }
    }
}
