using PhoneExclusives.Common;
using PortableEssentials.Utils;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WooqerTest.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PDFViewer : Page
    {
        private Task<bool> loadAsync;
        private StorageFile currentFile;
        public PDFViewer()
        {
            this.InitializeComponent();
            this.Loaded += PDFViewer_Loaded;
            this.Unloaded += PDFViewer_Unloaded;
        }

        async void PDFViewer_Unloaded(object sender, RoutedEventArgs e)
        {
            if (loadAsync != null && !loadAsync.IsCompleted && !loadAsync.IsFaulted)
            {
                await loadAsync;
            }
            this.PDFView.Unload();
            this.PDFView = null;
        }

        async void PDFViewer_Loaded(object sender, RoutedEventArgs e)
        {
            BusyInidicator.Visibility = Visibility.Visible;
            var docFile = await SharedLibrary.Essentials.Instance.StorageManager.GetFileFromApplicationFolder("Docs/resume.pdf");
            LoadPdf(docFile as StorageFile);
        }

        private async Task LoadPdf(StorageFile docFile)
        {
            try
            {
                var file = await docFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                currentFile = docFile;
                var stream = file.AsStreamForRead();

                PdfLoadedDocument ldoc = new PdfLoadedDocument(stream);
                loadAsync = PDFView.LoadDocumentAsync(ldoc);
                await loadAsync;
            }
            catch (Exception e)
            {

            }
            finally
            {
                BusyInidicator.Visibility = Visibility.Collapsed;
            }
        }


        private async void FileOpen_Clicked(object sender, RoutedEventArgs e)
        {
            BusyInidicator.Visibility = Visibility.Visible;
            var docFile = await PickerUtil.PickFileFromDevice(new string[] { ".pdf" });
            LoadPdf(docFile);
        }

        private async void LauchExternal(object sender, RoutedEventArgs e)
        {
            if (currentFile != null && !string.IsNullOrWhiteSpace(currentFile.Path))
            {
                await Windows.System.Launcher.LaunchFileAsync(currentFile);
            }
        }

        private void BackTapped(object sender, TappedRoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }
    }
}
