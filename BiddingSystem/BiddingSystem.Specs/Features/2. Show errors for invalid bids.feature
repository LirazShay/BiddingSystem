Feature: Show errors for invalid bids
	In order to avoid invalid bids from being saved
	As a user
	I want to be told when my bid is invalid


Background: 
	Given there is an open auction


Scenario: Place empty bid - Get an error
	When I send place bid request without bid
	Then I will get an error "Bid cannot be empty!"


Scenario: Place bid without price - Get an error
	When I place a bid
		| Username | Price |
		| user1    | Null  |
	Then I will get an error "Price cannot be empty!"


Scenario: Place bid with price 0 - Get an error
	When I place a bid
		| Username | Price |
		| user1    | 0     |
	Then I will get an error "Price must be greater than 0"


Scenario: Place bid with price lesser than 0 - Get an error
	When I place a bid
		| Username | Price |
		| user1    | -1    |
	Then I will get an error "Price must be greater than 0"


Scenario: Place bid without username - Get an error
	When I place a bid
		| Username | Price |
		| user1    | -1    |
	Then I will get an error "Price must be greater than 0"