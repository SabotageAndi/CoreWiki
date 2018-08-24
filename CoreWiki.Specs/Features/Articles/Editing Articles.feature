Feature: Editing Articles

Background:
	Given I have the role 'Authors'

Scenario: Change the content of an Article

	Given an article exists with the content:
		"""
		# outdated Content
		"""
	And I open this article to edit it

	When I change the content to
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
