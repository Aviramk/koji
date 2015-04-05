using System;
using System.Media;
using Koji;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class SoundClassTests
    {
        Sound sound = new Sound();
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNonExistantPath()
        {
            sound.FilePath = "C:\\temp\\doesntexistsforreallol.txt";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongExtension()
        {
            sound.FilePath = "C:\\Users\\Public\\Pictures\\Sample Pictures\\Chrysanthemum.jpg";
        }

        [TestMethod]
        public void TestMP3Path()
        {
            sound.FilePath = "C:\\Users\\Public\\Music\\Sample Music\\Sleep Away.mp3";
            Assert.AreEqual(sound.FilePath, "C:\\Users\\Public\\Music\\Sample Music\\Sleep Away.mp3");
            Assert.AreEqual(sound.FileType, ".mp3");
        }

        [TestMethod]
        public void TestWAVPath()
        {
            sound.FilePath = "C:\\Program Files (x86)\\Microsoft SDKs\\Windows Phone\\v8.1\\Sounds\\DoneListeningEarcon.wav";
            Assert.AreEqual(sound.FilePath, "C:\\Program Files (x86)\\Microsoft SDKs\\Windows Phone\\v8.1\\Sounds\\DoneListeningEarcon.wav");
            Assert.AreEqual(sound.FileType, ".wav");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTooHighVolume()
        {
            sound.Volume = 3000;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTooLowVolume()
        {
            sound.Volume = -1;
        }

        [TestMethod]
        public void TestRegularVolume()
        {
            sound.Volume = 5;
            Assert.AreEqual(sound.Volume, 5);
        }

        [TestMethod]
        public void TestSoundInitializeWithFileName()
        {
            sound = new Sound("C:\\Users\\Public\\Music\\Sample Music\\Sleep Away.mp3");
        }
    }
}
