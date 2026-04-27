using ApplicationLayer;

namespace Tests
{
    public class AuthTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void RegisterMethod_RegisteringUser_Successfull_ReturnsJWT()
        {
            // ARRANGE
            AuthorizationService authService = new AuthorizationService();
            // THIS IS THE CORRECT USERNAME AND PASSWORD DTO
            RegisterUserDto registerUserDto = new RegisterUserDto
            {
                UserName = "correctUsername",
                Password = "correctPassword"
            };

            // ACT
            var thisIsTheActualResutThatTheRealServiceReturns = authService.RegisterUser(registerUserDto);

            // ASSERT - WHAT YOU EXPECT TO BE THE RESULT OF THE A
            Assert.That(thisIsTheActualResutThatTheRealServiceReturns.Token, Is.Not.Null);
            Assert.That(thisIsTheActualResutThatTheRealServiceReturns.Name, Is.EqualTo(registerUserDto.UserName));
        }

        [Test]
        public void RegisterMethod_RegisteringUser_Failed_WrongUsername()
        {
            // ARRANGE
            AuthorizationService authService = new AuthorizationService();

            // THIS IS THE CORRECT USERNAME AND PASSWORD DTO
            RegisterUserDto registerUserDto = new RegisterUserDto
            {
                UserName = "wrongUsername",
                Password = "correctPassword"
            };

            // ACT
            var thisIsTheActualResutThatTheRealServiceReturns = authService.RegisterUser(registerUserDto);
            // ASSERT
            Assert.That(thisIsTheActualResutThatTheRealServiceReturns.Token, Is.Null);
            Assert.That(thisIsTheActualResutThatTheRealServiceReturns.ErrorMessage, Is.EqualTo("Username is wrong"));
        }

        [Test]
        public void RegisterMethod_RegisteringUser_Failed_WrongPassword()
        {
            // ARRANGE
            AuthorizationService authService = new AuthorizationService();
            // THIS IS THE CORRECT USERNAME AND PASSWORD DTO
            RegisterUserDto registerUserDto = new RegisterUserDto
            {
                UserName = "correctUsername",
                Password = "wrongPassword"
            };

            // ACT

            var thisIsTheActualResutThatTheRealServiceReturns = authService.RegisterUser(registerUserDto);
            
            // ASSERT
            Assert.That(thisIsTheActualResutThatTheRealServiceReturns.Token, Is.Null);
            Assert.That(thisIsTheActualResutThatTheRealServiceReturns.ErrorMessage, Is.EqualTo("Password is wrong"));

        }
    }
}
