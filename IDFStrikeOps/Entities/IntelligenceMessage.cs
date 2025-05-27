namespace IDFStrikeOps.Entities;

internal class IntelligenceMessage
{
    Terrorist AssociatedTerrorist { get; }
    public TargetType LocationType { get; }
    public DateTime TimeStamp { get; }
    private int _confidenceScore;
    public int ConfidenceScore 
    {
        get => _confidenceScore;
        init
        {
            if (value >= 0 && value <= 100)
            {
                _confidenceScore = value;
            }
        }
    }

    public IntelligenceMessage(Terrorist terrorist, TargetType targetType, int confidence = 100)
    {
        AssociatedTerrorist = terrorist;
        LocationType = targetType;
        ConfidenceScore = confidence;
        TimeStamp = DateTime.Now;
    }
}
