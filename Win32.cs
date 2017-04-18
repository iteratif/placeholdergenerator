using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PlaceholderGenerator
{
    class Win32
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public const int TCM_HITTEST = 0x130D;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public const int TCM_SETMINTABWIDTH = 0x1300 + 49;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public const int WS_EX_COMPOSITED = 0x02000000;

        public static IntPtr SendMessage(IntPtr _hWnd, int _msg, IntPtr _wParam, IntPtr _lParam)
        {
            Control control = Control.FromHandle(_hWnd);
            if (control == null)
            {
                return IntPtr.Zero;
            }

            Message message = new Message();
            message.HWnd = _hWnd;
            message.LParam = _lParam;
            message.WParam = _wParam;
            message.Msg = _msg;

            MethodInfo wproc = control.GetType().GetMethod("WndProc"
                                                           , BindingFlags.NonPublic
                                                            | BindingFlags.InvokeMethod
                                                            | BindingFlags.FlattenHierarchy
                                                            | BindingFlags.IgnoreCase
                                                            | BindingFlags.Instance);

            object[] args = new object[] { message };
            wproc.Invoke(control, args);

            return ((Message)args[0]).Result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2106:SecureAsserts")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static IntPtr ToIntPtr(object structure)
        {
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(structure));
            Marshal.StructureToPtr(structure, lparam, false);
            return lparam;
        }

        [Flags()]
        public enum TCHITTESTFLAGS
        {
            TCHT_NOWHERE = 1,
            TCHT_ONITEMICON = 2,
            TCHT_ONITEMLABEL = 4,
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TCHITTESTINFO
        {

            public TCHITTESTINFO(Point location)
            {
                pt = location;
                flags = TCHITTESTFLAGS.TCHT_ONITEM;
            }

            public Point pt;
            public TCHITTESTFLAGS flags;
        }
    }
}
