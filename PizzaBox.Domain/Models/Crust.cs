using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Crust : AItem, ISellable
    {
        private string _defaultSize = "Medium";
        private decimal _defaultPrice = 2.00m;
        private string _defaultName = "Traditional";
        private Dictionary<string, decimal> _sizingandpricing = new Dictionary<string, decimal>() 
        {
            {"Small", 1.00m},
            {"Medium", 1.50m},
            {"Large", 2.00m},
            {"XLarge", 2.50m}
        };

        private Dictionary<string, decimal> CleanupSAndP(Dictionary<string, decimal> ProposedSAndP)
        {

            foreach ( string sizeName in ProposedSAndP.Keys)
            {
                if (ProposedSAndP[sizeName] < 0.0m)
                {
                    // considering throwing an invalidpricingexception if price is negative
                    ProposedSAndP.Remove(sizeName);
                } 
            }

            return ProposedSAndP;
        }

        private Dictionary<string, decimal> SetupSAndP(Dictionary<string, decimal> ProposedSAndP)
        {
            if (ProposedSAndP != null)
            {
                _sizingandpricing = CleanupSAndP(ProposedSAndP);
            }

            return _sizingandpricing;
        }

        private decimal ComputeCurrentPrice( decimal value)
        {
            return _sizingandpricing[CurrentSize] + Price;
        }

        private string SetupCurrentSize(string value)
        {
            string result = _defaultSize;
            if (_sizingandpricing.ContainsKey(value))
            {
                result = value;
            }
            return result;
        }

        public Dictionary<string, decimal> SizingAndPricing 
        { 
            get => _sizingandpricing; 
            set => _sizingandpricing = SetupSAndP(value); 
        }
        public string CurrentSize 
        { 
            get => CurrentSize; 
            set => CurrentSize = SetupCurrentSize(value); 
        }

        public decimal CurrentPrice
        {
            get => CurrentPrice;
            private set => CurrentPrice = value;
        }

        public Crust(string name) : base(name)
        {
        }

    }
}