using System.Threading.Tasks;
using CoreWiki.Specs.Drivers;
using TechTalk.SpecFlow;

namespace CoreWiki.Specs.Steps
{
	[Binding]
	public class UserSteps
	{
		private readonly UserDriver _userDriver;

		public UserSteps(UserDriver userDriver)
		{
			_userDriver = userDriver;
		}

		[Given(@"I am a new user")]
		public void GivenIAmANewUser()
		{
			
		}

		[Given(@"I have the role '(.*)'")]
		public async Task GivenIHaveTheRole(string roleName)
		{
			await _userDriver.CreateCustomUserWithRole(roleName);
		}

	}
}
