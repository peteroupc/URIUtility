## PeterO.URIUtility.ParseMode

    public sealed struct ParseMode :
        System.Enum,
        System.IComparable,
        System.IConvertible,
        System.IFormattable

Specifies whether certain characters are allowed when parsing IRIs and URIs.

### Member Summary
* <code>[public static PeterO.URIUtility.ParseMode IRILenient = 2;](#IRILenient)</code> - The rules only check for the appropriate delimiters when splitting the path, without checking if all the characters in each component are valid.
* <code>[public static PeterO.URIUtility.ParseMode IRIStrict = 0;](#IRIStrict)</code> - The rules follow the syntax for parsing IRIs.
* <code>[public static PeterO.URIUtility.ParseMode IRISurrogateLenient = 4;](#IRISurrogateLenient)</code> - The rules only check for the appropriate delimiters when splitting the path, without checking if all the characters in each component are valid.
* <code>[public static PeterO.URIUtility.ParseMode URILenient = 3;](#URILenient)</code> - The rules only check for the appropriate delimiters when splitting the path, without checking if all the characters in each component are valid.
* <code>[public static PeterO.URIUtility.ParseMode URIStrict = 1;](#URIStrict)</code> - The rules follow the syntax for parsing IRIs, except that code points outside the Basic Latin range (U+0000 to U+007F) are not allowed.

<a id="IRILenient"></a>
### IRILenient

    public static PeterO.URIUtility.ParseMode IRILenient = 2;

The rules only check for the appropriate delimiters when splitting the path, without checking if all the characters in each component are valid. Even with this mode, strings with unpaired surrogate code points are considered invalid.

<a id="IRIStrict"></a>
### IRIStrict

    public static PeterO.URIUtility.ParseMode IRIStrict = 0;

The rules follow the syntax for parsing IRIs. In particular, many code points outside the Basic Latin range (U+0000 to U+007F) are allowed. Strings with unpaired surrogate code points are considered invalid.

<a id="IRISurrogateLenient"></a>
### IRISurrogateLenient

    public static PeterO.URIUtility.ParseMode IRISurrogateLenient = 4;

The rules only check for the appropriate delimiters when splitting the path, without checking if all the characters in each component are valid. Unpaired surrogate code points are treated as though they were replacement characters instead for the purposes of these rules, so that strings with those code points are not considered invalid strings.

<a id="URILenient"></a>
### URILenient

    public static PeterO.URIUtility.ParseMode URILenient = 3;

The rules only check for the appropriate delimiters when splitting the path, without checking if all the characters in each component are valid. Code points outside the Basic Latin range (U+0000 to U+007F) are not allowed.

<a id="URIStrict"></a>
### URIStrict

    public static PeterO.URIUtility.ParseMode URIStrict = 1;

The rules follow the syntax for parsing IRIs, except that code points outside the Basic Latin range (U+0000 to U+007F) are not allowed.
