package com.upokecenter.test;

import java.util.*;

import org.junit.Assert;
import org.junit.Test;
import com.upokecenter.util.*;

  public class URIUtilityTest {
    public static boolean SplitIRIFails(String iri, boolean expectedNonNull) {
      return expectedNonNull ? URIUtility.SplitIRI(iri) == null :
        URIUtility.SplitIRI(iri) != null;
    }

    @Test
    public void TestIPv6() {
      AppResources resources = new AppResources("Resources");
      String[] cases = ParseJSONStringArray(
          resources.GetString("ipv6parse"));
      for (int i = 0; i < cases.length; i += 2) {
        if (SplitIRIFails(
            cases[i],
            cases[i + 1].equals("1"))) {
          Assert.fail(cases[i] + " " + cases[i + 1]);
        }
      }
    }

    private static void TestEmptyPathOne(String uri) {
      int[] iriPositions = URIUtility.SplitIRI(uri);
      if (iriPositions == null) {
        Assert.fail();
      }
      if (!(iriPositions[4] >= 0)) {
 Assert.fail();
 }
      Assert.assertEquals(iriPositions[4], iriPositions[5]);
    }

    @Test
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

    private static void AssertIdempotency(String s) {
      boolean cond = URIUtility.IsValidIRI(s);

      if (!(cond)) {
 Assert.fail(s);
 }
      {
        String stringTemp = (String)URIUtility.EscapeURI(
          s,
          0);
        String stringTemp2 = (String)URIUtility.EscapeURI(
  (String)URIUtility.EscapeURI(s, 0),
  0);
        Assert.assertEquals(stringTemp, stringTemp2);
      }
      {
        String stringTemp = (String)URIUtility.EscapeURI(
          s,
          1);
        String stringTemp2 = (String)URIUtility.EscapeURI(
  (String)URIUtility.EscapeURI(s, 1),
  1);
        Assert.assertEquals(stringTemp, stringTemp2);
      }
      {
        String stringTemp = (String)URIUtility.EscapeURI(
          s,
          2);
        String stringTemp2 = (String)URIUtility.EscapeURI(
  (String)URIUtility.EscapeURI(s, 2),
  2);
        Assert.assertEquals(stringTemp, stringTemp2);
      }
      {
        String stringTemp = (String)URIUtility.EscapeURI(
          s,
          3);
        String stringTemp2 = (String)URIUtility.EscapeURI(
  (String)URIUtility.EscapeURI(s, 3),
  3);
        Assert.assertEquals(stringTemp, stringTemp2);
      }
    }

    private static void AssertIdempotencyNeg(
      String s) {
      if ((boolean)URIUtility.IsValidIRI(s)) {
        Assert.fail(s);
      }

      {
        String stringTemp = (String)URIUtility.EscapeURI(
          s,
          0);
        String stringTemp2 = (String)URIUtility.EscapeURI(
  (String)URIUtility.EscapeURI(s, 0),
  0);
        Assert.assertEquals(stringTemp, stringTemp2);
      }
      {
        String stringTemp = (String)URIUtility.EscapeURI(
          s,
          1);
        String stringTemp2 = (String)URIUtility.EscapeURI(
  (String)URIUtility.EscapeURI(s, 1),
  1);
        Assert.assertEquals(stringTemp, stringTemp2);
      }
      {
        String stringTemp = (String)URIUtility.EscapeURI(
          s,
          2);
        String stringTemp2 = (String)URIUtility.EscapeURI(
  (String)URIUtility.EscapeURI(s, 2),
  2);
        Assert.assertEquals(stringTemp, stringTemp2);
      }
      {
        String stringTemp = (String)URIUtility.EscapeURI(
          s,
          3);
        String stringTemp2 = (String)URIUtility.EscapeURI(
  (String)URIUtility.EscapeURI(s, 3),
  3);
        Assert.assertEquals(stringTemp, stringTemp2);
      }
    }

    private static void AssertResolve(
      String src,
      String baseuri,
      String dest) {
      AssertIdempotency(src);
      AssertIdempotency(baseuri);
      AssertIdempotency(dest);
      String res = (String)URIUtility.RelativeResolve(
        src,
        baseuri);
      AssertIdempotency(res);
      Assert.assertEquals(dest, res);
    }

    @Test(timeout = 5000)
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

    @Test(timeout = 5000)
    public void TestUri() {
      AssertIdempotency("");
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

    private static void AssertIPv6Neg(String str) {
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

    private static void TestPercentDecodeOne(String str, String exp) {
      Assert.assertEquals(exp, URIUtility.PercentDecode(str));
      Assert.assertEquals(exp, URIUtility.PercentDecode(str, true));
      Assert.assertEquals(exp, URIUtility.PercentDecode(str, false));
      Assert.assertEquals(exp, URIUtility.PercentDecode(str, 0, str.length(), true));
      Assert.assertEquals(exp, URIUtility.PercentDecode(str, 0, str.length(), false));
      Assert.assertEquals(
        exp,
        URIUtility.PercentDecode("??" + str + "??", 2, 2 + str.length(), true));
      Assert.assertEquals(
         exp,
         URIUtility.PercentDecode("??" + str + "??", 2, 2 + str.length(), false));
    }

    private static void TestPercentDecodeOneFail(String str, String exp) {
      Assert.assertEquals(exp, URIUtility.PercentDecode(str));
      Assert.assertEquals(exp, URIUtility.PercentDecode(str, true));
      Assert.assertEquals(null, URIUtility.PercentDecode(str, false));
      Assert.assertEquals(exp, URIUtility.PercentDecode(str, 0, str.length(), true));
    {
        Object objectTemp = null;
        Object objectTemp2 = URIUtility.PercentDecode(
          str,
          0,
          str.length(),
          false);
        Assert.assertEquals(objectTemp, objectTemp2);
      }
      Assert.assertEquals(
        exp,
        URIUtility.PercentDecode("??" + str + "??", 2, 2 + str.length(), true));
      Assert.assertEquals(
         null,
         URIUtility.PercentDecode("??" + str + "??", 2, 2 + str.length(), false));
    }

    @Test
    public void TestPercentDecode() {
      Assert.assertEquals(null, URIUtility.PercentDecode(null));
      TestPercentDecodeOne("test", "test");
      TestPercentDecodeOne("te%23t", "te\u0023t");
    TestPercentDecodeOne("te%7ft", "te\u007ft");
  TestPercentDecodeOne("te%04t", "te\u0004t");
  TestPercentDecodeOne("te%c2%80t", "te\u0080t");
  TestPercentDecodeOneFail("te%c2%40t", "te\ufffd\u0040t");
  TestPercentDecodeOneFail("te%c2%c3t", "te\ufffd\ufffdt");
   }

    private static void AssertIPv6(String str) {
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

    /**
     * @param str Not documented yet.
     * @throws NullPointerException The parameter {@code str} is null.
     */
    public static String[] ParseJSONStringArray(String str) {
      if (str == null) {
        throw new NullPointerException("str");
      }
      int[] endPos = new int[] { 0 };
      String[] ret = ParseJSONStringArray(str, endPos);
      if (endPos[0] != str.length()) {
        throw new IllegalStateException("Invalid JSON");
      }
      return ret;
    }
    public static String[] ParseJSONStringArray(String str, int[] endPos) {
      if (str == null) {
        throw new NullPointerException("str");
      }
      if (endPos == null) {
        throw new NullPointerException("endPos");
      }
      int i = endPos[0];
      int j = 0;
      ArrayList<String> list = new ArrayList<String>();
      StringBuilder sb = new StringBuilder();
      while (i < str.length() && (
          str.charAt(i) == 0x20 || str.charAt(i) == 0x0d || str.charAt(i) == 0x0a ||
          str.charAt(i) == 0x09)) {
        ++i;
      }
      if (i >= str.length() || str.charAt(i) != '[') {
        throw new IllegalStateException("Invalid JSON: " +
          str.substring(i));
      }
      ++i;
      boolean endValue = false;
      while (true) {
        while (i < str.length() && (
            str.charAt(i) == 0x20 || str.charAt(i) == 0x0d || str.charAt(i) == 0x0a ||
            str.charAt(i) == 0x09)) {
          ++i;
        }
        if (i >= str.length() || (
            str.charAt(i) != ']' && str.charAt(i) != '"' && str.charAt(i) != 0x2c)) {
          throw new IllegalStateException("Invalid JSON:" +
            "\u0020" + str.substring(i));
        }
        int si = (int)str.charAt(i);
        switch (si) {
          case 0x5d:
            // right square bracket
            ++i;
            while (i < str.length() && (
                str.charAt(i) == 0x20 || str.charAt(i) == 0x0d || str.charAt(i) == 0x0a || str.charAt(i)
                == 0x09)) {
              ++i;
            }
            endPos[0] = i;
            return list.toArray(new String[] { });
          case 0x2c:
            // comma
            if (!endValue) {
              throw new IllegalStateException("Invalid JSON:" +
                "\u0020" + str.substring(i));
            }
            ++i;
            endValue = false;
            break;
          case 0x22:
            // double quote
            j = i;
            i = ParseJSONString(str, i + 1, sb);
            if (i < 0) {
              throw new IllegalStateException("Invalid JSON: bad String:" +
                "\u0020" + str.substring(j));
            }
            endValue = true;
            list.add(sb.toString());
            break;
        }
      }
    }

    private static String ParseJSONString(String str) {
      if (str == null || str.length() < 2 || str.charAt(0) != '"') {
        throw new IllegalStateException("Invalid JSON");
      }
      StringBuilder sb = new StringBuilder();
      int result = ParseJSONString(str, 1, sb);
      if (result != str.length()) {
        throw new IllegalStateException("Invalid JSON");
      }
      return sb.toString();
    }

    private static int ParseJSONString(
      String str,
      int index,
      StringBuilder sb) {
      int c;
      sb.delete(0, sb.length());
      while (index < str.length()) {
        c = index >= str.length() ? -1 : str.charAt(index++);
        if (c == -1 || c < 0x20) {
          return -1;
        }
        if ((c & 0xfc00) == 0xd800 && index < str.length() &&
          (str.charAt(index) & 0xfc00) == 0xdc00) {
          // Get the Unicode code point for the surrogate pair
          c = 0x10000 + ((c & 0x3ff) << 10) + (str.charAt(index) & 0x3ff);
          ++index;
        } else if ((c & 0xf800) == 0xd800) {
          return -1;
        }
        switch (c) {
          case '\\':
            c = index >= str.length() ? -1 : str.charAt(index++);
            switch (c) {
              case '\\':
                sb.append('\\');
                break;
              case '/':
                // Now allowed to be escaped under RFC 8259
                sb.append('/');
                break;
              case '\"':
                sb.append('\"');
                break;
              case 'b':
                sb.append('\b');
                break;
              case 'f':
                sb.append('\f');
                break;
              case 'n':
                sb.append('\n');
                break;
              case 'r':
                sb.append('\r');
                break;
              case 't':
                sb.append('\t');
                break;
              case 'u': { // Unicode escape
                c = 0;
                // Consists of 4 hex digits
                for (int i = 0; i < 4; ++i) {
                  int ch = index >= str.length() ? -1 : str.charAt(index++);
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
                  // Nonsurrogate
                  sb.append((char)c);
                } else if ((c & 0xfc00) == 0xd800) {
                  int ch = index >= str.length() ? -1 : str.charAt(index++);
                  if (ch != '\\' ||
                    (index >= str.length() ? -1 : str.charAt(index++)) != 'u') {
                    return -1;
                  }
                  int c2 = 0;
                  for (int i = 0; i < 4; ++i) {
                    ch = index >= str.length() ? -1 : str.charAt(index++);
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
                    sb.append((char)c);
                    sb.append((char)c2);
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
            // pairs in the String or invalid encoding
            // in the stream
            if ((c >> 16) == 0) {
              sb.append((char)c);
            } else {
              sb.append((char)((((c - 0x10000) >> 10) & 0x3ff) | 0xd800));
              sb.append((char)(((c - 0x10000) & 0x3ff) | 0xdc00));
            }
            break;
          }
        }
      }
      return -1;
    }
  }
