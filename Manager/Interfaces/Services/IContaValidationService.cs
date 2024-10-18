namespace AL.Manager.Interfaces.Services;

public interface IContaValidationService
{
    Task<bool> IsEmailUniqueAsync(string email);
}
