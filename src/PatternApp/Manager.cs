public class Manager : Employee {
    public override void Work() {
        Console.WriteLine("Manager works");
    }
    public bool IsOnVacation { get; set; }
}