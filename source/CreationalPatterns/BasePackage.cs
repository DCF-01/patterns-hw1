namespace CreationalPatterns;

/// <summary>
/// This class wraps the service prototype, and is itself a prototype, since it also implements cloning.
/// In this case the value types from the service are copied by itself, and the <see cref="Name"/> property
/// of the <see cref="BasePackage"/> is copied from itself.
/// The <see cref="Name"/> <see cref="string"/> for the clone is either provided,
/// and if not some logic handles the naming of the new <see cref="BasePackage"/>.
/// </summary>
public abstract class BasePackage
{
    /// <summary>
    /// Clone the <see cref="BasePackage"/> and set the <see cref="Name"/> property.
    /// </summary>
    /// <param name="cloneName">Sets the <see cref="Name"/> property.</param>
    /// <returns></returns>
    public abstract BasePackage Clone(string cloneName = "");
    /// <summary>
    /// Print all contained services to console.
    /// </summary>
    public abstract void ListServices(int tarrifType = 0);
    /// <summary>
    /// Set in the <see cref="Clone"/> method.
    /// </summary>
    public string Name { get; set; }
}