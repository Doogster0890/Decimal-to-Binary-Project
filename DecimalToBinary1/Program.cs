// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.Write("What number do you want to convert to binary? ");
int input = -1;
try
{
    input = Int32.Parse(Console.ReadLine());
}
catch (Exception ex){}

while (input < 0)
{
    Console.Write("Must enter a non-negative integer. Try again: ");
    try
    {
        input = Int32.Parse(Console.ReadLine());
    }
    catch(Exception ex){}
}

// Function to perform the conversion:
int Convert(int num)
{
    // If argument is 0, return 0:
    if (num == 0)
    {
        return 0;
    }
    // If argument is 1, return 1:
    if (num == 1)
    {
        return 1;
    }
    // If argument is any other number:
    int counter = 0; // Counter for how many times num is divisible by 2.
    int numOriginal = num;
    do
    {
        // Add up how many times num is divisible by 2:
        if (num / 2 > 0)
        {
            counter++;
        }
        num /= 2;
    } while (num > 0);

    // Do 2^counter to determine the closest "prime" binary number (ex. 1, 2, 4, 8, 16, etc.) to the input number. Store result in binary and decimal form:
    int resultBinary = 1;
    int resultDecimal = 1;
    for (int i = counter; i > 0; i--)
    {
        resultBinary *= 10;
        resultDecimal *= 2;
    }
    // Determine the remainder of the argument number divided by the decimal form of the above prime binary number:
    int remainder = numOriginal % resultDecimal;
    // Convert the remainder to binary using recursion and add to the existing binary result:
    resultBinary += Convert(remainder);

    // Return the final binary result:
    return resultBinary;
}

int binary = Convert(input);
Console.WriteLine($"The integer {input} converted to binary is: {binary}");