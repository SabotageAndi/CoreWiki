namespace CoreWiki.Specs.Drivers
{
	


	public class LoginData
	{
		public string EMail { get; set; }
		public string Password { get; set; }

		public static LoginData ValidCredentialsAdmin =new LoginData(){EMail = "admin@corewiki.com" , Password = "Admin@123" };
		public static LoginData InvalidCredentials =new LoginData(){EMail = "admin@corewiki.com" , Password = "WRONG_PASSWORD" };
		public static LoginData CredentialsCustomRoles = new LoginData(){EMail = "customrole@corewiki.com", Password = "CustomrolePassW0rD!"};
	}
}
