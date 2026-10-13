namespace Costume;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Costume World!");
        List<Costume> myCostumes = new List<Costume>();
        Costume detective = new Costume();
        detective._headwear = "fedora";
        detective._upperGarment = "trenchcoat";
        detective._lowerGarment = "slacks";
        detective._footwear = "dress shoes";
        detective._accesories = "magnifying glass";
        myCostumes.Add(detective);

        Costume snorkler = new Costume();
        snorkler._headwear = "goggles";
        snorkler._upperGarment = "wetsuit";
        snorkler._lowerGarment = "wetsuit";
        snorkler._footwear = "flippers";
        snorkler._accesories = "snorkel";
        myCostumes.Add(snorkler);

        foreach (Costume c in myCostumes)
        {
            c.Output();
        }

        string filename = "costumes.csv";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Costume c in myCostumes)
            {
                outputFile.WriteLine($"{c._headwear}, {c._upperGarment}, {c._lowerGarment}, {c._footwear}, {c._accesories}");
            }
        }

    }
}
