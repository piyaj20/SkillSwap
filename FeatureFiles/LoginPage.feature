Feature: Login and SignUp Page
	In order to test the Login Feature
	As a user
	I want to be able to SignUp for a new user or Login successfully for existing user



Scenario: User is able to SignUp successfully when he enters valid information
	Given I am at the SignUp page
	When I enter valid information
	And I agree to the terms and conditions
	And I click the Join button
	Then I should be registered successfully


Scenario: User is able to Login successfully when he enters valid credentials
	Given I am at the Login page
	When I enter valid credentials
	And I click the Login button
	Then I should be logged in successfully