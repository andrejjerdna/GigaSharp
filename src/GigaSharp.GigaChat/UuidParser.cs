using System.Text.RegularExpressions;
using GigaSharp.GigaChat.Exceptions;

namespace GigaSharp.GigaChat;

internal static partial class UuidParser
{
    private static readonly Regex FileUuidRegex = GetUuidPattern();

    public static Guid ParseUuidFromContent(string? content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new GigaChatUuidParseException("Content is empty!");
        }
        
        var match = FileUuidRegex.Matches(content).FirstOrDefault();
        
        if (match == null)
        {
            throw new GigaChatUuidParseException("File uuid match is null!");
        }

        return new Guid(match.Value);
    }

    [GeneratedRegex("[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}")]
    private static partial Regex GetUuidPattern();
}