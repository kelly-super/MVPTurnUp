Feature: MaterialAndTimeEdit


Background:
Given user logined in the system with username "hari" password "123123" and navigate to the MaterialTime Page


@regression
Scenario Outline: user edit the last record
	Given User select the last record,click edit button
	And edit the'<typecode>' '<code>' and '<description>' and '<price>'
	Then click the save button
	Then verify the '<record>' is changed

Examples:
	| typecode | code      | description    | price | record    |
	| M        | M20240820 | M20240820 test | $30   | M20240820 |
	       