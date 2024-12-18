namespace LojinhaDaPaulinha.Exceptions.UserControllerExceptions
{
    public class UserRoleSetException : UsersControllerException
    {
        public UserRoleSetException() : base("Could not set User's Role.") { }
    }
}
