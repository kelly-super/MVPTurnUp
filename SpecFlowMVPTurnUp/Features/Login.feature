Feature: MVP TurnUp portal login feature
As a registerred user
I want to log in to the application
So that i can access my personalized dashboard

A short summary of the feature

@regression
Scenario: Successful login with valid Credentials
	Given the user navigates to the login page
	When user enters invalid credentials and click the login button
	Then the user should be redirected to the homepage
@regression
Scenario: Unsucessful login with invalid credentials
	Given the user navigates to the login page
	When user enters invalid credentials
	Then the user should see an error message 'Invalid username or password.'

Scenario: Unsucessful login with null username
	Given the user navigates to the login page
	When user enters password but null username
	Then the user should see an error message 'The User name field is required.'

Scenario: Unsucessful login with null password
	Given the user navigates to the login page
	When user enters password but null password
	Then the user should see an error message 'The Password field is required.'