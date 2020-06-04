﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK.VKUI.Controls {
    public enum VKIconName {
        None,
        Icon12Fire,
        Icon12FireVerified,
        Icon12Lock,
        Icon12Mention,
        Icon12OnlineMobile,
        Icon12OnlineVkmobile,
        Icon12Verified,
        Icon16Add,
        Icon16Camera,
        Icon16Cancel,
        Icon16CancelCircleOutline,
        Icon16CheckCircle,
        Icon16CheckCircleOutline,
        Icon16Chevron,
        Icon16Clear,
        Icon16Done,
        Icon16Down,
        Icon16Dropdown,
        Icon16Fire,
        Icon16FireVerified,
        Icon16Gift,
        Icon16Headphones,
        Icon16InfoOutline,
        Icon16Like,
        Icon16LikeOutline,
        Icon16Lock,
        Icon16MoreHorizontal,
        Icon16MoreVertical,
        Icon16Muted,
        Icon16PaletteOutline,
        Icon16Pin,
        Icon16Place,
        Icon16Play,
        Icon16Recent,
        Icon16ReplyOutline,
        Icon16Search,
        Icon16SearchOutline,
        Icon16Smile,
        Icon16Spinner,
        Icon16Up,
        Icon16User,
        Icon16UserAdd,
        Icon16Users,
        Icon16Verified,
        Icon20ArticleBoxOutline,
        Icon20ArticleOutline,
        Icon20CalendarOutline,
        Icon20CommentOutline,
        Icon20CommunityName,
        Icon20EducationOutline,
        Icon20FlipHorizontal,
        Icon20FlipVertical,
        Icon20FollowersOutline,
        Icon20GiftOutline,
        Icon20GlobeOutline,
        Icon20HomeOutline,
        Icon20Info,
        Icon20LikeOutline,
        Icon20MentionOutline,
        Icon20MessageOutline,
        Icon20MusicOutline,
        Icon20NarrativeOutline,
        Icon20NewsfeedOutline,
        Icon20PhoneOutline,
        Icon20PinOutline,
        Icon20PlaceOutline,
        Icon20PodcastOutline,
        Icon20RecentOutline,
        Icon20RotateLeft,
        Icon20RotateRight,
        Icon20Stars,
        Icon20UserOutline,
        Icon20WaterDropOutline,
        Icon20WorkOutline,
        Icon24Add,
        Icon24AddOutline,
        Icon24Advertising,
        Icon24Airplay,
        Icon24ArrowUturnLeftOutline,
        Icon24ArrowUturnRightOutline,
        Icon24Article,
        Icon24Artist,
        Icon24Attach,
        Icon24Attachments,
        Icon24Back,
        Icon24BrowserBack,
        Icon24BrowserForward,
        Icon24BrushOutline,
        Icon24Bug,
        Icon24Camera,
        Icon24CameraOutline,
        Icon24Cancel,
        Icon24Chats,
        Icon24Chevron,
        Icon24Coins,
        Icon24Comment,
        Icon24CommentOutline,
        Icon24Copy,
        Icon24Crop,
        Icon24Delete,
        Icon24Discussions,
        Icon24Dismiss,
        Icon24DismissDark,
        Icon24DismissSubstract,
        Icon24DoNotDisturb,
        Icon24Document,
        Icon24Done,
        Icon24DoneOutline,
        Icon24Download,
        Icon24Dropdown,
        Icon24Education,
        Icon24Error,
        Icon24Favorite,
        Icon24FavoriteOutline,
        Icon24Filter,
        Icon24Flash,
        Icon24Followers,
        Icon24Forward,
        Icon24Forward10,
        Icon24Fullscreen,
        Icon24FullscreenExit,
        Icon24Gallery,
        Icon24Game,
        Icon24GearOutline,
        Icon24Gift,
        Icon24Globe,
        Icon24Headphones,
        Icon24Help,
        Icon24Hide,
        Icon24Home,
        Icon24ImageFilterOutline,
        Icon24Info,
        Icon24Like,
        Icon24LikeOutline,
        Icon24Link,
        Icon24LinkCircle,
        Icon24Linked,
        Icon24List,
        Icon24ListAdd,
        Icon24Live,
        Icon24Locate,
        Icon24LogoFacebook,
        Icon24LogoGoogle,
        Icon24LogoInstagram,
        Icon24LogoLivejournal,
        Icon24LogoSkype,
        Icon24LogoTwitter,
        Icon24LogoVk,
        Icon24Market,
        Icon24MarketOutline,
        Icon24Mention,
        Icon24Message,
        Icon24MicrophoneSlash,
        Icon24MoneyCircle,
        Icon24MoneyTransfer,
        Icon24MoneyTransferOutline,
        Icon24MoreHorizontal,
        Icon24MoreVertical,
        Icon24Music,
        Icon24MusicMic,
        Icon24Mute,
        Icon24NarrativeActiveOutline,
        Icon24NarrativeFilled,
        Icon24NarrativeOutline,
        Icon24Newsfeed,
        Icon24Note,
        Icon24Notification,
        Icon24NotificationCheckOutline,
        Icon24NotificationDisable,
        Icon24OpenIn,
        Icon24Palette,
        Icon24Pause,
        Icon24Phone,
        Icon24PhoneOutline,
        Icon24Pin,
        Icon24Place,
        Icon24Play,
        Icon24PlayNext,
        Icon24PlaySpeed,
        Icon24Playlist,
        Icon24Poll,
        Icon24Privacy,
        Icon24Qr,
        Icon24Recent,
        Icon24RecentOutline,
        Icon24Reorder,
        Icon24ReorderIos,
        Icon24Repeat,
        Icon24RepeatOne,
        Icon24Replay,
        Icon24Replay10,
        Icon24Reply,
        Icon24ReplyOutline,
        Icon24Report,
        Icon24Repost,
        Icon24ScanViewfinderOutline,
        Icon24Search,
        Icon24Send,
        Icon24Services,
        Icon24Settings,
        Icon24Share,
        Icon24ShareExternal,
        Icon24ShareOutline,
        Icon24Shuffle,
        Icon24Similar,
        Icon24SkipNext,
        Icon24SkipPrevious,
        Icon24Smile,
        Icon24SmileOutline,
        Icon24Song,
        Icon24Sort,
        Icon24Spinner,
        Icon24StorefrontOutline,
        Icon24Story,
        Icon24StoryOutline,
        Icon24TextOutline,
        Icon24ThumbDown,
        Icon24ThumbUp,
        Icon24Unpin,
        Icon24Up,
        Icon24Upload,
        Icon24User,
        Icon24UserAdd,
        Icon24UserAddOutline,
        Icon24UserAdded,
        Icon24UserAddedOutline,
        Icon24UserIncoming,
        Icon24UserOutgoing,
        Icon24UserOutline,
        Icon24Users,
        Icon24Video,
        Icon24VideoFill,
        Icon24VideoFillNone,
        Icon24Videocam,
        Icon24View,
        Icon24ViewOutline,
        Icon24Voice,
        Icon24Volume,
        Icon24Work,
        Icon24Write,
        Icon28AddCircleOutline,
        Icon28AddOutline,
        Icon28AddSquareOutline,
        Icon28AdvertisingOutline,
        Icon28AirplayAudioOutline,
        Icon28AirplayVideoOutline,
        Icon28ArchiveOutline,
        Icon28ArrowLeftOutline,
        Icon28ArrowRightOutline,
        Icon28ArrowRightSquareOutline,
        Icon28ArrowUpOutline,
        Icon28ArrowUturnRightOutline,
        Icon28ArticleOutline,
        Icon28AttachOutline,
        Icon28Attachments,
        Icon28Backspace,
        Icon28BackspaceOutline,
        Icon28BlockOutline,
        Icon28BombOutline,
        Icon28BrainOutline,
        Icon28BugOutline,
        Icon28CalendarOutline,
        Icon28Camera,
        Icon28CameraOutline,
        Icon28CancelCircleOutline,
        Icon28CancelOutline,
        Icon28ChainOutline,
        Icon28ChatsOutline,
        Icon28CheckCircleDeviceOutline,
        Icon28CheckCircleOutline,
        Icon28CheckShieldDeviceOutline,
        Icon28CheckShieldOutline,
        Icon28CheckSquareOutline,
        Icon28ChecksOutline,
        Icon28ChevronBack,
        Icon28ChevronDownOutline,
        Icon28ChevronRightCircleOutline,
        Icon28ChevronRightOutline,
        Icon28ClearDataOutline,
        Icon28ClipOutline,
        Icon28CoinsOutline,
        Icon28CommentOutline,
        Icon28CompassOutline,
        Icon28CopyOutline,
        Icon28CubeBoxOutline,
        Icon28Delete,
        Icon28DeleteOutline,
        Icon28DeleteOutlineAndroid,
        Icon28DevicesOutline,
        Icon28Document,
        Icon28DocumentOutline,
        Icon28DoneOutline,
        Icon28DownloadCloudOutline,
        Icon28DownloadOutline,
        Icon28EditOutline,
        Icon28ErrorOutline,
        Icon28Favorite,
        Icon28FavoriteOutline,
        Icon28FireOutline,
        Icon28Game,
        Icon28GameOutline,
        Icon28GhostOutline,
        Icon28GiftOutline,
        Icon28GlobeOutline,
        Icon28GraphOutline,
        Icon28GridSquareOutline,
        Icon28HeadphonesOutline,
        Icon28HelpOutline,
        Icon28HideOutline,
        Icon28HistoryBackwardOutline,
        Icon28HistoryForwardOutline,
        Icon28HomeOutline,
        Icon28InboxOutline,
        Icon28InfoOutline,
        Icon28KeyOutline,
        Icon28KeySquareOutline,
        Icon28KeyboardBotsOutline,
        Icon28KeyboardOutline,
        Icon28LikeOutline,
        Icon28LinkCircleOutline,
        Icon28LinkOutline,
        Icon28ListAddOutline,
        Icon28ListCheckOutline,
        Icon28ListLikeOutline,
        Icon28ListOutline,
        Icon28ListPlayOutline,
        Icon28LiveOutline,
        Icon28LocationOutline,
        Icon28LockOutline,
        Icon28LogoInstagram,
        Icon28LogoSkype,
        Icon28LogoVk,
        Icon28LogoVkOutline,
        Icon28MagicWandOutline,
        Icon28MailOutline,
        Icon28MarketAddBadgeOutline,
        Icon28MarketLikeOutline,
        Icon28MarketOutline,
        Icon28Mention,
        Icon28MentionOutline,
        Icon28Menu,
        Icon28MenuOutline,
        Icon28Message,
        Icon28MessageAddBadgeOutline,
        Icon28MessageOutline,
        Icon28MessageUnreadOutline,
        Icon28MessageUnreadTop,
        Icon28Messages,
        Icon28MessagesOutline,
        Icon28MoneyCircleOutline,
        Icon28MoneyHistoryBackwardOutline,
        Icon28MoneyRequestOutline,
        Icon28MoneySendOutline,
        Icon28MoneyTransfer,
        Icon28MoneyTransferOutline,
        Icon28MoonOutline,
        Icon28More,
        Icon28MoreHorizontal,
        Icon28Music,
        Icon28MusicMicOutline,
        Icon28MusicOutline,
        Icon28MuteOutline,
        Icon28NameTagOutline,
        Icon28NarrativeOutline,
        Icon28Newsfeed,
        Icon28NewsfeedOutline,
        Icon28Notification,
        Icon28NotificationDisableOutline,
        Icon28Notifications,
        Icon28PaletteOutline,
        Icon28Pause,
        Icon28PaymentCardOutline,
        Icon28PhoneOutline,
        Icon28PictureOutline,
        Icon28PictureStackOutline,
        Icon28PinOutline,
        Icon28Place,
        Icon28PlaceOutline,
        Icon28Play,
        Icon28PlayRectangleStackOutline,
        Icon28PlaySpeedOutline,
        Icon28PlaylistOutline,
        Icon28PodcastOutline,
        Icon28PollSquareOutline,
        Icon28PrivacyOutline,
        Icon28Profile,
        Icon28QrCodeOutline,
        Icon28RadiowavesAroundOutline,
        Icon28RadiowavesLeftAndRightOutline,
        Icon28RecentOutline,
        Icon28RefreshOutline,
        Icon28RemoveCircleOutline,
        Icon28ReplyOutline,
        Icon28ReportOutline,
        Icon28ScanViewfinderOutline,
        Icon28Search,
        Icon28SearchOutline,
        Icon28Send,
        Icon28ServicesOutline,
        Icon28Settings,
        Icon28SettingsOutline,
        Icon28ShareExternalOutline,
        Icon28ShareOutline,
        Icon28ShuffleOutline,
        Icon28SkipNext,
        Icon28SkipPrevious,
        Icon28SlidersOutline,
        Icon28SmileOutline,
        Icon28SongOutline,
        Icon28SortHorizontalOutline,
        Icon28SortOutline,
        Icon28StatisticsOutline,
        Icon28StickerOutline,
        Icon28Story,
        Icon28StoryOutline,
        Icon28SubtitlesOutline,
        Icon28TagOutline,
        Icon28TargetOutline,
        Icon28UnfavoriteOutline,
        Icon28UnpinOutline,
        Icon28UploadOutline,
        Icon28User,
        Icon28UserAddOutline,
        Icon28UserCircleOutline,
        Icon28UserIncomingOutline,
        Icon28UserOutgoingOutline,
        Icon28UserOutline,
        Icon28Users,
        Icon28Users3Outline,
        Icon28UsersOutline,
        Icon28Video,
        Icon28VideoOutline,
        Icon28VideocamOutline,
        Icon28ViewOutline,
        Icon28Voice,
        Icon28VoiceOutline,
        Icon28VolumeOutline,
        Icon28WalletOutline,
        Icon28WaterDropOutline,
        Icon28Write,
        Icon28WriteOutline,
        Icon28WriteSquareOutline,
        Icon32Camera,
        Icon32Discussions,
        Icon32Document,
        Icon32Gallery,
        Icon32Gift,
        Icon32Graffiti,
        Icon32MoneyTransfer,
        Icon32Music,
        Icon32Place,
        Icon32Poll,
        Icon32Spinner,
        Icon32Videos,
        Icon36Add,
        Icon36Article,
        Icon36CalendarOutline,
        Icon36Cancel,
        Icon36Coins,
        Icon36Delete,
        Icon36Done,
        Icon36GameOutline,
        Icon36HomeOutline,
        Icon36Like,
        Icon36LikeOutline,
        Icon36LiveOutline,
        Icon36LogoVk,
        Icon36MarketOutline,
        Icon36MoneyCircleOutline,
        Icon36Music,
        Icon36MusicOutline,
        Icon36Playlist,
        Icon36PlaylistCached,
        Icon36PodcastsOutline,
        Icon36Replay,
        Icon36ServicesOutline,
        Icon36SmileOutline,
        Icon36Users3Outline,
        Icon36VideoOutline,
        Icon44CoinsOutline,
        Icon44GiftOutline,
        Icon44MusicOutline,
        Icon44SmileOutline,
        Icon44Spinner,
        Icon48Camera,
        Icon48Pause,
        Icon48Play,
        Icon48Playlist,
        Icon48SkipNext,
        Icon48SkipPrevious,
        Icon56AddCircleOutline,
        Icon56ArchiveOutline,
        Icon56CameraOffOutline,
        Icon56CheckCircleDeviceOutline,
        Icon56CheckCircleOutline,
        Icon56DeleteOutlineAndroid,
        Icon56DeleteOutlineIos,
        Icon56DoNotDisturbOutline,
        Icon56DocumentOutline,
        Icon56DownloadOutline,
        Icon56DownloadSquareOutline,
        Icon56ErrorOutline,
        Icon56EventOutline,
        Icon56FaceIdOutline,
        Icon56FavoriteOutline,
        Icon56FireOutline,
        Icon56GalleryOutline,
        Icon56GiftOutline,
        Icon56GoodsCollection,
        Icon56HideOutline,
        Icon56HistoryOutline,
        Icon56InboxOutline,
        Icon56InfoOutline,
        Icon56LikeOutline,
        Icon56LinkCircleOutline,
        Icon56LockOutline,
        Icon56MailOutline,
        Icon56MarketLikeOutline,
        Icon56MarketOutline,
        Icon56MentionOutline,
        Icon56MessageReadOutline,
        Icon56MoneyTransferOutline,
        Icon56MusicOutline,
        Icon56NewsfeedOutline,
        Icon56NotificationOutline,
        Icon56PhoneOutline,
        Icon56PlaceOutline,
        Icon56PlaylistOutline,
        Icon56RecentOutline,
        Icon56ServicesOutline,
        Icon56ShuffleOutline,
        Icon56TouchIdOutline,
        Icon56UserAddOutline,
        Icon56Users3Outline,
        Icon56UsersOutline,
        Icon56VideoOutline,
        Icon56WifiOutline,
        Icon56WriteOutline
    }
}