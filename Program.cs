using System;
using System.Collections.Generic;

namespace Receipt
{
    struct Chek
    {
        // Поля для хранения информации об адресе, номере телефона, названии документа и дате
        public string Location;
        public string Phone;
        public string DocumentName;
        public DateTime Date;
        // Коллекция для хранения списка товаров
        public List<Item> Items;

        // Структура "Товар"
        public struct Item
        {
            // Поля для хранения информации о наименовании, количестве, цене за единицу и скидке
            public string Name;
            public int Quantity;
            public double UnitPrice;
            public double Discount;

            // Конструктор для создания нового товара
            public Item(string name, int quantity, double unitPrice, double discount)
            {
                Name = name;
                Quantity = quantity;
                UnitPrice = unitPrice;
                Discount = discount;
            }

            // Вычисление общей стоимости товара с учетом скидки
            public double GetTotalPrice()
            {
                return (UnitPrice - Discount) * Quantity;
            }
        }

        // Добавление нового товара в чек
        public void AddItem(string name, int quantity, double unitPrice, double discount)
        {
            // Инициализация списка товаров, если он еще не был создан
            if (Items == null)
            {
                Items = new List<Item>();
            }

            // Добавление нового товара в список
            Items.Add(new Item(name, quantity, unitPrice, discount));
        }

        // Печать чека
        public void PrintChek()
        {
            Console.WriteLine($"---------------------------------------------");
            Console.WriteLine($"\t    {Location}\n");
            Console.WriteLine($"\t    Т: {Phone}\n");
            Console.WriteLine($"\t    {Date}\n");
            Console.WriteLine($"=============================================");
            Console.WriteLine($"\n\t    {DocumentName}\n");
            Console.WriteLine($"=============================================");

            Console.WriteLine("\n Список товаров:\n");
            Console.WriteLine($"*********************************************\n");
            double total = 0;
            foreach (var item in Items)
            {
                Console.WriteLine($" {item.Name} ............................. х {item.Quantity} шт\n\n" +
                    $"      1 х {item.Quantity}  {item.UnitPrice.ToString("F2")} грн............ {item.GetTotalPrice().ToString("F2")} грн.\n\n" +
                    $"      Скидка .................... - {item.Discount.ToString("F2")} грн.\n");
                total += item.GetTotalPrice();
            }

            Console.WriteLine($"********************************************");
            Console.WriteLine($"\nИтого: .......................... {total.ToString("F2")} грн.\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание нового чека и заполнение его информацией 
            Chek chek = new Chek();
            chek.Location = "Одесса, ул. Гранитная 48";
            chek.Phone = "+380999219011";
            chek.Date = DateTime.Now;
            chek.DocumentName = "Товарный чек";

            // Добавление товаров в чек
            chek.AddItem("Молоко", 2, 50.0, 5.0);
            chek.AddItem("Хлеб", 1, 30.0, 2.50);
            chek.AddItem("Яйца", 10, 6.0, 0.0);

            // Печать чека
            chek.PrintChek();
        }
    }
}
