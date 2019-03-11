Feature: PhptravelsSmokeTest
Background: 
Given I navigate to phptravels url 
Scenario: I want to book hotels 
When i login using 'user@phptravels.com' and 'demouser' 
And click on Hotels icon 
And input 'hotel' and '30/03/2019' and '10/04/2019' and search
And select the available hotel and book 
Then i should see a invoice on the screen
