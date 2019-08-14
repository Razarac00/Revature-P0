using System.Collections.Generic;

namespace PizzaBox.Domain.Interfaces
{
    public interface ISizeable
    {
        Dictionary<string, int> SizingDictionary { get; set; }

    }
}