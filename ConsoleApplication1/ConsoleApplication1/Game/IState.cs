using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Game {
    public interface IState {
        void Setup();
        void Update();
        void Draw();

    }
}
