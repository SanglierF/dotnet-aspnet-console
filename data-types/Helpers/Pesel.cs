namespace data_types;

public struct Pesel
{
    private const int PESEL_WIDTH = 11;
    private int _peselNumber;

    public Pesel(string pesel)
    {
        SetPesel(pesel);
    }

    public string GetPesel()
    {
        return ToString();
    }

    public bool SetPesel(string pesel)
    {
        return int.TryParse(pesel, out _peselNumber);
    }

    public override string ToString()
    {
        return $"{_peselNumber.ToString().PadLeft(PESEL_WIDTH, '0')}";
    }
}