using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator;
public class WeightRepositiery : IDataRepository
{
    IEnumerable<WeightCalculator> weight;

    public WeightRepositiery()
    {
        weight = new List<WeightCalculator>()
        {
            new WeightCalculator {Height=175, Sex='w'},
            new WeightCalculator {Height=167, Sex='m'},
            new WeightCalculator {Height=182, Sex='m'},
        };
    }

    public IEnumerable<WeightCalculator> GetWeights()
    {
        return weight;
    }
}
