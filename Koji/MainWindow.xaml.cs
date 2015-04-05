using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;



namespace Koji
{
    /// <summary>
    /// Constants that will be used across the namespace.
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// Sound related constants.
        /// </summary>
        public const string SOUND_EXT_FILTER = "Sound files |*.wav;*.mp3";

        public static readonly string[] VALID_EXT_TYPE =
        {
            ".mp3",
            ".wav",
        };

}
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Enables user adding of new sound to Koji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog   = new OpenFileDialog();

            openFileDialog.Filter           = Constants.SOUND_EXT_FILTER;
            openFileDialog.RestoreDirectory = true;

            Nullable<bool> dialogSuccess = openFileDialog.ShowDialog();

            if (null == dialogSuccess)
            {
                throw new ArgumentNullException("Dialog returned null");
            }

            if (false == dialogSuccess)
            {
                return;
            }

        }
    }
}
