public class StringCalculator
{
    public int add(string numbers)
    {
        if (numbers == "") return 0;
        if (numbers.Contains("//"))
        {
            char[] charsToRemove = { '/', '\\', '\n' };
            string newNumbers = new string(numbers.Where(c => !charsToRemove.Contains(c)).ToArray());
            numbers = newNumbers;
        }

        List<string> result = numbers
        .Split(',', '\n', ';').ToList()
        .Where(s => !string.IsNullOrWhiteSpace(s))
        .ToList();
        int sum = 0;
        List<int> negativeNumbers = new List<int>();
        foreach (var num in result)
        {
            if (int.TryParse(num, out int resultNumber))
            {
                if (resultNumber < 0)
                {
                    negativeNumbers.Add(resultNumber);
                }
                else
                {   if (resultNumber>= 1000){
                    continue;
                }else{
                    sum += resultNumber;
                }
                    
                }
            }
        }
        if (negativeNumbers.Any())
        {
            throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
        }
        return sum;
        //    Console.WriteLine(string.Join(", ",result));

    }
}

