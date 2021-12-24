Feature: Add new product

Add new product to database


Scenario: Add new product
	Given I Loggin
	When  I Go to products page and add product
	Then  Ok
