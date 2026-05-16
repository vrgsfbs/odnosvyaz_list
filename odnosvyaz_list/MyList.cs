using System;
using System.Collections;
using System.Collections.Generic;

namespace lab7;

public class Node<T> //  Элементы списка реализовать как экземпляры класса.
{
    public T Data { get; set; } // значение переменной 
    public Node<T>? Next { get; set; } // ссылка на некст экземпляр класса
    public Node<T>? Prev {get;set;}

    public Node(T data)
    {
        Data = data;
    }
    // все наши элементы это экземпляры класса, 
    // которые не хранятся в определенной последовательности от первого элемента (индексы шаришь как работают да)
    // и получается .next у нас в каждом экземпляре ссылается на некст экземпляр, который находится в совершенно другой ячейке памяти
}

public class MyList<T> : IEnumerable<T>//  Создать класс для работы с однонаправленным линейным списком.
{

// 1. Добавление элемента в начало списка
// 2. Добавление элемента в конец списка
// 3. Вывод списка на экран в прямом и обратном порядке
// 4. Поиск элемента по его значению (возвращает bool)
// 5. Поиск элемента по номеру (возвращает значение)
// 6. Добавление элемента перед заданным
// 7. Добавление элемента после заданного
// 8. Удаление элемента из начала списка
// 9. Удаление элемента из конца
// списка 10.Удаление элемента перед
// заданным
// 11.Удаление элемента после заданного
    private Node<T>? tail;
    private Node<T>? head;
    public int Count { get; set; }
    // 3. Вывод списка на экран
    public void WriteList()
    {
        Node<T>? cont = head;
        if (head == null)
        {
            System.Console.WriteLine("list empty"); return;
        }
        while (cont != null)
        {
            System.Console.WriteLine($"el: {cont!.Data}");
            cont = cont.Next;
        }
    }
    
    // 1. Добавление элемента в начало списка
    // 2. Добавление элемента в конец списка
    public void AddLast(T item)
    {
        Node<T> node = new Node<T>(item);

        if (head == null) head = node;
        else tail!.Next = node;

        tail = node;
        Count++;
    }
    public void AddFirst(T item)
    {
        Node<T> node = new Node<T>(item);
        if (head == null) tail = node;
        else node.Next = head;

        head = node;
        Count++;
    }
    // 8. Удаление элемента из начала списка
    // 9. Удаление элемента из конца списка
    public void DelFirst() // 1
    {
        if (head == null) return;
        head = head.Next;
        Count--;
    }
    public void DelLast() // last
    {
        if (head == null) return;
        if (head.Next == null)
        {
            head = null;
            tail = null;
            Count--;
            return;
        }
        Node<T> cont = head;
        for (int i = 0; i < Count; i++)
        {
            if (i == (Count - 2)) break;
            cont = cont.Next!;
        }
        cont.Next = null;
        tail = cont;
        Count--;
    }

    // 4. Поиск элемента по его значению (возвращает bool)
    // 5. Поиск элемента по номеру (возвращает значение)
    public bool FindElBoll(T item)
    {
        Node<T>? find = head;
        if (head == null) return false;

        while (find != null)
        {
            if (find!.Data!.Equals(item))
            {
                return true;
            }
            find = find.Next;
        }
        return false;
    }

