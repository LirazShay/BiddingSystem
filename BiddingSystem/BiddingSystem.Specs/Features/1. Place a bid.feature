Feature: Place a bid
	In order to buy something
	As a user
	I want to place my bid


Background: 
	Given there is an open auction


Scenario: Place a new bid - the bid will be saved
	When I place a bid
		| Username | Price |
		| user1    | 12.00 |
	Then my bid will be saved correly
		| Username | Price |
		| user1    | 12.00 |


Scenario: Multiple users placing bids - all bids will be saved
	When I place a bid
		| Username | Price |
		| user1    | 12.00 |
	And I place a bid
		| Username | Price |
		| user2    | 14.50 |
	Then all bids will be saved correctly
		| Username | Price |
		| user1    | 12.00 |
		| user2    | 14.50 |


Scenario: Update my bid

Scenario: Place bid without price will get error

Scenario: Place bid without username will get error