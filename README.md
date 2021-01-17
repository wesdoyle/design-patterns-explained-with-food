# Design Patterns Explained with Food 🥕

GOF Design Patterns in C# with working examples inspired by food

This repository was made as a way to demonstrate and learn using moderately realistic examples of the Gang of Four Design Patterns (Design Patterns - Elements of Reusable Object-Oriented Software).

## Motivation

Many examples of these patterns as taught online typically avoid incorporating __[external dependencies](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/RealisticDependencies)__ like Databases, AMQP queues, external services for things like email and HTTP APIs.  While avoiding adding these dependencies to example code makes it easier to demonstrate the core motivation of the design patterns, it also makes it more difficult to imagine real-world scenarios where these patterns might be used. The projects in this repo contain mock versions of these types of dependencies incorporated into various plausible business scenarios.  The examples are intended to be lean enough so that the principal benefit of each pattern is evident, but complex enough to avoid oversimplified scenarios.

## Example Programs

Every design pattern has a corresponding .NET 5.0 console application.

| Pattern  | Type  | Example Program  | Why Used  |
|---|---|---|---|
| [Abstract Factory](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/CreationalPatterns/AbstractFactory)  | Creational  | [Custom Meal Planner](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/CreationalExamples/CustomMealPlanner)  | We want to be able to create families of Diets with their own behavior for generating things like grocery lists and other data in an extensible fashion without specifying concrete classes in our client |
| [Builder](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/CreationalPatterns/Builder)  | Creational  | [Bakery Purchase Order System](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/CreationalExamples/BakeryPurchaseOrderSystem)  | We want to separate the complex logic used to construct POs from its representation. We can provide a fluent syntax for creating new purchase orders and a seamless way to use the builder as an instance of the class it is responsible for building when construction is complete.  |
| [Factory Method](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/CreationalPatterns/FactoryMethod)  | Creational  | [Food Delivery Service](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/CreationalExamples/FoodDeliveryService)  | We want to make it easier to extend delivery type construction. We can introduce new delivery types without modifying client code.  |
| [Prototype](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/CreationalPatterns/Prototype)  | Creational  | [Dining Room Designer](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/CreationalExamples/DiningRoomDesigner)  | In our graphic design application, we'd like to make it easier to create icons that are expensive or cumbersome to otherwise obtain.  We can create deep copies of protypical chair and table objects - without knowing the internal state of the copied object - for our designer that can be used and modified independently after being cloned.  |
| [Singleton](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/CreationalPatterns/Singleton)  | Creational  | [Ingredients Database Connection Pool](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/CreationalExamples/IngredientsDatabaseClient)  | We create a singleton connection pool manager that is used by different clients to connect to a database.  If more clients try to connect than the pool permits, it prevents further connection.  Uses Lazy initialization for thread safety.  |
| [Adapter](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/StructuralPatterns/Adapter)  | Structural  | [Recipe Search](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/StructuralExamples/RecipeSearch)  | We need to use JSON to populate a recipe document store for our website, but our favorite API returns XML.  We can use an adapter to match our required interface and use the existing resource as-is.  |
| [Bridge](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/StructuralPatterns/Bridge)  | Structural   | [Farmer's Market Simulator](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/StructuralExamples/FarmersMarketSimulator)  | A Farmer's Market Simulator provides different class hierarchies for types of Vendors and types of Payment Processors.  Since any vendor should be compatible with any Payment Processor, we favor composition using a bridge to develop the Vendor Abstraction from the Payment Processor Implementation independently.  |
| [Composite](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/StructuralPatterns/Composite)  | Structural   | [Tea Cartonizer](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/StructuralExamples/TeaCartonizer)  | We sell tea by the carton.  Cartons can contain more cartons.  We'd like to print the number of servings on the outside of any carton, even if it contains lots of other cartons.  We can use the composite pattern to treat the aggregation in the same way that we treat individual objects, exposing behavior to get the number of servings regardless of the specific object details, treating aggregations and individual objects uniformly.  |
| [Decorator](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/StructuralPatterns/Decorator)  | Structural  | [Front-of-House Service](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/StructuralExamples/FrontOfHouseService)  | We have an automated system for letting diners know when their table is ready.  By default, we make an announcement over the restaurant intercom.  However, we would like to extend the ability to notify customers by email or text, and need a way to easily add, remove, and combine these options without adding a lot of complex logic or exponentially increasing the number of subclasses. |
| [Facade](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/StructuralPatterns/Facade)  | Structural  | [Grocery Store Report](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/StructuralExamples/GroceryReporter)  | The underlying service providers that help us put our Grocery Store Reports are complex and hard to use.  We want to hide that complexity behind an easy-to-use interface for use in our client code |
| [Flyweight](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/StructuralPatterns/Flyweight)  | Structural  | [Grocery Store City Planning Simulation](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/StructuralExamples/GroceryStoreCityPlanningSimulation)  | As part of our city planning efforts, we want to build a grocery store in an optimal location. We are building a simulation that simulates the location and movement of our city's Inhabitants, which are objects containing fields and other objects.  Some of these objects represent unchanging, static data that is shared by large portions of other inhabitants, like neighborhood and mode of travel. Some of the data is intrinsic to the inhabitant itself during the simulation, like its latitude and longitude.  A flyweight can be used to save memory during the simulation by caching the extrinsic data as a shared resource among the hundreds of thousands of inhabitant objects. |
| [Proxy](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/StructuralPatterns/Proxy)  | Structural  | [Food Bank Donation Processor](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/StructuralExamples/FoodBank) | Our Food Bank Processor uses an off-the-shelf system for accepting food donations.  However, we want to control access to this resource while maintaining the same interface.  We have the need to log use of the resource and prevent certain items from being donated, so we use a Proxy.  |
| [Chain of Responsibility](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/ChainOfResponsibility)  | Behavioral  | [Kombucha Order Processor](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/BehavioralExamples/KombuchaOrderProcessor)  | Our order pipeline for kombucha customers is pretty straightforward.  We cartonize, query a loyalty program, print shipping labels if the order is online, and email or print a receipt.  Some of the details of these steps change depending on some state - like whether the order is online, whether or not the customer is a loyalty member.  For instance, we want to print ads on receipts for non-loyalty-member customers.  We can use the chain of responsibility pattern to compose and execute each stage of the order processing pipeline.  |
| [Command](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/Command)  | Behavioral  | [Composter Sign Up Form](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/BehavioralExamples/NeighborhoodComposterSignUpForm) | We run a company that allows people in our neighborhood to sign up for organic compost collection. Some complex business logic happens behind-the-scenes, including sending messages to AWS SQS queues for vehicle routing services to consume and sending welcome emails. We want a way to parametrize methods with different types of commands for executing this logic at different points in our onboarding process, so we create Command objects to encapsulate the logic and data required to complete these operations, and allow our client to execute arbitrary command types at specific times during its onboarding algorithm.  |
| [Interpreter]()  | Behavioral  | Chocolate Shop Barcode Reader  |  We started a low-waste chocolate shop that serves fair-trade chocolate to patrons in bulk.  Each container of chocolate needs to be scanned using a custom barcode scanner.  The barcode needs to be interpreted by our software to perform downstream operations related to inventory and reporting. We'll build and integrate an interpreter for use by our scanner to make this possible.
| [Iterator](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/Iterator)  | Behavioral  | [Best Restaurant Finder]()  | We built an app that lets users travel through their favorite restaurants in order of "best to worst", but different users have different criteria for ranking their restaurants.  We generally want to be able to traverse a collection of restaurants without worrying about the underlying details or even revealing its structure.  So, we'll use the Iterator pattern without exposing these implementation details. |
| [Mediator](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/Mediator)  | Behavioral  | [Food Truck Coordinator]()  | We need a way to coordinate our Food Trucks and Food Carts throughout the city. These various vehicles need to communicate with each other, but things are getting messy as we try to add new types of vehicles and reasons for communication.  We'll build a Mediator to handle this complex collaboration so we can vary their interactions independently. |
| [Memento](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/Memento)  | Behavioral  | Donut Shop  | We run a shop that sells the best donuts in the city.  We run an online e-commerce store that allows users to add donuts to their cart.  We want a way for customers to undo adding donuts to their cart, so we implemented a basic version of this feature using the Memento Pattern. |
| [Observer](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/Observer)  | Behavioral  | [Diet Plan Tracking App]()  | We just launched our diet plan tracking app, and our users are constantly refining their profiles with their new weight, exercise goals, and photos.  Every time the profiles get updated, we need to kick off other processes to fulfill many different features of our service. We tried polling for changes, but that's getting too expensive, and we're missing updates between intervals.  Let's switch from a "pull" to a "push" design using the Observer pattern, so all of our dependent services can subscribe to the profile change event. |
| [State](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/State)  | Behavioral  | Table Buzzer  | Our family restaurant is growing in popularity.  As a result, we have limited seating.  Many customers need to wait to be seated.  We now offer hand-held buzzing devices to our patrons that are triggered when a table is available.  Depending on their state, which is configuratble by our patrons, they either light up or play music.  We can implement this behavior using the State Pattern.  |
| [Strategy](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/Strategy) | Behavioral  | Restaurant Menu Changer | We run a restaurant that displays a menu that changes throughout the day.  We have different processes that go into making breakfast, lunch, and dinner menus, higher-level processes remain the same.  We cook and serve food at all hours, but the strategy for getting that done varies depending on the circumstance.  We implement the Strategy Pattern to keep our code a bit cleaner. |
| [Template Method](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/TemplateMethod)  | Behavioral  | [Cookbook Printer](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/BehavioralExamples/CookbookPrinter)  | We run a cookbook printing business for self-published chefs.  Much of the process used to print the recpies in our cookbooks is exactly the same, but often differs slightly depending on the recipe.  We use a template method with default behavior and virtual behavior overridden (either forcibly or optionally) by concrete recipes using inheritance. |
| [Visitor](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/BehavioralPatterns/Visitor)  | Behavioral  | [Farmer's Market Research](https://github.com/wesdoyle/design-patterns-explained-with-food/tree/main/ExamplePrograms/BehavioralExamples/FarmersMarketResearch)  | We work for a company that provides sales and marketing reports for regional Farmer's Markets.  Different Farmer's Markets and their vendors have their own logic for generating data we can use for our reports, but we need to be able to generate our reports without significantly modifying any of the existing data-producing classes.  We instead make them 'visitable' by our own classes, which can in turn use them as needed to generate custom reports for sales and marketing teams. |

