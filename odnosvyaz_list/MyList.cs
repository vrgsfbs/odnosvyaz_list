using System;
using System.Collections;
using System.Collections.Generic;

namespace lab7;

public class Node<T> 
{
    public T Data { get; set; } // значение переменной 
    public Node<T>? Next { get; set; } // ссылка на некст экземпляр класса
    public Node<T>? Prev {get;set;}

    public Node(T data)
    {
        Data = data;
    }

}

public class MyList<T> : IEnumerable<T>
{


    private Node<T>? tail;
    private Node<T>? head;
    public int Count { get; set; }
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

    public void DelFirst()
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
    public bool AddBeforeEl(T item, T findItem) 
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
    public bool AddAfterEl(T item, T findItem) 
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
    
    public bool DelBeforeEl(T findItem) 
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
    public bool DelAfterEl(T findItem) 
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

    public override string ToString() 
    {
        if (head == null) return "Список пуст";

        var sb = new System.Text.StringBuilder(); 
        Node<T>? current = head;

        while (current != null)
        {
            sb.Append($"[{current.Data}]"); 
            if (current.Next != null) sb.Append(" -> "); 
            current = current.Next;
        }

        return sb.ToString(); 
    }


    IEnumerator<T> IEnumerable<T>.GetEnumerator() 
    {
        Node<T>? current = head; 
        while (current != null)
        {
            yield return current.Data; 
            current = current.Next; 
        }
    }

    IEnumerator IEnumerable.GetEnumerator() 
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }



      public void Task(T item) 
    {
        if (head == null) return;
        
        Node<T>? current = head;
        
        while (current != null)
        {
            Node<T> duplicate = new Node<T>(current.Data);
            
            duplicate.Next = current.Next;
            current.Next = duplicate;
            
            if (duplicate.Next == null)
            {
                tail = duplicate;
            }
            
            current = duplicate.Next;
            
            Count++;
        }
    }
}