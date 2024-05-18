using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using lab10;
using lab12_1;
using lab121;

namespace lab12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size1 = 0;
            MyList<Carriage> list1 = new MyList<Carriage>();
            bool flag = false;
            do
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Сформировать двунаправленный список, в информационное поле записать объекты из иерархии классов лабораторной работы 10.");
                Console.WriteLine("2. Распечатать полученный список.");
                Console.WriteLine("3. Задания");
                Console.WriteLine("4. Выполнить глубокое клонирование списка");
                Console.WriteLine("5. Удалить список из памяти.");
                Console.WriteLine("6. Выход");

                int choice = GetIntInput("Введите номер пункта меню (1-6): ", 1, 6);

                switch (choice)
                {
                    case 1:
                        size1 = GetIntInput("Введите размер списка для Carriage: ", 1, 100);
                        list1 = new MyList<Carriage>(size1);
                        list1.PrintList();
                        break;
                    case 2:
                        if (list1.IsEmpty())
                        {
                            Console.WriteLine("\nСписок пустой");
                        }
                        else
                        {
                            list1.PrintList();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Меню:");
                        Console.WriteLine("1. Удалить из списка первый элемент с заданным информационным полем");
                        Console.WriteLine("2. Добавить в список элементы с номерами 1, 3, 5 и т.д.");
                        Console.WriteLine("3. Назад");
                        int answer = GetIntInput("Введите номер пункта меню (1-3): ", 1, 3);
                        switch (answer)
                        {
                            case 1:
                                if (list1.IsEmpty())
                                {
                                    Console.WriteLine("\nСписок пустой, элемент не могут быть удалены");
                                }
                                else
                                {
                                    int indexToRemove = GetIntInput("Введите позицию элемента для удаления: ", 1, size1);
                                    list1.RemoveFirst(indexToRemove - 1); // Позиции в списке начинаются с 1, поэтому вычитаем 1
                                    Console.WriteLine("\nПосле удаления");
                                    list1.PrintList();
                                }
                                break;
                            case 2:
                                Carriage newCarriage = new Carriage(new IdNumber(5), 5, 5);
                                list1.AddToOddPositions(newCarriage);
                                Console.WriteLine("\nПосле добавления");
                                list1.PrintList();
                                break;
                            case 3:
                                flag = true;
                                break;
                        }

                        break;
                    case 4:
                        if (list1.IsEmpty())
                        {
                            Console.WriteLine("\nСписок пустой");
                        }
                        else
                        {
                            MyList<Carriage> clonedList = list1.DeepClone();
                            Console.WriteLine("\nСкопированный список");
                            clonedList.PrintList();
                        }

                        break;
                    case 5:
                        if (list1.IsEmpty())
                        {
                            Console.WriteLine("\nСписок пустой, элемент не может быть удален.");
                        }
                        else
                        {
                            list1.Clear();
                            Console.WriteLine("\nСписок удален из памяти");
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            } while (flag = true);
        }

        static int GetIntInput(string prompt, int min, int max)
        {
            int value = -1;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value >= min && value <= max)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Введите число от {0} до {1}.", min, max);
                }
            }

            return value;
        }
    }
}
