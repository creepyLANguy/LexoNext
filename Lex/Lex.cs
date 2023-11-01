public static class Lex
{
  public static string GetNext(string input)
  {
    if (input.Length < 2)
    {
      return input;
    }

    var digits = input.Select(character => character - '0').ToList();

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

        return string.Join("", head);
      }
    }

    return input;
  }
}