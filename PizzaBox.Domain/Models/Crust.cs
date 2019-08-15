using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Crust : ISellable, ISizeable
    {
        private Dictionary<string, double> _sizingandpricing = new Dictionary<string, double>() 
        {
            {"Small", 1.00},
            {"Medium", 1.50},
            {"Large", 2.00},
            {"XLarge", 2.50}
        };

        private Dictionary<string, double> CleanupSAndP(Dictionary<string, double> ProposedSAndP)
        {

            foreach ( string sizeName in ProposedSAndP.Keys)
            {
                if (ProposedSAndP[sizeName] < 0.0)
                {
                    // considering throwing an invalidpricingexception if price is negative
                    ProposedSAndP.Remove(sizeName);
                } 
            }

            return ProposedSAndP;
        }

        private Dictionary<string, double> SetupSAndP(Dictionary<string, double> ProposedSAndP)
        {
            if (ProposedSAndP != null)
            {
                _sizingandpricing = CleanupSAndP(ProposedSAndP);
            }

            return _sizingandpricing;
        }

        public double Price 
        { 
            get => Price; 
            set => Price = value; 
        }
        public string Name 
        { 
            get => Name; 
            set => Name = value;
        }
        public Dictionary<string, double> SizingAndPricing 
        { 
            get => _sizingandpricing; 
            set => _sizingandpricing = SetupSAndP(value); 
        }
        public string CurrentSize 
        { 
            get => CurrentSize; 
            set => CurrentSize = value; 
        }

    }
}