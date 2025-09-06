Feature: Customer Management

  Scenario: Create a new customer
    Given the customer management service is available
    When a request to create a new customer with name "John Doe" and email "john.doe@example.com" is sent
    Then the customer should be created successfully
    And the customer's ID should be returned