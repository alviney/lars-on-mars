using System.Collections.Generic;

public class Program
{
    public Dictionary<string, Output> bank = new Dictionary<string, Output>();

    public Output GetOutput(Input input)
    {
        Output output;
        if (bank.TryGetValue(input?.name, out output)) return output;
        return null;
    }

    public void Add(string inputKey, Output output)
    {
        this.bank[inputKey] = output;
    }
}