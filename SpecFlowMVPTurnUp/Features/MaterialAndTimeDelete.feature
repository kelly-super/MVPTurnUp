Feature: MaterialAndTimeDelete


Background:
Given user log in the system with username "hari" password "123123" and navigate to the MaterialTime Page


@regression
Scenario: user delete the last record
	Given User select the last record
	And click the delete button
	And confirm to delete
	Then verify the  record count should minus 1 

	       