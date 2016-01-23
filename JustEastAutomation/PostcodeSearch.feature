Feature: Postcode search

Scenario 1: For the known outcode se19, results are returned
	Given I visit http://localhost:777/
	And I enter the known postcode SE19
	When the search button is pressed 
	Then a list of restuarants should be returned

Scenario 2: The Name, Cuisines and Rating of the restaurant are displayed
	Given I visit http://localhost:777/
	And I enter the known postcode SE19
	When the search button is pressed 
	Then the returned restaurants Name, Cuisine and Rating are displayed