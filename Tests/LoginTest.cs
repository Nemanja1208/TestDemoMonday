using ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class LoginTest
    {

        [Test]
        public void LoginMethod_LoginUser_Successfull_ReturnsJWT()
        {
            // ARRANGE
            AuthorizationService authService = new AuthorizationService();
            // THIS IS THE CORRECT USERNAME AND PASSWORD DTO
            LoginUserDto loginUserDto = new LoginUserDto
            {
                UserName = "correctUsername",
                Password = "correctPassword"
            };
            // ACT
            var thisIsTheActualResutThatTheRealServiceReturns = authService.LoginUser(loginUserDto);
            // ASSERT - WHAT YOU EXPECT TO BE THE RESULT OF THE A
            Assert.That(thisIsTheActualResutThatTheRealServiceReturns.Token, Is.Not.Null);
            Assert.That(thisIsTheActualResutThatTheRealServiceReturns.Name, Is.EqualTo(loginUserDto.UserName));
        }

        [Test]
        public void LoginMethod_LoginUser_Fail_UserEnters_WrongPassword()
        {
            // ARRANGE
            AuthorizationService authService = new AuthorizationService();

            LoginUserDto loginUserDto = new LoginUserDto
            {
                UserName = "correctUsername",
                Password = "wrongPassword"
            };

            // ACT
            var result = authService.LoginUser(loginUserDto);

            // ASSERT - scenarion som vi förväntar oss att ske i att vi har angivit fel password
            Assert.That(result.ErrorMessage, Is.EqualTo("Invalid password, would you like to reset password?"));
            Assert.That(result.Name, Is.EqualTo(loginUserDto.UserName));
        }
        [Test]
        public void LoginMethod_LoginUser_Fail_UserEnters_WrongUsername()
        {
            // ARRANGE
            AuthorizationService authService = new AuthorizationService();

            LoginUserDto loginUserDto = new LoginUserDto
            {
                UserName = "wrongUsername",
                Password = "correctPassword"
            };

            // ACT
            var result = authService.LoginUser(loginUserDto);

            // ASSERT - scenarion som vi förväntar oss att ske i att vi har angivit fel password
            Assert.That(result.ErrorMessage, Is.EqualTo("Invalid username"));
        }
    }
}
