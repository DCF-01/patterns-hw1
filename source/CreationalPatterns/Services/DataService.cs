using CreationalPatterns.Interfaces;

namespace CreationalPatterns.Services;

/// <summary>
/// An arbitrary service that implements the <see cref="IService"/> interface and
/// inherits from an abstract class <see cref="BaseService"/>,
/// uses some default properties and its <see cref="BaseService.ToString()"/> method
/// </summary>
public class DataService : BaseService, IService
{
    /// <summary>
    /// Used in determining service pricing.
    /// </summary>
    public int MaxDl { get; set; }

    /// <summary>
    /// Used in determining service pricing.
    /// </summary>
    public int MaxUp { get; set; }
    
    public DataService(decimal basePrice, decimal discountAmount, int units, int maxDl, int maxUp)
    {
        Price = basePrice - discountAmount;
        Units = units;
        MaxDl = maxDl;
        MaxUp = maxUp;
    }

    /// <summary>
    /// An implementation of the <see cref="CalcSum"/> method that takes in a tariff type <see cref="int"/>
    /// and executes a switch statement to get the final price for the configured service.
    /// </summary>
    /// <param name="tariffType"></param>
    /// <returns>The total price for the service.</returns>
    public decimal CalcSum(int tariffType = 0)
    {
        switch ((MaxDl, MaxUp))
        {
            case(>= 1024, >= 512) when tariffType == 1:
                return Price * Units * 1.2M;
            case (<= 1024, <= 512) when tariffType == 1:
                return Price * Units;
            case(>= 1024, >= 512) when tariffType == 2:
                return Price * Units * 1.1M;
            case (<= 1024, <= 512) when tariffType == 2:
                return Price * Units * 0.9M;
            default:
                return Price * Units;
        }
    }

    /// <summary>
    /// A shallow clone that copies all of the service's (current object / this) members, in this case properties
    /// Price, Units, MaxDl, MaxUp. Then we cast the object to an IService as we're aware it implements that interface.
    /// This methods is that ultimately makes this class a prototype, the ability to clone itself and return that new
    /// <see cref="object"/> to the caller.
    /// </summary>
    /// <returns></returns>
    public IService Clone()
    {
        return (IService)MemberwiseClone();
    }
    
}