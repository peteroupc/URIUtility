using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PeterO;

namespace Test {
  [TestFixture]
  public class URIUtilityTest {
    public static bool SplitIRIFails(string iri, bool expectedNonNull) {
      return expectedNonNull ? URIUtility.SplitIRI(iri) == null :
        URIUtility.SplitIRI(iri) != null;
    }

    [Test]
    public void TestIPv6() {
      var resources = new AppResources("Resources");
      string[] cases = ParseJSONStringArray(
          resources.GetString("ipv6parse"));
      for (var i = 0; i < cases.Length; i += 2) {
        if (SplitIRIFails(
            cases[i],
            cases[i + 1].Equals("1", StringComparison.Ordinal))) {
          Assert.Fail(cases[i] + " " + cases[i + 1]);
        }
      }
    }

    private static void TestEmptyPathOne(string uri) {
      int[] iriPositions = URIUtility.SplitIRI(uri);
      if (iriPositions == null) {
        Assert.Fail();
      }
      Assert.IsTrue(iriPositions[4] >= 0);
      Assert.AreEqual(iriPositions[4], iriPositions[5]);
    }

    [Test]
    public void TestEmptyPathURIs() {
      TestEmptyPathOne("s://h");
      TestEmptyPathOne("s://h?x");
      TestEmptyPathOne("s://h#x");
      TestEmptyPathOne("//h");
      TestEmptyPathOne("//h?x");
      TestEmptyPathOne("//h#x");
      TestEmptyPathOne("s://");
      TestEmptyPathOne("s://?x");
      TestEmptyPathOne("s://#x");
      TestEmptyPathOne("s:");
      TestEmptyPathOne("s:?x");
      TestEmptyPathOne("s:#x");
    }

    private static void AssertIdempotency(string s) {
      bool cond = URIUtility.IsValidIRI(s);

      Assert.IsTrue(cond, s);
      {
        var stringTemp = (string)URIUtility.EscapeURI(
          s,
          0);
        var stringTemp2 = (string)URIUtility.EscapeURI(
  (string)URIUtility.EscapeURI(s, 0),
  0);
        Assert.AreEqual(stringTemp, stringTemp2);
      }
      {
        var stringTemp = (string)URIUtility.EscapeURI(
          s,
          1);
        var stringTemp2 = (string)URIUtility.EscapeURI(
  (string)URIUtility.EscapeURI(s, 1),
  1);
        Assert.AreEqual(stringTemp, stringTemp2);
      }
      {
        var stringTemp = (string)URIUtility.EscapeURI(
          s,
          2);
        var stringTemp2 = (string)URIUtility.EscapeURI(
  (string)URIUtility.EscapeURI(s, 2),
  2);
        Assert.AreEqual(stringTemp, stringTemp2);
      }
      {
        var stringTemp = (string)URIUtility.EscapeURI(
          s,
          3);
        var stringTemp2 = (string)URIUtility.EscapeURI(
  (string)URIUtility.EscapeURI(s, 3),
  3);
        Assert.AreEqual(stringTemp, stringTemp2);
      }
    }

    private static void AssertIdempotencyNeg(
      string s) {
      if ((bool)URIUtility.IsValidIRI(s)) {
        Assert.Fail(s);
      }

      {
        var stringTemp = (string)URIUtility.EscapeURI(
          s,
          0);
        var stringTemp2 = (string)URIUtility.EscapeURI(
  (string)URIUtility.EscapeURI(s, 0),
  0);
        Assert.AreEqual(stringTemp, stringTemp2);
      }
      {
        var stringTemp = (string)URIUtility.EscapeURI(
          s,
          1);
        var stringTemp2 = (string)URIUtility.EscapeURI(
  (string)URIUtility.EscapeURI(s, 1),
  1);
        Assert.AreEqual(stringTemp, stringTemp2);
      }
      {
        var stringTemp = (string)URIUtility.EscapeURI(
          s,
          2);
        var stringTemp2 = (string)URIUtility.EscapeURI(
  (string)URIUtility.EscapeURI(s, 2),
  2);
        Assert.AreEqual(stringTemp, stringTemp2);
      }
      {
        var stringTemp = (string)URIUtility.EscapeURI(
          s,
          3);
        var stringTemp2 = (string)URIUtility.EscapeURI(
  (string)URIUtility.EscapeURI(s, 3),
  3);
        Assert.AreEqual(stringTemp, stringTemp2);
      }
    }