    public T FindElNum(int item)
    {
        Node<T>? find = head;
        if (item < 0 || item >= Count) return default!;
        else
        {
            for (int i = 0; i < item; i++)
            {
                find = find!.Next;
            }
        }
        return find!.Data;
    }
    // 6. Добавление элемента перед заданным
    // 7. Добавление элемента после заданного
    // переписать значение next для пред элемента и значение next для нового элемента
    public bool AddBeforeEl(T item, T findItem) // перед эл
    {
        bool isok = false;
        Node<T>? find = head;
        Node<T> node = new Node<T>(item);
        if (head == null)
        {
            head = node;
            tail = node;
            Count++;

            return true;
        }
        else if (head!.Data!.Equals(findItem))
        {
            AddFirst(item);
            return true;
        }
        else
        {
            while (find!.Next != null)
            {
                if (find!.Next!.Data!.Equals(findItem))
                {
                    isok = true;
                    break;
                }
                find = find.Next;
            }
            if (!isok)
            {
                return false;
            }
            node.Next = find!.Next;
            find.Next = node;

        }
        Count++;
        return true;
    }
    public bool AddAfterEl(T item, T findItem) // после эл
    {
        bool isok = false;
        Node<T>? find = head;
        Node<T> node = new Node<T>(item);
        if (head == null)
        {
            head = node;
            Count++;
            return true;
        }
        else if (tail!.Data!.Equals(findItem))
        {
            AddLast(item);
            return true;
        }
        else
        {
            while (find!.Next != null)
            {
                if (find!.Data!.Equals(findItem))
                {
                    isok = true;
                    break;
                }
                find = find.Next;
            }
            if (!isok)
            {
                return false;
            }
            node.Next = find!.Next;
            find.Next = node;

        }
        Count++;
        return true;
    }
    // 10. Удаление элемента перед заданным
    // 11.Удаление элемента после заданного
    public bool DelBeforeEl(T findItem) // перед эл
    {
        bool isok = false;
        Node<T>? find = head;
        if (head == null || head.Next == null) return false;

        else
        {
            while (find!.Next != null && find!.Next.Next != null)
            {
                if (find!.Next!.Next!.Data!.Equals(findItem))
                {
                    isok = true;
                    break;
                }
                find = find.Next;
            }
            if (!isok) return false;
            find.Next = find!.Next!.Next;

        }
        Count--;
        return true;
    }
    public bool DelAfterEl(T findItem) // после эл
    {
        bool isok = false;
        Node<T>? find = head;
        if (head == null || head.Next == null || tail!.Data!.Equals(findItem))
        {
            return false;
        }
        if (head!.Data!.Equals(findItem))
        {
            if (head.Next == tail) tail = head;
            head.Next = head.Next.Next;
            Count--;
            return true;
        }
        else
        {
            while (find!.Next != null)
            {
                if (find!.Data!.Equals(findItem))
                {
                    isok = true;
                    break;
                }
                find = find.Next;
            }
            if (!isok) return false;
            if (find.Next == tail)
            {
                tail = find;
            }
            find.Next = find!.Next!.Next;

        }
        Count--;
        return true;
    }
    //  Класс должен содержать переопределенный метод ToString() и реализовывать
    // интерфейс IEnumerable.
    public override string ToString() // эта хуйня тоже чисто в консольку насрать без циклов
    {
        if (head == null) return "Список пуст";

        var sb = new System.Text.StringBuilder(); // стрингбилдер это сложение строк, чтобы не ебаться с +
        Node<T>? current = head;

        while (current != null)
        {
            sb.Append($"[{current.Data}]"); // это сам элемент
            if (current.Next != null) sb.Append(" -> "); // чисто для кайфа стрелочка между элементами
            current = current.Next;
        }

        return sb.ToString(); // вызов примерно такой: Console.WriteLine(MyList); [1] -> [2] -> [3] и так далее
    }


    IEnumerator<T> IEnumerable<T>.GetEnumerator() // эта хуйня дает возможность работать с элементами как с массивом
    {
        Node<T>? current = head; //создали экземпляр
        while (current != null)
        {
            yield return current.Data; // этот yield укидает элементы в foreach. нам нужен для вывода в консоль без while
            current = current.Next; // крч получится чисто вывод writeline через цикл но 1 строкой
        }
    }

    IEnumerator IEnumerable.GetEnumerator() // вызов самого метода (без этого не работает)
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    //     16. Удалить из непустого списка за каждым вхождением элемента Е один
    // элемент, если такой есть.

    public void Task(T item) // item = E
    {
        if (head == null) return;
        Node<T>? find = head;
        while (find != null)
        {
            if (find!.Data!.Equals(item))
            {


                if (find!.Next != null)
                {
                    if (find.Next == tail) tail = find;
                    find.Next = find!.Next!.Next;
                    Count--;
                    continue;
                }
            }
        }
        find = find!.Next;
    }
}