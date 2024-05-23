Feature: Users

All scenarios related to Users will be placed he

@petstorecreateuser
Scenario: Verify if a Customer is able to create an user in pet store
	Given I have a valid customer data
	When I call the create user api with the correct data
	Then I should see 200 response
