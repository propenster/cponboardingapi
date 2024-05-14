namespace CPOnboardingAPI.Models
{
    /// <summary>
    /// All questions no matter their type and form have these common attributes...
    /// good thing, C# is smooth and flexible. we can use interfaces
    /// </summary>
    public interface IBaseQuestion
    {
        string Type { get; set; }
        string Name { get; set; }
        string Title { get; set; }
        bool IsRequired { get; set; }
    }
}
