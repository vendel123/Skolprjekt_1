
using ConsoleApplication1.Game;
using ConsoleApplication1.Game.Entities.Abilities;
using ConsoleApplication1.Game.Entities.Races;
using ConsoleApplication1.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6 {
    class Program {

       public static IState GameState;
        static void Main(string[] args) {
            makeBorderless();

            Program.GameState = new RaceSelect();
            Program.GameState.Setup();


            while (true) {
                Program.GameState.Draw();
                Program.GameState.Update();
            }

        }


        #region window
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32", ExactSpelling = true, SetLastError = true)]
        internal static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] ref RECT rect, [MarshalAs(UnmanagedType.U4)] int cPoints);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT {
            public int left, top, bottom, right;
        }


        private const int nIndex = -16;
        private const int dwNewLong = 0x00080000;

        public static string GameTitle { get; private set; }

        static void makeBorderless() {
            IntPtr window = FindWindowByCaption(IntPtr.Zero, GameTitle);
            RECT rect;
            GetWindowRect(window, out rect);
            IntPtr hWndFrom = GetDesktopWindow();
            MapWindowPoints(hWndFrom, window, ref rect, 2);
            SetWindowLong(window, nIndex, dwNewLong);
            SetWindowPos(window, -2, 100, 75, rect.bottom, rect.right, 0x0040);
            DrawMenuBar(window);
            Process process = Process.GetCurrentProcess();
            Console.BufferHeight = Console.WindowHeight;
            ShowWindow(process.MainWindowHandle, 3);
            Console.CursorVisible = false;

        }
        #endregion



    }

}
