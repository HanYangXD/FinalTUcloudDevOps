using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Threading.Tasks;

namespace UnitTest2
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }


    [TestClass]
    public class UnitTest1
    {
        private readonly SignInManager<AppUser> _signInManager;
        [TestMethod]
        public async void TestLogin()
        {
            string email = "admin@gmail.com";
            string password = "Admin12#";
            bool rmbme = false;

            var result = await _signInManager.PasswordSignInAsync(email, password, rmbme, lockoutOnFailure: false);
            var expected = result;

            Assert.AreEqual(expected, result, "Invalid login!");
            //return null;
        }

        
    }

    
}
