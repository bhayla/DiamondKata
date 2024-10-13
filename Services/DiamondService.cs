using Abstractions;
using System.Text;
using System.Linq;

namespace Services;

public class DiamondService : IDiamondService
{
    private readonly char BASE_CHAR = 'A';
    private readonly int BASE_CHAR_ASCII_INDEX = 65;
    private readonly char SPACER = ' ';

    public string? Create(char middleCharacter)
    {
        middleCharacter = char.ToUpper(middleCharacter);

        if (middleCharacter < 'A' || middleCharacter > 'Z')
            return null;

        if (middleCharacter == BASE_CHAR)
            return BASE_CHAR.ToString();

        var topDiamond = BuildTopDiamond(middleCharacter);

        var bottomDiamond = topDiamond.Reverse().Skip(1).ToArray();

        return string.Join(Environment.NewLine, topDiamond.Concat(bottomDiamond));
    }

    private string[] BuildTopDiamond(char middleCharacter)
    {
        var diamondDepth = GetDiamondDepth(middleCharacter);
        var topDiamond = new string[diamondDepth];

        for (var i = BASE_CHAR; i <= middleCharacter; i++)
        {
            var index = i - BASE_CHAR;
            var padding = new string(SPACER, diamondDepth - index - 1);
            if (index == 0)
            {
                topDiamond[index] = $"{padding}{i}{padding}";
            }
            else
            {
                var spacing = new string(SPACER, 2 * index - 1);
                topDiamond[index] = $"{padding}{i}{spacing}{i}{padding}";
            }
        }

        return topDiamond;
    }

    private int GetDiamondDepth(char upperChar)
    {
        return upperChar - (BASE_CHAR_ASCII_INDEX -1);
    }
}
