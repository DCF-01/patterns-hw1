namespace CreationalPatterns.Interfaces;

/// <summary>
/// Each service should implement an interface in order to decouple
/// internal service logic and expose likely used methods. 
/// </summary>
public interface IService
{
    /// <summary>
    /// Calculate the sum to be paid for using the configured service.
    /// </summary>
    /// <param name="tariffType">An arbitrary integer value that gives variation in pricing.</param>
    /// <returns></returns>
    decimal CalcSum(int tariffType = 0);
    /// <summary>
    /// Each service is a Prototype and therefore should expose a method
    /// which clones itself and returns that to the method caller. 
    /// </summary>
    /// <returns><see cref="IService"/> A new <see cref="object"/> that is a clone from the current <see cref="object"/>
    /// where this method is called.</returns>
    IService Clone();
}