    private static void AssertResolve(
      String src,
      String baseuri,
      String dest) {
      AssertIdempotency(src);
      AssertIdempotency(baseuri);
      AssertIdempotency(dest);
      var res = (string)URIUtility.RelativeResolve(
        src,
        baseuri);
      AssertIdempotency(res);
      Assert.AreEqual(dest, res);
    }

    [Test]
    [Timeout(5000)]
    public void TestRelativeResolve() {
      AssertResolve(
        "index.html",
        "http://example.com",
        "http://example.com/index.html");
      AssertResolve(
        "./.x",
        "http://example.com/a/b/c/d/e.f",
        "http://example.com/a/b/c/d/.x");
      AssertResolve(
        ".x",
        "http://example.com/a/b/c/d/e.f",
        "http://example.com/a/b/c/d/.x");
      AssertResolve(
        "../.x",
        "http://example.com/a/b/c/d/e.f",
        "http://example.com/a/b/c/.x");
      AssertResolve(
        "../..../../../.../.x",
        "http://example.com/a/b/c/d/e.f",
        "http://example.com/a/b/.../.x");
    }

    [Test]
    [Timeout(5000)]
    public void TestUri() {
      AssertIdempotency(String.Empty);
      AssertIdempotency("e");
      AssertIdempotency("e:x");
      AssertIdempotency("e://x:@y");
      AssertIdempotency("e://x/y");
      AssertIdempotency("e://x//y");
      AssertIdempotency("a://x:@y/z");
      AssertIdempotency("a://x:/y");
      AssertIdempotency("aa:/w/x");
      AssertIdempotency("01/w/x");
      AssertIdempotency("e://x");
      AssertIdempotency("e://x/:/");
      AssertIdempotency("x/:/");
      AssertIdempotency("/:/");
      AssertIdempotency("///");
      AssertIdempotency("e://x:");
      AssertIdempotency("e://x:%30");
      AssertIdempotency("a://x:?x");
      AssertIdempotency("a://x#x");
      AssertIdempotency("a://x?x");
      AssertIdempotency("a://x:#x");
      AssertIdempotency("e://x@x");
      AssertIdempotency("e://x@:");
      AssertIdempotency("e://x@:?");
      AssertIdempotency("e://x@:#");
      AssertIdempotency("//x@x");
      AssertIdempotency("//x@:");
      AssertIdempotency("//x@:?");
      AssertIdempotency("//x@:#");
      AssertIdempotency("//x@:?x");
      AssertIdempotency("e://x@:#x");
      AssertIdempotency("a://x:?x");
      AssertIdempotency("a://x#x");
      AssertIdempotency("a://x?x");
      AssertIdempotency("a://x:#x");

      AssertIdempotencyNeg("e://^//y");
      AssertIdempotencyNeg("e^");
      AssertIdempotencyNeg("e://x:a");
      AssertIdempotencyNeg("a://x::/y");
      AssertIdempotency("x@yz");
      AssertIdempotencyNeg("x@y:z");
      AssertIdempotencyNeg("01:/w/x");
      AssertIdempotencyNeg("e://x:%30/");
      AssertIdempotencyNeg("a://xxx@[");
      AssertIdempotencyNeg("a://[");

      AssertIdempotency("a://[va.a]");
      AssertIdempotency("a://[v0.0]");
      AssertIdempotency("a://x:/");
      AssertIdempotency("a://[va.a]:/");

      AssertIdempotencyNeg("a://x%/");
      AssertIdempotencyNeg("a://x%xy/");
      AssertIdempotencyNeg("a://x%x%/");
      AssertIdempotencyNeg("a://x%%x/");
      AssertIdempotency("a://x%20/");
      AssertIdempotency("a://[v0.0]/");
      AssertIdempotencyNeg("a://[wa.a]");
      AssertIdempotencyNeg("a://[w0.0]");
      AssertIdempotencyNeg("a://[va.a/");
      AssertIdempotencyNeg("a://[v.a]");
      AssertIdempotencyNeg("a://[va.]");

      AssertIPv6("a:a:a:a:a:a:100.100.100.100");
      AssertIPv6("::a:a:a:a:a:100.100.100.100");
      AssertIPv6("::a:a:a:a:a:99.255.240.10");
      AssertIPv6("::a:a:a:a:99.255.240.10");
      AssertIPv6("::99.255.240.10");
      AssertIPv6Neg("99.255.240.10");
      AssertIPv6("a:a:a:a:a::99.255.240.10");
      AssertIPv6("a:a:a:a:a:a:a:a");
      AssertIPv6("aaa:a:a:a:a:a:a:a");
      AssertIPv6("aaaa:a:a:a:a:a:a:a");
      AssertIPv6("::a:a:a:a:a:a:a");
      AssertIPv6("a::a:a:a:a:a:a");
      AssertIPv6("a:a::a:a:a:a:a");
      AssertIPv6("a:a:a::a:a:a:a");
      AssertIPv6("a:a:a:a::a:a:a");
      AssertIPv6("a:a:a:a:a::a:a");
      AssertIPv6("a:a:a:a:a:a::a");
      AssertIPv6("a::a");
      AssertIPv6("::a");
      AssertIPv6("::a:a");
      AssertIPv6("::");
      AssertIPv6("a:a:a:a:a:a:a::");
      AssertIPv6("a:a:a:a:a:a::");
      AssertIPv6("a:a:a:a:a::");
      AssertIPv6("a:a:a:a::");
      AssertIPv6("a:a::");
      AssertIPv6Neg("a:a::a:a:a:a:a:a");
      AssertIPv6Neg("aaaaa:a:a:a:a:a:a:a");
      AssertIPv6Neg("a:a:a:a:a:a:a:100.100.100.100");
      AssertIPv6Neg("a:a:a:a:a:a::99.255.240.10");
      AssertIPv6Neg(":::a:a:a:a:a:a:a");
      AssertIPv6Neg("a:a:a:a:a:a:::a");
      AssertIPv6Neg("a:a:a:a:a:a:a:::");
      AssertIPv6Neg("::a:a:a:a:a:a:a:");
      AssertIPv6Neg("::a:a:a:a:a:a:a:a");
      AssertIPv6Neg("a:a");
      AssertIdempotency("e://[va.a]");
      AssertIdempotency("e://[v0.0]");

      AssertIdempotencyNeg("e://[wa.a]");
      AssertIdempotencyNeg("e://[va.^]");
      AssertIdempotencyNeg("e://[va.]");
      AssertIdempotencyNeg("e://[v.a]");
    }

