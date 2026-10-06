using System.Text.RegularExpressions;

namespace Globomatics.Web.Transformers
{
    public class SlugParameterTransformer : IOutboundParameterTransformer
    {
        // Assist in building the URI.
        // Transform a parameter that is leverged by an Action into the appropriate shape.
        // NOTE> Wise to have a short timeout associated. Avoiding annoying attacks.
        public string? TransformOutbound(object? value)
        {
            if (value is not string) return null;

            return Regex.Replace(
                value.ToString()!, 
                @"[^a-zA-Z0-9]+", "-", 
                RegexOptions.CultureInvariant,
                TimeSpan.FromMicroseconds(200)).ToLowerInvariant().Trim('-');
        }
    }
}
