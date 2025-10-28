namespace CleanArch.Core.ToDoListAggregate;

public class ToDoList
{
    public int Id { get; private set; }
    public string Name { get; private set; } = "Untitled List";

    private readonly List<ToDoItem> _items = [];
    public IReadOnlyCollection<ToDoItem> Items => _items.AsReadOnly();

    // Business rule: a list is completed when all items are completed (empty list => true).
    public bool IsCompleted => _items.All(item => item.IsCompleted);

    // For persistence
    private ToDoList() { }
    public ToDoList(string name)
    {
        Rename(name);
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("List name must be provided.", nameof(name));

        Name = name.Trim();
    }

    public ToDoItem AddItem(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Item title must be provided.", nameof(title));

        var normalized = title.Trim();

        // Invariant: avoid duplicate titles in a list (case-insensitive)
        if (_items.Any(i => string.Equals(i.Title, normalized, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"An item with the title '{normalized}' already exists.");

        var nextOrder = _items.Count == 0 ? 1 : _items.Max(i => i.Order) + 1;
        var item = new ToDoItem(normalized, nextOrder);

        _items.Add(item);
        return item;
    }

    public void RemoveItem(int itemId)
    {
        var item = FindItem(itemId);
        _items.Remove(item);

        // Compact orders to keep them contiguous
        var ordered = _items.OrderBy(i => i.Order).ToList();
        for (int i = 0; i < ordered.Count; i++)
        {
            ordered[i].SetOrder(i + 1);
        }
    }

    public void CompleteItem(int itemId)
    {
        var item = FindItem(itemId);
        item.Complete();
    }

    public void ReopenItem(int itemId)
    {
        var item = FindItem(itemId);
        item.Reopen();
    }

    public void RenameItem(int itemId, string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Item title must be provided.", nameof(newTitle));

        var normalized = newTitle.Trim();
        var item = FindItem(itemId);

        // Invariant: avoid duplicates after rename
        if (_items.Any(i => i.Id != item.Id &&
                            string.Equals(i.Title, normalized, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"An item with the title '{normalized}' already exists.");

        item.Rename(normalized);
    }

    public void ReorderItem(int itemId, int newOrder)
    {
        if (_items.Count <= 1) return;

        var item = FindItem(itemId);
        var oldOrder = item.Order;

        newOrder = Math.Clamp(newOrder, 1, _items.Count);
        if (newOrder == oldOrder) return;

        if (newOrder < oldOrder)
        {
            foreach (var it in _items.Where(i => i.Order >= newOrder && i.Order < oldOrder))
                it.SetOrder(it.Order + 1);
        }
        else
        {
            foreach (var it in _items.Where(i => i.Order <= newOrder && i.Order > oldOrder))
                it.SetOrder(it.Order - 1);
        }

        item.SetOrder(newOrder);
    }

    private ToDoItem FindItem(int itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);

        return item ?? throw new KeyNotFoundException($"Item with Id {itemId} was not found.");
    }
}
