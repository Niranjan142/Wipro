using System;
using System.Collections.Generic;

class TaskSchedulerSystem
{
    Queue<string> taskQueue = new Queue<string>();
    Stack<string> undoStack = new Stack<string>();
    List<string> allTasks = new List<string>();
    SortedDictionary<int, string> priorityTasks = new SortedDictionary<int, string>();
    HashSet<string> taskSet = new HashSet<string>();

    public void AddTask(string task, int priority)
    {
        if (!taskSet.Contains(task))
        {
            taskQueue.Enqueue(task);
            allTasks.Add(task);
            priorityTasks[priority] = task;
            taskSet.Add(task);
        }
        else
        {
            Console.WriteLine("Duplicate Task not allowed");
        }
    }

    public void ExecuteTask()
    {
        if (taskQueue.Count == 0) return;

        string task = taskQueue.Dequeue();
        undoStack.Push(task);
        Console.WriteLine("Executed: " + task);
    }

    public void UndoTask()
    {
        if (undoStack.Count == 0) return;

        string task = undoStack.Pop();
        Console.WriteLine("Undo: " + task);
    }

    public void DisplayAllTasks()
    {
        foreach (var t in allTasks)
            Console.WriteLine(t);
    }

    public void DisplayPriorityTasks()
    {
        foreach (var p in priorityTasks)
            Console.WriteLine(p.Key + " : " + p.Value);
    }

    public void DisplayQueue()
    {
        foreach (var t in taskQueue)
            Console.WriteLine(t);
    }
}

class Program
{
    static void Main()
    {
        TaskSchedulerSystem ts = new TaskSchedulerSystem();

        ts.AddTask("Backup", 3);
        ts.AddTask("Update", 1);
        ts.AddTask("Scan", 2);
        ts.AddTask("Backup", 3); // duplicate

        Console.WriteLine("All Tasks:");
        ts.DisplayAllTasks();

        Console.WriteLine("\nPriority Tasks:");
        ts.DisplayPriorityTasks();

        Console.WriteLine("\nExecuting Tasks:");
        ts.ExecuteTask();
        ts.ExecuteTask();

        Console.WriteLine("\nUndo Last Task:");
        ts.UndoTask();

        Console.WriteLine("\nRemaining Queue:");
        ts.DisplayQueue();
    }
}
