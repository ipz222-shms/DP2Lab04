using System.Text;
using System.Text.RegularExpressions;
using StrategyLibrary.ImageLoaders;

namespace StrategyLibrary;

public partial class LightImageNode : LightElementNode
{
    private readonly IImageLoader _loader;
    public string Href { get; set; }

    public LightImageNode(string href, IImageLoader loader) : base("img")
    {
        Href = href;
        IsSingle = true;
        _loader = loader;

        // if (WebHrefRegex().IsMatch(href))
        //     _loader = new WebImageLoader();
        // else if (FileHrefRegex().IsMatch(href))
        //     _loader = new FileImageLoader();
        // else
        //     throw new ArgumentException("Href is neither Web nor File path!");
    }

    public override string Render()
    {
        StringBuilder sb = new($"<{Tag}");
        
        if (Display != null)
            sb.Append($" style=\"display:{Display};\"");
        
        if (_classes.Count != 0)
            sb.Append($" class=\"{string.Join(' ', _classes)}\"");

        sb.Append($" />: {_loader.GetImage(Href)}");

        return sb.ToString();
    }

    // [GeneratedRegex(@"^(?:https:\/\/|http:\/\/).+\.(?:png|jpg|jpeg|webp|gif|svg|bmp)$")]
    // private static partial Regex WebHrefRegex();
    // [GeneratedRegex(@"^.+\.(?:png|jpg|jpeg|webp|gif|svg|bmp)$")]
    // private static partial Regex FileHrefRegex();
}
