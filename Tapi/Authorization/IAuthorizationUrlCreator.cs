namespace Tapi.Authorization
{
    public interface IAuthorizationUrlCreator
    {
        string Create(ApplicationKey applicationKey, string applicationName, AuthorizationScope scope, AuthorizationExpiration expiration);
    }
}