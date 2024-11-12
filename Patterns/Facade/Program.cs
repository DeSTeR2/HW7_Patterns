using System;

namespace FacadeExample
{
    class OrderSystem
    {
        public void TakeOrder()
        {
            Console.WriteLine("Замовлення прийняте.");
        }
    }

    class KitchenSystem
    {
        public void PrepareFood()
        {
            Console.WriteLine("Їжа готується.");
        }
    }

    class PaymentSystem
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Платіж оброблено.");
        }
    }

    class CafeFacade
    {
        private OrderSystem orderSystem;
        private KitchenSystem kitchenSystem;
        private PaymentSystem paymentSystem;

        public CafeFacade()
        {
            orderSystem = new OrderSystem();
            kitchenSystem = new KitchenSystem();
            paymentSystem = new PaymentSystem();
        }

        public void OrderAndPay()
        {
            orderSystem.TakeOrder();
            kitchenSystem.PrepareFood();
            paymentSystem.ProcessPayment();
            Console.WriteLine("Замовлення готове, і платіж виконано!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CafeFacade facade = new CafeFacade();
            facade.OrderAndPay();

            Console.ReadLine();
        }
    }
}

/*
 * Нам потрібно створити Facade, який дозволяє 
 * клієнту просто зробити замовлення та оплатити його
 * без необхідності взаємодіяти з кожною з підсистем.
 */