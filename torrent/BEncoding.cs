using System.Collections;
using System.Text;

namespace torrent;

public static class BEncoding
{
    private static readonly byte DictionaryStart = Encoding.UTF8.GetBytes("d")[0]; //100
    private static readonly byte DictionaryEnd = Encoding.UTF8.GetBytes("e")[0]; //101
    private static readonly byte ListStart = Encoding.UTF8.GetBytes("l")[0]; //108
    private static readonly byte ListEnd = Encoding.UTF8.GetBytes("e")[0]; //101
    private static readonly byte NumberStart = Encoding.UTF8.GetBytes("i")[0]; //105
    private static readonly byte NumberEnd = Encoding.UTF8.GetBytes("e")[0]; //101
    private static readonly byte ByteArrayDivider = Encoding.UTF8.GetBytes(":")[0]; //58

    public static object Decode(IEnumerable<byte> bytes)
    {
        using var enumerator = bytes.GetEnumerator();
        enumerator.MoveNext();

        return DecodeNextObject(enumerator);
    }

    private static object DecodeNextObject(IEnumerator<byte> enumerator)
    {
        var current = enumerator.Current;
        if (current == DictionaryStart)
        {
            return DecodeDictionary(enumerator); 
        }

        if (current == ListStart)
        {
            return DecodeList(enumerator);      
        }
        
        return DecodeByteArray(enumerator);
    }

    private static long DecodeNumber(IEnumerator<byte> enumerator)
    {
        var bytes = new List<byte>();

        while (enumerator.MoveNext())
        {
            if (enumerator.Current == NumberEnd)
            {
                break;
            }
            
            bytes.Add(enumerator.Current);
        }

        var numAsString = Encoding.UTF8.GetString(bytes.ToArray());

        return long.Parse(numAsString);
    }

    private static byte[] DecodeByteArray(IEnumerator<byte> enumerator)
    {
        var lengthBytes = new List<byte>();

        do
        {
            if (enumerator.Current == ByteArrayDivider)
            {
                break;
            }
            lengthBytes.Add(enumerator.Current);
        } while (enumerator.MoveNext());

        var lengthString = Encoding.UTF8.GetString(lengthBytes.ToArray());

        if (int.TryParse(lengthString, out var length))
        {
            throw new InvalidOperationException("unable to parse length of byte array");
        }

        var bytes = new byte[length];

        for (var i = 0; i < length; i++)
        {
            enumerator.MoveNext();
            bytes[i] = enumerator.Current;
        }

        return bytes;
    }
    
    private static List<object> DecodeList(IEnumerator<byte> enumerator)
    {
        var list = new List<object>();

        // keep decoding objects until we hit the end flag
        while (enumerator.MoveNext())
        {
            if (enumerator.Current == ListEnd)
            {
                break;
            }

            list.Add(DecodeNextObject(enumerator));
        }

        return list;
    }
}