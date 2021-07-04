Feature: Validating Chat functionality
	

@mytag
Scenario: I am able to chat with other users
	Given I am at the Service Detail Page
	When I click on Chat button
	And I enter message in the chat box
	And I click on Send
	Then Message should be sent to that user

Scenario: I am able to view the chat history 
	Given I am on the Chat Page
	When I enter seller name in search box
	Then Chat History with that seller should be visible