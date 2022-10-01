[Seán O'Flynn (seanjoflynn.com)](https://www.seanjoflynn.com/research/bittorrent.html)

### Bittorrent
Bitorrent는 피어 간(peer-to-peer) 파일 공유 프로토콜입니다. 이 프로토콜은 중간 역할을 하는 어떠한 중앙 서버 없이 서로간에 파일을 공유할 수 있게 해 줍니다.

이렇게 하기 위해선, 파일들이 작은 균일한 조각들로 나뉘어져야 합니다. 네트워크에 있는 각 클라이언트나 피어들은 (조각이 필요 할 경우) 이 조각을 요청할 수도 있고 조각을 보낼 수 있습니다. (만약 또 다른 피어가 해당 조각을 요청 할 경우) 피어들은 모든 피어들이 완료할때까지 다수의 또 다른 피어들로부터 동시에 조각을 주고받을 수 있습니다. 피어가 보낼 수 있는 조각이 있다면 __시더(seeder)__ 라고 하고 조각을 요청하는 경우에는 __리쳐(leecher)__ 라고 합니다.

중앙 서버가 없다는 것은 컨텐츠 공유에 필요한 대역폭 비용을 절약할 수 있다는 의미입니다. 초반에는 하나의 시더가 있지만, 또 다른 피어들이 파일을 획득한다면 그 피어들도 시더가 됩니다. 이 프로토콜은 인기많은 콘텐츠에 효과적인 경향이 있습니다. 피어들이 파일을 원하면 원할수록, 공유 할 파일을 가지고 있는 피어들이 많아집니다. 공급은 수요에 따라 확장되는 것이죠.  네트워크가 시스템 장애에 저항력이 있고 여러 시드가 있으면 단일 장애 지점이 없기 때문에 탄력적인 방법이기도 합니다.

유명하지 않는 콘텐츠의 시더들이 손에 꼽다면 다운받을 수 없거나 느려질 수 있고, 작은 파일들은 피어들을 찾는 오버헤드 시간이 있기 때문에 전통적인 서버(중앙 서버)로부터 다운로드를 받는 것 보다 더 느릴 수 있습니다. 중앙 서버의 부재는 네트워크에 있는 모든 피어들이 거의 다 다운받았지만 모두 다 같은 조각이 없는 상황을 초래할 수도 있습니다. (비록 요청할 조각을 선택하는 알고리즘에 의해 매우 희귀한 조건임에도 불구하고)

### 역사
피어간 네트워크는 Shawn Fanning이 1999년 Napster를 만들면서 주류가 되었습니다. Napster는 각 사용자의 컴퓨터에서 선택한 파일의 중앙 집약식 인덱싱을 관리한 다음 서로 직접 파일을 검색하고 다운로드할 수 있도록 했습니다.

Bittorrent 프로토콜은 2001년 Bram Cohen이 만들었고 Napster system에서 다양한 개선이 이루어졌습니다. 단일 중앙 집약식 파일 인덱스들은 사라지고 모두가 호스팅 할 수 있는 인덱싱으로 대체했습니다. (__tracker__ 라고 불립니다) 또한 단일 피어에서 전체 파일을 다운로드 하는 대신 다른 클라이언트에서 각각 다운로드 할 수 있는 조각으로 파일을 나눴습니다. (결합된 조각은 해시를 사용하여 확인함) 이후에 프로토콜이 개선되어 tracker가 필요 없게 되었습니다.

Napster가 이전에 그랬던것처럼, Bittorrent는 불법 파일 공유에 많이 사용되었습니다. 둘다 법적으로 부정적인 의미가 있습니다. Napster와 달리 중앙 집약식이 아니기때문에 훨씬 더 폐쇄적입니다.

오늘날 이 프로토콜은 일반 사용자 간의 파일 공유뿐만 아니라 콘텐츠 전달 (게임 뿐만 아니라 다양한 오픈 소스 소프트웨어 프로젝트), 서버에 새 코드의 내부 배포 (Facebook 및 Twitter) 에도 여전히 사용됩니다. P2P 네트워크를 사용하는 다른 인기 있는 시스템은 다양한 암호화폐(비트코인이나 이더리움)와 분산 시장 (OpenBazaar)입니다.

-----------

### 컴포넌트
기본적인 사양에는 다음과 같은 여러 구성요소가 있습니다.
- 토렌트 파일 : 하나의 파일이나 파일 묶음들에 대한 기본 메타데이터가 포함된 작고 간단한 파일입니다. 이 파일은 다운받으려는 파일이 어떻게 조각으로 나누어 지는 방법과 토렌트가 트레킹하는 트렉커를 지정합니다.
- 트렉커 : 이것은 각 토렌트에 해당하는 피어 목록과 함께 토렌트 목록을 유지 관리하는 중앙 집중식 서버입니다. 가장 유명한 예시는 Priate Bay입니다.
- 클라이언트 : 토렌트 파일을 만들거나 열 수 있는 프로그램입니다. 특정한 트렉커들을 연결하고 필요한 파일의 조각을 보내거나 받기 시작합니다. 예를들면 Vuze, Transmission, uTorrent 그리고 Deluge가 있습니다.

프로토콜에 최근 추가 된 것은 토렌트 파일이나 트래커가 더 이상 필요하지 않습니다. 결과적으로 중앙 집중화가 완전히 사라집니다.

-----------

## 프로젝트
### 범위
이 프로젝트의 목적은 BitTorrent 프로토콜의 기술적인 세부사항에 대한 이해를 얻는 것입니다. BitTorrent는 HTTP, TCP, 사용자 정의 인코딩, 암호화 해싱, 파일 IO 및 멀티 스레딩과 같은 다양한 영역을 다루기 때문에 훌륭한 주제입니다. 가장 친근한 c#을 사용할것입니다.  본직적으로 프로토콜의 버전 1.0을 구축했지만 실제로 테스트하려면 추가적으로 개발이 필요합니다. [Seán O'Flynn (seanjoflynn.com)](https://www.seanjoflynn.com/research/bittorrent.html#further-research)

#### 레퍼런스
[bep_0003.rst_post (bittorrent.org)](http://www.bittorrent.org/beps/bep_0003.html)
[BitTorrentSpecification - TheoryOrg](https://wiki.theory.org/BitTorrentSpecification)

#### Tools
- Xamarin Studio C# IDE
- Deuge 토렌트 클라이언트
- OpenTracker 비트토렌트 트렉커
- 테스팅 목적인 우분투 가상머신


#### Testing
자세히 알아보기 전에 기존 소프트웨어로 테스트를 실행하여 모든것이 올바르게 작동하는지 확인하겠습니다. 먼저 BitTorrent 클라이언트를 사용하여 새 토렌트 파일을 생성해 보겠습니다. 테스트 파일로 사용하기 위해 ipsum lorem의 몇 단락을 가져와 텍스트 파일에 입력했습니다. 토렌트에 트래커를 추가할 때 트래커를 실행할 컴퓨터의 IP주소를 사용해야 합니다. 트래커의 기본 포트는 6969입니다.

![[Pasted image 20221002021312.png]]

-----------
### BEncoding
텍스트에디터로 우리가 만든 토렌트 파일을 열어봅시다.
```
d8:announce32:http://172.30.1.53:6969/announce10:created by30:Transmission/3.00 (bb6b5a062e)13:creation datei1664644557e8:encoding5:UTF-84:infod6:lengthi27e4:name13:hello.txt.txt12:piece lengthi32768e6:pieces20:p:7������$�����jJ%�7:privatei0eee
```

못생긴 문자가 있습니다. 일반적이지 않은 포맷으로 인코딩되어보입니다. 우리가 스팩을 확인하면 _BEncoding_ 이라고 불리는 커스텀 인코딩 시스템을 사용하는 것을 볼 수 있습니다.
다행이도 문자열은 꽤 간단합니다. 인코딩 할 수 있는 유형은 4가지 뿐입니다.

- 문자열: `8:announce`
문자열들은 길이 뒤에 `:` 가 따라오며 시작하고, 그 뒤에 문자열이 있습니다. 여기서 "문자열" 이라는 용어를 아주 느슨하게 사용합니다. 어떤 경우에는 UTF-8 로 인코딩된 문자열이고 다른 경우에는 원시 바이트 배열 (SHA1 해시)입니다. UTF-8 문자열인지 여부를 미리 알 수 있는 방법이 없기 때문에 이것을 `byte[]`  로 저장합니다. C#에서 `string` 에는 유효한 유니코드 문자만 포함 될 수 있습니다. string을 사용하여 원시 바이트 배열을 저장하면 유효하지 않은 유니코드가 대체 문자 U+FFFD (�) 로 대체되므로 데이터 손실이 발생할 수 있습니다. 길이 값은 특히 문자 수가 아니라 바이트 수를 나타냅니다 (일부 문자는 UTF-8에서 1바이트 이상을 차지함).

- 정수: `i32768e`
이것은 `i` 로 시작하고 `e` 로 끝납니다. 파일의 바이트 수를 나타낼 수 있고 일부 파일은 2.14GB 보다 클 수 있기 때문에 `long` 으로 저장합니다.

- 딕셔너리: `d3:key5:valuee`
이것은 `d`로 시작하고 `e`로 끝나며 키와 해당 값의 리스트를 포함합니다. 모든 키는 반드시 UTF-8 문자열이어야 합니다. 딕셔너리는 반드시 키(원시 UTF-8 인코딩 바이트)별로 정렬되어야 합니다. 이것을 `Dictionaray<string, object>` 로 저장합니다. c#에서 딕셔너리는 정렬 할 수 없으므로 파일에 저장할 때만 키를 정렬합니다.

- 리스트 : `l5:ItemA5:ItemBe`
이것은 `l` 로 시작하고 `e` 로 끝납니다. 우리는 이것을 `List<object>` 로 저장할 것입니다.

파일에 공백 을 적용하면 구조를 더 명확하게 볼 수 있습니다. 물론 인코딩에서 공백은 허용되지 않으므로 이것은 그냥 보기 편하려고 하는 것입니다.
```torrent
d

    8:announce  27:http://172.30.1.53/announce

    10:created by   30:Transmission/3.00 (bb6b5a062e)

    13:creation datei1664644464e

    8:encoding  5:UTF-8

    4:info

        d

            6:length    i27e

            4:name  13:hello.txt.txt

            12:piece lengthi32768e

            6:pieces    20:p:7������$�����jJ%�

            7:private   i0e

        e

e
```

구조를 더 명확하게 보여줍니다.

#### Decoding
우리의 `Decode()` 함수는 바이트 어레이를 받을 것입니다. 한 번에 한 바이트씩 파싱하여 iterator를 설정하고 첫 바이트로 푸쉬 합니다. 그런 다음, 다음 개체의 유형을 평가하고 디코딩 관련 함수를 호출하는 `DecodeNextObject()` 를 호출합니다. 중첩 리스트나 딕셔너리에 있는 개체를 재귀적으로 처리할 수 있도록 이것을 별도의 함수로 분리했습니다.

```C#
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
    {        using var enumerator = bytes.GetEnumerator();  
        enumerator.MoveNext();  
  
        return DecodeNextObject(enumerator);  
    }  
    private static object DecodeNextObject(IEnumerator<byte> enumerator)  
    {        var current = enumerator.Current;  
        if (current == DictionaryStart)  
        {            return DecodeDictionary(enumerator);   
        }  
  
        if (current == ListStart)  
        {  
            return DecodeList(enumerator);        
        }  
        return DecodeByteArray(enumerator);  
    }
}
```

또한 파일을 디코드하는 메소드를 만듭니다.
```C#
static async Task<object> DecodeFile(string path)  
{  
    if (File.Exists(path) is false)  
    {        throw new FileNotFoundException($"unable to find file: {path}");  
    }  
    var bytes = await File.ReadAllBytesAsync(path);  
  
    return BEncoding.Decode(bytes);  
}
```

### 숫자
숫자가 다음 개체라는 것을 알고 있으면 숫자의 끝을 나타내는 문자(e)를 만날때까지 배열을 계속 이동하면서 바이트를 수집합니다. 그런 다음 이 바이트를 문자열로 변환한 다음 문자열을 long으로 반환합니다. 일부 숫자가 파일의 바이트 수를 나타내는 한 long을 사용할 수 있으며, int의 최댓값보다 클 수 있습니다.
```C#
private static long DecodeNumber(IEnumerator<byte> enumerator)  
{  
    var bytes = new List<byte>();  
  
    while (enumerator.MoveNext())  
    {        if (enumerator.Current == NumberEnd)  
        {            break;  
        }        bytes.Add(enumerator.Current);  
    }  
    var numAsString = Encoding.UTF8.GetString(bytes.ToArray());  
  
    return long.Parse(numAsString);  
}
```

#### 문자열

문자열(바이트 배열)의 경우 두 개의 개별 부분을 파싱해야합니다. 첫 번째는 바이트 배열의 길이를 나타내는 숫자이고 다음은 바이트 자체입니다. 따라서 먼저 길이 숫자의 끝을 나타내는 문자에 도달할 때까지 반복합니다. 첫 번째 문자가 필요하기 때문에 `do...while` 루프를 사용합니다. 그런 다음 숫자 디코딩과 마찬가지로 바이트를 문자열로 변환한 다음 문자열을 `int` 로 변환하여 길이를 얻습니다. 길이는 배열의 바이트 수를 나타냅니다. 필요한 바이트를 얻을 떄까지 배열을 통해 이동할 수 있습니다.

``` C#
private static byte[] DecodeByteArray(IEnumerator<byte> enumerator)  
{  
    var lengthBytes = new List<byte>();  
  
    do  
    {  
        if (enumerator.Current == ByteArrayDivider)  
        {            break;  
        }        lengthBytes.Add(enumerator.Current);  
    } while (enumerator.MoveNext());  
  
    var lengthString = Encoding.UTF8.GetString(lengthBytes.ToArray());  
  
    if (int.TryParse(lengthString, out var length))  
    {        throw new InvalidOperationException("unable to parse length of byte array");  
    }  
    var bytes = new byte[length];  
  
    for (var i = 0; i < length; i++)  
    {        enumerator.MoveNext();  
        bytes[i] = enumerator.Current;  
    }  
    return bytes;  
}
```

#### Lists
리스트인 경우 끝 문자에 도달할 때까지 다음 개체를 계속 그래핑합니다. 우리는 리스트에 있는 개체의 유형을 알 필요가 없으며 그냥 진행합니다. 사양은 모든 항목이 동일한 유형이어야 하는지 여부를 지정하지 않으며 구현 시 확인하지 않습니다.

