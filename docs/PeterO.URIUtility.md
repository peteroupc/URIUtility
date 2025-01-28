## PeterO.URIUtility

    public static class URIUtility

Contains auxiliary methods for processing Uniform Resource Identifiers (URIs) and Internationalized Resource Identifiers (IRIs) under RFC3986 and RFC3987, respectively. In the following documentation, URIs and IRIs include URI references and IRI references, for convenience. There are five components to a URI: scheme, authority, path, query, and fragment identifier. The generic syntax to these components is defined in RFC3986 and extended in RFC3987. According to RFC3986, different URI schemes can further restrict the syntax of the authority, path, and query component (see also RFC 7320). However, the syntax of fragment identifiers depends on the media type (also known as MIME type) of the resource a URI references (see also RFC 3986 and RFC 7320). As of September 3, 2019, only the following media types specify a syntax for fragment identifiers:

 * The following application/* media types: epub + zip, pdf, senml + cbor, senml + json, senml-exi, sensml + cbor, sensml + json, sensml-exi, smil, vnd.3gpp-v2x-local-service-information, vnd.3gpp.mcdata-signalling, vnd.collection.doc + json, vnd.hc + json, vnd.hyper + json, vnd.hyper-item + json, vnd.mason + json, vnd.microsoft.portable-executable, vnd.oma.bcast.sgdu, vnd.shootproof + json

 * The following image/* media types: avci, avcs, heic, heic-sequence, heif, heif-sequence, hej2k, hsj2, jxra, jxrs, jxsi, jxss

 * The XML media types: application/xml, application/xml-external-parsed-entity, text/xml, text/xml-external-parsed-entity, application/xml-dtd

 * All media types with subtypes ending in "+xml" (see RFC 7303) use XPointer Framework syntax as fragment identifiers, except the following application/* media types: dicom + xml (syntax not defined), senml + xml (own syntax), sensml + xml (own syntax), ttml + xml (own syntax), xliff + xml (own syntax), yang-data + xml (syntax not defined)

 * font/collection

 * multipart/x-mixed-replace

 * text/plain

 * text/csv

 * text/html

 * text/markdown

 * text/vnd.a

### Member Summary
* <code>[BuildIRI(string, string, string, string)](#BuildIRI_string_string_string_string)</code> - Builds an internationalized resource identifier (IRI) from its components.
* <code>[DirectoryPath(string)](#DirectoryPath_string)</code> - Extracts the scheme, the authority, and the path component (up to and including the last "/" in the path if any) from the specified URI or IRI, using the IRIStrict parse mode to check the URI or IRI.
* <code>[DirectoryPath(string, PeterO.URIUtility.ParseMode)](#DirectoryPath_string_PeterO_URIUtility_ParseMode)</code> - Extracts the scheme, the authority, and the path component (up to and including the last "/" in the path if any) from the specified URI or IRI, using the specified parse mode to check the URI or IRI.
* <code>[EncodeStringForURI(string)](#EncodeStringForURI_string)</code> - Encodes characters other than "unreserved" characters for URIs.
* <code>[EscapeURI(string, int)](#EscapeURI_string_int)</code> - Checks a text string representing a URI or IRI and escapes characters it has that can't appear in URIs or IRIs.
* <code>[HasScheme(string)](#HasScheme_string)</code> - Determines whether the string is a valid IRI with a scheme component.
* <code>[HasSchemeForURI(string)](#HasSchemeForURI_string)</code> - Determines whether the string is a valid URI with a scheme component.
* <code>[IsValidCurieReference(string, int, int)](#IsValidCurieReference_string_int_int)</code> - Determines whether the substring is a valid CURIE reference under RDFA 1.
* <code>[IsValidIRI(string)](#IsValidIRI_string)</code> - Returns whether a string is a valid IRI according to the IRIStrict parse mode.
* <code>[IsValidIRI(string, PeterO.URIUtility.ParseMode)](#IsValidIRI_string_PeterO_URIUtility_ParseMode)</code> - Returns whether a string is a valid IRI according to the specified parse mode.
* <code>[PercentDecode(string)](#PercentDecode_string)</code> - Decodes percent-encoding (of the form "%XX" where X is a hexadecimal (base-16) digit) in the specified string.
* <code>[PercentDecode(string, int, int)](#PercentDecode_string_int_int)</code> - Decodes percent-encoding (of the form "%XX" where X is a hexadecimal (base-16) digit) in the specified portion of a string.
* <code>[RelativeResolve(string, string)](#RelativeResolve_string_string)</code> - Resolves a URI or IRI relative to another URI or IRI.
* <code>[RelativeResolve(string, string, PeterO.URIUtility.ParseMode)](#RelativeResolve_string_string_PeterO_URIUtility_ParseMode)</code> - Resolves a URI or IRI relative to another URI or IRI.
* <code>[RelativeResolveWithinBaseURI(string, string)](#RelativeResolveWithinBaseURI_string_string)</code> - Resolves a URI or IRI relative to another URI or IRI, but only if the resolved URI has no ".
* <code>[SplitIRI(string)](#SplitIRI_string)</code> - Parses an Internationalized Resource Identifier (IRI) reference under RFC3987.
* <code>[SplitIRI(string, int, int, PeterO.URIUtility.ParseMode)](#SplitIRI_string_int_int_PeterO_URIUtility_ParseMode)</code> - Parses a substring that represents an Internationalized Resource Identifier (IRI) under RFC3987.
* <code>[SplitIRI(string, PeterO.URIUtility.ParseMode)](#SplitIRI_string_PeterO_URIUtility_ParseMode)</code> - Parses an Internationalized Resource Identifier (IRI) reference under RFC3987.
* <code>[SplitIRIToStrings(string)](#SplitIRIToStrings_string)</code> - Parses an Internationalized Resource Identifier (IRI) reference under RFC3987.

<a id="BuildIRI_string_string_string_string"></a>
### BuildIRI

    public static string BuildIRI(
        string schemeAndAuthority,
        string path,
        string query,
        string fragment);

Builds an internationalized resource identifier (IRI) from its components.

<b>Parameters:</b>

 * <i>schemeAndAuthority</i>: String representing a scheme component, an authority component, or both. Examples of this parameter include "example://example", "example:", and "//example", but not "example". Can be null or empty.

 * <i>path</i>: A string representing a path component. Can be null or empty.

 * <i>query</i>: The query string. Can be null or empty.

 * <i>fragment</i>: The fragment identifier. Can be null or empty.

<b>Return Value:</b>

A URI built from the specified components.

<b>Exceptions:</b>

 * System.ArgumentException:
Invalid schemeAndAuthority parameter, or the arguments result in an invalid IRI.

<a id="DirectoryPath_string"></a>
### DirectoryPath

    public static string DirectoryPath(
        string uref);

Extracts the scheme, the authority, and the path component (up to and including the last "/" in the path if any) from the specified URI or IRI, using the IRIStrict parse mode to check the URI or IRI. Any "./" or "../" in the path is not condensed.

<b>Parameters:</b>

 * <i>uref</i>: A text string representing a URI or IRI. Can be null.

<b>Return Value:</b>

The directory path of the URI or IRI. Returns null if  <i>uref</i>
 is null or not a valid URI or IRI.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter  <i>uref</i>
 is null.

<a id="DirectoryPath_string_PeterO_URIUtility_ParseMode"></a>
### DirectoryPath

    public static string DirectoryPath(
        string uref,
        PeterO.URIUtility.ParseMode parseMode);

Extracts the scheme, the authority, and the path component (up to and including the last "/" in the path if any) from the specified URI or IRI, using the specified parse mode to check the URI or IRI. Any "./" or "../" in the path is not condensed.

<b>Parameters:</b>

 * <i>uref</i>: A text string representing a URI or IRI. Can be null.

 * <i>parseMode</i>: The parse mode to use to check the URI or IRI.

<b>Return Value:</b>

The directory path of the URI or IRI. Returns null if  <i>uref</i>
 is null or not a valid URI or IRI.

<a id="EncodeStringForURI_string"></a>
### EncodeStringForURI

    public static string EncodeStringForURI(
        string s);

Encodes characters other than "unreserved" characters for URIs.

<b>Parameters:</b>

 * <i>s</i>: A string to encode.

<b>Return Value:</b>

The encoded string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter  <i>s</i>
 is null.

<a id="EscapeURI_string_int"></a>
### EscapeURI

    public static string EscapeURI(
        string s,
        int mode);

Checks a text string representing a URI or IRI and escapes characters it has that can't appear in URIs or IRIs. The function is idempotent; that is, calling the function again on the result with the same mode doesn't change the result.

<b>Parameters:</b>

 * <i>s</i>: A text string representing a URI or IRI. Can be null.

 * <i>mode</i>: Has the following meaning: 0 = Encode reserved code points, code points below U+0021, code points above U+007E, and square brackets within the authority component, and do the IRISurrogateLenient check. 1 = Encode code points above U+007E, and square brackets within the authority component, and do the IRIStrict check. 2 = Same as 1, except the check is IRISurrogateLenient. 3 = Same as 0, except that percent characters that begin illegal percent-encoding are also encoded.

<b>Return Value:</b>

A form of the URI or IRI that possibly contains escaped characters, or null if s is null.

<a id="HasScheme_string"></a>
### HasScheme

    public static bool HasScheme(
        string refValue);

 Determines whether the string is a valid IRI with a scheme component. This can be used to check for relative IRI references. The following cases return true:

    xx-x:mm example:/ww

 The following cases return false:

    x@y:/z /x/y/z example.xyz

 .

<b>Parameters:</b>

 * <i>refValue</i>: A string representing an IRI to check.

<b>Return Value:</b>

 `true`  if the string is a valid IRI with a scheme component; otherwise,  `false`  .

<a id="HasSchemeForURI_string"></a>
### HasSchemeForURI

    public static bool HasSchemeForURI(
        string refValue);

 Determines whether the string is a valid URI with a scheme component. This can be used to check for relative URI references. The following cases return true:

    [http://example/z](http://example/z) xx-x:mm example:/ww

 The following cases return false:

    x@y:/z /x/y/z example.xyz

 .

<b>Parameters:</b>

 * <i>refValue</i>: A string representing an IRI to check.

<b>Return Value:</b>

 `true`  if the string is a valid URI with a scheme component; otherwise,  `false`  .

<a id="IsValidCurieReference_string_int_int"></a>
### IsValidCurieReference

    public static bool IsValidCurieReference(
        string s,
        int offset,
        int length);

Determines whether the substring is a valid CURIE reference under RDFA 1.1. (The CURIE reference is the part after the colon.).

<b>Parameters:</b>

 * <i>s</i>: A string containing a CURIE reference. Can be null.

 * <i>offset</i>: An index starting at 0 showing where the desired portion of "s" begins.

 * <i>length</i>: The number of elements in the desired portion of "s" (but not more than "s" 's length).

<b>Return Value:</b>

 `true`  if the substring is a valid CURIE reference under RDFA 1; otherwise,  `false` . Returns false if  <i>s</i>
 is null.

<b>Exceptions:</b>

 * System.ArgumentException:
Either  <i>offset</i>
 or  <i>length</i>
 is less than 0 or greater than  <i>s</i>
 's length, or  <i>s</i>
 's length minus  <i>offset</i>
 is less than  <i>length</i>
.

 * System.ArgumentNullException:
The parameter  <i>s</i>
 is null.

<a id="IsValidIRI_string"></a>
### IsValidIRI

    public static bool IsValidIRI(
        string s);

Returns whether a string is a valid IRI according to the IRIStrict parse mode.

<b>Parameters:</b>

 * <i>s</i>: A text string. Can be null.

<b>Return Value:</b>

True if the string is not null and is a valid IRI; otherwise, false.

<a id="IsValidIRI_string_PeterO_URIUtility_ParseMode"></a>
### IsValidIRI

    public static bool IsValidIRI(
        string s,
        PeterO.URIUtility.ParseMode parseMode);

Returns whether a string is a valid IRI according to the specified parse mode.

<b>Parameters:</b>

 * <i>s</i>: A text string. Can be null.

 * <i>parseMode</i>: The parse mode to use when checking for a valid IRI.

<b>Return Value:</b>

True if the string is not null and is a valid IRI; otherwise, false.

<a id="PercentDecode_string"></a>
### PercentDecode

    public static string PercentDecode(
        string str);

Decodes percent-encoding (of the form "%XX" where X is a hexadecimal (base-16) digit) in the specified string. Successive percent-encoded bytes are assumed to form characters in UTF-8.

<b>Parameters:</b>

 * <i>str</i>: A string that may contain percent encoding. May be null.

<b>Return Value:</b>

The string in which percent-encoding was decoded.

<a id="PercentDecode_string_int_int"></a>
### PercentDecode

    public static string PercentDecode(
        string str,
        int index,
        int endIndex);

Decodes percent-encoding (of the form "%XX" where X is a hexadecimal (base-16) digit) in the specified portion of a string. Successive percent-encoded bytes are assumed to form characters in UTF-8.

<b>Parameters:</b>

 * <i>str</i>: A string a portion of which may contain percent encoding. May be null.

 * <i>index</i>: Index starting at 0 showing where the desired portion of  <i>str</i>
 begins.

 * <i>endIndex</i>: Index starting at 0 showing where the desired portion of  <i>str</i>
 ends. The character before this index is the last character.

<b>Return Value:</b>

The portion of the specified string in which percent-encoding was decoded. Returns null if  <i>str</i>
 is ull.

<a id="RelativeResolve_string_string"></a>
### RelativeResolve

    public static string RelativeResolve(
        string refValue,
        string absoluteBase);

Resolves a URI or IRI relative to another URI or IRI.

<b>Parameters:</b>

 * <i>refValue</i>: A string representing a URI or IRI reference. Example:  `dir/file.txt` .

 * <i>absoluteBase</i>: A string representing an absolute URI or IRI reference. Can be null. Example:  `http://example.com/my/path/` .

<b>Return Value:</b>

The resolved IRI, or null if  <i>refValue</i>
 is null or is not a valid IRI. If  <i>absoluteBase</i>
 is null or is not a valid IRI, returns refValue. Example:  `http://example.com/my/path/dir/file.txt` .

<a id="RelativeResolve_string_string_PeterO_URIUtility_ParseMode"></a>
### RelativeResolve

    public static string RelativeResolve(
        string refValue,
        string absoluteBase,
        PeterO.URIUtility.ParseMode parseMode);

Resolves a URI or IRI relative to another URI or IRI.

<b>Parameters:</b>

 * <i>refValue</i>: A string representing a URI or IRI reference. Example:  `dir/file.txt` . Can be null.

 * <i>absoluteBase</i>: A string representing an absolute URI or IRI reference. Can be null. Example:  `http://example.com/my/path/` .

 * <i>parseMode</i>: Parse mode that specifies whether certain characters are allowed when parsing IRIs and URIs.

<b>Return Value:</b>

The resolved IRI, or null if  <i>refValue</i>
 is null or is not a valid IRI. If  <i>absoluteBase</i>
 is null or is not a valid IRI, returns refValue.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter  <i>refValue</i>
 or  <i>absoluteBase</i>
 or  <i>refValue</i>
 or  <i>refValue</i>
 is null.

<a id="RelativeResolveWithinBaseURI_string_string"></a>
### RelativeResolveWithinBaseURI

    public static string RelativeResolveWithinBaseURI(
        string refValue,
        string absoluteBase);

Resolves a URI or IRI relative to another URI or IRI, but only if the resolved URI has no "." or ".." component in its path and only if resolved URI's directory path matches that of the second URI or IRI.

<b>Parameters:</b>

 * <i>refValue</i>: A string representing a URI or IRI reference. Example:  `dir/file.txt` .

 * <i>absoluteBase</i>: A string representing an absolute URI reference. Example:  `http://example.com/my/path/` .

<b>Return Value:</b>

The resolved IRI, or null if  <i>refValue</i>
 is null or is not a valid IRI, or  <i>refValue</i>
 if  <i>absoluteBase</i>
 is null or an empty string, or null if  <i>absoluteBase</i>
 is neither null nor empty and is not a valid IRI. Returns null instead if the resolved IRI has no "." or ".." component in its path or if the resolved URI's directory path does not match that of  <i>absoluteBase</i>
. Example:  `http://example.com/my/path/dir/file.txt` .

<a id="SplitIRI_string"></a>
### SplitIRI

    public static int[] SplitIRI(
        string s);

Parses an Internationalized Resource Identifier (IRI) reference under RFC3987. If the IRI reference is syntactically valid, splits the string into its components and returns an array containing the indices into the components.

<b>Parameters:</b>

 * <i>s</i>: A string that contains an IRI. Can be null.

<b>Return Value:</b>

If the string is a valid IRI reference, returns an array of 10 integers. Each of the five pairs corresponds to the start and end index of the IRI's scheme, authority, path, query, or fragment identifier, respectively. The scheme, authority, query, and fragment identifier, if present, will each be given without the ending colon, the starting "//", the starting "?", and the starting "#", respectively. If a component is absent, both indices in that pair will be -1. If the string is null or is not a valid IRI, returns null.

<a id="SplitIRI_string_int_int_PeterO_URIUtility_ParseMode"></a>
### SplitIRI

    public static int[] SplitIRI(
        string s,
        int offset,
        int length,
        PeterO.URIUtility.ParseMode parseMode);

Parses a substring that represents an Internationalized Resource Identifier (IRI) under RFC3987. If the IRI is syntactically valid, splits the string into its components and returns an array containing the indices into the components.

<b>Parameters:</b>

 * <i>s</i>: A string that contains an IRI. Can be null.

 * <i>offset</i>: An index starting at 0 showing where the desired portion of "s" begins.

 * <i>length</i>: The length of the desired portion of "s" (but not more than "s" 's length).

 * <i>parseMode</i>: Parse mode that specifies whether certain characters are allowed when parsing IRIs and URIs.

<b>Return Value:</b>

If the string is a valid IRI, returns an array of 10 integers. Each of the five pairs corresponds to the start and end index of the IRI's scheme, authority, path, query, or fragment component, respectively. The scheme, authority, query, and fragment components, if present, will each be given without the ending colon, the starting "//", the starting "?", and the starting "#", respectively. If a component is absent, both indices in that pair will be -1 (an index won't be less than 0 in any other case). If the string is null or is not a valid IRI, returns null.

<b>Exceptions:</b>

 * System.ArgumentException:
Either  <i>offset</i>
 or  <i>length</i>
 is less than 0 or greater than  <i>s</i>
 's length, or  <i>s</i>
 's length minus  <i>offset</i>
 is less than  <i>length</i>
.

 * System.ArgumentNullException:
The parameter  <i>s</i>
 is null.

<a id="SplitIRI_string_PeterO_URIUtility_ParseMode"></a>
### SplitIRI

    public static int[] SplitIRI(
        string s,
        PeterO.URIUtility.ParseMode parseMode);

Parses an Internationalized Resource Identifier (IRI) reference under RFC3987. If the IRI is syntactically valid, splits the string into its components and returns an array containing the indices into the components.

<b>Parameters:</b>

 * <i>s</i>: A string representing an IRI. Can be null.

 * <i>parseMode</i>: The parameter  <i>parseMode</i>
 is a ParseMode object.

<b>Return Value:</b>

If the string is a valid IRI reference, returns an array of 10 integers. Each of the five pairs corresponds to the start and end index of the IRI's scheme, authority, path, query, or fragment identifier, respectively. The scheme, authority, query, and fragment identifier, if present, will each be given without the ending colon, the starting "//", the starting "?", and the starting "#", respectively. If a component is absent, both indices in that pair will be -1. If the string is null or is not a valid IRI, returns null.

<a id="SplitIRIToStrings_string"></a>
### SplitIRIToStrings

    public static string[] SplitIRIToStrings(
        string s);

Parses an Internationalized Resource Identifier (IRI) reference under RFC3987. If the IRI reference is syntactically valid, splits the string into its components and returns an array containing those components.

<b>Parameters:</b>

 * <i>s</i>: A string that contains an IRI. Can be null.

<b>Return Value:</b>

If the string is a valid IRI reference, returns an array of five strings. Each of the five pairs corresponds to the IRI's scheme, authority, path, query, or fragment identifier, respectively. If a component is absent, the corresponding element will be null. If the string is null or is not a valid IRI, returns null.
