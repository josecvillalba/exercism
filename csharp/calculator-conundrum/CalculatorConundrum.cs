using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {

        var str = $"{operand1} {operation} {operand2} = ";
        
        return operation switch
        {
            "+" => str + SimpleOperation.Addition(operand1, operand2).ToString(),

            "*" => str + SimpleOperation.Multiplication(operand1, operand2).ToString(),
            
            "/" when operand2 == 0 => "Division by zero is not allowed.",
            
            "/" => str + SimpleOperation.Division(operand1, operand2).ToString(),
            
            "" => throw new ArgumentException(),
            
            null => throw new ArgumentNullException(),
            
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
