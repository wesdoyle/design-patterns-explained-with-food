using CreationalPatterns.AbstractFactory.Menus;

namespace CreationalPatterns.AbstractFactory {
    public interface IMealPlanFactory {

        // One of the things that our Meal Plan Factories do is generate different Menus 
        // to match the chosen customer diet plan.  They produce a "family" of products 
        // based on the diet.  A MealPlanFactory may have other behavior; the following methods 
        // are given to provide a simple example.

        public IMenu GenerateLunchesMenu();
        public IMenu GenerateDessertsMenu();
    }
}
