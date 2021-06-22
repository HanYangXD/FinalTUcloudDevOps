using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly SignInManager<AppUser> _signInManager;
        [TestMethod]
        public async void TestMethod1()
        {
            string Email = "Admin@gmail.com";
            string Password = "Admin123$";
            bool RememberMe = false;


            var result = await _signInManager.PasswordSignInAsync(Email, Password, RememberMe, lockoutOnFailure: false);
            var expected = result.Succeeded;


        }
    }
}
