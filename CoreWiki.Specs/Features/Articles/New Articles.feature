Feature: New Articles

Background:
	Given I have the role 'Authors'


Scenario: New Article with only a title

	When I create a new article with the title 'SpecFlow Tips & Tricks'
	And save it

	Then the article is saved in the database


Scenario: New Article with title and text

	When I create a new article
	And enter the title 'SpecFlow Best practices'
	And enter the text
		"""
		# Tags

		Use Tags to make a connection to your userstory
		"""
	And save it

	Then the article is saved in the database
