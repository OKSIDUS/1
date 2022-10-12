using System;

namespace LPR_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int momentm = Convert.ToInt32(DateTime.Now.Month);
            int momentd = Convert.ToInt32(DateTime.Now.Day);
            int lenth =0;
            Console.Write("Enter the maximum number of orders: ");
            bool restartNumber = true;
            while (restartNumber)
            {
                lenth = Convert.ToInt32(Console.ReadLine());
                if (lenth <= 0)
                {
                    Console.Write("Invalid value. Enter the number again: ");
                    restartNumber = true;
                }
                else restartNumber = false;
            }
            Order [] order = new Order[lenth];
            int count = 0;
            bool menu = true;
            while (menu)
            {
                Console.Write("\nChoose one of the options: \n\t 1 - Add order \n\t 2 - Display orders \n\t 3 - Find order \n\t 4 - Delete order \n\t 5 - Exit");
                string choise;
                Console.Write("\nEnter your choise: ");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        if (count < lenth)
                        {

                            Console.Write("\nEnter the number of orders to be added: ");
                            bool addOrdAgain = true;
                            while (addOrdAgain)
                            {
                                int addAmount = Convert.ToInt32(Console.ReadLine());
                                if (count + addAmount <= lenth && count + addAmount >= 0)
                                {
                                    int forcount = count;
                                    for (int i = 0; i < lenth; i++)
                                    {
                                        Console.WriteLine("\nEnter order details: ");
                                        order[i] = new Order();
                                        order[i].numberOrder = i+1;
                                        Console.WriteLine($"Order number: {order[i].numberOrder}");
                                        Console.Write("Customer name: ");
                                        bool namebool = true;
                                        while (namebool)
                                        {
                                            order[i].name = Convert.ToString(Console.ReadLine());
                                            if (order[i].name != "")
                                                namebool = false;
                                            else
                                                Console.Write("Name string cannot be empty. Enter the name: ");
                                        }
                                        Console.Write("Delivery address: ");
                                        bool adr = true;
                                        while (adr)
                                        {
                                            order[i].address = Convert.ToString(Console.ReadLine());
                                            if (order[i].address != "")
                                                adr = false;
                                            else
                                                Console.Write("Address string cannot be empty. Enter the address: ");
                                        }
                                        Console.WriteLine("Delivery date");
                                        Console.Write("Month: ");
                                        bool month = true;
                                        while (month)
                                        {
                                            order[i].month = Convert.ToInt32(Console.ReadLine());
                                            if (order[i].month < momentm || order[i].month > 12)
                                                Console.Write("Invalid value. Enter the month again: ");
                                            else month = false;
                                        }
                                        Console.Write("Day: ");
                                        bool day = true;
                                        while (day)
                                        {
                                            order[i].day = Convert.ToInt32(Console.ReadLine());
                                            if (order[i].month == 1 || order[i].month == 3 || order[i].month == 5 || order[i].month == 7 || order[i].month == 8 || order[i].month == 10 || order[i].month == 12)
                                            {
                                                if ((order[i].day <= momentd && order[i].month <= momentm) || (order[i].day > 31 || order[i].day < 1))
                                                    Console.Write("Invalid value. Enter the day again: ");
                                                else day = false;
                                            }
                                            if (order[i].month == 2)
                                            {
                                                if ((order[i].day <= momentd && order[i].month <= momentm) || (order[i].day > 28 || order[i].day < 1))
                                                    Console.Write("Invalid value. Enter the day again: ");
                                                else day = false;
                                            }
                                            if (order[i].month == 4 || order[i].month == 6 || order[i].month == 9 || order[i].month == 11)
                                            {
                                                if ((order[i].day <= momentd && order[i].month <= momentm) || (order[i].day > 30 || order[i].day < 1))
                                                    Console.Write("Invalid value. Enter the day again: ");
                                                else day = false;
                                            }
                                        }
                                        Console.Write("Order amount: ");
                                        bool sum = true;
                                        while (sum)
                                        {
                                            order[i].sum = Convert.ToInt32(Console.ReadLine());
                                            if (order[i].sum <= 0)
                                                Console.Write("Order amount cannot be less than or equal to 0. Enter the total amount again: ");
                                            else sum = false;
                                        }
                                        order[i].state = 0;
                                        Console.Write($"Order status: {order[i].state}\n");
                                        count++;
                                    }
                                    addOrdAgain = false;
                                }
                                else
                                    Console.Write($"Orders can not be more {lenth} and less than 0. Now there are {count} of them. Enter the number of orders to be added again: ");
                            }
                        }
                        else
                            Console.Write("Array is full!\n");
                        break;
                    case "2":
                        if (count > 0)
                        {
                            for (int i = 0; i < lenth; i++)
                            {
                                if(order[i].numberOrder!=0)
                                    order[i].ShowInfo();
                            }
                        }
                        else
                            Console.Write("Array is empty!\n");
                        break;
                    case "3":
                        if (count > 0)
                        {
                            bool search = true;
                            while (search)
                            {
                                Console.Write("\nSelect a search method: \n\t 1 - By order number \n\t 2 - By custome name and delivery date");
                                Console.Write("\nEnter your choise: ");
                                string searchMethod = Console.ReadLine();
                                switch (searchMethod)
                                {
                                    case "1":
                                        Console.Write("\nEnter order number: ");
                                        int ordnum = Convert.ToInt32(Console.ReadLine());
                                        if (ordnum<=lenth && ordnum>0)
                                        {
                                            if (order[ordnum - 1].numberOrder <= lenth && order[ordnum - 1].numberOrder > 0)
                                            {
                                                order[ordnum - 1].ShowInfo();
                                                search = false;
                                            }
                                            else
                                                Console.WriteLine("The order was previously deleted.");
                                        }
                                        else
                                            Console.WriteLine("Order not found.");
                                        break;
                                    case "2":
                                        Console.Write("Enter custome name: ");
                                        string custname = Console.ReadLine();
                                        Console.Write("Enter delivery date");
                                        Console.Write("\nMonth: ");
                                        int dmonth = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Day: ");
                                        int dday = Convert.ToInt32(Console.ReadLine());
                                        int res = 0;
                                        for (int i = 0; i < lenth; i++)
                                        {
                                            if (order[i].name == custname && order[i].month == dmonth && order[i].day == dday && order[i].numberOrder != 0)
                                            {
                                                Console.WriteLine("Order found.");
                                                order[i].ShowInfo();
                                                search = false;
                                                res = 1;
                                            }
                                        }
                                        if (res==0)
                                            Console.WriteLine("Order not found.");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid value. Enter your choise again: ");
                                        search = true;
                                        break;
                                }
                            }
                        }
                        else
                            Console.Write("Array is empty!\n");
                        break;
                    case "4":
                        if (count > 0)
                        {
                            Console.Write("\nEnter order number: ");
                            int ordnumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter custome name: ");
                            string customername = Console.ReadLine();
                            if (ordnumber <= lenth && ordnumber > 0)
                            {
                                if (order[ordnumber - 1].numberOrder <= lenth && order[ordnumber - 1].numberOrder > 0 && order[ordnumber - 1].name == customername)
                                {
                                    order[ordnumber - 1].ShowInfo();
                                    order[ordnumber - 1].numberOrder = 0;
                                    Console.WriteLine("Order was deleted.\n");
                                    count--;
                                }
                                else
                                    Console.WriteLine("\nOrder not found.");
                            }
                            else
                                Console.WriteLine("\nOrder not found.");
                        }
                        else
                            Console.Write("Array is empty!\n");
                        break;
                    case "5":
                        menu = false;
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid value. Enter your choise again.");
                        break;
                }
            }
        }
    }
}
