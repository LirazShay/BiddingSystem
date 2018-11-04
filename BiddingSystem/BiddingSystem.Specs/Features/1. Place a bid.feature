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
	Then the bid list will be
		| Username | Price |
		| user1    | 12.00 |


Scenario: Multiple users placing bids - all bids will be saved
	When I place a bid
		| Username | Price |
		| user1    | 12.00 |
	And I place a bid
		| Username | Price |
		| user2    | 14.50 |
	Then the bid list will be
		| Username | Price |
		| user1    | 12.00 |
		| user2    | 14.50 |


Scenario: Update my bid - the bid will be updated correctly
	When I place a bid
		| Username | Price |
		| user1    | 12.00 |
	And I place a bid
		| Username | Price |
		| user1    | 15.05 |
	Then the bid list will be
		| Username | Price |
		| user1    | 15.05 |

			   
Scenario: Place bid with price 0.05 will be allowed
	When I place a bid
		| Username | Price |
		| user1    | 0.05  |
	Then the bid list will be
		| Username | Price |
		| user1    | 0.05  |