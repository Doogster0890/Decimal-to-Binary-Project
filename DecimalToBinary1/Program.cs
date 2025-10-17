
Console.Write("What number do you want to convert to binary? (Non-negative integer) ");
int input = -1;
string inputText = "";
do
{
    inputText = Console.ReadLine();
    if (inputText != "") int.TryParse(Console.ReadLine(), out input);
    if (input < 0) Console.Write("Must enter a non-negative integer. Try again: ");
    
} while (input < 0);

// Convert the input to binary and display to the user:
Console.WriteLine($"The integer {input} converted to binary is: {Convert(input)}");
Console.Write("Press 'Enter' to exit...");
Console.ReadLine();

// Declaration of function to perform the conversion:
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
