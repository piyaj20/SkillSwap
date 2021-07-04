Feature: Validating Share Skill Functionality
	

Scenario: User is able to add ShareSkill successfully
	Given I am at the Share Skill Page
	When I enter data in all the mandatory fields
	And I click on Save button
	Then ShareSkill should be saved successfully


Scenario: User is able to edit ShareSkill successfully
	Given I am at the Manage Listings Page
	When I click on edit icon
	And I update the information on ShareSkill Page
	And I click on Save button
	Then ShareSkill should be updated successfully

Scenario: User is able to delete ShareSkill successfully
	Given I am at the Manage Listings Page
	When I click on delete icon
	And I click Yes on Delete popup
	Then ShareSkill should be deleted successfully 