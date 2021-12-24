Feature: Logout

I want to disconnect from Northwind DATABASE

Scenario: Logout from NorthWind DATABASE
	Given I connect to Northwind
	When  I click logout
	Then  I logout from NORTHWIND DATABASE
