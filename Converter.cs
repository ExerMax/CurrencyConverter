namespace CurrencyConverter
{
    public class Converter : IConverter
    {
        //Rates must be relative to a third currency with rate = 1
        //For example   { { "USD", 1 }, { "RUB", 100 }, { "AAA", 0.12345M } }
        //Or            { { "RUB", 100 }, { "AAA", 0.12345M } }
        //In this case it is implied that currencies will be converted relative to { "USD", 1 }
        private readonly IDictionary<string, decimal> _rates;

        public Converter(IDictionary<string, decimal> rates)
        {
            _rates = rates;
        }

        public Amount Convert(Amount value, string currency)
        {
            decimal coefficient1 = _rates[value.Name];

            if(coefficient1 == 0)
            {
                throw new ArgumentException("Cannot find currency", value.Name);
            }

            decimal coefficient2 = _rates[currency];

            if (coefficient2 == 0)
            {
                throw new ArgumentException("Cannot find currency", currency);
            }

            decimal res = value.Value / coefficient1 * coefficient2;

            Amount resAmount = new Amount { Value = res, Name = currency };

            return resAmount;
        }
    }
}