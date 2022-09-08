Feature: Order the book at Tzomet Sfarim site

Scenario: Verify that user can successfuly order books 
	Given in chrome browser user navigate to site - https://www.booknet.co.il/
	When in menu user choses מבצעים , then מבצע - ספרי ילדים 
	And on מבצעים page user adds two books to cart
	And user checkout to cart and filled the following fileds
	| email          | name | surname | cell       | city     | street | homenumber |
	| test@gmail.com | jon  | snow    | 0549405350 | tel aviv | alenbi | 123        |
