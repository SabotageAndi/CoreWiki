Feature: Login

Scenario: Use valid user for login

	When I use valid credentials to login
	Then I see a message that I am successful logged in


Scenario: Use invalid user for login

	When I use invalid credentials to login
	Then I see a message that I couldn't be logged in
