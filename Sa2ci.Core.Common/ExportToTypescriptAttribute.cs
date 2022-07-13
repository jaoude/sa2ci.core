namespace Sa2ci.Core.Common
{
    /// <summary>
    /// Marks C# (enum|class|interface) for export
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Interface)]
    public class ExportToTypescriptAttribute : Attribute
    {
        
    }
}