using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Puzrain.Commands
{
    class OpenFileDialogCommand : Command
    {
        public delegate void ExecuteMethod();
        public ExecuteMethod? _executeMethod;

        public OpenFileDialogCommand() { }

        public override void Execute(object? parameter)
        {
            _executeMethod?.Invoke();
        }
    }
}
