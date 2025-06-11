using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLManager
    {
        public IBLUser BLUser { get; }
        public IBLCategory BLCategory { get; }
        public IBLSubCategory BLSubCategory { get; }
        public IBLPrompt BLPrompt { get; }
    }
}
