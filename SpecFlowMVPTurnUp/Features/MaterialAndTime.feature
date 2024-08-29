Feature: MaterialAndTime

Background:
Given user login the system with username "hari" password "123123" and navigate to the MaterialTime Page

@regression
Scenario: Create a new Material and time record 	 
	Given click the createNew button and enter the information and save
	| typeCode | code        | description | price |
	| T        | T2024082207 | T20240822   | $30   |
	Then a new record should be created
	| record    |
	| T2024082207 |
	
 