using System.Collections.Generic;
using System.Text;

namespace IdealWeightCalculator.Test;

[TestClass]
public class TestInilalizer
{
    [AssemblyInitialize]
    public static void AssemblyInitialaze(TestContext context)
    {
        context.WriteLine("In Assembly Initilalize");
    }

    [AssemblyCleanup]
    public static void AssemblyCleanUp()
    {

    }
}
