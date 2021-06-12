# com.upokecenter.util.URIUtility

    public final class URIUtility extends java.lang.Object

Contains utility methods for processing Uniform Resource Identifiers (URIs)
 and Internationalized Resource Identifiers (IRIs) under RFC3986 and
 RFC3987, respectively. In the following documentation, URIs and IRIs
 include URI references and IRI references, for convenience. <p>There
 are five components to a URI: scheme, authority, path, query, and
 fragment identifier. The generic syntax to these components is defined
 in RFC3986 and extended in RFC3987. According to RFC3986, different
 URI schemes can further restrict the syntax of the authority, path,
 and query component (see also RFC 7320). However, the syntax of
 fragment identifiers depends on the media type (also known as MIME
 type) of the resource a URI references (see also RFC 3986 and RFC
 7320). As of September 3, 2019, only the following media types specify
 a syntax for fragment identifiers:</p> <ul> <li>The following
 application/* media types: epub + zip, pdf, senml + cbor, senml +
 json, senml-exi, sensml + cbor, sensml + json, sensml-exi, smil,
 vnd.3gpp-v2x-local-service-information, vnd.3gpp.mcdata-signalling,
 vnd.collection.doc + json, vnd.hc + json, vnd.hyper + json,
 vnd.hyper-item + json, vnd.mason + json,
 vnd.microsoft.portable-executable, vnd.oma.bcast.sgdu, vnd.shootproof
 + json</li> <li>The following image/* media types: avci, avcs, heic,
 heic-sequence, heif, heif-sequence, hej2k, hsj2, jxra, jxrs, jxsi,
 jxss</li> <li>The XML media types: application/xml,
 application/xml-external-parsed-entity, text/xml,
 text/xml-external-parsed-entity, application/xml-dtd</li> <li>All
  media types with subtypes ending in "+xml" (see RFC 7303) use XPointer
 Framework syntax as fragment identifiers, except the following
 application/* media types: dicom + xml (syntax not defined), senml +
 xml (own syntax), sensml + xml (own syntax), ttml + xml (own syntax),
 xliff + xml (own syntax), yang-data + xml (syntax not defined)</li>
 <li>font/collection</li> <li>multipart/x-mixed-replace</li>
 <li>text/plain</li> <li>text/csv</li> <li>text/html</li>
 <li>text/markdown</li> <li>text/vnd.a</li></ul>

## Methods

* `static class  URIUtility.ParseMode`<br>
 Specifies whether certain characters are allowed when parsing IRIs and URIs.
* `static java.lang.String BuildIRI​(java.lang.String schemeAndAuthority,
        java.lang.String path,
        java.lang.String query,
        java.lang.String fragment)`<br>
 Builds an internationalized resource identifier (IRI) from its components.
* `static java.lang.String DirectoryPath​(java.lang.String uref)`<br>
 Extracts the scheme, the authority, and the path component (up to and
  including the last "/" in the path if any) from the given URI or
 IRI, using the IRIStrict parse mode to check the URI or IRI.
* `static java.lang.String DirectoryPath​(java.lang.String uref,
             URIUtility.ParseMode parseMode)`<br>
 Extracts the scheme, the authority, and the path component (up to and
  including the last "/" in the path if any) from the given URI or
  IRI, using the given parse mode to check the URI or IRI.
* `static java.lang.String EncodeStringForURI​(java.lang.String s)`<br>
 Encodes characters other than "unreserved" characters for URIs.
* `static java.lang.String EscapeURI​(java.lang.String s,
         int mode)`<br>
 Checks a text string representing a URI or IRI and escapes characters it has
 that can't appear in URIs or IRIs.
* `static boolean HasScheme​(java.lang.String refValue)`<br>
 Determines whether the string is a valid IRI with a scheme component.
* `static boolean HasSchemeForURI​(java.lang.String refValue)`<br>
 Determines whether the string is a valid URI with a scheme component.
* `static boolean IsValidCurieReference​(java.lang.String s,
                     int offset,
                     int length)`<br>
 Determines whether the substring is a valid CURIE reference under RDFA 1.1.
* `static boolean IsValidIRI​(java.lang.String s)`<br>
 Returns whether a string is a valid IRI according to the IRIStrict parse
 mode.
* `static boolean IsValidIRI​(java.lang.String s,
          URIUtility.ParseMode parseMode)`<br>
 Returns whether a string is a valid IRI according to the given parse mode.
* `static java.lang.String PercentDecode​(java.lang.String str)`<br>
 Decodes percent-encoding (of the form "%XX" where X is a hexadecimal digit)
 in the given string.
* `static java.lang.String PercentDecode​(java.lang.String str,
             boolean replace)`<br>
 Decodes percent-encoding (of the form "%XX" where X is a hexadecimal digit)
 in the given string, with an option to fail rather than replace
 invalid encoding.
* `static java.lang.String PercentDecode​(java.lang.String str,
             int index,
             int endIndex)`<br>
 Decodes percent-encoding (of the form "%XX" where X is a hexadecimal digit)
 in the given portion of a string.
* `static java.lang.String PercentDecode​(java.lang.String str,
             int index,
             int endIndex,
             boolean replace)`<br>
 Decodes percent-encoding (of the form "%XX" where X is a hexadecimal digit)
 in the given portion of a string, with an option to fail rather than
 replace invalid encoding.
* `static java.lang.String RelativeResolve​(java.lang.String refValue,
               java.lang.String absoluteBase)`<br>
 Resolves a URI or IRI relative to another URI or IRI.
* `static java.lang.String RelativeResolve​(java.lang.String refValue,
               java.lang.String absoluteBase,
               URIUtility.ParseMode parseMode)`<br>
 Resolves a URI or IRI relative to another URI or IRI.
* `static java.lang.String RelativeResolveWithinBaseURI​(java.lang.String refValue,
                            java.lang.String absoluteBase)`<br>
 Resolves a URI or IRI relative to another URI or IRI, but only if the
  resolved URI has no "." or ".." component in its path and only if
 resolved URI's directory path matches that of the second URI or IRI.
* `static int[] SplitIRI​(java.lang.String s)`<br>
 Parses an Internationalized Resource Identifier (IRI) reference under
 RFC3987.
* `static int[] SplitIRI​(java.lang.String s,
        int offset,
        int length,
        URIUtility.ParseMode parseMode)`<br>
 Parses a substring that represents an Internationalized Resource Identifier
 (IRI) under RFC3987.
* `static int[] SplitIRI​(java.lang.String s,
        URIUtility.ParseMode parseMode)`<br>
 Parses an Internationalized Resource Identifier (IRI) reference under
 RFC3987.
* `static java.lang.String[] SplitIRIToStrings​(java.lang.String s)`<br>
 Parses an Internationalized Resource Identifier (IRI) reference under
 RFC3987.

## Nested Classes

* `static class  URIUtility.ParseMode`<br>
 Specifies whether certain characters are allowed when parsing IRIs and URIs.

## Method Details

### EscapeURI
    public static java.lang.String EscapeURI​(java.lang.String s, int mode)
Checks a text string representing a URI or IRI and escapes characters it has
 that can't appear in URIs or IRIs. The function is idempotent; that
 is, calling the function again on the result with the same mode
 doesn't change the result.

**Parameters:**

* <code>s</code> - A text string representing a URI or IRI. Can be null.

* <code>mode</code> - Has the following meaning: 0 = Encode reserved code points, code
 points below U+0021, code points above U+007E, and square brackets
 within the authority component, and do the IRISurrogateLenient
 check. 1 = Encode code points above U+007E, and square brackets
 within the authority component, and do the IRIStrict check. 2 = Same
 as 1, except the check is IRISurrogateLenient. 3 = Same as 0, except
 that percent characters that begin illegal percent-encoding are also
 encoded.

**Returns:**

* A form of the URI or IRI that possibly contains escaped characters,
 or null if s is null.

### HasScheme
    public static boolean HasScheme​(java.lang.String refValue)
Determines whether the string is a valid IRI with a scheme component. This
 can be used to check for relative IRI references. <p>The following
 cases return true:</p> <pre>xx-x:mm example:/ww</pre> The following
 cases return false: <pre>x@y:/z /x/y/z example.xyz</pre>.

**Parameters:**

* <code>refValue</code> - A string representing an IRI to check.

**Returns:**

* <code>true</code> if the string is a valid IRI with a scheme component;
 otherwise, <code>false</code>.

### HasSchemeForURI
    public static boolean HasSchemeForURI​(java.lang.String refValue)
Determines whether the string is a valid URI with a scheme component. This
 can be used to check for relative URI references. The following
 cases return true: <pre>http://example/z xx-x:mm example:/ww</pre>
 The following cases return false: <pre>x@y:/z /x/y/z example.xyz</pre> .

**Parameters:**

* <code>refValue</code> - A string representing an IRI to check.

**Returns:**

* <code>true</code> if the string is a valid URI with a scheme component;
 otherwise, <code>false</code>.

### PercentDecode
    public static java.lang.String PercentDecode​(java.lang.String str)
Decodes percent-encoding (of the form "%XX" where X is a hexadecimal digit)
 in the given string. Successive percent-encoded bytes are assumed to
 form characters in UTF-8.

**Parameters:**

* <code>str</code> - A string that may contain percent encoding. May be null.

**Returns:**

* The string in which percent-encoding was decoded.

### PercentDecode
    public static java.lang.String PercentDecode​(java.lang.String str, boolean replace)
Decodes percent-encoding (of the form "%XX" where X is a hexadecimal digit)
 in the given string, with an option to fail rather than replace
 invalid encoding. Successive percent-encoded bytes are assumed to
 form characters in UTF-8.

**Parameters:**

* <code>str</code> - A string that may contain percent encoding. May be null.

* <code>replace</code> - Indicates whether to replace invalid encoding with U+FFFD,
 the replacement character. If false, returns null if invalid
 encoding is found.

**Returns:**

* The string in which percent-encoding was decoded. Returns null if
  "str" is null or if "replace" is true and the string has an invalid
 encoding.

### PercentDecode
    public static java.lang.String PercentDecode​(java.lang.String str, int index, int endIndex)
Decodes percent-encoding (of the form "%XX" where X is a hexadecimal digit)
 in the given portion of a string. Successive percent-encoded bytes
 are assumed to form characters in UTF-8.

**Parameters:**

* <code>str</code> - A string a portion of which may contain percent encoding. May be
 null.

* <code>index</code> - Index starting at 0 showing where the desired portion of <code>
 str</code> begins.

* <code>endIndex</code> - Index starting at 0 showing where the desired portion of
 <code>str</code> ends. The character before this index is the last
 character.

**Returns:**

* The portion of the given string in which percent-encoding was
 decoded. Returns null if <code>str</code> is null.

### PercentDecode
    public static java.lang.String PercentDecode​(java.lang.String str, int index, int endIndex, boolean replace)
Decodes percent-encoding (of the form "%XX" where X is a hexadecimal digit)
 in the given portion of a string, with an option to fail rather than
 replace invalid encoding. Successive percent-encoded bytes are
 assumed to form characters in UTF-8.

**Parameters:**

* <code>str</code> - A string a portion of which may contain percent encoding. May be
 null.

* <code>index</code> - Index starting at 0 showing where the desired portion of <code>
 str</code> begins.

* <code>endIndex</code> - Index starting at 0 showing where the desired portion of
 <code>str</code> ends. The character before this index is the last
 character.

* <code>replace</code> - Indicates whether to replace invalid encoding with U+FFFD,
 the replacement character. If false, returns null if invalid
 encoding is found.

**Returns:**

* The portion of the given string in which percent-encoding was
  decoded. Returns null if <code>str</code> is null or if "replace" is true
 and the portion of the string has an invalid encoding.

**Throws:**

* <code>java.lang.IllegalArgumentException</code> - doesn't satisfy lastIndex&gt;= index.

### EncodeStringForURI
    public static java.lang.String EncodeStringForURI​(java.lang.String s)
Encodes characters other than "unreserved" characters for URIs.

**Parameters:**

* <code>s</code> - A string to encode.

**Returns:**

* The encoded string.

**Throws:**

* <code>java.lang.NullPointerException</code> - The parameter <code>s</code> is null.

### IsValidCurieReference
    public static boolean IsValidCurieReference​(java.lang.String s, int offset, int length)
Determines whether the substring is a valid CURIE reference under RDFA 1.1.
 (The CURIE reference is the part after the colon.).

**Parameters:**

* <code>s</code> - A string containing a CURIE reference. Can be null.

* <code>offset</code> - An index starting at 0 showing where the desired portion of
  "s" begins.

* <code>length</code> - The number of elements in the desired portion of "s" (but not
  more than "s" 's length).

**Returns:**

* <code>true</code> if the substring is a valid CURIE reference under RDFA
 1; otherwise, <code>false</code>. Returns false if <code>s</code> is null.

**Throws:**

* <code>java.lang.IllegalArgumentException</code> - Either <code>offset</code> or <code>length</code> is less
 than 0 or greater than <code>s</code> 's length, or <code>s</code> 's length
 minus <code>offset</code> is less than <code>length</code>.

* <code>java.lang.NullPointerException</code> - The parameter <code>s</code> is null.

### BuildIRI
    public static java.lang.String BuildIRI​(java.lang.String schemeAndAuthority, java.lang.String path, java.lang.String query, java.lang.String fragment)
Builds an internationalized resource identifier (IRI) from its components.

**Parameters:**

* <code>schemeAndAuthority</code> - string representing a scheme component, an
 authority component, or both. Examples of this parameter include
  "example://example", "example:", and "//example", but not "example".
 Can be null or empty.

* <code>path</code> - A string representing a path component. Can be null or empty.

* <code>query</code> - The query string. Can be null or empty.

* <code>fragment</code> - The fragment identifier. Can be null or empty.

**Returns:**

* A URI built from the given components.

**Throws:**

* <code>java.lang.IllegalArgumentException</code> - Invalid schemeAndAuthority parameter, or the
 arguments result in an invalid IRI.

### IsValidIRI
    public static boolean IsValidIRI​(java.lang.String s)
Returns whether a string is a valid IRI according to the IRIStrict parse
 mode.

**Parameters:**

* <code>s</code> - A text string. Can be null.

**Returns:**

* True if the string is not null and is a valid IRI; otherwise, false.

### IsValidIRI
    public static boolean IsValidIRI​(java.lang.String s, URIUtility.ParseMode parseMode)
Returns whether a string is a valid IRI according to the given parse mode.

**Parameters:**

* <code>s</code> - A text string. Can be null.

* <code>parseMode</code> - The parse mode to use when checking for a valid IRI.

**Returns:**

* True if the string is not null and is a valid IRI; otherwise, false.

### RelativeResolve
    public static java.lang.String RelativeResolve​(java.lang.String refValue, java.lang.String absoluteBase)
Resolves a URI or IRI relative to another URI or IRI.

**Parameters:**

* <code>refValue</code> - A string representing a URI or IRI reference. Example:
 <code>dir/file.txt</code>.

* <code>absoluteBase</code> - A string representing an absolute URI or IRI reference.
 Can be null. Example: <code>http://example.com/my/path/</code>.

**Returns:**

* The resolved IRI, or null if <code>refValue</code> is null or is not a
 valid IRI. If <code>absoluteBase</code> is null or is not a valid IRI,
 returns refValue. Example: <code>
 http://example.com/my/path/dir/file.txt</code>.

### RelativeResolve
    public static java.lang.String RelativeResolve​(java.lang.String refValue, java.lang.String absoluteBase, URIUtility.ParseMode parseMode)
Resolves a URI or IRI relative to another URI or IRI.

**Parameters:**

* <code>refValue</code> - A string representing a URI or IRI reference. Example:
 <code>dir/file.txt</code>. Can be null.

* <code>absoluteBase</code> - A string representing an absolute URI or IRI reference.
 Can be null. Example: <code>http://example.com/my/path/</code>.

* <code>parseMode</code> - Parse mode that specifies whether certain characters are
 allowed when parsing IRIs and URIs.

**Returns:**

* The resolved IRI, or null if <code>refValue</code> is null or is not a
 valid IRI. If <code>absoluteBase</code> is null or is not a valid IRI,
 returns refValue.

**Throws:**

* <code>java.lang.NullPointerException</code> - The parameter <code>refValue</code> or <code>
 absoluteBase</code> or <code>refValue</code> or <code>refValue</code> is null.

### SplitIRIToStrings
    public static java.lang.String[] SplitIRIToStrings​(java.lang.String s)
Parses an Internationalized Resource Identifier (IRI) reference under
 RFC3987. If the IRI reference is syntactically valid, splits the
 string into its components and returns an array containing those
 components.

**Parameters:**

* <code>s</code> - A string that contains an IRI. Can be null.

**Returns:**

* If the string is a valid IRI reference, returns an array of five
 strings. Each of the five pairs corresponds to the IRI's scheme,
 authority, path, query, or fragment identifier, respectively. If a
 component is absent, the corresponding element will be null. If the
 string is null or is not a valid IRI, returns null.

### SplitIRI
    public static int[] SplitIRI​(java.lang.String s)
Parses an Internationalized Resource Identifier (IRI) reference under
 RFC3987. If the IRI reference is syntactically valid, splits the
 string into its components and returns an array containing the
 indices into the components.

**Parameters:**

* <code>s</code> - A string that contains an IRI. Can be null.

**Returns:**

* If the string is a valid IRI reference, returns an array of 10
 integers. Each of the five pairs corresponds to the start and end
 index of the IRI's scheme, authority, path, query, or fragment
 identifier, respectively. The scheme, authority, query, and fragment
 identifier, if present, will each be given without the ending colon,
  the starting "//", the starting "?", and the starting "#",
 respectively. If a component is absent, both indices in that pair
 will be -1. If the string is null or is not a valid IRI, returns
 null.

### SplitIRI
    public static int[] SplitIRI​(java.lang.String s, int offset, int length, URIUtility.ParseMode parseMode)
Parses a substring that represents an Internationalized Resource Identifier
 (IRI) under RFC3987. If the IRI is syntactically valid, splits the
 string into its components and returns an array containing the
 indices into the components.

**Parameters:**

* <code>s</code> - A string that contains an IRI. Can be null.

* <code>offset</code> - An index starting at 0 showing where the desired portion of
  "s" begins.

* <code>length</code> - The length of the desired portion of "s" (but not more than
  "s" 's length).

* <code>parseMode</code> - Parse mode that specifies whether certain characters are
 allowed when parsing IRIs and URIs.

**Returns:**

* If the string is a valid IRI, returns an array of 10 integers. Each
 of the five pairs corresponds to the start and end index of the
 IRI's scheme, authority, path, query, or fragment component,
 respectively. The scheme, authority, query, and fragment components,
 if present, will each be given without the ending colon, the
  starting "//", the starting "?", and the starting "#", respectively.
 If a component is absent, both indices in that pair will be -1 (an
 index won't be less than 0 in any other case). If the string is null
 or is not a valid IRI, returns null.

**Throws:**

* <code>java.lang.IllegalArgumentException</code> - Either <code>offset</code> or <code>length</code> is less
 than 0 or greater than <code>s</code> 's length, or <code>s</code> 's length
 minus <code>offset</code> is less than <code>length</code>.

* <code>java.lang.NullPointerException</code> - The parameter <code>s</code> is null.

### SplitIRI
    public static int[] SplitIRI​(java.lang.String s, URIUtility.ParseMode parseMode)
Parses an Internationalized Resource Identifier (IRI) reference under
 RFC3987. If the IRI is syntactically valid, splits the string into
 its components and returns an array containing the indices into the
 components.

**Parameters:**

* <code>s</code> - A string representing an IRI. Can be null.

* <code>parseMode</code> - The parameter <code>parseMode</code> is a ParseMode object.

**Returns:**

* If the string is a valid IRI reference, returns an array of 10
 integers. Each of the five pairs corresponds to the start and end
 index of the IRI's scheme, authority, path, query, or fragment
 identifier, respectively. The scheme, authority, query, and fragment
 identifier, if present, will each be given without the ending colon,
  the starting "//", the starting "?", and the starting "#",
 respectively. If a component is absent, both indices in that pair
 will be -1. If the string is null or is not a valid IRI, returns
 null.

### DirectoryPath
    public static java.lang.String DirectoryPath​(java.lang.String uref)
Extracts the scheme, the authority, and the path component (up to and
  including the last "/" in the path if any) from the given URI or
 IRI, using the IRIStrict parse mode to check the URI or IRI. Any
  "./" or "../" in the path is not condensed.

**Parameters:**

* <code>uref</code> - A text string representing a URI or IRI. Can be null.

**Returns:**

* The directory path of the URI or IRI. Returns null if <code>uref</code>
 is null or not a valid URI or IRI.

**Throws:**

* <code>java.lang.NullPointerException</code> - The parameter <code>uref</code> is null.

### DirectoryPath
    public static java.lang.String DirectoryPath​(java.lang.String uref, URIUtility.ParseMode parseMode)
Extracts the scheme, the authority, and the path component (up to and
  including the last "/" in the path if any) from the given URI or
  IRI, using the given parse mode to check the URI or IRI. Any "./" or
  "../" in the path is not condensed.

**Parameters:**

* <code>uref</code> - A text string representing a URI or IRI. Can be null.

* <code>parseMode</code> - The parse mode to use to check the URI or IRI.

**Returns:**

* The directory path of the URI or IRI. Returns null if <code>uref</code>
 is null or not a valid URI or IRI.

### RelativeResolveWithinBaseURI
    public static java.lang.String RelativeResolveWithinBaseURI​(java.lang.String refValue, java.lang.String absoluteBase)
Resolves a URI or IRI relative to another URI or IRI, but only if the
  resolved URI has no "." or ".." component in its path and only if
 resolved URI's directory path matches that of the second URI or IRI.

**Parameters:**

* <code>refValue</code> - A string representing a URI or IRI reference. Example:
 <code>dir/file.txt</code>.

* <code>absoluteBase</code> - A string representing an absolute URI reference.
 Example: <code>http://example.com/my/path/</code>.

**Returns:**

* The resolved IRI, or null if <code>refValue</code> is null or is not a
 valid IRI, or <code>refValue</code> if <code>absoluteBase</code> is null or an
 empty string, or null if <code>absoluteBase</code> is neither null nor
 empty and is not a valid IRI. Returns null instead if the resolved
  IRI has no "." or ".." component in its path or if the resolved
 URI's directory path does not match that of <code>absoluteBase</code>.
 Example: <code>http://example.com/my/path/dir/file.txt</code>.
