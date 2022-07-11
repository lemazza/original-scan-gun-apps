using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BarcodeSetup
{
    class UnmanagedAPI
    {
        #region  ########## Play_Sound ##########
        [DllImport("coredll.dll", EntryPoint="PlaySound", SetLastError=true)]
        private static extern int _PlaySound(string szSound, IntPtr hModule, int flags);

        [DllImport("coredll.dll", EntryPoint = "PlaySound", SetLastError = true)]
        private static extern int _PlaySound(byte[] szSound, IntPtr hModule, int flags);

        private enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0,     // play synchronously (default)
            SND_ASYNC = 0x1,    // play asynchronously
            SND_NODEFAULT = 0x2,    // silence (!default) if sound not found
            SND_MEMORY = 0x4,       // pszSound points to a memory file
            SND_LOOP = 0x8,     // loop the sound until next sndPlaySound
            SND_NOSTOP = 0x10,      // don't stop any currently playing sound
            SND_NOWAIT = 0x2000,    // don't wait if the driver is busy
            SND_ALIAS = 0x10000,    // name is a registry alias
            SND_ALIAS_ID = 0x110000,// alias is a predefined ID
            SND_FILENAME = 0x20000, // name is file name
            SND_RESOURCE = 0x40004, // name is resource name or atom
        };

        public static void PlaySound(string fileName)
        {
            _PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
        }
        public static void PlaySound(byte[] szSound)
        {
            _PlaySound(szSound, IntPtr.Zero, (int)(PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP | PlaySoundFlags.SND_MEMORY));
        }
        #endregion

        #region ########## Battery Status ##########

        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal static extern int GetSystemPowerStatusEx2(SYSTEM_POWER_STATUS_EX2 pSystemPowerStatusEx2, [MarshalAs(UnmanagedType.U4), In] int dwLen, [MarshalAs(UnmanagedType.Bool), In] bool fUpdate);

        internal class SYSTEM_POWER_STATUS_EX2
        {
            public byte ACLineStatus = 0;
            public byte BatteryFlag = 0;
            public byte BatteryLifePercent = 0;
            public byte Reserved1 = 0;
            public int BatteryLifeTime = 0;
            public int BatteryFullLifeTime = 0;
            public byte Reserved2 = 0;
            public byte BackupBatteryFlag = 0;
            public byte BackupBatteryLifePercent = 0;
            public byte Reserved3 = 0;
            public int BackupBatteryLifeTime = 0;
            public int BackupBatteryFullLifeTime = 0;
            public int BatteryVoltage = 0;
            public int BatteryCurrent = 0;
            public int BatteryAverageCurrent = 0;
            public int BatteryAverageInterval = 0;
            public int BatterymAHourConsumed = 0;
            public int BatteryTemperature = 0;
            public int BackupBatteryVoltage = 0;
            public byte BatteryChemistry = 0;
        }

        internal enum ACLineStatus : byte
        {
            Offline = 0,
            Online = 1,
            BackUp = 2,
            Unknown = 255,
        }

        internal enum BatteryFlag : byte
        {
            HIGH = 0x01,
            LOW = 0x02,
            CRITICAL = 0x04,
            CHARGING = 0x08,
            NO_BATTERY = 0x80,
            UNKNOWN = 0xFF,
        }

        public static int BatteryLifePercent
        {
            get
            {
                SYSTEM_POWER_STATUS_EX2 SystemPowerStatusEx2 = new SYSTEM_POWER_STATUS_EX2();

                if (GetSystemPowerStatusEx2(SystemPowerStatusEx2, Marshal.SizeOf(SystemPowerStatusEx2), true) > 0)
                {
                    //if ((ACLineStatus)SystemPowerStatusEx2.ACLineStatus != ACLineStatus.)
                    //    return 0;

                    return SystemPowerStatusEx2.BatteryLifePercent;
                }

                return 0;
            }
        }

        public static BatteryFlag BatteryDetectionStatus
        {
            get
            {
                SYSTEM_POWER_STATUS_EX2 SystemPowerStatusEx2 = new SYSTEM_POWER_STATUS_EX2();

                if (GetSystemPowerStatusEx2(SystemPowerStatusEx2, Marshal.SizeOf(SystemPowerStatusEx2), true) > 0)
                {
                    return (BatteryFlag)SystemPowerStatusEx2.BatteryFlag;
                }

                return BatteryFlag.UNKNOWN;
            }
        }


        #endregion

        public static string FullAppPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        [DllImport("CSysSvcApi.dll", EntryPoint = "SetVibratorEnable", SetLastError = true)]
        public static extern int _SetVibratorEnable(bool bEnable);

        //[DllImport("coredll.dll", SetLastError = true)]
        //public static extern Int32 GetLastError();

        public static int Test()
        {
            return Marshal.GetLastWin32Error();
        }


        [DllImport("coredll", EntryPoint = "CreateFile", SetLastError = true)]
        public static extern IntPtr CreateFile(String lpFileName, UInt32 dwDesiredAccess, UInt32 dwShareMode, IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition, 
                                                            UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("coredll.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        public const uint FILE_DEVICE_UNKNOWN = 0x00000022;
        public const uint FILE_DEVICE_HAL = 0x00000101;
        public const uint FILE_DEVICE_CONSOLE = 0x00000102;
        public const uint FILE_DEVICE_PSL = 0x00000103;
        public const uint METHOD_BUFFERED = 0;
        public const uint METHOD_IN_DIRECT = 1;
        public const uint METHOD_OUT_DIRECT = 2;
        public const uint METHOD_NEITHER = 3;
        public const uint FILE_ANY_ACCESS = 0;
        public const uint FILE_READ_ACCESS = 0x0001;
        public const uint FILE_WRITE_ACCESS = 0x0002;

        public static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
        {
            return ((DeviceType << 16) | (Access << 14) | (Function << 2) | Method);
        }

        [DllImport("coredll.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateEvent(IntPtr lpEventAttributes, [In, MarshalAs(UnmanagedType.Bool)] bool bManualReset, [In, MarshalAs(UnmanagedType.Bool)] bool bIntialState, [In, MarshalAs(UnmanagedType.BStr)] string lpName);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern Int32 WaitForSingleObject(IntPtr Handle, long Wait);

        [DllImport("coredll.dll", EntryPoint = "WaitForMultipleObjects", SetLastError = true)]
        public static extern Int32 WaitForMultipleObjects(UInt32 nCount, IntPtr[] lpHandles, Boolean fWaitAll, long  dwMilliseconds);

        //[DllImport("coredll.dll", SetLastError = true)]
        //public static extern bool SetEvent(IntPtr hEvent);
        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EventModify(IntPtr hEvent, [In, MarshalAs(UnmanagedType.U4)] int dEvent);

        private enum EventFlags
        {
            PULSE = 1,
            RESET = 2,
            SET = 3
        }   
        public static bool SetEvent(IntPtr hEvent)
        {
            return EventModify(hEvent, (int)EventFlags.SET);
        }

        // Set, Reset, Sleep/Wakeup Notification
        [DllImport("CSysSvcApi.dll", EntryPoint = "SleepWakeupNotificationSet", SetLastError = true)]
        public static extern int _SleepWakeupNotificationSet(IntPtr hWnd);

        [DllImport("CSysSvcApi.dll", EntryPoint = "SleepWakeupNotificationReset", SetLastError = true)]
        public static extern int _SleepWakeupNotificationReset(IntPtr hWnd);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern bool SetLocalTime(ref SYSTEMTIME SystemTime);

        //[DllImport("coredll.dll", SetLastError = true)]
        //public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SYSTEMTIME
        {
            public UInt16 Year;
            public UInt16 Month;
            public UInt16 DayOfWeek;
            public UInt16 Day;
            public UInt16 Hour;
            public UInt16 Minute;
            public UInt16 Second;
            public UInt16 Millisecond;
        }

        #region DeviceIoControl
        [DllImport("coredll.dll", EntryPoint = "DeviceIoControl", SetLastError = true)]
        internal static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, 
                                                        IntPtr lpInBuffer, int nInBufferSize, 
                                                        IntPtr lpOutBuffer, int nOutBufferSize,
                                                        ref int lpBytesReturned, IntPtr lpOverlapped);

        [DllImport("coredll.dll", EntryPoint = "DeviceIoControl", SetLastError = true)]
        internal static extern int DeviceIoControlCE(
            int hDevice,
            int dwIoControlCode,
            byte[] lpInBuffer,
            int nInBufferSize,
            byte[] lpOutBuffer,
            int nOutBufferSize,
            ref int lpBytesReturned,
            IntPtr lpOverlapped);

        #endregion

        #region KernelIoControl
        [DllImport("coredll.dll", SetLastError = true)]
        internal static extern bool KernelIoControl(uint dwIoControlCode, 
                                                    IntPtr inBuf, 
                                                    int inBufSize, 
                                                    IntPtr outBuf, 
                                                    int outBufSize, 
                                                    ref int bytesReturned);

        #endregion

        public const string NETCF_WND_CLASS_NAME = "#NETCF_AGL_BASE_";

        [DllImport("coredll.dll", EntryPoint = "FindWindowW", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("coredll.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static bool Reboot()
        {
            int bytesReturned = 0;
            bool Ret = false;
            uint IOCTL_HAL_REBOOT = CTL_CODE(FILE_DEVICE_HAL, 15, METHOD_BUFFERED, FILE_ANY_ACCESS);

            Ret = KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, IntPtr.Zero, 0, ref bytesReturned);

            return Ret;
        }


        // +++++++++++++++++++++++++++++++  2011.07.26

        public const Int32 INVALID_HANDLE_VALUE = -1;
        public const UInt32 FILE_FLAG_OVERLAPPED = 0x40000000;	//dwFlagsAndAttributes
        public const UInt32 OPEN_EXISTING = 3;					//dwCreationDisposition

        public const UInt32 GENERIC_READ = 0x80000000;			//dwDesiredAccess
        public const UInt32 GENERIC_WRITE = 0x40000000;
        public const UInt32 READ_WRITE = GENERIC_READ | GENERIC_WRITE;

        [StructLayout(LayoutKind.Sequential)]
        public struct COMMTIMEOUTS
        {
            internal UInt32 readIntervalTimeout;
            internal UInt32 readTotalTimeoutMultiplier;
            internal UInt32 readTotalTimeoutConstant;
            internal UInt32 writeTotalTimeoutMultiplier;
            internal UInt32 writeTotalTimeoutConstant;
        }

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern Boolean WaitCommEvent(IntPtr hFile, IntPtr lpEvtMask, IntPtr lpOverlapped);

        [DllImport("coredll.dll")]
        public static extern Boolean SetCommMask(IntPtr hFile, UInt32 dwEvtMask);

        [DllImport("coredll.dll")]
        public static extern Boolean GetCommMask(IntPtr hFile, out IntPtr lpEvtMask);

        [DllImport("coredll.dll")]
        public static extern Boolean SetCommTimeouts(IntPtr hFile, [In] ref COMMTIMEOUTS lpCommTimeouts);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern int GetFileVersionInfoSize(string lptstrFilename, IntPtr lpdwHandle);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern bool GetFileVersionInfo(string lptstrFilename, int dwHandle, int dwLen, IntPtr lpData);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern bool VerQueryValue(IntPtr pBlock, string lpSubBlock, ref VS_FIXEDFILEINFO lplpBuffer, ref uint puLen);

        [StructLayout(LayoutKind.Sequential)]
        public struct VS_FIXEDFILEINFO
        {
            public int dwSignature;
            public int dwStrucVersion;
            public int dwFileVersionMS;
            public int dwFileVersionLS;
            public int dwProductVersionMS;
            public int dwProductVersionLS;
            public int dwFileFlagsMask;
            public int dwFileFlags;
            public int dwFileOS;
            public int dwFileType;
            public int dwFileSubtype;
            public int dwFileDateMS;
            public int dwFileDateLS;
        }


        #region for UHF
        //[DllImport("ATRMUHF.dll", SetLastError = true)]
        //internal static extern bool ATRMUHF_GET_XcvrMaxPwr(ref uint pPwr);

        //[DllImport("ATRMUHF.dll", SetLastError = true)]
        //internal static extern uint ATRMUHF_GET_OEMBandID(string szID);

        //[DllImport("CRfidApi.dll", SetLastError = true)]
        //internal static extern int RfidGetXcvrMaxPwr(ref uint pPwr);

        //public static string GetUhfMaxPwr()
        //{
        //    uint nPwr = 0;
        //    string sRtn = String.Empty;

        //    if (frmMain.isDoTel)
        //    {
        //        if (ATRMUHF_GET_XcvrMaxPwr(ref nPwr))
        //        {
        //            switch (nPwr.ToString().Substring(0, 2))
        //            {
        //                case "30":
        //                    sRtn = "1W";
        //                    break;
        //                case "28":
        //                    sRtn = "600mW";
        //                    break;
        //                case "27":
        //                    sRtn = "500mW";
        //                    break;
        //                case "24":
        //                    sRtn = "250mW";
        //                    break;
        //                default:
        //                    sRtn = "Unknown";
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            sRtn = "Unknown";
        //        }
        //    }
        //    else
        //    {
        //        if (RfidGetXcvrMaxPwr(ref nPwr) == 0)
        //        {
        //            switch (nPwr)
        //            {
        //                case 240:
        //                    sRtn = "250mW";
        //                    break;
        //                case 300:
        //                    sRtn = "1W";
        //                    break;
        //                default:
        //                    sRtn = "Unknown";
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            sRtn = "Unknown";
        //        }
        //    }
            
            

        //    return sRtn;
        //}

        //public static string GetOEMBand(NRfidApi.HOPPING_MODE mode)
        //{
        //    if (mode != NRfidApi.HOPPING_MODE.ANONYMOUS)
        //        return mode.ToString();

        //    string sRtn = String.Empty;
        //    string ReadData = new string(new char[50]);
        //    ATRMUHF_GET_OEMBandID(ReadData);
        //    ReadData = ReadData.Substring(0, ReadData.IndexOf(Char.MinValue));

        //    switch (ReadData)
        //    {
        //        case "AUS_":
        //            sRtn = "Australia_(O)";
        //            break;
        //        case "MAL_":
        //            sRtn = "Malaysia_(O)";
        //            break;
        //        case "WR1_":
        //            sRtn = "WorldReader1_(O)";
        //            break;
        //        case "SAF_":
        //            sRtn = "SouthAfrica_(O)";
        //            break;
        //        case "BRA_":
        //            sRtn = "Brazil_(O)";
        //            break;
        //        case "EMA_":
        //            sRtn = "EMA_(O)";
        //            break;
        //        case "IND_":
        //            sRtn = "Indonesia_(O)";
        //            break;
        //        case "KCCh":
        //            sRtn = "KOREA2008_(O)";
        //            break;
        //        case "FCC":
        //            sRtn = "US_(O)";
        //            break;
        //        case "SING":
        //            sRtn = "Singapore_(O)";
        //            break;
        //        case "TAIW":
        //            sRtn = "Taiwan_(O)";
        //            break;
        //        case "CHIN":
        //            sRtn = "China_(O)";
        //            break;
        //        default:
        //            sRtn = ReadData;
        //            break;
        //    }

        //    return sRtn;
        //}
        #endregion

        public enum COMMONIOCTL
        {
            IOCTL_GET_FUNCKEY = 0,
            IOCTL_SET_KEYPADLED,
            IOCTL_SET_GPSPWR,
            IOCTL_SET_BTPWR,
            IOCTL_SET_RFIDPWR,
            IOCTL_SET_RFIDAGP0,
            IOCTL_SET_VIBPWR,
            IOCTL_SET_RFIDGP0,
            IOCTL_SET_SCANPWR,
            IOCTL_SET_SAMPWR,
            IOCTL_SET_SAMSEL,
            IOCTL_GET_EARJACK_STATUS,
            IOCTL_SET_HFPWR,
            IOCTL_SET_GPSRST,									//(+)CJKIM_GPS Reset 0110308
            IOCTL_SET_BTRST,									//(+)CJKIM_BlueTooth Reset 0110308
            IOCTL_SET_DMPORT,								//(+)CJKIM_DM Port Control 0110308
            IOCTL_SET_FLASH,									//(+)CJKIM_Camera Flash Control 0110408
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COMMONCTL
        {
            public COMMONIOCTL ComIoctl;
            public Int32 dwInBuf;
            public Int32 dwOutBuf;
        }

        public static bool isFnKeyDown
        {
            get
            {
                bool bRet = false;
                UnmanagedAPI.COMMONCTL ComCtl = new UnmanagedAPI.COMMONCTL();
                uint IOCTL_SET_COMMON_CONTROL = CTL_CODE(FILE_DEVICE_HAL, 4040, METHOD_BUFFERED, FILE_ANY_ACCESS);
                int bytesReturned = 0;

                ComCtl.ComIoctl = UnmanagedAPI.COMMONIOCTL.IOCTL_GET_FUNCKEY;
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(ComCtl));
                Marshal.StructureToPtr(ComCtl, ptr, false);

                if (!UnmanagedAPI.KernelIoControl(IOCTL_SET_COMMON_CONTROL, ptr, Marshal.SizeOf(ComCtl), IntPtr.Zero, 0, ref bytesReturned))
                {
                    bRet = false;
                }

                ComCtl = (COMMONCTL)Marshal.PtrToStructure(ptr, typeof(COMMONCTL));
                Marshal.FreeHGlobal(ptr);

                bRet = ComCtl.dwOutBuf == 1 ? true : false;

                return bRet;
            }
        }

        //[StructLayout(LayoutKind.Explicit, Size=516)]
        //public struct HWCFG
        //{
        //    [FieldOffset(0)]public ulong HwCfgSig;
        //    [FieldOffset(8)]public byte LCDType;
        //    [FieldOffset(9)]public byte ModemType;
        //    [FieldOffset(10)]public byte ScanType;
        //    [FieldOffset(11)]public byte HFType;
        //    [FieldOffset(12)]public byte UHFType;
        //    [FieldOffset(13)]public byte CamType;
        //    [FieldOffset(14)]public byte WLANType;
        //    [FieldOffset(15)]public byte BTType;
        //    [FieldOffset(16)]public byte GPSType;
        //    [FieldOffset(17)]public byte SAMType;
        //    [FieldOffset(18)]public byte PrinterType;
        //    [FieldOffset(19)]public byte MSRType;
        //    [FieldOffset(20)]public byte FingerPrinterType;

        //    [FieldOffset(21)]//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 479)]
        //    public byte[] Dummy;

        //    [FieldOffset(500)]public ulong dwHwCfgSingConfirm;
        //    [FieldOffset(508)]public ulong dwResetType;
        //    [FieldOffset(516)]public ulong bShowDbgMsg;
        //}
        [StructLayout(LayoutKind.Sequential, Size = 508)]
        public struct HWCFG
        {
            public ulong HwCfgSig;
            public byte LCDType;
            public byte ModemType;
            public byte ScanType;
            public byte HFType;
            public byte UHFType;
            public byte CamType;
            public byte WLANType;
            public byte BTType;
            public byte GPSType;
            public byte SAMType;
            public byte PrinterType;
            public byte MSRType;
            public byte FingerPrinterType;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 479)]
            public byte[] Dummy;

            public ulong dwHwCfgSingConfirm;
            public ulong dwResetType;
            public ulong bShowDbgMsg;
        }

        public static bool GetHWCFG(ref HWCFG hwcfg)
        {
            bool bRet = false;
            
            uint IOCTL_GET_HW_CONFIG = CTL_CODE(FILE_DEVICE_HAL, 4012, METHOD_BUFFERED, FILE_ANY_ACCESS);
            int bytesReturned = 0;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(hwcfg));
            Marshal.StructureToPtr(hwcfg, ptr, false);
            if (!UnmanagedAPI.KernelIoControl(IOCTL_GET_HW_CONFIG, IntPtr.Zero, 0, ptr, Marshal.SizeOf(hwcfg), ref bytesReturned))
            {
                Marshal.FreeHGlobal(ptr);
                return bRet;
            }

            hwcfg = (HWCFG)Marshal.PtrToStructure(ptr, typeof(HWCFG));
            Marshal.FreeHGlobal(ptr);
            bRet = true;
            return bRet;
        }
    }
}
