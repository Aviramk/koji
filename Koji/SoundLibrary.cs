using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Koji
{
    class SoundLibrary
    {
        protected List<Sound> soundsList; 

        protected int lastId = 0;

        public void AddSound(string filePath)
        {
            Sound sound = new Sound(filePath);
        }
    }

}
