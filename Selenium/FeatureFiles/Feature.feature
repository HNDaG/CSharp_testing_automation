Feature: Time shifting test om OrangeHRM



@tag1
Scenario: Time shifting normal-flow
    Given we have logged in the site
    When we go to time shift panel
    And we add new time shift
    Then we have new time shift appeared
    When we remove row
    Then we have row removed