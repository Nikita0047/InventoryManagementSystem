using InventoryModels.DTOs;
using InventoryService.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUsers _user;

    public UsersController(IUsers user)
    {
        _user = user;
    }

    // GET api/users
    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
    {
        var users = await _user.GetAllUsersAsync(); // ← just call service
        return Ok(users);
    }

    // GET api/users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUserById(int id)
    {
        var user = await _user.GetUserByIdAsync(id); // ← just call service
        if (user == null) return NotFound($"User {id} not found");
        return Ok(user);
    }

    // PUT api/users/5/role
    [HttpPut("{id}/role")]
    public async Task<IActionResult> UpdateUserRole(int id, [FromBody] int roleId)
    {
        await _user.UpdateUserRoleAsync(id, roleId); // ← just call service
        return Ok("Role updated");
    }

    // DELETE api/users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _user.DeleteUserAsync(id); // ← just call service
        return Ok("User deleted");
    }
}