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

            // ACT
            var result = authService.RegisterUser();


            // ASSERT
            Assert.That(result.Name, Is.EqualTo("John Doe"));
            Assert.That(result.Token, Is.EqualTo("JWTToken"));
        }

    }
}
