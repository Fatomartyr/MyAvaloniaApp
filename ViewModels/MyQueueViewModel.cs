
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyAvaloniaApp.Models;

namespace MyAvaloniaApp.ViewModels;

public partial class MyQueueViewModel : ObservableObject 
{
    private MyQueue<string> _queue = new MyQueue<string>();
    [ObservableProperty] private string? inputText;
    [ObservableProperty] private string? currentItem;
    public ObservableCollection<string> QueueItems { get; } = new();
    public MyQueueViewModel()
    {
        UpdateQueue();
    }
    [RelayCommand]
    private void Enqueue()
    {
        if (!string.IsNullOrWhiteSpace(InputText))
        {
            _queue.Enqueue(InputText);
            CurrentItem = _queue.Current;
            InputText = string.Empty;
            UpdateQueue();
        }
    }
    [RelayCommand]
    private void Dequeue()
    {
        if (!_queue.IsEmpty)
        {
            _queue.Dequeue();
            UpdateQueue();
        }
    }

    [RelayCommand]
    private void ClearQueue()
    {
        _queue.Clear();
        UpdateQueue();
    }

    [RelayCommand]
    private void MoveNext()
    {
        _queue.MoveCurrent();
        CurrentItem = _queue.Current;
    }
    private void UpdateQueue()
    {
        QueueItems.Clear(); 
        var tempQueue = new MyQueue<string>();

        while (!_queue.IsEmpty)
        {
            string item = _queue.Dequeue();
            QueueItems.Add(item);
            tempQueue.Enqueue(item);
        }
        _queue = tempQueue; 
        CurrentItem = _queue.Current; 
    }

    
}