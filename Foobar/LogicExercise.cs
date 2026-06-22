namespace Foobar;

class LogicExercise
{
    public string AddRule(int input)
    {
        List<string> listOfOutput = new List<string>();

        for (var x = 1; x <= input; x++)
        {
            if (x % 3 == 0 && x % 5 == 0 && x % 7 == 0)
            {
                listOfOutput.Add("foobarjazz");
            }
            else if (x % 5 == 0 && x % 7 == 0)
            {
                listOfOutput.Add("barjazz");
            }
            else if (x % 3 == 0 && x % 7 == 0)
            {
                listOfOutput.Add("foojazz");
            }
            else if (x % 3 == 0 && x % 5 == 0)
            {
                listOfOutput.Add("foobar");
            }
            else if (x % 9 == 0)
            {
                listOfOutput.Add("huzz");
            }
            else if (x % 4 == 0)
            {
                listOfOutput.Add("baz");
            }
            else if (x % 3 == 0)
            {
                listOfOutput.Add("foo");
            }
            else if (x % 5 == 0)
            {
                listOfOutput.Add("bar");
            }
            else if (x % 7 == 0)
            {
                listOfOutput.Add("jazz");
            }
            else
            {
                listOfOutput.Add(x.ToString());
            }
        }

        string output = string.Join(" ", listOfOutput);

        return output;
    }
}