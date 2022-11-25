namespace Anilibria.NET.Client
{
    /// <summary>
    /// Exception thrown on invalid login in anilibria.tv
    /// </summary>
    public class AnilibriaInvalidUserException : Exception
    {
        /// <summary>
        /// Login of user
        /// </summary>
        public string Login { get; private set; }


        /// <summary>
        /// Password of user
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Creation of exception
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        internal AnilibriaInvalidUserException(string login, string password)
        {
            Login = login;
            Password = password;
        }


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns>Exception message</returns>
        public override string ToString() => $"Invalid user exception! Please, try another login or password.";
    }
}
