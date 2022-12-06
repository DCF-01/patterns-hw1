using CreationalPatterns.Interfaces;

namespace CreationalPatterns.Services;

public class SmsService : BaseService, IService
{
    public SmsService(decimal basePrice, decimal discountAmount, int units, int freeUnits)
    {
        Price = basePrice - discountAmount;
        Units = units - freeUnits;
    }
    
    /// <summary>
    /// An implementation of the <see cref="CalcSum"/> method that takes in a tariff type <see cref="int"/>
    /// and executes a switch statement to get the final price for the configured service.
    /// </summary>
    /// <param name="tariffType"></param>
    /// <returns>The total price for the service.</returns>
    public decimal CalcSum(int tariffType = 0)
    {
        switch (tariffType)
        {
            case 1:
                return Price * Units * 2.0M;
            case 2:
                return Price * Units * 0.7M;
            default:
                return Price * Units;
        }
    }

    /// <summary>
    /// A shallow clone that copies all of the service's (current object / this) members,
    /// Then we cast the object to an IService as we're aware it implements that interface.
    /// This methods is that ultimately makes this class a prototype, the ability to clone itself and return that new
    /// <see cref="object"/> to the caller.
    /// </summary>
    /// <returns></returns>
    public IService Clone()
    {
        return (IService)MemberwiseClone();
    }
}