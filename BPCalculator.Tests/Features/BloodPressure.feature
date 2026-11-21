Feature: Blood Pressure Classification
  As a user
  I want to calculate my blood pressure category
  So that I can understand my blood pressure level

  Scenario: High blood pressure
    Given the systolic pressure is 145
    And the diastolic pressure is 95
    When the blood pressure category is calculated
    Then the category should be High

  Scenario: PreHigh blood pressure
    Given the systolic pressure is 130
    And the diastolic pressure is 85
    When the blood pressure category is calculated
    Then the category should be PreHigh

  Scenario: Ideal blood pressure
    Given the systolic pressure is 110
    And the diastolic pressure is 70
    When the blood pressure category is calculated
    Then the category should be Ideal

  Scenario: Low blood pressure
    Given the systolic pressure is 85
    And the diastolic pressure is 55
    When the blood pressure category is calculated
    Then the category should be Low