# csharp-design-patterns-by-example

GOF Design Patterns in C# with working examples inspired by food.

This repository was made as a way to demonstrate and learn using moderately realistic examples of the Gang of Four Design Patterns (Design Patterns - Elements of Reusable Object-Oriented Software).

## Motivation

Many examples of these patterns elsewhere avoid including typical dependencies like Databases, AMQP Queues, external services for things like Email and HTTP APIs.  The projects in this repo contain mock versions of these types of dependencies incorporated into moderately-realistic business scenarios.  The examples are intended to be lean enough so that the principal benefit of each pattern can be learned, but complex enough to avoid oversimplified scenarios.

## Example Programs

Every design pattern has a corresponding .NET 5.0 console application.

| Pattern  | Type  | Example Program  | Why Used  |
|---|---|---|---|
| Abstract Factory  | Creational  | Custom Meal Planner  | Can create families of Diets with their own behavior for generating grocery lists and other data without specifying concrete classes  |
| Builder  | Creational  | Bakery Purchase Order System  | Can separate the complex logic used to construct POs from its representation. Provides a fluent syntax for creating new purchase orders.  |
| Factory Method  | Creational  | Food Delivery Service  | Make it easier to extend delivery type construction. We can introduce new delivery types without modifying client code.  |
| Prototype  | Creational  | Dining Room Designer  | Make it easier to create an object that is expensive to create or obtain by other means.  We create deep copies of protypical chair and table objects for our designer that can be used and modified independently after being cloned.  |
| Singleton  | Creational  | Ingredients Database  | We create a singleton connection pool manager that is used by different clients to connect to a database.  If more clients try to connect than the pool permits, it prevents further connection.  Uses Lazy initialization.  |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
