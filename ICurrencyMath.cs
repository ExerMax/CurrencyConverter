namespace CurrencyConverter
{
    public interface ICurrencyMath
    {
        Amount Add(Amount a1, Amount a2);
        Amount Add(Amount a1, Amount a2, string currency);
        Amount Substract(Amount a1, Amount a2);
        Amount Substract(Amount a1, Amount a2, string currency);
    }
}