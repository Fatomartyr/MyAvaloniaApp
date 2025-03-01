using System;

namespace MyAvaloniaApp.Models;

public class MyQueue<T>
{
    private class Node
    {
        public T Data { get; set;}
        public Node? Next { get; set; }

        public Node (T data) { Data = data; Next = null; }
    }
    
    private Node? _head;
    private Node? _tail;
    private Node? _current;
    private int _count; 

    public int Count => _count;
    public bool IsEmpty => _count == 0;
    public T? Current => _current != null ? _current.Data : default;
    
    public MyQueue() {
        _head = null;
        _tail = null;
        _current = null;
        _count = 0;
    }
    
    public void Enqueue(T value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            if (_tail != null)
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
        }
        _count++;
        ResetCurrent();    
    }
    
    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Очередь пуста");
        }

        T val  = _head.Data;
        _head = _head.Next;
        if (_head == null)
        {
            _tail = null;
        }

        _count--;
        return val;
    }

    public void Clear()
    {
        _head = null;
        _tail = null;
        _current = null;
        _count = 0;
    }
    
    public void ResetCurrent()
    {
        _current = _head;
    }

    public bool MoveCurrent()
    {
        if (_current == null)
        {
            ResetCurrent();    
        }

        if (_current != null && _current.Next != null)
        {
            _current = _current.Next;
            return true;
        }

        return false;
    }
}