using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Model;



namespace Unit.ViewModels
{
    [TestFixture]
    internal class ViewModelTests
    {
        private const string VALID_USER = "a";

        private const string INVALID_USER = "";


        [Test]
        public void Enable_Login_LoginView()
        {
            // arrange
            var loginViewModel = new LoginViewModel(null);

            //act
            loginViewModel.Benutzername = VALID_USER;
            var result = loginViewModel.CmdLogin.CanExecute();

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Disable_Login_LoginView()
        {
            // arrange
            var loginViewModel = new LoginViewModel(null);

            //act
            loginViewModel.Benutzername = INVALID_USER;
            var result = loginViewModel.CmdLogin.CanExecute();

            //assert
            Assert.That(result, Is.False);
        }

        //Wird auf den [Abbrechen]-Button gedrückt, wird die Applikation beendet.

        [Test]
        public void Check_UserName_LoginView()
        {
            //arrange
            var loginViewModel = new LoginViewModel(null);

            //act
            loginViewModel.Benutzername = VALID_USER;
            var result = loginViewModel.Benutzername;

            //assert
            Assert.AreEqual(result, VALID_USER);
        }

        [Test]
        public void OnComandLogin_Check_CallToMainView()
        {
            //arrange
            var loginViewModel = new LoginViewModel(null);

            //act
            //var System;
            var result = loginViewModel.Benutzername;

            //assert
            Assert.AreEqual(result, VALID_USER);
        }
}
}
