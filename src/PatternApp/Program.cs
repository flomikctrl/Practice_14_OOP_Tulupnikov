using System;
using System.Collections.Generic;

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

string GetMessage(Person? p) => p switch
{
    { Language: "english" } => "Hello!",
    { Language: "german", Status: "admin" } => "Hallo, admin!",
    { Language: "french" } => "Salute!",
    { } => "undefined",
    null => "null"
};


string message1 = GetWelcome("english", "evening");
Console.WriteLine(message1);

string message2 = GetWelcome("french", "morning");
Console.WriteLine(message2);

string GetWelcome(string lang, string daytime) => (lang, daytime) switch
{
    ("english", "morning") => "Good morning",
    ("english", "evening") => "Good evening",
    ("german", "morning") => "Guten Morgen",
    ("german", "evening") => "Guten Abend",
    (_, "admin") => "Hello, Admin",
    _ => "Добрый день"
};



Console.WriteLine(GetNumber([1, 2, 3, 4, 5]));
Console.WriteLine(GetNumber([1, 2]));
Console.WriteLine(GetNumber([]));
Console.WriteLine(GetNumber([1, 2, 5]));

int GetNumber(int[] values) => values switch
{
    [1, 2, 3, 4, 5] => 1,
    [1, 2, 3] => 2,
    [1, 2] => 3,
    [] => 4,
    _ => 5
};

List<int> numbers = [1, 2, 3];
Console.WriteLine(GetNumberList(numbers));

int GetNumberList(List<int> values) => values switch
{
    [1, 2, 3, 4, 5] => 1,
    [1, 2, 3] => 2,
    [1, 2] => 3,
    [] => 4,
    _ => 5
};



// Задание 1
DescribeAnimal(new Dog { Breed = "Лабрадор" });
DescribeAnimal(new Cat { IsIndoor = true });
DescribeAnimal(null);

// Задание 2
var p1 = new Product { Category = "food", Price = 500 };
var p2 = new Product { Category = "electronics", Country = "USA" };
Console.WriteLine(GetDiscount(p1));
Console.WriteLine(GetDiscount(p2));

// Задание 3
Console.WriteLine(GetTransport("Москва", "дождь", "день"));
Console.WriteLine(GetTransport("Москва", "солнце", "ночь"));
Console.WriteLine(GetTransport("Питер", "снег", "утро"));

// Задание 4
int[][] testArrays = [
    [1, 2, 3],
    [1, 5, 10],
    [1, 5, 6, 7, 9],
    [1, 2, 3, 4]
];

foreach (var arr in testArrays)
{
    Console.WriteLine(AnalyzeList(arr));
    SpecialLengthCheck(arr);
}

// Методы 
void DescribeAnimal(Animal? animal)
{
    switch (animal)
    {
        case Dog dog:
            Console.WriteLine($"Собака породы {dog.Breed}");
            break;
        case Cat cat:
            Console.WriteLine(cat.IsIndoor ? "Домашняя кошка" : "Уличная кошка");
            break;
        case null:
            Console.WriteLine("null");
            break;
        default:
            Console.WriteLine("Неизвестное животное");
            break;
    }
}

string GetDiscount(Product? p) => p switch
{
    { Category: "electronics", Country: "USA" } => "10% discount",
    { Category: "food", Price: var price } => $"5% discount ({price * 0.05} руб.)",
    { Category: "electronics" } => "7% discount",
    { } => "no discount",
    null => "invalid product"
};

string GetTransport(string city, string weather, string time) => (city, weather, time) switch
{
    ("Москва", "дождь", _) => "Берите такси",
    ("Москва", _, "ночь") => "Метро закрыто, берите такси",
    ("Москва", _, _) => "Можно на метро",
    (_, "снег", _) => "Сложная ситуация",
    _ => "Идите пешком"
};

string AnalyzeList(int[] numbers) => numbers switch
{
    [1, 2, 3] => "exact",
    [1, _, _] => "starts with 1",
    [1, .., 9] => "from 1 to 9",
    [var first, var second, .., var last] => $"first={first}, second={second}, last={last}",
    [..] => "other"
};

void SpecialLengthCheck(int[] numbers)
{
    if (numbers is { Length: 4 } and [var a, var b, var c, var d])
    {
        Console.WriteLine($"Length 4: {a}, {b}, {c}, {d}");
    }
}

// Классы 
public class Animal { }
public class Dog : Animal { public string Breed { get; set; } = ""; }
public class Cat : Animal { public bool IsIndoor { get; set; } }

public class Product
{
    public string Category { get; set; } = "";
    public string Country { get; set; } = "";
    public double Price { get; set; }
}