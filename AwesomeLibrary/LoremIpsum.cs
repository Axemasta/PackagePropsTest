using System.Reflection;

namespace AwesomeLibrary;

public class LoremIpsum
{
    public string GetText()
    {
        var assembly = Assembly.GetEntryAssembly();

        if (assembly is null)
        {
            throw new InvalidOperationException("Could not find entry assembly.");
        }

        var resourceNames = assembly.GetManifestResourceNames();
        
        var lipsumResourceName = resourceNames.FirstOrDefault(x => x.EndsWith("lipsum.txt"));

        if (lipsumResourceName is null)
        {
            throw new InvalidOperationException("Could not find lipsum.txt in assembly");
        }
        
        var stream = assembly.GetManifestResourceStream(lipsumResourceName);

        if (stream is null)
        {
            throw new InvalidOperationException("Could not read lipsum.txt stream");
        }
        
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}