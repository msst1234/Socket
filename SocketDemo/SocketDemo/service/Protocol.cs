namespace Framework.Protocol
{
    //命令定义
    public enum Command : byte
    { 
        Login = 0, //用户登录
        Logout,    //用户注销
        ORLogin,   //手术室上线
        ORLogout,  //手术室下线
        Register,  //注册
        Beaten,    //报告心跳
        SaveLog,   //保存日志
        QueryConfig, //查询配置
        SaveConfig,  //保存配置
        ShutDown,    //关闭
        QueryRoute,  //查询路由关系
        SetRoute,  //设置路由
        CutRoute, //切断路由
        ResetRoute, //复位路由 即 切断所有路由
        SwitchPreView,//切换预览视频
        CameraQueryStatus,//查询摄像头状态 
        CameraPowerOn,//摄像头开
        CameraPowerOff,//摄像头关
        CameraUp,//调节摄像头
        CameraDown,
        CameraLeft,
        CameraRight,
        CameraZoomOut,
        CameraZoomIn,
        CameraFocusNear,
        CameraFocusFar,
        CameraAutoFocus,
        CameraIrisUp,
        CameraIrisDown,
        CameraAutoIris,
        CameraFreezeOn,
        CameraFreezeOff,
        CameraWhiteBalance,
        CameraPanTiltStop,
        CameraZoomStop,
        CameraFocusStop,
        PIP,
        PBP,
        PIPExChange,//大小画切换
        DisConnect,//切断视频信号到PIP/PBP某一个窗口的连接关系
        OTFunctionLeft, //左侧功能按钮，默认为设置标准体位1
        OTFunctionRight,
        OTNormalMode,//手术床正常模式
        OTReverseMode, //手术床反向模式
        OperationTableUp,//手术床向上        
        OperationTableDown,
        OperationTableLeft,
        OperationTableRight,
        OperationTableHeadTilt,
        OperationTableFootTilt,
        OTBackFoldUp,
        OTBackFoldDown,
        OTMovetoHead,
        OTMovetoFoot,
        OTLegFoldUp,
        OTLegFoldDown,
        OTRightLegFoldDown,
        OTRightLegFoldUp,        
        OTLeftLegFoldDown,
        OTLeftLegFoldUp,
        OTLock,
        OTUnLock,
        OTReset,
        OTPowerOff,
        OTPowerOn,
        OLPower,//手术灯开关
        IncreaseIllumin,
        DecreaseIllumin,
        IncreaseLightField,
        DecreaseLightField,
        ChangeOperationLightColorTemp,
        OperationLightSyncColorTemp,//色温同步
        IncreaseColorTemp,//增加色温
        DecreaseColorTemp,
        OperationLightAICS,
        OperationLightAmbient,
        OLBrightMode,
        OLNormalMode,
        QueryOLConfig,//查询手术灯配置
        QueryOLState,//查询手术灯状态
        OLCameraPower,//中置摄像头开关
        OLCameraZoomout,//中置摄像头
        OLCameraZoomin,
        OLCameraFocusNear,
        OLCameraFocusFar,
        OLCameraIrisUp,
        OLCameraIrisDown,
        OLCameraAutoFocus,
        OLCameraAutoIris,
        OLCameraFreeze,
        OLCameraWhiteBalance,
        ChangeVideoMatrix,//调节视频矩阵
        UpdateVideoMatrix,//更新视频路由连接关系
        UpdateVideoRecordState,//更新视频录制状态
        CheckUpdate,    //查询软件是否有更新
        QueryDemog,
        ResponseDemog,
        ControlPushMsg, //中控服务上的推送消息
        AudioMute,//静音
        AudioVolumeUp,//声音增大
        AudioVolumeDown,//声音减小
        SaveCustomIcon, //保存自定义图标
        LoadCustomIcon, //下载自定义图标
        GetRecordVideoStreamURL,//获取录制视频流的url
        StopRecordVideo,//停止录制视频
        QueryRecordState,//查询录制状态
        ModifyHospitalName,//修改医院名称
        ModifyORName,//修改手术室名称
        ModifyPassword,//修改密码
        ModifyVideoState,//修改视频清晰度属性
        GatewayLogin,//网关登录
        QueryActiveORList,//查询活跃的手术室和示教室列表
        ClientRegister,//客户端注册请求
        GetConferenceUsers,//获取视频会议用户列表
        LoginConference,//登录到视频会议
        QueryMultiView,//画中画（包括PIP和PBP）
        OTReverseCurve,//手术床反区曲
        OTCurve,//手术床屈曲
        OTBeachChair,//手术床沙滩椅 
        OTOpenSetting,//手术床打开设置菜单:如记忆体位
        OTSaveSetting,//手术床保存设置:记忆体位
        QueryDoc,//查询手术记录
        UpdateDoc,//更新手术记录信息
        DeleteDoc,//删除手术记录
        QueryUPS,//查询UPS剩余电量
        SaveAllOperationLightConfigs,//保存现在所有灯组的配置信息（照度，色温，亮度，开关状态等）
        QueryAllOperationLightConfigs,//查询现在所有灯组的配置信息（照度，色温，亮度，开关状态等）
        ApplyUserOperationLightConfigs,//去应用用户对灯的预设配置去
        StartLive,//开始一个直播
        StopLive,//停止直播
        QueryLives,//查询直播信号
        LivePushMsg,//直播管理的推送消息   
        OTApplySetting,//运行记忆体位
        ForceLogin,//强制登录，会导致该用户在别的地方下线
        ForceLogout,//状态服务给客户端发送强制下线的命令
        PreviewChanged,//预览发生变化的消息
        OTGetState,//获取手术床最新状态命令
        OTMovetoHeadLong,//手术床头端超长平移
        OTMenuOpen,//主菜单打开
        OTMenuItemClick,//手术床菜单点击，保证床控90秒内部关机
        OTMovetoFootLong,//手术床脚端超长平移，命令用于反向体位
        MultiViewModeChanged,//画中画模式发生变化
        PushLogoutMessage,    //用户推送注销消息
    }

    //元素定义
    public enum Tag : ushort
    {
        ClientUID = 0,//终端唯一标识 0
        Account,      //账号 
        Password,     //密码
        ORUID,        //手术室标识
        ORName,       //手术室名字 
        ClientType,   //客户端类型:手术室 or 普通客户端 
        IP,           //ip                               5
        Port,         //端口号
        Log,          //日志  
        Status,       //返回包的状态
        ErrorCode,    //错误码
        Config,       //配置数据                10
        ConfigType,   //配置数据类型
        BeatenFreq,   //心跳频率 
        InputPort,    //矩阵输入端口
        OutputPort,   //矩阵输出端口
        GroupID,      //组标识，一个组下可能包含了多个设备
        DeviceID,     //设备标识                15
        ColorTemp,    //色温
        Switch,       //开关，如阴影同步、环境光等
        AppName,      //软件名称
        Domain,       //域信息
        Version,      //版本                    20
        UpdatePacketPath, //升级文件路径,
        UpdateSequenceBegin,  //升级序列开始
        SequenceEnd,          //序列结束
        ItemBegin,            //序列下的每一个item开始
        ItemEnd,              //序列下的每一个item结束  25
        PdqKeys,    //查询关键字
        PdqDomains, //查询域信息
        PdqResponse,    //查询即时响应，返回查询唯一ID
        PdqResults,     //查询最终结果
        RouteMap,       //路由关系
        ControlMsgType, //中控服务控制消息类型
        ControlMsg,//控制消息
        OLConfig, //手术灯配置
        OLState, //手术灯状态
        RecordState, //视频录制状态
        HospitalName, //医院名称
        NewORName,//新手术室名称
        AuthorityLevel,//权限级别
        MultiView,//画中画
        DocSequenceBegin,//手术记录查询结果序列
        UPS_Ramain,//UPS剩余电量
        AllOperationLightStates,//当前手术室所有灯的配置信息（照度，色温，亮度，开关状态等）
        VideoState,//视频录取清晰度
        UPS_LastBatteryState,//UPS电池状态
    }

    //数据类型定义
    public enum DataType : byte
    {
        Byte   = 0, //字节 0
        SInt32,     //有符号32位整数 
        UInt32,     //无符号32位整数
        String,     //字符串
        ByteArray,  //字节数组
    }

    //配置类型定义
    public enum ConfigType : byte
    {
        General = 0,//通用配置
        DORConfig,  //手术室配置
        Terminal,   //终端配置
        Personal,   //个性化配置
        Unknown,
    }

    //客户端类型定义
    public enum ClientType : byte
    {
        ORClient = 0,//一体机客户端:手术室客户端+示教室客户端
        PCClient,    //PC客户端
        AppClient,   //移动客户端
        OR,        //手术室
        TC,        //示教室 
        Unknown,
    }

    //权限级别定义
    class AuthorityLevel
    {
        public static readonly string Admin = "Admin";
        public static readonly string Normal = "Normal";
        public static readonly string Guest = "Guest";
    }

    //包头包尾定义
    class PacketDelimiter
    {
        public static readonly byte[] Begin = { 0x0B, 0x0D, 0x0B, 0x0D };
        public static readonly byte[] End = { 0x1C, 0x0D, 0x1C, 0x0D };
    }

    //定义录制视频清晰度
    public enum VideoState:byte
    {
        Unknown = 0,
        SD,   //超清
        HD,   //高清
        LD,   //标清
    }
}
