using System.Collections.Generic;

namespace PizzaBox.Domain.Interfaces
{
    public interface ISizeable
    {
        Dictionary<string, decimal> SizingAndPricing { get; set; }

        string CurrentSize { get; set; }

    }
}