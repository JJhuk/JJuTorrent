// See https://aka.ms/new-console-template for more information

using torrent;

static async Task<object> DecodeFile(string path)
{
    if (File.Exists(path) is false)
    {
        throw new FileNotFoundException($"unable to find file: {path}");
    }

    var bytes = await File.ReadAllBytesAsync(path);

    return BEncoding.Decode(bytes);
}


var decodeFile = DecodeFile("blabla");

Console.WriteLine("Hello, World!");