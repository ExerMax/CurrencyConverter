namespace CurrencyConverter
{
    public class CurrencyMath : ICurrencyMath
    {
        private readonly IConverter _converter;

        public CurrencyMath(IConverter converter)
        {
            _converter = converter;
        }

        public Amount Add(Amount a1, Amount a2)
        {
            if(a1.Name != a2.Name)
            {
                throw new ArgumentException("Different currencies");
            }

            return new Amount { Value = a1.Value + a2.Value, Name = a1.Name };
        }

        public Amount Add(Amount a1, Amount a2, string currency)
        {
            Amount newA1 = _converter.Convert(a1, currency);
            Amount newA2 = _converter.Convert(a2, currency);

            return new Amount { Value = newA1.Value + newA2.Value, Name = currency };
        }

        public Amount Substract(Amount a1, Amount a2)
        {
            if (a1.Name != a2.Name)
            {
                throw new ArgumentException("Different currencies");
            }

            return new Amount { Value = a1.Value - a2.Value, Name = a1.Name };
        }

        public Amount Substract(Amount a1, Amount a2, string currency)
        {
            Amount newA1 = _converter.Convert(a1, currency);
            Amount newA2 = _converter.Convert(a2, currency);

            return new Amount { Value = newA1.Value - newA2.Value, Name = currency };
        }
    }
}
