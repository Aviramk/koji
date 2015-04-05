using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Koji.Properties;
using WMPLib;

namespace Koji
{
    [ExcludeFromCodeCoverage]
    public class SoundNotReadyException : ApplicationException
    {
        public SoundNotReadyException()
        {
        }

        public SoundNotReadyException(string message)
        {
        }
    }

    public class Sound
    {
        public delegate void PlayerStatusChangeEventHandler(int PlayerId, WMPPlayState NewState);

        /// Private Members
        protected string _FilePath;

        protected string _FileType;

        /// <summary>
        ///     Volume to play the sound at.
        /// </summary>
        protected int _Volume = 50;

        public int Id;

        /// <summary>
        ///     Player that will be used to play sounds.
        /// </summary>
        protected WindowsMediaPlayer Player;

        public PlayerStatusChangeEventHandler playerStatusChangeHandler;

        public Sound()
        {
            Player = new WindowsMediaPlayer();
        }

        public Sound(string PathToFile)
        {
            Player = new WindowsMediaPlayer();
            FilePath = PathToFile;
        }

        public Sound(int newId)
        {
            Player = new WindowsMediaPlayer();
            Id = newId;
        }

        public Sound(string PathToFile, int newId)
        {
            Player = new WindowsMediaPlayer();
            FilePath = PathToFile;
            Id = newId;
        }

        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                if (!File.Exists(value))
                {
                    throw new ArgumentException(Resources.Sound_FilePath_File_Doesnt_Exist, "value");
                }
                _FilePath = value;
                FileType = Path.GetExtension(value);
                Player.URL = value;
            }
        }

        /// <summary>
        ///     The sound file extension.
        /// </summary>
        public string FileType
        {
            get { return _FileType; }
            set
            {
                if (!Constants.VALID_EXT_TYPE.Contains(value))
                {
                    throw new ArgumentException(Resources.Sound_FilePath_File_Invalid_Ext, "value");
                }
                _FileType = value;
            }
        }

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

        public void RegisterPlayerStatusNotifications()
        {
            Player.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(PlayStateTranslator);
        }

        public void PlayStateTranslator(int playState)
        {
            playerStatusChangeHandler(Id, (WMPLib.WMPPlayState) playState);
        }

        public void Play()
        {
            if (Player.playState != WMPPlayState.wmppsReady)
            {
                throw new SoundNotReadyException(Resources.Sound_Not_Ready_Exception);
            }
            Player.controls.play();
        }

        public void Pause()
        {
            if (Player.playState == WMPPlayState.wmppsPlaying)
            {
                Player.controls.pause();
            }
        }

        public void Stop()
        {
            if ((Player.playState == WMPPlayState.wmppsPaused) || (Player.playState == WMPPlayState.wmppsPlaying))
            {
                Player.controls.stop();
            }
        }
    }
}