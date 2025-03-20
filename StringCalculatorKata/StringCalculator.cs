public class StringCalculator
{
    public int calculateString(string numbers)
    {
       if (numbers == "") return 0;
       List<string> result = numbers.Split(',').ToList();
       int sum = 0;
       foreach (var num in result){
            sum+=Int32.Parse(num);
       }
       return sum;
    //    Console.WriteLine(string.Join(", ",result));

    }
}

