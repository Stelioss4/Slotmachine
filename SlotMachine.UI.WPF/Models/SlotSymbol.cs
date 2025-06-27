using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.UI.WPF.Models
{
    public class SlotSymbol
    {
        public string Emoji { get; set; }

        public SlotSymbol(string emoji)
        {
            Emoji = emoji;
        }
    }
}
