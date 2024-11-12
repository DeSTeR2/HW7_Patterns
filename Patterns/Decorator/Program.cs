using System;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Tree tree = new Tree();
            Ornaments ornaments = new Ornaments();
            Garland garland = new Garland();

            ornaments.SetComponent(tree);
            garland.SetComponent(ornaments);

            garland.Operation();
        }
    }

    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class Tree : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка.");
        }
    }

    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class Ornaments : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddOrnaments();
            Console.WriteLine("Декорування ялинки прикрасами.");
        }

        private void AddOrnaments()
        {
            // Додати ялинкові прикраси
            Console.WriteLine("Прикрасили ялинку кульками, зірочками та іншими прикрасами.");
        }
    }

    // "ConcreteDecoratorB"
    class Garland : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            LightUp();
            Console.WriteLine("Ялинка світиться.");
        }

        private void LightUp()
        {
            // Додати світло
            Console.WriteLine("Гірлянда на ялинці почала світитися.");
        }
    }
}
