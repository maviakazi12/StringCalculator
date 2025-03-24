public class StringCalculator
{
    public int Add(string numbers)
    {
        string delimeter;
        List<string> result = new List<string>();
        int start = 0;
        int end = 0;
        if (numbers == "") return 0;
        if (numbers.StartsWith("//"))
        {
            if (numbers.Contains("[")&& numbers.Contains("]")){
                start = numbers.IndexOf("[") + 1;
                end = numbers.IndexOf("]");
            }else{
                start = numbers.IndexOf("//")+2;
                end = numbers.IndexOf('\n');
            }
            
            delimeter = numbers.Substring(start, end - start);
            char[] charsToRemove = { '/', '\\', '\n', '[', ']' };
            string newNumbers = new string(numbers.Where(n => !charsToRemove.Contains(n)).ToArray());
            result = newNumbers.Split(new string[] { delimeter }, StringSplitOptions.RemoveEmptyEntries).ToList();
            // numbers = newNumbers;
        }
        ;
        if (!result.Any())
        {
            result = numbers
        .Split(',', '\n', ';').ToList()
        .Where(s => !string.IsNullOrWhiteSpace(s))
        .ToList();
        }

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
                {
                    if (resultNumber >= 1000)
                    {
                        continue;
                    }
                    else
                    {
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