    private static void AssertIPv6Neg(string str) {
      AssertIdempotencyNeg("e://[" + str + "]");
      AssertIdempotencyNeg("e://[" + str + "NANA]");
      AssertIdempotencyNeg("e://[" + str + "%25]");
      AssertIdempotencyNeg("e://[" + str + "%NANA]");
      AssertIdempotencyNeg("e://[" + str + "%25NANA]");
      AssertIdempotencyNeg("e://[" + str + "%52NANA]");
      AssertIdempotencyNeg("e://[" + str + "%25NA<>NA]");
      AssertIdempotencyNeg("e://[" + str + "%25NA%E2NA]");
      AssertIdempotencyNeg("e://[" + str + "%25NA%2ENA]");
    }

    private static void TestPercentDecodeOne(string str, string exp) {
      Assert.AreEqual(exp, URIUtility.PercentDecode(str));
      Assert.AreEqual(exp, URIUtility.PercentDecode(str, true));
      Assert.AreEqual(exp, URIUtility.PercentDecode(str, false));
      Assert.AreEqual(exp, URIUtility.PercentDecode(str, 0, str.Length, true));
      Assert.AreEqual(exp, URIUtility.PercentDecode(str, 0, str.Length, false));
      Assert.AreEqual(
        exp,
        URIUtility.PercentDecode("??"+str+"??", 2, 2+str.Length,true));
      Assert.AreEqual(
         exp,
         URIUtility.PercentDecode("??"+str+"??", 2, 2+str.Length,false));
    }

    private static void TestPercentDecodeOneFail(string str, string exp) {
      Assert.AreEqual(exp, URIUtility.PercentDecode(str));
      Assert.AreEqual(exp, URIUtility.PercentDecode(str, true));
      Assert.AreEqual(null, URIUtility.PercentDecode(str, false));
      Assert.AreEqual(exp, URIUtility.PercentDecode(str, 0, str.Length, true));
{
        object objectTemp = null;
        object objectTemp2 = URIUtility.PercentDecode(
          str,
          0,
          str.Length,
          false);
        Assert.AreEqual(objectTemp, objectTemp2);
      }
      Assert.AreEqual(
        exp,
        URIUtility.PercentDecode("??"+str+"??", 2, 2+str.Length,true));
      Assert.AreEqual(
         null,
         URIUtility.PercentDecode("??"+str+"??", 2, 2+str.Length,false));
    }

