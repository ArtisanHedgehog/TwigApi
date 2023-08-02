using Pchp.Core;
using Twig;

namespace TwigApi;

public static class TemplateWrapperExtensions
{
    public static string Render(this TemplateWrapper templateWrapper, Dictionary<string, object> dictionary)
        => templateWrapper.render(dictionary.ToPhpArray());

    private static PhpArray ToPhpArray(this Dictionary<string, object> dictionary)
    {
        var result = new PhpArray();

        foreach(var pair in dictionary)
        {
            result.Add(pair.Key, pair.Value);
        }

        return result;
    }
}
