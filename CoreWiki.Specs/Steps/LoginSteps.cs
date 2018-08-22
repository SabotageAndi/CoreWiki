using CoreWiki.Specs.Drivers;
using TechTalk.SpecFlow;

namespace CoreWiki.Specs.Steps
{
	[Binding]
	public class LoginSteps
	{
		private readonly LoginDriver _loginDriver;
		private readonly MainPageDriver _mainPageDriver;

		public LoginSteps(LoginDriver loginDriver, MainPageDriver mainPageDriver)
		{
			_loginDriver = loginDriver;
			_mainPageDriver = mainPageDriver;
		}

		[When(@"I use valid credentials to login")]
		public void WhenIUseValidCredentialsToLogin()
		{
			_loginDriver.LoginWithCredentials(LoginData.ValidCredentialsAdmin);
		}

		[When(@"I use invalid credentials to login")]
		public void WhenIUseInvalidCredentialsToLogin()
		{
			_loginDriver.LoginWithCredentials(LoginData.InvalidCredentials);
		}

		[Then(@"I see a welcome message in the top right corner")]
		public void ThenISeeAWelcomeMessageInTheTopRightCorner()
		{
			_mainPageDriver.AssertWelcomeMessage();
		}


		[Then(@"I see a message that I couldn't be logged in")]
		public void ThenISeeAMessageThatICouldnTBeLoggedIn()
		{
			_loginDriver.AssertThatAnInvalidLoginAttemptMessage();
		}


	}
}
