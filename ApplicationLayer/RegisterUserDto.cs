namespace ApplicationLayer
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class  LoginUserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}