    [Test]
    public void TestPercentDecode() {
      Assert.AreEqual(null, URIUtility.PercentDecode(null));
      TestPercentDecodeOne("test", "test");
      TestPercentDecodeOne("te%23t", "te\u0023t");
    TestPercentDecodeOne("te%7ft", "te\u007ft");
  TestPercentDecodeOne("te%04t", "te\u0004t");
  TestPercentDecodeOne("te%c2%80t", "te\u0080t");
  TestPercentDecodeOneFail("te%c2%40t", "te\ufffd\u0040t");
  TestPercentDecodeOneFail("te%c2%c3t", "te\ufffd\ufffdt");
   }

    private static void AssertIPv6(string str) {
      AssertIdempotency("e://[" + str + "]");

      AssertIdempotencyNeg("e://[" + str + "NANA]");
      AssertIdempotencyNeg("e://[" + str + "%25]");
      AssertIdempotencyNeg("e://[" + str + "%NANA]");
      AssertIdempotencyNeg("e://[" + str + "%52NANA]");
      AssertIdempotencyNeg("e://[" + str + "%25NA<>NA]");
      // NOTE: Commented out because current parser allows
      // IPv6 addresses with zone identifiers only if
      // the address is link-local
      // AssertIdempotency("e://[" + str + "%25NANA]");
      // AssertIdempotency("e://[" + str + "%25NA%E2NA]");
      // AssertIdempotency("e://[" + str + "%25NA%2ENA]");
    }

    /// <param name='str'>Not documented yet.</param>
    /// <returns/>
    /// <exception cref='ArgumentNullException'>The parameter <paramref
    /// name='str'/> is null.</exception>
    public static string[] ParseJSONStringArray(string str) {
      if (str == null) {
        throw new ArgumentNullException(nameof(str));
      }
      var endPos = new int[] { 0 };
      string[] ret = ParseJSONStringArray(str, endPos);
      if (endPos[0] != str.Length) {
        throw new InvalidOperationException("Invalid JSON");
      }
      return ret;
    }
    public static string[] ParseJSONStringArray(string str, int[] endPos) {
      if (str == null) {
        throw new ArgumentNullException(nameof(str));
      }
      if (endPos == null) {
        throw new ArgumentNullException(nameof(endPos));
      }
      int i = endPos[0];
      var j = 0;
      var list = new List<string>();
      var sb = new StringBuilder();
      while (i < str.Length && (
          str[i] == 0x20 || str[i] == 0x0d || str[i] == 0x0a ||
          str[i] == 0x09)) {
        ++i;
      }
      if (i >= str.Length || str[i] != '[') {
        throw new InvalidOperationException("Invalid JSON: " +
          str.Substring(i));
      }
      ++i;
      var endValue = false;
      while (true) {
        while (i < str.Length && (
            str[i] == 0x20 || str[i] == 0x0d || str[i] == 0x0a ||
            str[i] == 0x09)) {
          ++i;
        }
        if (i >= str.Length || (
            str[i] != ']' && str[i] != '"' && str[i] != 0x2c)) {
          throw new InvalidOperationException("Invalid JSON:" +
            "\u0020" + str.Substring(i));
        }
        var si = (int)str[i];
        switch (si) {
          case 0x5d:
            // right square bracket
            ++i;
            while (i < str.Length && (
                str[i] == 0x20 || str[i] == 0x0d || str[i] == 0x0a || str[i]
                == 0x09)) {
              ++i;
            }
            endPos[0] = i;
            return (string[])list.ToArray();
          case 0x2c:
            // comma
            if (!endValue) {
              throw new InvalidOperationException("Invalid JSON:" +
                "\u0020" + str.Substring(i));
            }
            ++i;
            endValue = false;
            break;
          case 0x22:
            // double quote
            j = i;
            i = ParseJSONString(str, i + 1, sb);
            if (i < 0) {
              throw new InvalidOperationException("Invalid JSON: bad string:" +
                "\u0020" + str.Substring(j));
            }
            endValue = true;
            list.Add(sb.ToString());
            break;
        }
      }
    }

