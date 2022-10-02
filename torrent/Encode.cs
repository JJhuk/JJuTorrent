namespace torrent;

public class Encode
{
    public static byte[] EncodeA(object obj)
    {
        var buffer = new MemoryStream();

        EncodeNextObject(buffer, obj);

        return buffer.ToArray();
    }

    private static void EncodeNextObject(MemoryStream buffer, object obj)
    {
        if (obj is byte[] bytes)
        {
            EncodeByteArray(buffer, bytes);
        }
        else if (obj is string stringObject)
        {
            EncodeString(buffer, stringObject);
        }
        else if (obj is long longObject)
        {
            EncodeNumber(buffer, longObject);
        }
        else if (obj.GetType() == typeof(List<object>))
        {
            EncodeList(buffer, (List<object>)obj);
        }
        else if (obj.GetType() == typeof(Dictionary<string, object>))
        {
            EncodeDictionary(buffer, (Dictionary<string, object>)obj);
        }

        throw new InvalidOperationException($"unable to encode type : {obj.GetType()}");
    }

    private static void EncodeDictionary(MemoryStream buffer, Dictionary<string,object> dictionary)
    {
        throw new NotImplementedException();
    }

    private static void EncodeList(MemoryStream buffer, List<object> objects)
    {
        throw new NotImplementedException();
    }

    private static void EncodeNumber(MemoryStream buffer, long longObject)
    {
        throw new NotImplementedException();
    }

    private static void EncodeString(MemoryStream buffer, string str)
    {
        throw new NotImplementedException();
    }

    private static void EncodeByteArray(MemoryStream buffer, byte[] o)
    {
        throw new NotImplementedException();
    }
}