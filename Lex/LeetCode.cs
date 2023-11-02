//LeetCode-specific solution.
//Runtime - 19ms Beats 80.00%of users with C#
//Memory - 26.91MB , Beats 73.33%of users with C#
public static class Solution
{
  public static int NextGreaterElement(int n)
  {
    if (n < 10 || n == int.MaxValue)
    {
      return -1;
    }

    var digits = new List<int>();
    while (n > 0)
    {
      digits.Add(n % 10);
      n /= 10;
    }
    digits.Reverse();

    for (var pivotIndex = digits.Count - 2; pivotIndex >= 0; pivotIndex--)
    {
      var pivotValue = digits[pivotIndex];

      if (pivotValue == 9)
      {
        continue;
      }

      var tail = digits.GetRange(pivotIndex + 1, digits.Count - 1 - pivotIndex);
      tail.Sort();

      foreach (var tailItem in tail)
      {
        if (tailItem <= pivotValue)
        {
          continue;
        }

        tail.Remove(tailItem);
        tail.Add(pivotValue);
        tail.Sort();

        var head = digits.GetRange(0, pivotIndex);
        head.Add(tailItem);
        head.AddRange(tail);

        var output = 0;
        foreach (var item in head)
        {
          var previous = output;
          output *= 10;
          output += item;

          if (output < 0)
          {
            return -1;
          }
          if (previous > output)
          {
            return -1;
          }
        }
        return output;
      }
    }

    return -1;
  }
}