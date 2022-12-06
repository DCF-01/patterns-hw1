using CreationalPatterns.Interfaces;

namespace CreationalPatterns;

/// <summary>
/// Go to <see cref="BasePackage"/> for class documentation
/// </summary>
public class ServicePackage : BasePackage
{
    /// <summary>
    /// Services that are contained within the <see cref="ServicePackage"/> object.
    /// Cannot be accessed outside class, only through add/remove
    /// and private constructor when cloning
    /// </summary>
    private HashSet<IService> Services { get; set; }

    /// <summary>
    /// Init the object with only the package name.
    /// </summary>
    /// <param name="packageName"></param>
    public ServicePackage(string packageName)
    {
        Name = packageName;
        Services = new HashSet<IService>();
    }

    /// <summary>
    /// Init the object with the package name and initial services that are already instantiated.
    /// </summary>
    /// <param name="packageName"></param>
    /// <param name="services"></param>
    private ServicePackage(string packageName, HashSet<IService> services)
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
        if (!Services.Any(x => service.GetType() == x.GetType()))
        {
            Services.Add(service);
            Console.WriteLine($"Added service of type {service.GetType().Name}");
            return;
        }
        Console.WriteLine($"Service of type {service.GetType().Name} already exists");
    }

    public void Remove(Type type)
    {
        int removedServices = Services.RemoveWhere(x => x.GetType() == type);
        if (removedServices > 0)
        {
            Console.WriteLine($"Removed service of type {type.Name}.");
            return;
        }
        Console.WriteLine($"No service of type {type.Name} found.");
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
        var clonedServices = new HashSet<IService>();
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
        decimal total = 0;
        Console.WriteLine($"Service package: {Name}");
        for(int i = 0; i < Services.Count; i++)
        {
            var svc = Services.ElementAt(i);
            decimal svcPrice = svc.CalcSum(tarriffType);
            total += svcPrice;
            
            Console.WriteLine($"{i+1}. {svc.ToString()}, {svcPrice}");
        }
        Console.WriteLine($"Total: {total}");
        Console.Write("\r\n");
    }
}