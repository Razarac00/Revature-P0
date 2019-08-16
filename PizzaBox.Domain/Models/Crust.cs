using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Crust : ISellable, ISizeable
    {
        private string _defaultSize = "Medium";
        private double _defaultPrice = 2.00;
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

        private double ComputeCurrentPrice(double value)
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

        private double SetupPrice(double value)
        {
            double result = _defaultPrice;
            if (value > 0)
            {
                result = value;
            }
            return result;
        }

        private string SetupName(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Crust must have a name");
            }
            else
            {
                return value;
            }
            
        }

        public double Price 
        { 
            get => _defaultPrice; 
            set => _defaultPrice = SetupPrice(value); 
        }
        public string Name 
        { 
            get => Name; 
            set => Name = SetupName(value);
        }
        public Dictionary<string, double> SizingAndPricing 
        { 
            get => _sizingandpricing; 
            set => _sizingandpricing = SetupSAndP(value); 
        }
        public string CurrentSize 
        { 
            get => CurrentSize; 
            set => CurrentSize = SetupCurrentSize(value); 
        }

        public double CurrentPrice
        {
            get => CurrentPrice;
            private set => CurrentPrice = value;
        }

        public Crust(string name)
        {
            Name = name;
            CurrentSize = _defaultSize;
            Price = _defaultPrice;
        }

    }
}