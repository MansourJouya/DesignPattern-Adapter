using System;

/// <summary>
/// Target interface that clients expect to work with.
/// </summary>
public interface ITarget
{
    void Request();
}

/// <summary>
/// Adaptee class that has an interface incompatible with the target.
/// </summary>
public class Adaptee
{
    /// <summary>
    /// A method with a different interface that needs to be adapted.
    /// </summary>
    public void SpecificRequest()
    {
        Console.WriteLine("Specific request from Adaptee");
    }
}

/// <summary>
/// Adapter class that implements the ITarget interface and translates calls to the Adaptee.
/// </summary>
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    /// <summary>
    /// Initializes a new instance of the Adapter class.
    /// </summary>
    /// <param name="adaptee">The adaptee instance to be adapted.</param>
    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    /// <summary>
    /// Adapts the request method to call the adaptee's specific request.
    /// </summary>
    public void Request()
    {
        // Translation of the method call
        _adaptee.SpecificRequest();
    }
}

/// <summary>
/// Client code that uses the ITarget interface.
/// </summary>
public class Program
{
    /// <summary>
    /// The main entry point of the program.
    /// </summary>
    public static void Main()
    {
        // Create an instance of the Adaptee
        Adaptee adaptee = new Adaptee();

        // Create the adapter and pass the adaptee to it
        ITarget adapter = new Adapter(adaptee);

        // Call the adapted method through the adapter
        Console.WriteLine("Client code is calling the adapter:");
        adapter.Request();
    }
}
