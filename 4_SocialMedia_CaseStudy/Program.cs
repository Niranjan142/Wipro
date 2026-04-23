using System;
using System.Collections.Generic;

class SocialMediaPlatform
{
    // Data Structures
    private List<string> posts = new List<string>();
    private Dictionary<string, int> likes = new Dictionary<string, int>();
    private HashSet<int> users = new HashSet<int>();
    private Stack<string> actions = new Stack<string>();
    private Queue<string> notifications = new Queue<string>();

    // Add User
    public void AddUser(int userId)
    {
        if (users.Add(userId))
            Console.WriteLine($"User {userId} added.");
        else
            Console.WriteLine($"User {userId} already exists.");
    }

    // Add Post
    public void AddPost(int userId, string post)
    {
        if (!users.Contains(userId))
        {
            Console.WriteLine("User not found.");
            return;
        }

        posts.Add(post);
        likes[post] = 0;
        actions.Push($"Post:{post}");
        notifications.Enqueue($"User {userId} added a post.");

        Console.WriteLine("Post added.");
    }

    // Like Post
    public void LikePost(string post)
    {
        if (likes.ContainsKey(post))
        {
            likes[post]++;
            actions.Push($"Like:{post}");
            notifications.Enqueue($"Post liked: {post}");
            Console.WriteLine("Post liked.");
        }
        else
        {
            Console.WriteLine("Post not found.");
        }
    }

    // Undo Last Action
    public void Undo()
    {
        if (actions.Count == 0)
        {
            Console.WriteLine("Nothing to undo.");
            return;
        }

        string lastAction = actions.Pop();
        string[] parts = lastAction.Split(':');

        if (parts[0] == "Post")
        {
            posts.Remove(parts[1]);
            likes.Remove(parts[1]);
            Console.WriteLine("Last post undone.");
        }
        else if (parts[0] == "Like")
        {
            if (likes.ContainsKey(parts[1]) && likes[parts[1]] > 0)
                likes[parts[1]]--;
            Console.WriteLine("Last like undone.");
        }
    }

    // Process Notifications
    public void ProcessNotifications()
    {
        while (notifications.Count > 0)
        {
            Console.WriteLine("Notification: " + notifications.Dequeue());
        }
    }

    // Display Posts
    public void ShowPosts()
    {
        Console.WriteLine("\nPosts & Likes:");
        foreach (var post in posts)
        {
            Console.WriteLine($"{post} - Likes: {likes[post]}");
        }
    }
}

class Program
{
    static void Main()
    {
        SocialMediaPlatform app = new SocialMediaPlatform();

        app.AddUser(1);
        app.AddUser(2);
        app.AddUser(1); // duplicate check

        app.AddPost(1, "Trip!!!");
        app.AddPost(2, "AI is booming");

        app.LikePost("Trip!!!");
        app.LikePost("Trip!!!");
        app.ShowPosts();

        app.Undo(); // undo like
        app.ShowPosts();

        app.ProcessNotifications();
    }
}
