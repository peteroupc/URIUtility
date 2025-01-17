# com.upokecenter.util.URIUtility.ParseMode

    public static enum URIUtility.ParseMode extends Enum<URIUtility.ParseMode>

Specifies whether certain characters are allowed when parsing IRIs and URIs.

## Nested Classes

## Enum Constants

* `IRILenient `<br>
 The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are valid.

* `IRIStrict `<br>
 The rules follow the syntax for parsing IRIs.

* `IRISurrogateLenient `<br>
 The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are valid.

* `URILenient `<br>
 The rules only check for the appropriate delimiters when splitting the path,
 without checking if all the characters in each component are valid.

* `URIStrict `<br>
 The rules follow the syntax for parsing IRIs, except that code points
 outside the Basic Latin range (U+0000 to U+007F) are not allowed.

## Methods

* `static URIUtility.ParseMode valueOf(String name)`<br>
 Returns the enum constant of this class with the specified name.

* `static URIUtility.ParseMode[] values()`<br>
 Returns an array containing the constants of this enum class, in
the order they are declared.

## Method Details

### values

    public static URIUtility.ParseMode[] values()

### valueOf

    public static URIUtility.ParseMode valueOf(String name)
