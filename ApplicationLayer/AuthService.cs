namespace ApplicationLayer
{
    public class AuthorizationService
    {
        // REGISTER METHOD
        public JWTDto RegisterUser(RegisterUserDto registerUserDto)
        {
            // Make sure we have correct username and password, then create a JWT token and return it
            bool usernameIsValid = registerUserDto.UserName == "correctUsername";
            bool passwordIsValid = registerUserDto.Password == "correctPassword";

            if (!usernameIsValid)
            {
                return new JWTDto { ErrorMessage = "Username is wrong" };
            }

            if (!passwordIsValid)
            {
                return new JWTDto { ErrorMessage = "Password is wrong", Name = registerUserDto.UserName };
            }

            if (usernameIsValid && passwordIsValid)
            {
                JWTDto tokenToReturn = new JWTDto();
                tokenToReturn.Token = "JWTToken";
                tokenToReturn.Name = registerUserDto.UserName;
                return tokenToReturn;
            }

            return new JWTDto { ErrorMessage = "An unknown error occurred" };

        }

        public JWTDto LoginUser(LoginUserDto loginUserDto)
        {
            bool usernameIsValid = loginUserDto.UserName == "correctUsername";
            if (!usernameIsValid) {
                return new JWTDto { ErrorMessage = "Invalid username" };
            }
            bool passwordIsValid = loginUserDto.Password == "correctPassword";
            if(!passwordIsValid)
            {
                return new JWTDto { ErrorMessage = "Invalid password, would you like to reset password?", Name = loginUserDto.UserName };
            }

            // IS BOTH ARE VALID THEN WE CREATE AND RETURN THE TOKEN
            if (usernameIsValid && passwordIsValid)
            {
                JWTDto tokenToReturn = new JWTDto();
                tokenToReturn.Token = "ValidJWTToken";
                tokenToReturn.Name = loginUserDto.UserName;
                return tokenToReturn;
            }

            return null;
        }
    }
}
