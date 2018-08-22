Feature: Cookie Message


Scenario: The cookie message is shown on first visit

	Given I am a new user
	When I visit the main page
	Then I see the cookie message at the top of the page


Scenario: The cookie message is gone after agreeing it

	Given I am a new user
	When I visit the main page
	And agree to the cookie message
	Then I the cookie message at the top of the page is gone
