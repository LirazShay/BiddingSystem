Feature: Get all bids
	In order to know the auction status
	As a user
	I want to be told all the bids for the current auction


Background:
	Given there is an open auction


Scenario: When there are no bids yet - Get empty list
	When I get all current bids
	Then the bids list in the response will be empty

	
Scenario: There is only 1 bid, get this bid
	When I place a bid
		| Username | Price |
		| user1    | 12.00 |
	Then the response will contain the bid list
		| Username | Price |
		| user1    | 12.00 |


Scenario: When there are multiple bids, they will be sorted by price descending
	When I place a bid
		| Username | Price |
		| user1    | 12.00 |
	And I place a bid
		| Username | Price |
		| user2    | 10.00 |
	And I place a bid
		| Username | Price |
		| user4    | 15.50 |
	And I place a bid
		| Username | Price |
		| user3    | 00.05 |
	Then the response will contain the bid list
		| Username | Price |
		| user4    | 15.50 |
		| user1    | 12.00 |
		| user2    | 10.00 |
		| user3    | 00.05 |
