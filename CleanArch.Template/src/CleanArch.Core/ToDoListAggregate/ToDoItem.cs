using System;

namespace CleanArch.Core.ToDoListAggregate;

public class ToDoItem
{
    public int Id { get; private set; }

    public string Title { get; private set; }

    public bool IsCompleted { get; private set; }

    public DateTimeOffset? CompletedOnUtc { get; private set; }

    // Aggregate-level order within a list
    public int Order { get; private set; }

    // For persistence
    private ToDoItem() { }

    internal ToDoItem(string title, int order)
    {
        Title = title;
        Order = order;
        IsCompleted = false;
    }

    public void Complete()
    {
        if (IsCompleted) return;

        IsCompleted = true;
        CompletedOnUtc = DateTimeOffset.UtcNow;
    }

    public void Reopen()
    {
        if (!IsCompleted) return;

        IsCompleted = false;
        CompletedOnUtc = null;
    }

    public void Rename(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title must be provided.", nameof(title));

        Title = title.Trim();
    }

    internal void SetOrder(int order)
    {
        if (order < 1) throw new ArgumentOutOfRangeException(nameof(order), "Order must be >= 1.");
        Order = order;
    }
}
