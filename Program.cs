using System;

namespace IMJunior
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderForm = new OrderForm();
            var paymentHandler = new PaymentHandler();

            string systemId = orderForm.ShowForm();

            IPaymentSystem paymentSystem = null;

            if (systemId == "QIWI")
                paymentSystem = new QIWIPayment();
            else if (systemId == "WebMoney")
                paymentSystem = new WebMoneyPayment();
            else if (systemId == "Card")
                paymentSystem = new CardPayment();

            if (paymentSystem == null)
                paymentSystem = new CardPayment();

            paymentHandler.ShowPaymentResult(paymentSystem);
        }
    }

    public class OrderForm
    {
        public string ShowForm()
        {
            Console.WriteLine("Мы принимаем: QIWI, WebMoney, Card");

            //симуляция веб интерфейса
            Console.WriteLine("Какое системой вы хотите совершить оплату?");

            return Console.ReadLine();
        }
    }

    public class PaymentHandler
    {    
        public void ShowPaymentResult(IPaymentSystem paymentSystem)
        {
            paymentSystem.ShowPaymentResult();

            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class QIWIPayment : IPaymentSystem
    {
        public QIWIPayment()
        {
            Console.WriteLine("Перевод на страницу QIWI...");
        }

        public void ShowPaymentResult()
        {
            Console.WriteLine("Проверка платежа через QIWI...");
        }
    }

    public class WebMoneyPayment : IPaymentSystem
    {
        public WebMoneyPayment()
        {
            Console.WriteLine("Вызов API WebMoney...");
        }

        public void ShowPaymentResult()
        {
            Console.WriteLine("Проверка платежа через WebMoney...");
        }
    }

    public class CardPayment : IPaymentSystem
    {
        public CardPayment()
        {
            Console.WriteLine("Вызов API банка эмитера карты Card...");
        }

        public void ShowPaymentResult()
        {
            Console.WriteLine("Проверка платежа через Card...");
        }
    }

    public interface IPaymentSystem
    {
        public void ShowPaymentResult();
    }
}