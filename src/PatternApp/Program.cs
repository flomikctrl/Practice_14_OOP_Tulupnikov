using System;

Employee denis = new Manager();
UseEmployee(denis);

var message = "hello";
if (message is "hello") {
    Console.WriteLine("hello");
}

Employee? anton = new();
Employee? max = null;
UseEmployee(anton);
UseEmployee(max);

Employee bob = new Manager() { IsOnVacation = true };
Employee tom = new Manager() { IsOnVacation = false };
UseEmployee(tom);
UseEmployee(bob);

void UseEmployee(Employee? emp) {
    if (emp is Manager manager && manager.IsOnVacation == false) {
        manager.Work();
    }
    else {
        switch (emp) {
            case Manager m when !m.IsOnVacation:
                m.Work();
                break;
            case null:
                Console.WriteLine("Employee is null");
                break;
            default:
                Console.WriteLine("Employee does not work");
                break;
        }
    }
}