Feature: Get all bids
	In order to know the auction status
	As a user
	I want to be told all the bids for the current auction


Background:
	Given there is an open auction 


Scenario: When there are no bids yet - Get empty list
	When I perform get all bids request
	Then the response will be empty

	
Scenario: There is only 1 bid, get this bid
	Given the following bids were offered
		| Username | Price |
		| user1    | 12.00 |
	When I perform get all bids request
	Then the response will contain the bid list
		| Username | Price |
		| user1    | 12.00 |


Scenario: When there are multiple bids, they will be sorted by price descending
	Given the following bids were offered
		| Username | Price |
		| user1    | 12.00 |
		| user2    | 10.00 |
		| user4    | 15.50 |
		| user3    | 00.05 |
	When I perform get all bids request
	Then the response will contain the bid list
		| Username | Price |
		| user4    | 15.50 |
		| user1    | 12.00 |
		| user2    | 10.00 |
		| user3    | 00.05 |