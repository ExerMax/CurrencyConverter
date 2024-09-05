namespace CurrencyConverter
{
    public interface IConverter
    {
        Amount Convert(Amount value, string currency);
    }
}