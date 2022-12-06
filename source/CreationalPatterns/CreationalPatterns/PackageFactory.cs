using CreationalPatterns.Interfaces;

namespace CreationalPatterns;

/// <summary>
/// The Package factory manages <see cref="ServicePackages"/> constrained to the type <see cref="BasePackage"/>
/// Finding and resolving which service to clone, depends on the string parameter inside the <see cref="FindAndClone"/> method.
/// </summary>
/// <typeparam name="T"></typeparam>
public class PackageFactory<T> where T : BasePackage
{
    public List<BasePackage> ServicePackages { get; set; }

    /// <summary>
    /// Find the service and use the exposed method Clone to copy the entire service and return it. 
    /// </summary>
    /// <param name="packageName">String name property of the service.</param>
    /// <returns><see cref="BasePackage"/></returns>
    public BasePackage FindAndClone(string packageName = "", string newPackageName = "")
    {
        return ServicePackages?.FirstOrDefault(x => x.Name == packageName)?.Clone(newPackageName);
    }

    /// <summary>
    /// Ctor sets the service <see cref="ServicePackages"/> to an empty list of <see cref="BasePackage"/>
    /// </summary>
    public PackageFactory()
    {
        ServicePackages = new List<BasePackage>();
    }

    /// <summary>
    /// Exposes a method for adding <see cref="ServicePackages"/> to manage.
    /// </summary>
    /// <param name="basePackage">The service package to add to the factory.</param>
    public void Add(BasePackage basePackage)
    {
        ServicePackages.Add(basePackage);
    }
}