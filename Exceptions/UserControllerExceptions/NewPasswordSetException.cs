namespace LojinhaDaPaulinha.Exceptions.UserControllerExceptions
{
    public class NewPasswordSetException : UsersControllerException
    {
        public NewPasswordSetException() : base("Could not set User's password.") { }
    }
}
