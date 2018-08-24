Feature: Editing Articles


Background:
	Given I have the role 'Authors'
	And an article 'SpecFlow Links' exists


Scenario: Change the text of an Article

	Given I open the article 'SpecFlow Links' to edit it

	When I edit the text
		"""
		# Links

		- SpecFlow Documentation - www.specflow.org/docs
		"""
	And save it

	Then the new text is saved to the database


Scenario: Link two articles

	Given an article 'SpecFlow ToC' exists
	And I open the article 'SpecFlow ToC' to edit it

	When I edit the text
		"""
		(Links)[/wiki/SpecFlow%20Links]
		"""
	And save it

