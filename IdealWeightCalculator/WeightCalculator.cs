using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator;

public class WeightCalculator
{
    public double Height { get; set; }
    public char Sex { get; set; }

    public readonly IDataRepository repository;
    public WeightCalculator()
    {

    }
    public WeightCalculator(IDataRepository repository)
    {
        this.repository = repository;
    }

    public double GetIdealBodyWeight()
    {
        switch (Sex)
        {
            case 'm':
                return (Height - 100) - ((Height - 150) / 4);
            case 'w':
                return (Height - 100) - ((Height - 150) / 2);
            default:
                return 0;

        }

    }

    public List<double> GetIdealBodyWeightFromDataSource()
    {
        List<double> result = new List<double>();

        var repo = new WeightRepositiery();
        IEnumerable<WeightCalculator> weights = repo.GetWeights();

        foreach (var weight in weights)
        {
            result.Add(weight.GetIdealBodyWeight());
        }

        return result;
    }

    public bool Validate()
    {
        return Sex == 'm' || Sex == 'w';
    }
}
