Feature: Customer Management

  Scenario: Create a new customer
    Given the user is on the customer creation page
    When the user enters valid customer details
    And the user clicks the create button
    Then a new customer should be created
