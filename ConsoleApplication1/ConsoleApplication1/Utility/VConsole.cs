using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Utility {
    public class VConsole {

        /// <summary>
        /// VConsole.Write("dfgdg");
        ///    VConsole.Write("fdgdfg", ConsoleColor.Cyan);
        ///    VConsole.Write("fdgdfg", ConsoleColor.Cyan, ConsoleColor.DarkMagenta);
        ///    VConsole.Write("dfgdg", back: ConsoleColor.Red);        
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="fore">text color</param>
        /// <param name="back">background color</param>
        public void Write(string text, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black) {
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
            Console.Write(text);
            Console.ResetColor();
        }
        public void WriteLine(string text, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black) {
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public void Clear() {
            Console.Clear();
        }
        public ConsoleKeyInfo ReadKey() {
            return Console.ReadKey();        
        }
        public string ReadLine() {
            return Console.ReadLine();
        }
        public void Render() {
            //later to be implemented for off screen buffering
        }

        public ConsoleColor SimpleForegroundColor { get { return Console.ForegroundColor; } set { Console.ForegroundColor = value; } }
        public ConsoleColor SimpleBackgroundColor { get { return Console.BackgroundColor; } set { Console.BackgroundColor = value; } }
        public void SimpleResetColor() { Console.ResetColor(); }
        public void SimpleWrite(string text) {
            Console.Write(text);
        }
        public void SimpleWriteLine(string text) {
            Console.WriteLine(text);
        }

    }
}
