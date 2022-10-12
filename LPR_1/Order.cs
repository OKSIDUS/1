using System;

namespace LPR_1
{
    public class Order
    {
        public int numberOrder;
        public string name;
        public string address;
        public int day;
        public int month;
        public int sum;
        public OrderState state;
        /// <summary>
        /// Метод класса Order, который изменяет дату доставки.
        /// </summary>
        /// <param name="d">Принимает номер дня.</param>
        /// <param name="m">Принимает номер месяца.</param>
        public void DataChange(int d, int m)
        {
            day = d;
            month = m;
            Console.WriteLine("Data was changed.");
        }
        /// <summary>
        /// Метод класса Order, который изменяет адрес доставки.
        /// </summary>
        /// <param name="adr">Принимает новый адрес, которым заменит старый.</param>
        public void AddressChange(string adr)
        {
            address = adr;
            Console.WriteLine("Address was changed.");
        }
        /// <summary>
        /// Метод класса Order, который выводит всю информацию об объекте.
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine($"Order number: {numberOrder}\nCustomer name: {name}\nDelivery address: {address}\nDelivery date: {day}.{month}.{DateTime.Now.Year}\nTotal amount: {sum}UAH \nOrder state: {state}");
            Console.WriteLine("__________________________________________________________________________________");
        }
    }
}
