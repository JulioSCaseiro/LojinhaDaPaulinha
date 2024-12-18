namespace LojinhaDaPaulinha.Exceptions.UserControllerExceptions
{
    public class UserUpdateException : UsersControllerException
    {
        public UserUpdateException() : base("Could not update User.") { }
    }
}
