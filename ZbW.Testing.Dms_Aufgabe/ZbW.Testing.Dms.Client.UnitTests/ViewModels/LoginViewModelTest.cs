using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Properties;


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
            var user = loginViewModel.Benutzername;
            Assert.That(result, Is.True);
            Assert.AreEqual(user, Settings.Default.DefaultUser);
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

       
}
}
