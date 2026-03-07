using InventoryModels.DTOs;


namespace InventoryService.Services.IServices
{
    public interface IAuth
    {
        Task<AuthResponse> SignUpAsync(SignUp request);
        Task<AuthResponse> SignInAsync(SignIn request);
    }
}
