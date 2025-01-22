namespace SchoolProject.Service.Abstract;

public interface IAppUserService
{
    public Task<bool> IsEmailExistExcludeSelf(string id, string email);
}