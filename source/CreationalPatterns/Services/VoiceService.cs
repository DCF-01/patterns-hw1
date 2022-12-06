using CreationalPatterns.Interfaces;

namespace CreationalPatterns.Services;

/// <summary>
/// An arbitrary service that implements the <see cref="IService"/> interface and
/// inherits from an abstract class <see cref="BaseService"/>,
/// uses some default properties and its <see cref="BaseService.ToString()"/> method
/// </summary>
public class VoiceService : BaseService, IService
{
    /// <summary>
    /// This property is used in determining the price of the service.
    /// </summary>
    public decimal PricePerMinute { get; set; }
    
    public VoiceService(decimal basePrice, decimal discountAmount, int units, decimal pricePerMinute)
    {
        Price = basePrice - discountAmount;
        Units = units;
        PricePerMinute = pricePerMinute;
    }

    /// <summary>
    /// An implementation of the <see cref="CalcSum"/> method that takes in a tariff type <see cref="int"/>
    /// and executes a switch statement to get the final price for the configured service.
    /// </summary>
    /// <param name="tariffType">An integer that determines if a discount will be applied.</param>
    /// <returns>The total price for the service.</returns>
    public decimal CalcSum(int tariffType = 0) => tariffType switch
    {
        1 => Price + Units * PricePerMinute * 0.85M,
        2 => Price + Units * PricePerMinute * 0.7M,
        _ => Price + Units * PricePerMinute
    };

    /// <summary>
    /// A shallow clone that copies all of the service's (current object / this) members, in this case properties
    /// Price, Units, PricePerMinute. Then we cast the object to an IService as we're aware it implements that interface.
    /// This methods is that ultimately makes this class a prototype, the ability to clone itself and return that new
    /// <see cref="object"/> to the caller.
    /// </summary>
    /// <returns></returns>
    public IService Clone()
    {
        return (IService)MemberwiseClone();
    }
    
}