    private static string ParseJSONString(string str) {
      if (str == null || str.Length < 2 || str[0] != '"') {
        throw new InvalidOperationException("Invalid JSON");
      }
      var sb = new StringBuilder();
      int result = ParseJSONString(str, 1, sb);
      if (result != str.Length) {
        throw new InvalidOperationException("Invalid JSON");
      }
      return sb.ToString();
    }

    private static int ParseJSONString(
      string str,
      int index,
      StringBuilder sb) {
      #if DEBUG
      if (str == null) {
        throw new ArgumentNullException(nameof(str));
      }
      if (sb == null) {
        throw new ArgumentNullException(nameof(sb));
      }
      #endif
      int c;
      sb.Remove(0, sb.Length);
      while (index < str.Length) {
        c = index >= str.Length ? -1 : str[index++];
        if (c == -1 || c < 0x20) {
          return -1;
        }
        if ((c & 0xfc00) == 0xd800 && index < str.Length &&
          (str[index] & 0xfc00) == 0xdc00) {
          // Get the Unicode code point for the surrogate pair
          c = 0x10000 + ((c & 0x3ff) << 10) + (str[index] & 0x3ff);
          ++index;
        } else if ((c & 0xf800) == 0xd800) {
          return -1;
        }
        switch (c) {
          case '\\':
            c = index >= str.Length ? -1 : str[index++];
            switch (c) {
              case '\\':
                sb.Append('\\');
                break;
              case '/':
                // Now allowed to be escaped under RFC 8259
                sb.Append('/');
                break;
              case '\"':
                sb.Append('\"');
                break;
              case 'b':
                sb.Append('\b');
                break;
              case 'f':
                sb.Append('\f');
                break;
              case 'n':
                sb.Append('\n');
                break;
              case 'r':
                sb.Append('\r');
                break;
              case 't':
                sb.Append('\t');
                break;
              case 'u': { // Unicode escape
                c = 0;
                // Consists of 4 hex digits
                for (var i = 0; i < 4; ++i) {
                  int ch = index >= str.Length ? -1 : str[index++];
                  if (ch >= '0' && ch <= '9') {
                    c <<= 4;
                    c |= ch - '0';
                  } else if (ch >= 'A' && ch <= 'F') {
                    c <<= 4;
                    c |= ch + 10 - 'A';
                  } else if (ch >= 'a' && ch <= 'f') {
                    c <<= 4;
                    c |= ch + 10 - 'a';
                  } else {
                    return -1;
                  }
                }
                if ((c & 0xf800) != 0xd800) {
                  // Non-surrogate
                  sb.Append((char)c);
                } else if ((c & 0xfc00) == 0xd800) {
                  int ch = index >= str.Length ? -1 : str[index++];
                  if (ch != '\\' ||
                    (index >= str.Length ? -1 : str[index++]) != 'u') {
                    return -1;
                  }
                  var c2 = 0;
                  for (var i = 0; i < 4; ++i) {
                    ch = index >= str.Length ? -1 : str[index++];
                    if (ch >= '0' && ch <= '9') {
                      c2 <<= 4;
                      c2 |= ch - '0';
                    } else if (ch >= 'A' && ch <= 'F') {
                      c2 <<= 4;
                      c2 |= ch + 10 - 'A';
                    } else if (ch >= 'a' && ch <= 'f') {
                      c2 <<= 4;
                      c2 |= ch + 10 - 'a';
                    } else {
                      return -1;
                    }
                  }
                  if ((c2 & 0xfc00) != 0xdc00) {
                    return -1;
                  } else {
                    sb.Append((char)c);
                    sb.Append((char)c2);
                  }
                } else {
                  return -1;
                }
                break;
              }
              default: {
                // NOTE: Includes surrogate code
                // units
                return -1;
              }
            }
            break;
          case 0x22: // double quote
            return index;
          default: {
            // NOTE: Assumes the character reader
            // throws an error on finding illegal surrogate
            // pairs in the string or invalid encoding
            // in the stream
            if ((c >> 16) == 0) {
              sb.Append((char)c);
            } else {
              sb.Append((char)((((c - 0x10000) >> 10) & 0x3ff) | 0xd800));
              sb.Append((char)(((c - 0x10000) & 0x3ff) | 0xdc00));
            }
            break;
          }
        }
      }
      return -1;
    }
  }
}
