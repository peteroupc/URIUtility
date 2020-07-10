# com.upokecenter.util.URIUtility.ParseMode

    public static enum URIUtility.ParseMode extends java.lang.Enum<URIUtility.ParseMode>

Specifies whether certain characters are allowed when parsing IRIs and URIs.

## Enum Constants

* `IRILenient`<br>
 The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are
 valid.
* `IRIStrict`<br>
 The rules follow the syntax for parsing IRIs.
* `IRISurrogateLenient`<br>
 The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are
 valid.
* `URILenient`<br>
 The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are
 valid.
* `URIStrict`<br>
 The rules follow the syntax for parsing IRIs, except that code points
 outside the Basic Latin range (U+0000 to U+007F) are not allowed.

## Methods

* `static URIUtility.ParseMode valueOf​(java.lang.String name)`<br>
 Returns the enum constant of this type with the specified name.
* `static URIUtility.ParseMode[] values()`<br>
 Returns an array containing the constants of this enum type, in
the order they are declared.

## Method Details

### IRIStrict
    public static final URIUtility.ParseMode IRIStrict
### URIStrict
    public static final URIUtility.ParseMode URIStrict
### IRILenient
    public static final URIUtility.ParseMode IRILenient
### URILenient
    public static final URIUtility.ParseMode URILenient
### IRISurrogateLenient
    public static final URIUtility.ParseMode IRISurrogateLenient
### values
    public static URIUtility.ParseMode[] values()
### valueOf
    public static URIUtility.ParseMode valueOf​(java.lang.String name)
## Enum Constant Details

### IRIStrict
    public static final URIUtility.ParseMode IRIStrict
The rules follow the syntax for parsing IRIs. In particular, many code
 points outside the Basic Latin range (U+0000 to U+007F) are
 allowed. Strings with unpaired surrogate code points are
 considered invalid.
### URIStrict
    public static final URIUtility.ParseMode URIStrict
The rules follow the syntax for parsing IRIs, except that code points
 outside the Basic Latin range (U+0000 to U+007F) are not allowed.
### IRILenient
    public static final URIUtility.ParseMode IRILenient
The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are
 valid. Even with this mode, strings with unpaired surrogate code
 points are considered invalid.
### URILenient
    public static final URIUtility.ParseMode URILenient
The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are
 valid. Code points outside the Basic Latin range (U+0000 to
 U+007F) are not allowed.
### IRISurrogateLenient
    public static final URIUtility.ParseMode IRISurrogateLenient
The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are
 valid. Unpaired surrogate code points are treated as though they
 were replacement characters instead for the purposes of these
 rules, so that strings with those code points are not considered
 invalid strings.
