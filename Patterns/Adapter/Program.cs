using System;

namespace AdapterExample
{
    class OldOrderSystem
    {
        public string ProcessOldOrder()
        {
            return "Стара система обробляє замовлення.";
        }
    }

    interface INewOrderSystem
    {
        string ProcessOrder();
    }

    class NewOrderSystem : INewOrderSystem
    {
        public string ProcessOrder()
        {
            return "Нова система обробляє замовлення.";
        }
    }

    class OrderAdapter : INewOrderSystem
    {
        private readonly OldOrderSystem oldOrderSystem;

        public OrderAdapter(OldOrderSystem oldOrderSystem)
        {
            this.oldOrderSystem = oldOrderSystem;
        }

        public string ProcessOrder()
        {
            return oldOrderSystem.ProcessOldOrder();
        }
    }

    class OrderProcessor
    {
        public void ProcessOrder(INewOrderSystem orderSystem)
        {
            Console.WriteLine(orderSystem.ProcessOrder());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            INewOrderSystem newOrderSystem = new NewOrderSystem();
            OrderProcessor processor = new OrderProcessor();
            processor.ProcessOrder(newOrderSystem);

            OldOrderSystem oldOrderSystem = new OldOrderSystem();
            OrderAdapter adapter = new OrderAdapter(oldOrderSystem);
            processor.ProcessOrder(adapter);
        }
    }
}
/*є стара система для обробки замовлень в ресторані, яка приймає 
 * замовлення за допомогою класу OldOrderSystem, але наша нова 
 * система використовує клас NewOrderSystem, який працює з іншими методами. Ми хочемо 
 * інтегрувати стару систему в нову, не змінюючи її код, використовуючи адаптер.*/