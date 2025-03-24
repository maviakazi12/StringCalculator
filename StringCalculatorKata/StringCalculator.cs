using System.Text.RegularExpressions;
public class StringCalculator
{
    public int Add(string numbers)
    {
        List<string> delimiter = new List<string>();
        List<string> result = new List<string>();
        int start = 0;
        int end = 0;
        if (numbers == "") return 0;
        if (numbers.StartsWith("//"))
        {
            if (numbers.Contains('[') && numbers.Contains(']'))
            {
                string pattern = @"\[(.*?)\]";
                MatchCollection matches = Regex.Matches(numbers, pattern);
                foreach(Match match in matches){
                    delimiter.Add(match.Groups[1].Value );
                }
            }
            else
            {
                start = numbers.IndexOf("//") + 2;
                end = numbers.IndexOf('\n');
                string singleDelimiter = numbers.Substring(start, end - start);
                delimiter.Add(singleDelimiter);
            }            
            char[] charsToRemove = { '/', '\\', '\n', '[', ']' };
            string numbersWithRemovedSymbols = new string(numbers.Where(n => !charsToRemove.Contains(n)).ToArray());
            result = numbersWithRemovedSymbols.Split(delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
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
    }
}

