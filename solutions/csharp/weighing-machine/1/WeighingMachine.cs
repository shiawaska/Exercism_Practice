class WeighingMachine
{
    public int Precision { get; }
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
    private double _Weight;
    public double Weight
    {
        get => _Weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _Weight = value;
        }
    }

    public string DisplayWeight
    {
        get { 
            return Math.Round((Weight - TareAdjustment), Precision).ToString("F" + Precision) + " kg"; }
    }
    private double _TareAdjustment = 5;
    public double TareAdjustment
    {
        get => _TareAdjustment;
        set
        {
            _TareAdjustment = value;
        }
    }
}
