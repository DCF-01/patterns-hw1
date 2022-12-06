using CreationalPatterns.Interfaces;

namespace CreationalPatterns;

/// <summary>
/// Go to <see cref="BasePackage"/> for class documentation
/// </summary>
public class ServicePackage : BasePackage
{
    /// <summary>
    /// Services that are contained within the <see cref="ServicePackage"/> object.
    /// </summary>
    public List<IService> Services { get; private set; }

    /// <summary>
    /// Init the object with only the package name.
    /// </summary>
    /// <param name="packageName"></param>
    public ServicePackage(string packageName)
    {
        Name = packageName;
        Services = new List<IService>();
    }

    /// <summary>
    /// Init the object with the package name and initial services that are already instantiated.
    /// </summary>
    /// <param name="packageName"></param>
    /// <param name="services"></param>
    public ServicePackage(string packageName, List<IService> services)
    {
        Name = packageName;
        Services = services;
    }

    /// <summary>
    /// Add <see cref="IService"/>
    /// </summary>
    /// <param name="service"></param>
    public void Add(IService service)
    {
        Services.Add(service);
    }

    /// <summary>
    /// Each <see cref="IService"/> calls its own <see cref="IService.Clone"/> method.
    /// All cloned services are added to a new List.
    /// The <see cref="ServicePackage.Name"/> is set from the cloneName parameter.
    /// </summary>
    /// <param name="cloneName"></param>
    /// <returns>A new <see cref="ServicePackage"/> that contains the clone services and a new set name.</returns>
    public override BasePackage Clone(string cloneName = "")
    {
        var clonedServices = new List<IService>();
        string newName = string.IsNullOrWhiteSpace(cloneName) ? Name + "-clone" : cloneName;
        
        foreach (var svc in Services)
        {
            clonedServices.Add(svc.Clone());
        }

        return new ServicePackage(newName, clonedServices);
    }

    /// <summary>
    /// A method for printing out each service to the console.
    /// It will print the number position + 1, the <see cref="string"/>
    /// representation of the <see cref="IService"/> and the result
    /// of its <see cref="IService.CalcSum"/> method.
    /// </summary>
    public override void ListServices(int tarriffType = 0)
    {
        Console.WriteLine($"Service package: {Name}");
        for(int i = 0; i < Services.Count; i++)
        {
            var svc = Services.ElementAt(i);
            Console.WriteLine($"{i+1}. {svc.ToString()}, {svc.CalcSum(tarriffType)}");
        }
        Console.Write("\r\n");
    }
}