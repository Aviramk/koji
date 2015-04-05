using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

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

        protected string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            set
            {
            if (!File.Exists(value))
            {
                throw new ArgumentException("File doesn't exist", "value");
            }
            _FilePath = value;
            FileType = Path.GetExtension(value);
            Player.URL = value;
            }
        }

        protected string _FileType;
        ///<summary>
        /// The sound file extension.
        /// </summary>
        public string FileType
        {
            get { return _FileType; }
            set
            {
                if (!Constants.VALID_EXT_TYPE.Contains(value))
                {
                    throw new ArgumentException("File isn't in valid format", "value");
                }
                _FileType = value;
            }
        }


        ///<summary>
        /// Volume to play the sound at.
        /// </summary>
        protected int _Volume = 50;

        public int Volume
        {
            get { return _Volume; }
            set
            {
                if ((value < Constants.MIN_VOLUME) || (value > Constants.MAX_VOLUME))
                {
                    throw new ArgumentException("Volume must be between 1-100", "value");
                }
                _Volume = value;
                Player.settings.volume = value;
            }
        }

        ///<summary>
        /// Current state of the Sound.
        /// </summary>
        protected SoundStates CurrentState;

        /// <summary>
        /// Player that will be used to play sounds.
        /// </summary>
        protected WMPLib.WindowsMediaPlayer Player;

        public Sound()
        {
            Player = new WMPLib.WindowsMediaPlayer();
        }

        public Sound(string PathToFile)
        {
            Player = new WMPLib.WindowsMediaPlayer();
            FilePath = PathToFile;
        }

    }
}
