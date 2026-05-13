using System;

// Employee denis = new Manager();
// UseEmployee(denis);

// var message = "hello";
// if (message is "hello") {
//     Console.WriteLine("hello");
// }

// Employee? anton = new();
// Employee? max = null;
// UseEmployee(anton);
// UseEmployee(max);

// Employee bob = new Manager() { IsOnVacation = true };
// Employee tom = new Manager() { IsOnVacation = false };
// UseEmployee(tom);
// UseEmployee(bob);

// void UseEmployee(Employee? emp)
// {
//     if (emp is Manager manager && manager.IsOnVacation == false)
//     {
//         manager.Work();
//     }
//     else
//     {
//         switch (emp)
//         {
//             case Manager m when !m.IsOnVacation:
//                 m.Work();
//                 break;
//             case null:
//                 Console.WriteLine("Employee is null");
//                 break;
//             default:
//                 Console.WriteLine("Employee does not work");
//                 break;
//         }
//     }
// }


Person alexander = new() { Language = "english", Status = "user", Name = "Alexander" };
Person max = new() { Language = "french", Status = "user", Name = "Max" };
Person admin = new Person { Language = "english", Status = "admin", Name = "Admin" };

SayHello(alexander);
SayHello(max);
SayHello(admin);

string message = GetMessage(max);
Console.WriteLine(message);

Person pablo = new Person { Language = "spanish", Status = "user", Name = "Pablo" };
Console.WriteLine(GetMessage(pablo));
Console.WriteLine(GetMessage(null));

void SayHello(Person person) {
    if (person is Person { Language: "english", Status: "admin" }) {
        Console.WriteLine("Hello, admin");
    }
    else if (person is Person { Language: "french" }) {
        Console.WriteLine("Salute");
    }
    else {
        Console.WriteLine("Hello");
    }
}

string GetMessage(Person? p) => p switch {
    { Language: "english" } => "Hello!",
    { Language: "german", Status: "admin" } => "Hallo, admin!",
    { Language: "french" } => "Salute!",
    { } => "undefined",
    null => "null"
};