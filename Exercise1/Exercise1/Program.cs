// Exercise 1: LINQ Query

// 1. Create a list of integers from 1 to 100.
List<int> numbers = Enumerable.Range(1, 100).ToList();

// 2. Use LINQ to find all even numbers in the list and print them
List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
Console.WriteLine("Use LINQ to find all even numbers in the list and print them:");
Console.WriteLine(string.Join(", ", evenNumbers));

// Print two new lines to make the result look better
Console.WriteLine("");

// 3. Use LINQ to find all numbers in the original list that are divisible by 3 or 5, but not 3 and 5
List<int> divisibleBy3Or5 = numbers.Where(n => (n % 3 == 0 || n % 5 == 0) && !(n % 3 == 0 && n % 5 == 0)).ToList();
Console.WriteLine("Use a loop to find all of the numbers in the original list that are divisible by 3 or 5, but not 3 and 5. The result should be:");
Console.WriteLine(string.Join(", ", divisibleBy3Or5));

// Ensure the console window wouldn't close
Console.ReadLine();
