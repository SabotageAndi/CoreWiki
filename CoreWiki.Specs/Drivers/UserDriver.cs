using CoreWiki.Data.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CoreWiki.Specs.Drivers
{
	public class UserDriver
	{
		private readonly IServiceScope _serviceScope;
		private readonly UserManager<CoreWikiUser> _userManager;

		public UserDriver(IServiceScope serviceScope)
		{
			_serviceScope = serviceScope;

			_userManager = _serviceScope.ServiceProvider.GetRequiredService<UserManager<CoreWikiUser>>();
		}

		public async Task CreateCustomUserWithRole(string roleName)
		{
			var coreWikiUser = new CoreWikiUser()
			{
				UserName = LoginData.CredentialsCustomRoles.EMail,
				Email = LoginData.CredentialsCustomRoles.EMail
			};
			var userResult = await _userManager.CreateAsync(coreWikiUser, LoginData.CredentialsCustomRoles.Password);

			var result = await _userManager.AddToRoleAsync(coreWikiUser, roleName);

		}
	}
}
