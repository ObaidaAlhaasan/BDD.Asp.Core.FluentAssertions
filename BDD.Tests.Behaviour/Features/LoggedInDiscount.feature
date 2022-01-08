Feature: Logged in users has a discount
As a user
I want to have a 5% discount when I am logged In

    @Discounts
    Scenario: Guest users should pay full price
        Given a user named Jak that is not logged in
        And an empty basket
        When Jak added a t-shirt to the basket costs 5$
        Then the basket value is 5$

    Scenario: Logged In users should have 5% discount
        Given a user named Marie that is logged in
        And an empty basket
        When Marie added a dress to the basket costs 100$
        Then the basket value is 95$