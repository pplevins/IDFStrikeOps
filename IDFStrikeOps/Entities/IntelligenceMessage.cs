namespace IDFStrikeOps.Entities;

/// <summary>
/// Class representing intelligence message on a terrorist.
/// </summary>
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

    /// <summary>
    /// Constructor for the intelligence message.
    /// </summary>
    /// <param name="terrorist">Associated terrorist</param>
    /// <param name="targetType">location type of the target.</param>
    /// <param name="confidence">confidence score of the intel.</param>
    public IntelligenceMessage(Terrorist terrorist, TargetType targetType, int confidence = 100)
    {
        AssociatedTerrorist = terrorist;
        LocationType = targetType;
        ConfidenceScore = confidence;
        TimeStamp = DateTime.Now;
    }
}
