/*
 * 各クラス等で使用する構造体などの定義ファイル
 */

using Microsoft.VisualBasic.Logging;
using System.Runtime.InteropServices;

namespace MyMacro
{
    namespace Utility
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct tagKBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        internal struct WindowEdge
        {
            public const int WMSZ_LEFT = 1;
            public const int WMSZ_RIGHT = 2;
            public const int WMSZ_TOP = 3;
            public const int WMSZ_TOPLEFT = 4;
            public const int WMSZ_TOPRIGHT = 5;
            public const int WMSZ_BOTTOM = 6;
            public const int WMSZ_BOTTOMLEFT = 7;
            public const int WMSZ_BOTTOMRIGHT = 8;
        }

        internal struct WindowLong
        {
            public const int GWL_EXSTYLE = -20;
            public const int GWL_HINSTANCE = -6;
            public const int GWL_HWNDPARENT = -8;
            public const int GWL_ID = -12;
            public const int GWL_STYLE = -16;
            public const int GWL_USERDATA = -21;
            public const int GWL_WNDPROC = -4;
        }

        internal struct WindowStyle
        {
            public const long WS_EX_ACCEPTFILES = 0x00000010L;
            public const long WS_EX_APPWINDOW = 0x00040000L;
            public const long WS_EX_CLIENTEDGE = 0x00000200L;
            public const long WS_EX_COMPOSITED = 0x02000000L;
            public const long WS_EX_CONTEXTHELP = 0x00000400L;
            public const long WS_EX_CONTROLPARENT = 0x00010000L;
            public const long WS_EX_DLGMODALFRAME = 0x00000001L;
            public const int WS_EX_LAYERED = 0x00080000;
            public const long WS_EX_LAYOUTRTL = 0x00400000L;
            public const long WS_EX_LEFT = 0x00000000L;
            public const long WS_EX_LEFTSCROLLBAR = 0x00004000L;
            public const long WS_EX_LTRREADING = 0x00000000L;
            public const long WS_EX_MDICHILD = 0x00000040L;
            public const long WS_EX_NOACTIVATE = 0x08000000L;
            public const long WS_EX_NOINHERITLAYOUT = 0x00100000L;
            public const long WS_EX_NOPARENTNOTIFY = 0x00000004L;
            public const long WS_EX_NOREDIRECTIONBITMAP = 0x00200000L;
            public const long WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
            public const long WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
            public const long WS_EX_RIGHT = 0x00001000L;
            public const long WS_EX_RIGHTSCROLLBAR = 0x00000000L;
            public const long WS_EX_RTLREADING = 0x00002000L;
            public const long WS_EX_STATICEDGE = 0x00020000L;
            public const long WS_EX_TOOLWINDOW = 0x00000080L;
            public const long WS_EX_TOPMOST = 0x00000008L;
            public const long WS_EX_TRANSPARENT = 0x00000020L;
            public const long WS_EX_WINDOWEDGE = 0x00000100L;
        }

        internal struct WindowsHook
        {
            public const int WH_CALLWNDPROC = 4;
            public const int WH_CALLWNDPROCRET = 12;
            public const int WH_CBT = 5;
            public const int WH_DEBUG = 9;
            public const int WH_FOREGROUNDIDLE = 11;
            public const int WH_GETMESSAGE = 3;
            public const int WH_JOURNALPLAYBACK = 1;
            public const int WH_JOURNALRECORD = 0;
            public const int WH_KEYBOARD = 2;
            public const int WH_KEYBOARD_LL = 13;
            public const int WH_MOUSE = 7;
            public const int WH_MOUSE_LL = 14;
            public const int WH_MSGFILTER = -1;
            public const int WH_SHELL = 10;
            public const int WH_SYSMSGFILTER = 6;
        }
    }
}
