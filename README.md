# WandhiM3U8Downloader


M3U8解析下载工具

先挖个坑


# M3U8标签详解
标签的类型可分为五种类型：基础标签（Basic Tags），媒体片段类型标签（Media Segment Tags），媒体播放列表类型标签，主播放列表类型标签 和 播放列表类型标签。其具体内容如下所示：

    基础标签（Basic Tags）：可同时适用于媒体播放列表（Media Playlist）和主播放列表（Master Playlist）。具体标签如下：
    ▷ EXTM3U：表明该文件是一个 m3u8 文件。每个 M3U 文件必须将该标签放置在第一行。
    ▷ EXT-X-VERSION：表示 HLS 的协议版本号，该标签与流媒体的兼容性相关。该标签为全局作用域，使能整个 m3u8 文件；每个 m3u8 文件内最多只能出现一个该标签定义。如果 m3u8 文件不包含该标签，则默认为协议的第一个版本。

    媒体片段类型标签（Media Segment Tags）：每个切片 URI 前面都有一系列媒体片段标签对其进行描述。有些片段标签只对其后切片资源有效；有些片段标签对其后所有切片都有效，直到后续遇到另一个该标签描述。媒体片段类型标签不能出现在主播放列表（Master Playlist）中。具体标签如下：
    ▷ EXTINF：表示其后 URL 指定的媒体片段时长（单位为秒）。每个 URL 媒体片段之前必须指定该标签。该标签的使用格式为：#EXTINF:<duration>,[<title>],其中，参数duration可以为十进制的整型或者浮点型，其值必须小于或等于 EXT-X-TARGETDURATION 指定的值（注：建议始终使用浮点型指定时长，这可以让客户端在定位流时，减少四舍五入错误。但是如果兼容版本号 EXT-X-VERSION 小于 3，那么必须使用整型）。
    ▷ EXT-X-BYTERANGE：该标签表示接下来的切片资源是其后 URI 指定的媒体片段资源的局部范围（即截取 URI 媒体资源部分内容作为下一个切片）。该标签只对其后一个 URI 起作用。其格式为：#EXT-X-BYTERANGE:<n>[@<o>]，其中，n是一个十进制整型，表示截取片段大小（单位：字节）。可选参数o也是一个十进制整型，指示截取起始位置（以字节表示，在 URI 指定的资源开头移动该字节位置后进行截取）。如果o未指定，则截取起始位置从上一个该标签截取完成的下一个字节（即上一个n+o+1）开始截取。
    如果没有指定该标签，则表明的切分范围为整个 URI 资源片段。
    注：使用 EXT-X-BYTERANGE 标签要求兼容版本号 EXT-X-VERSION 大于等于 4。
    ▷ EXT-X-DISCONTINUITY：该标签表明其前一个切片与下一个切片之间存在中断。其格式为：EXT-X-DISCONTINUITY。当出现以下情况时，必须使用该标签：
    ☛ file format
    ☛ number, type, and identifiers of tracks
    ☛ timestamp sequence
    当出现以下情况时，应该使用该标签：
    ☛ encoding parameters
    ☛ encoding sequence
    注：EXT-X-DISCONTINUITY 的一个经典使用场景就是在视屏流中插入广告，由于视屏流与广告视屏流不是同一份资源，因此在这两种流切换时使用 EXT-X-DISCONTINUITY 进行指明，客户端看到该标签后，就会处理这种切换中断问题，让体验更佳。更多详细内容，请查看：Incorporating Ads into a Playlist
    ▷ EXT-X-KEY：媒体片段可以进行加密，而该标签可以指定解密方法。该标签对所有 媒体片段 和 由标签 EXT-X-MAP 声明的围绕其间的所有 媒体初始化块（Meida Initialization Section） 都起作用，直到遇到下一个 EXT-X-KEY（若 m3u8 文件只有一个 EXT-X-KEY 标签，则其作用于所有媒体片段）。多个 EXT-X-KEY 标签如果最终生成的是同样的秘钥，则他们都可作用于同一个媒体片段。
    该标签使用格式为：#EXT-X-KEY:<attribute-list>，属性列表可以包含如下几个键：
    ☛ METHOD：该值是一个可枚举的字符串，指定了加密方法。该键是必须参数。其值可为NONE，AES-128，SAMPLE-AES当中的一个。
    其中：NONE表示切片未进行加密（此时其他属性不能出现）；AES-128表示表示使用 AES-128 进行加密。SAMPLE-AES意味着媒体片段当中包含样本媒体，比如音频或视频，它们使用 AES-128 进行加密。这种情况下 IV 属性可以出现也可以不出现。
    ☛ URI：指定密钥路径。该键是必须参数，除非 METHOD 为NONE。该密钥是一个 16 字节的数据。
    ☛ IV：该值是一个 128 位的十六进制数值。AES-128 要求使用相同的 16字节 IV 值进行加密和解密。使用不同的 IV 值可以增强密码强度。
    如果属性列表出现 IV，则使用该值；如果未出现，则默认使用媒体片段序列号（即 EXT-X-MEDIA-SEQUENCE）作为其 IV 值，使用大端字节序，往左填充 0 直到序列号满足 16 字节（128 位）。
    ☛ KEYFORMAT：由双引号包裹的字符串，标识密钥在密钥文件中的存储方式（密钥文件中的 AES-128 密钥是以二进制方式存储的16个字节的密钥。）。该属性为可选参数，其默认值为 "identity"。使用该属性要求兼容版本号 EXT-X-VERSION 大于等于 5。
    ☛ KEYFORMATVERSIONS：由一个或多个被 "/" 分割的正整型数值构成的带引号的字符串（比如："1"，"1/2"，"1/2/5"）。如果有一个或多特定的 KEYFORMT 版本被定义了，则可使用该属性指示具体版本进行编译。该属性为可选参数，其默认值为 "1"。使用该属性要求兼容版本号 EXT-X-VERSION 大于等于 5。
    ▷ EXT-X-MAP：该标签指明了获取媒体初始化块（Meida Initialization Section）的方法。该标签对其后所有媒体片段生效，直至遇到另一个 EXT-X-MAP 标签。
    其格式为：#EXT-X-MAP:<attribute-list>，其属性列表取值范围如下：
    ☛ URI：由引号包裹的字符串，指定了包含媒体初始化块的资源的路径。该属性为必选参数。
    ☛ BYTERANGE：由引号包裹的字符串，指定了媒体初始化块在 URI 指定的资源的位置（片段）。该属性指定的范围应当只包含媒体初始化块。该属性为可选参数，如果未指定，则表示 URI 指定的资源就是全部的媒体初始化块。
    ▷ EXT-X-PROGRAM-DATE-TIME：该标签使用一个绝对日期/时间表明第一个样本片段的取样时间。
    其格式为：#EXT-X-PROGRAM-DATE-TIME:<date-time-msec>，其中，date-time-msec是一个 ISO/IEC 8601:2004 规定的日期格式，形如：YYYY-MM-DDThh:mm:ss.SSSZ。
    ▷ EXT-X-DATERANGE：该标签定义了一系列由属性/值对组成的日期范围。
    其格式为：#EXT-X-DATERANGE:<attribute-list>，其属性列表取值如下：
    ☛ ID：双引号包裹的唯一指明日期范围的标识。该属性为必选参数。
    ☛ CLASS：双引号包裹的由客户定义的一系列属性与与之对应的语意值。所有拥有同一 CLASS 属性的日期范围必须遵守对应的语意。该属性为可选参数。
    ☛ START-DATE：双引号包裹的日期范围起始值。该属性为必选参数。
    ☛ END-DATE：双引号包裹的日期范围结束值。该属性值必须大于或等于 START-DATE。该属性为可选参数。
    ☛ DURATION：日期范围的持续时间是一个十进制浮点型数值类型（单位：秒）。该属性值不能为负数。当表达立即时间时，将该属性值设为 0 即可。该属性为可选参数。
    ☛ PLANNED-DURATION：该属性为日期范围的期望持续时长。其值为一个十进制浮点数值类型（单位：秒）。该属性值不能为负数。在预先无法得知真实持续时长的情况下，可使用该属性作为日期范围的期望预估时长。该属性为可选参数。
    ☛ X-<client-attribute>："X-"前缀是预留给客户端自定义属性的命名空间。客户端自定义属性名时，应当使用反向 DNS（reverse-DNS）语法来避免冲突。自定义属性值必须是使用双引号包裹的字符串，或者是十六进制序列，或者是十进制浮点数，比如：X-COM-EXAMPLE-AD-ID="XYZ123"。该属性为可选参数。
    ☛ SCTE35-CMD, SCTE35-OUT, SCTE35-IN：用于携带 SCET-35 数据。该属性为可选参数。
    ☛ END-ON-NEXT：该属性值为一个可枚举字符串，其值必须为 YES。该属性表明达到该范围末尾，也即等于后续范围的起始位置 START-DATE。后续范围是指具有相同 CLASS 的，在该标签 START-DATE 之后的具有最早 START-DATE 值的日期范围。该属性时可选参数。

    媒体播放列表类型标签：媒体播放列表标签为 m3u8 文件的全局参数信息。这些标签只能在 m3u8 文件中至多出现一次。媒体播放列表（Media Playlist）标签不能出现在主播放列表（Master Playlist）中。媒体播放列表具体标签如下所示：
    ▷ EXT-X-TARGETDURATION：表示每个视频分段最大的时长（单位秒）。该标签为必选标签。
    其格式为：#EXT-X-TARGETDURATION:<s>，其中，参数s表示目标时长（单位：秒）。
    ▷ EXT-X-MEDIA-SEQUENCE：表示播放列表第一个 URL 片段文件的序列号，每个媒体片段 URL 都拥有一个唯一的整型序列号。每个媒体片段序列号按出现顺序依次加 1。媒体片段序列号与片段文件名无关。如果该标签未指定，则默认序列号从 0 开始。
    其格式为：#EXT-X-MEDIA-SEQUENCE:<number>，其中，参数number即为尾随切片序列号。
    ▷ EXT-X-DISCONTINUITY-SEQUENCE：该标签使能同步相同流的不同 Rendition 和 具备 EXT-X-DISCONTINUITY 标签的不同备份流。
    其格式为：#EXT-X-DISCONTINUITY-SEQUENCE:<number>，其中，参数number为一个十进制整型数值。
    如果播放列表未设置 EXT-X-DISCONTINUITY-SEQUENCE 标签，那么对于第一个切片的中断序列号应当为 0。
    ▷ EXT-X-ENDLIST：表明 m3u8 文件的结束。该标签可出现在 m3u8 文件任意位置，一般是结尾。
    其格式为：#EXT-X-ENDLIST。
    ▷ EXT-X-PLAYLIST-TYPE：表明流媒体类型。全局生效。该标签为可选标签。
    其格式为：#EXT-X-PLAYLIST-TYPE:<type-enum>，其中，type-enum可选值如下：
    ☛ VOD 即 Video on Demand，表示该视屏流为点播源，因此服务器不能更改该 m3u8 文件；
    ☛ EVENT 表示该视频流为直播源，因此服务器不能更改或删除该文件任意部分内容（但是可以在文件末尾添加新内容）（注：VOD 文件通常带有 EXT-X-ENDLIST 标签，因为其为点播源，不会改变；而 EVEVT 文件初始化时一般不会有 EXT-X-ENDLIST 标签，暗示有新的文件会添加到播放列表末尾，因此也需要客户端定时获取该 m3u8 文件，以获取新的媒体片段资源，直到访问到 EXT-X-ENDLIST 标签才停止）。
    ▷ EXT-X-I-FRAMES-ONLY：该标签表示每个媒体片段都是一个 I-frame。I-frames 帧视屏编码不依赖于其他帧数，因此可以通过 I-frame 进行快速播放，急速翻转等操作。该标签全局生效。
    其格式为：#EXT-X-I-FRAMES-ONLY。
    如果播放列表设置了 EXT-X-I-FRAMES-ONLY，那么切片的时长（EXTINF 标签的值）即为当前切片 I-frame 帧开始到下一个 I-frame 帧出现的时长。
    媒体资源如果包含 I-frame 切片，那么必须提供媒体初始化块或者通过 EXT-X-MAP 标签提供媒体初始化块的获取途径，这样客户端就能通过这些 I-frame 切片以任意顺序进行加载和解码。如果 I-frame 切片设置了 EXT-BYTERANGE，那么就绝对不能提供媒体初始化块。
    使用 EXT-X-I-FRAMES-ONLY 要求的兼容版本号 EXT-X-VERSION 大于等于 4。

    主播放列表类型标签：主播放列表（Master Playlist）定义了备份流，多语言翻译流和其他全局参数。主播放列表标签绝不能出现在媒体播放列表（Media Playlist）中。其具体标签如下：
    ▷ EXT-X-MEDIA：用于指定相同内容的可替换的多语言翻译播放媒体列表资源。比如，通过三个 EXT-X-MEIDA 标签，可以提供包含英文，法语和西班牙语版本的相同内容的音频资源，或者通过两个 EXT-X-MEDIA 提供两个不同拍摄角度的视屏资源。
    其格式为：#EXT-X-MEDIA:<attribute-list>，其中，属性列表取值范围如下：
    ☛ TYPE：该属性值为一个可枚举字符串。其值有如下四种：AUDIO，VIDEO，SUBTITLES，CLOSED-CAPTIONS。通常使用的都是CLOSED-CAPTIONS。该属性为必选参数。
    ☛ URI：双引号包裹的媒体资源播放列表路径。如果 TYPE 属性值为 CLOSED-CAPTIONS，那么则不能提供 URI。该属性为可选参数。
    ☛ GROUP-ID：双引号包裹的字符串，表示多语言翻译流所属组。该属性为必选参数。
    ☛ LANGUAGE：双引号包裹的字符串，用于指定流主要使用的语言。该属性为可选参数。
    ☛ ASSOC-LANGUAGE：双引号包裹的字符串，其内包含一个语言标签，用于提供多语言流的其中一种语言版本。该参数为可选参数。
    ☛ NAME：双引号包裹的字符串，用于为翻译流提供可读的描述信息。如果设置了 LANGUAGE 属性，那么也应当设置 NAME 属性。该属性为必选参数。
    ☛ DEFAULT：该属性值为一个可枚举字符串。可选值为YES和NO。如果该属性设为YES，那么客户端在缺乏其他可选信息时应当播放该翻译流。该属性未指定时默认值为NO。该属性为可选参数。
    ☛ AUTOSELECT：该属性值为一个可枚举字符串。其有效值为YES或NO。未指定时，默认设为NO。如果该属性设置YES，那么客户端在用户没有显示进行设置时，可以选择播放该翻译流，因为其能配置当前播放环境，比如系统语言选择。
    如果设置了该属性，那么当 DEFAULT 设置YES时，该属性也必须设置为YES。
    该属性为可选参数。
    ☛ FORCED：该属性值为一个可枚举字符串。其有效值为YES或NO。未指定时，默认设为NO。只有在设置了 TYPE 为 SUBTITLES 时，才可以设置该属性。
    当该属性设为YES时，则暗示该翻译流包含重要内容。当设置了该属性，客户端应当选择播放匹配当前播放环境最佳的翻译流。
    当该属性设为NO时，则表示该翻译流内容意图用于回复用户显示进行请求。
    该属性为可选参数。
    ☛ INSTREAM-ID：由双引号包裹的字符串，用于指示切片的语言（Rendition）版本。当 TYPE 设为 CLOSED-CAPTIONS 时，必须设置该属性。其可选值为："CC1", "CC2", "CC3", "CC4" 和 "SERVICEn"（n 的值为 1~63）。
    对于其他 TYPE 值，该属性绝不能进行设置。
    ☛ CHARACTERISTICS：由双引号包裹的由一个或多个由逗号分隔的 UTI 构成的字符串。每个 UTI 表示一种翻译流的特征。该属性可包含私有 UTI。该属性为可选参数。
    ☛ CHANNELS：由双引号包裹的有序，由反斜杠（"/"）分隔的参数列表组成的字符串。
    所有音频 EXT-X-MEDIA 标签应当都设置 CHANNELS 属性。如果主播放列表包含两个相同编码但是具有不同数目 channed 的翻译流，则必须设置 CHANNELS 属性；否则，CHANNELS 属性为可选参数。
    ▷ EXT-X-STREAM-INF：该属性指定了一个备份源。该属性值提供了该备份源的相关信息。
    其格式为：
```
#EXT-X-STREAM-INF:<attribute-list>
   <URI>
```
