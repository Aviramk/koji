using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koji
{
    public class Sound
    {
        protected enum SoundStates
        {
            PLAYING,
            PAUSED,
            STOPPED
        };
        
        /// Private Members
        
        ///<summary>
        /// Path to the sound file.
        /// </summary>
        protected string FilePath;

        ///<summary>
        /// The sound file extension.
        /// </summary>
        protected string FileType;

        ///<summary>
        /// Volume to play the sound at.
        /// </summary>
        protected int Volume;

        ///<summary>
        /// Current state of the Sound.
        /// </summary>
        protected SoundStates CurrentState;

        /// <summary>
        /// Sets the instance variable of FilePath to the given path if it has a valid extension.
        /// </summary>
        /// <param name="PathToFile"></param>
        /// <returns></returns>
        public bool SetFile(string PathToFile)
        {
            if (File.Exists(PathToFile) &&
                Constants.VALID_EXT_TYPE.Contains(Path.GetExtension(PathToFile))
                )
            {
                FilePath = PathToFile;
                FileType = Path.GetExtension(PathToFile);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the sound file path.
        /// </summary>
        /// <returns>String path to file.</returns>
        public string GetFile()
        {
            return FilePath;
        }

    }
}
