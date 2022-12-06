using System.Text.Json.Serialization.Metadata;

namespace CreationalPatterns;

public abstract class BaseService
{
    /// <summary>
    /// Used in child classes to store initial values for Price and Units for a service.
    /// </summary>
    protected decimal Price { get; init; }
    /// <summary>
    /// Used in child classes to store initial values for Price and Units for a service.
    /// </summary>
    protected decimal Units { get; init; }
    
    /// <summary>
    /// Used by child classes when printing to console.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => GetType().Name;
}