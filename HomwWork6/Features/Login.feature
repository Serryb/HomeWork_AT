Feature: Login

I want to connect to database

Scenario: Connect to NorthWind
	Given I open "http://localhost:5000" url
	When  I write in the login field "user" and in the passwor field "user"
	Then  I connect to database
