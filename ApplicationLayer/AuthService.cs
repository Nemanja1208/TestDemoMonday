namespace ApplicationLayer
{
    public class AuthorizationService
    {

        // REGISTER METHOD
        public JWTDto RegisterUser()
        {
            JWTDto tokenToReturn = new JWTDto();
            tokenToReturn.Token = "JWTToken";
            tokenToReturn.Name = "John Doe";
            return tokenToReturn;
        }


    }
}
