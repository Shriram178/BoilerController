using BoilerHandler.Model;
namespace BoilerHandler;

/// <summary>
/// Custom exception for <see cref="Boiler"/>
/// error
/// </summary>
public class BoilerError : Exception
{
    public BoilerError(string message) : base(message) { }
}
