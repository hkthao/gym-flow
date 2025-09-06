Feature: Face Recognition

  Scenario: Recognize a known face
    Given the service is running
    When a known face is sent to the service
    Then the correct user ID is returned
