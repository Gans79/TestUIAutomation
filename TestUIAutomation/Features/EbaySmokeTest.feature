Feature: EbaySmokeTest
#Scenario: I want to add 2 items to cart and checkout 
#Given I navigate to ebay url
#When I search for "thomas train" product 
#And I click the item in search results
#And I click the add to cart button 
#When I search for "Game of Thrones Book" product 
#And I click the item in search results
#And I click the add to cart button 
#Then "2" items should be added to cart 

Background: 
Given I navigate to ebay url
Scenario Outline: I want to add items to cart 
When I search for '<item>'product
And I click the item in search results
And I click the add to cart button 
Then '<expectedProductsCount>' number of items should be added to cart 
Examples:
| item                 | expectedProductsCount |
| thomas train         | 1                     |
| game of thrones book | 2                     |
