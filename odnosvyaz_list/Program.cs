﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace lab7;

class Program
{
    static void Main(string[] args)
    {
        MyList<string> myList = new MyList<string>(); // создать объект пользовательского класса
        ConsoleKeyInfo K;
        do
        {
            Console.Clear(); //очистка экрана перед выводом меню
            Console.WriteLine($"Текущее количество элементов: {myList.Count}");
            Console.WriteLine("1. Добавить элемент в начало списка");
            Console.WriteLine("2. Добавить элемент в конец списка");
            Console.WriteLine("3. Вывести список (в прямом порядке)");
            Console.WriteLine("5. Поиск элемента по значению (bool)");
            Console.WriteLine("6. Поиск элемента по номеру (значение)");
            Console.WriteLine("7. Добавить элемент перед заданным");
            Console.WriteLine("8. Добавить элемент после заданного");
            Console.WriteLine("9. Удалить элемент из начала списка");
            Console.WriteLine("10. Удалить элемент из конца списка");
            Console.WriteLine("11. Удалить элемент перед заданным");
            Console.WriteLine("12. Удалить элемент после заданного");
            Console.WriteLine("13. Вывести список (ToString)");
            Console.WriteLine("14. Выполнить задание (удалить за каждым E один элемент)");
            Console.WriteLine("15. Очистить список");
            Console.WriteLine("Esc. Выход из программы");
            Console.Write("Выберите пункт меню: ");
            
            K = Console.ReadKey(); //считывание кода вводимой клавиши
            Console.WriteLine();
            
            switch (K.Key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1: // Добавление в начало
                {
                    Console.Write("Введите значение для добавления в начало: ");
                    string input = Console.ReadLine()!;
                    myList.AddFirst(input);
                    Console.WriteLine($"Элемент '{input}' добавлен в начало списка");
                    break;
                }
                case ConsoleKey.D2: case ConsoleKey.NumPad2: // Добавление в конец
                {
                    Console.Write("Введите значение для добавления в конец: ");
                    string input = Console.ReadLine()!;
                    myList.AddLast(input);
                    Console.WriteLine($"Элемент '{input}' добавлен в конец списка");
                    break;
                }
                case ConsoleKey.D3: case ConsoleKey.NumPad3: // Вывод в прямом порядке
                {
                    Console.WriteLine("\nСписок в прямом порядке:");
                    myList.WriteList();
                    break;
                }

                case ConsoleKey.D5: case ConsoleKey.NumPad5: // Поиск по значению (bool)
                {
                    Console.Write("Введите значение для поиска: ");
                    string input = Console.ReadLine()!;
                    bool found = myList.FindElBoll(input);
                    if (found)
                        Console.WriteLine($"Элемент '{input}' НАЙДЕН в списке");
                    else
                        Console.WriteLine($"Элемент '{input}' НЕ НАЙДЕН в списке");
                    break;
                }
                case ConsoleKey.D6: case ConsoleKey.NumPad6: // Поиск по номеру (значение)
                {
                    Console.Write("Введите номер элемента (индекс от 0): ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        if (index >= 0 && index < myList.Count)
                        {
                            var value = myList.FindElNum(index);
                            Console.WriteLine($"Элемент с индексом {index}: {value}");
                        }
                        else
                        {
                            Console.WriteLine($"Ошибка: индекс {index} вне диапазона (0-{myList.Count - 1})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите корректное число");
                    }
                    break;
                }
                case ConsoleKey.D7: case ConsoleKey.NumPad7: // Добавление перед заданным
                {
                    Console.Write("Введите значение, перед которым нужно добавить: ");
                    string findItem = Console.ReadLine()!;
                    Console.Write("Введите новое значение для добавления: ");
                    string newItem = Console.ReadLine()!;
                    bool result = myList.AddBeforeEl(newItem, findItem);
                    if (result)
                        Console.WriteLine($"Элемент '{newItem}' добавлен перед '{findItem}'");
                    else
                        Console.WriteLine($"Ошибка: элемент '{findItem}' не найден в списке");
                    break;
                }
                case ConsoleKey.D8: case ConsoleKey.NumPad8: // Добавление после заданного
                {
                    Console.Write("Введите значение, после которого нужно добавить: ");
                    string findItem = Console.ReadLine()!;
                    Console.Write("Введите новое значение для добавления: ");
                    string newItem = Console.ReadLine()!;
                    bool result = myList.AddAfterEl(newItem, findItem);
                    if (result)
                        Console.WriteLine($"Элемент '{newItem}' добавлен после '{findItem}'");
                    else
                        Console.WriteLine($"Ошибка: элемент '{findItem}' не найден в списке");
                    break;
                }
                case ConsoleKey.D9: case ConsoleKey.NumPad9: // Удаление из начала
                {
                    if (myList.Count > 0)
                    {
                        myList.DelFirst();
                        Console.WriteLine("Элемент удален из начала списка");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: список пуст");
                    }
                    break;
                }
                case ConsoleKey.F1: // Удаление из конца
                {
                    if (myList.Count > 0)
                    {
                        myList.DelLast();
                        Console.WriteLine("Элемент удален из конца списка");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: список пуст");
                    }
                    break;
                }
                case ConsoleKey.F2:  // Удаление перед заданным
                {
                    Console.Write("Введите значение, перед которым нужно удалить элемент: ");
                    string findItem = Console.ReadLine()!;
                    bool result = myList.DelBeforeEl(findItem);
                    if (result)
                        Console.WriteLine($"Элемент ПЕРЕД '{findItem}' успешно удален");
                    else
                        Console.WriteLine($"Ошибка: невозможно удалить элемент перед '{findItem}'");
                    break;
                }
                case ConsoleKey.F3:  // Удаление после заданного
                {
                    Console.Write("Введите значение, после которого нужно удалить элемент: ");
                    string findItem = Console.ReadLine()!;
                    bool result = myList.DelAfterEl(findItem);
                    if (result)
                        Console.WriteLine($"Элемент ПОСЛЕ '{findItem}' успешно удален");
                    else
                        Console.WriteLine($"Ошибка: невозможно удалить элемент после '{findItem}'");
                    break;
                }
                case ConsoleKey.F4:  // Вывод ToString
                {
                    Console.WriteLine($"\nСписок (ToString): {myList.ToString()}");
                    break;
                }
                case ConsoleKey.F5:  // Выполнить задание
                {
                    if (myList.Count > 0)
                    {
                        Console.Write("Введите значение E (элемент, после которого будут удаляться элементы): ");
                        string itemE = Console.ReadLine()!;
                        int oldCount = myList.Count;
                        myList.Task(itemE);
                        Console.WriteLine($"Задание выполнено. Удалено {oldCount - myList.Count} элемент(ов)");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: список пуст");
                    }
                    break;
                }
                case ConsoleKey.F6: // Очистить список
                {
                    while (myList.Count > 0)
                    {
                        myList.DelFirst();
                    }
                    Console.WriteLine("Список полностью очищен");
                    break;
                }
                default: 
                {
                    if (K.Key != ConsoleKey.Escape)
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
                }
            }
            // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
            if (K.Key != ConsoleKey.Escape)
            {
                System.Threading.Thread.Sleep(2000); // 2 сек.
            }
        }
        while (K.Key != ConsoleKey.Escape);// цикл заканчивается, если нажата клавиша Esc
        
        Console.WriteLine("\nПрограмма завершена. Нажмите любую клавишу...");
        Console.ReadKey();
    }
}