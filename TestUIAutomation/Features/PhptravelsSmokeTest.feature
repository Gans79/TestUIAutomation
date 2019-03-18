Feature: PhptravelsSmokeTest

Background: 
Given I navigate to phptravels url 

Scenario: I want to book hotels with valid invalid username returns error 
When i login using 'XXXXXXXX' and 'demouser' 
Then i should see a error on the screen

Scenario: I want to book hotels with valid valid username invalid password returns error 
When i login using 'user@phptravels.com' and 'xxxxx' 
Then i should see a error on the screen

Scenario: I want to book hotels with invalid startdates returns error 
When i login using 'user@phptravels.com' and 'demouser' 
And click on Hotels icon 
And input 'hotel' and 'xxxxxxxx' and '10/04/2019' and search
Then i should see a error on the screen

Scenario: I want to book hotels with invalid startdates returns error 
When i login using 'user@phptravels.com' and 'demouser' 
And click on Hotels icon 
And input 'hotel' and '30/03/2019' and 'xxxxxx' and search
Then i should see a error on the screen

Scenario: I want to book hotels with valid input returns success
When i login using 'user@phptravels.com' and 'demouser' 
And click on Hotels icon 
And input 'hotel' and '30/03/2019' and '10/04/2019' and search
And select the available hotel and book 
Then i should see a invoice on the screen

