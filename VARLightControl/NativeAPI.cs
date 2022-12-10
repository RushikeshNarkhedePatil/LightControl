using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VARLightControl
{
    public struct OPENCOM_CALLBACK_ARG_T
    {
        public UInt16 portNum;
        public Byte devId;
        public Byte hardwareMajorVer;
        public Byte hardwareMinorVer;
        public Byte hardwareRevVer;
        public Byte firmwareMajorVer;
        public Byte firmwareMinorVer;
        public Byte firmwareRevVer;
        public Byte fillup_1;
        public Byte fillup_2;
        public Byte error;
        public UInt32 errorId;
    }

    public struct CLOSECOM_CALLBACK_ARG_T
    {
        public UInt32 fill_up;
        public Byte fill_up_1;
        public Byte fill_up_2;
        public Byte fill_up_3;
        public Byte error;
        public UInt32 errorId;
        public UInt32 fill_up_4;
    }

    public struct GET_DEVICE_VER_CALLBACK_ARG_T
    {
        public Byte hardwareMajorVer;
        public Byte hardwareMinorVer;
        public Byte hardwareRevVer;
        public Byte firmwareMajorVer;
        public Byte firmwareMinorVer;
        public Byte firmwareRevVer;
        public Byte fill_up;
        public Byte error;
        public UInt32 errorId;
        public UInt32 fill_up_2;
    }

    public struct SET_PWM_PARAMS_CALLBACK_ARG_T
    {
        public UInt32 fill_up;
        public Byte chIdx;
        public Byte fill_up_1;
        public Byte fill_up_2;
        public Byte error;
        public UInt32 errorId;
        public UInt32 fill_up_3;
    }

    public struct GET_PWM_PARAMS_CALLBACK_ARG_T
    {
        public Byte chIdx;
        public Byte pwmMode;
        public Byte pwmValue;
        public Byte pwmHoldingTime;
        public Byte pwmOnOff;
        public Byte fill_up_2;
        public Byte fill_up_3;
        public Byte error;
        public UInt32 errorId;
        public UInt32 fill_up_4;
    }

    public struct SET_GENERAL_PARAM_CALLBACK_ARG_T
    {
        public Byte devId;
        public Byte cmdId;
        public Byte paramId;
        public Byte paramLen;
        public UInt32 paramValue;
        public Byte fill_up_1;
        public Byte fill_up_2;
        public Byte fill_up_3;
        public Byte error;
        public UInt32 errorId;
    }


    public struct GET_GENERAL_PARAM_CALLBACK_ARG_T
    {
        public Byte devId;
        public Byte cmdId;
        public Byte paramId;
        public Byte paramLen;
        public UInt32 paramValue;
        public Byte fill_up_1;
        public Byte fill_up_2;
        public Byte fill_up_3;
        public Byte error;
        public UInt32 errorId;
    }



    [StructLayout(LayoutKind.Explicit)]
    public class LC_CALLBACK_ARG_T
    {
        [FieldOffset(0)]
        public OPENCOM_CALLBACK_ARG_T openComCallbackArg;
        [FieldOffset(0)]
        public CLOSECOM_CALLBACK_ARG_T closeComCallbackArg;
        [FieldOffset(0)]
        public GET_DEVICE_VER_CALLBACK_ARG_T getDeviceVerCallbackArg;
        [FieldOffset(0)]
        public SET_PWM_PARAMS_CALLBACK_ARG_T setPwmParamsCallbackArg;
        [FieldOffset(0)]
        public GET_PWM_PARAMS_CALLBACK_ARG_T getPwmParamsCallbackArg;
        [FieldOffset(0)]
        public SET_GENERAL_PARAM_CALLBACK_ARG_T setGeneralParamCallbackArg;
        [FieldOffset(0)]
        public GET_GENERAL_PARAM_CALLBACK_ARG_T getGeneralParamCallbackArg;

    };

    // Light Control
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LCCallbackMethod(LC_CALLBACK_ARG_T arg);// Delegate type, mainly used for callback.

    public static class NativeAPI
    {



        // Library
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIOLC_LibraryBaseInit", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIOLC_LibraryBaseInit(string configIniFile);
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIOLC_LibraryBaseDeinit", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIOLC_LibraryBaseDeinit();
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIOLC_OpenDevice", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIOLC_OpenDevice(UInt16 port, LCCallbackMethod pCallBackFun);
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIOLC_CloseDevice", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIOLC_CloseDevice(UInt16 port, LCCallbackMethod pCallBackFun);
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIOLC_IsDeviceOpened", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIOLC_IsDeviceOpened(UInt16 port, UInt32 devId);
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIOLC_Process", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIOLC_Process();



        // Read and Write DIO in polling mode
        /*-Polling Mode API------------------------------------------------------------------------------*/
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIO_PollingReadDiBit", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIO_PollingReadDiBit(Byte diByteIndex, Byte diBitIndex);
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIO_PollingReadDiByte", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Byte DIO_PollingReadDiByte(Byte diByteIndex);
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIO_PollingWriteDoBit", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DIO_PollingWriteDoBit(Byte doByteIndex, Byte doBitIndex, Byte doBitValue);
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIO_PollingWriteDoByte", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DIO_PollingWriteDoByte(Byte doByteIndex, Byte doByteValue);



        /*-Light control API------------------------------------------------------------------------------*/
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "LC_GetVerInfo", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 LC_GetVerInfo(UInt32 devId, LCCallbackMethod pCallBackFun);

        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "LC_SetPwmParams", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 LC_SetPwmParams(UInt32 devId,
            Byte ucChIdx,
            Byte ucPwmMode,
            Byte ucPwmValue,
            Byte ucPwmHoldingTime,
            Byte ucPwmOnOff,
            LCCallbackMethod pCallBackFun);

        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "LC_GetPwmParams", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 LC_GetPwmParams(UInt32 devId,
            Byte ucChIdx,
            LCCallbackMethod pCallBackFun);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Add for the parameters settings
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// For the general parameter settings
        /// </summary>
        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIOLC_SetGeneralParam", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIOLC_SetGeneralParam(UInt32 devId,
            Byte ucParamId,
            Byte ucParamLen,
            UInt32 uiParamValue,
            LCCallbackMethod pCallBackFun);

        [DllImport("NKIOLCLIBx64.dll", EntryPoint = "DIOLC_GetGeneralParam", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 DIOLC_GetGeneralParam(UInt32 devId,
            Byte ucParamId,
            Byte ucParamLen,
            LCCallbackMethod pCallBackFun);

    }
}
