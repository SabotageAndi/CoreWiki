Feature: Create Articles

Background:
	Given I have the role 'Authors'


Scenario: Create Article is after saving available

	When I create a new article
	And save it

	Then the new article is available


Scenario: Find an article by topic

	Given an article with the topic 'SpecFlow Tips & Tricks' was created
	And save it

	When I look at the list of available topics

	Then the article with the topic 'SpecFlow Tips & Tricks' is available


Scenario: Create an Article without content

	When I create a new article without content
	And save it

	Then the new article is available


Scenario: Create Article with content 

	When I create a new article
	And enter the content
		"""
		# Heading 1
		## Heading 2

		Content
		"""
	And save it

	Then the new article has the content:
		"""
		# Heading 1
		## Heading 2

		Content
		"""
