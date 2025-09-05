// See https://aka.ms/new-console-template for more information
namespace ManageArray;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        /*
        string[] fradulentOrderIds = new string[3];
        fradulentOrderIds [0] = "A123";
        fradulentOrderIds [1] = "B456";
        fradulentOrderIds [2] = "C789";
        */
        //string[] fradulentOrderIds = new string[3] { "A123", "B456", "C789" };
        //string[] fradulentOrderIds = { "A123", "B456", "C789" }; //Older syntax
        string[] fradulentOrderIds = ["A123", "B456", "C789"]; //Newer syntax
        Console.WriteLine($"First: {fradulentOrderIds[0]}");
        Console.WriteLine($"Second: {fradulentOrderIds[1]}");
        Console.WriteLine($"Third: {fradulentOrderIds[2]}");

        fradulentOrderIds[2] = "F000";
        Console.WriteLine($"Reassigned Third: {fradulentOrderIds[2]}");

        Console.WriteLine($"There are {fradulentOrderIds.Length} fraudulent orders to process.");
    }

}
