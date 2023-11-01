public static class Tests
{
  private static readonly (string, string)[] TestCases = 
  {
    ("1", "1"),
    ("12", "21"),
    ("21", "21"),
    ("123", "132"),
    ("132", "213"),
    ("32121", "32211"),
    ("314159", "314195"),
    ("1233311", "1311233"),
    ("987654321", "987654321"),
    ("123456789", "123456798"),
    ("0987654321", "1023456789"),
    ("0123456789", "0123456798"),
    ("9876543210", "9876543210"),
    ("1234567890", "1234567908"),
    ("23998043210", "23998100234"), 
    //TODO - get some actual test cases. 
  };

  public static void Run()
  {
    Console.WriteLine("Running tests...\n");

    var passed = 0;
    
    for (var i = 0; i < TestCases.Length; i++)
    {
      var lex = Lex.GetNext(TestCases[i].Item1);

      if (lex == TestCases[i].Item2)
      {
        //Console.WriteLine(
        //  "PASS\n" +
        //  "Input:\t{0}\n" +
        //  "Output:\t{1}\n",
        //  testCases[i].Item1,
        //  lex);

        passed++;
      }
      else
      {
        Console.WriteLine(
          "FAILURE\n" +
          "Input:\t{0}\n" +
          "Expect:\t{1}\n" +
          "Actual:\t{2}\n",
          TestCases[i].Item1,
          TestCases[i].Item2,
          lex);
      }
    }

    Console.WriteLine("Passed : {0}/{1}", passed, TestCases.Length);
  }
}