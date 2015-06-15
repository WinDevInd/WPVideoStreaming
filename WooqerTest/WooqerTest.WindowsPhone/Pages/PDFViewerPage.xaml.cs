using PhoneExclusives.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WooqerTest.Shared;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WooqerTest.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PDFViewerPage : BasePage
    {
        CoreApplicationView view;
        StorageFile currentFile;
        public PDFViewerPage()
        {
            this.InitializeComponent();
            this.Loaded += PDFViewerPage_Loaded;
            this.Unloaded += PDFViewerPage_Unloaded;
            view = CoreApplication.GetCurrentView();

        }

        void PDFViewerPage_Unloaded(object sender, RoutedEventArgs e)
        {
            this.PDFView = null;
        }


        async void view_Activated(CoreApplicationView sender, Windows.ApplicationModel.Activation.IActivatedEventArgs args)
        {
            FileOpenPickerContinuationEventArgs fileOpenArgs = args as FileOpenPickerContinuationEventArgs;

            if (fileOpenArgs != null)
            {
                if (fileOpenArgs.Files.Count == 0) return;

                BusyInidicator.Visibility = Visibility.Visible;
                view.Activated -= view_Activated;
                var docFile = fileOpenArgs.Files[0];
                currentFile = docFile;
                await this.LoadPdf(docFile);

            }
        }

        async void PDFViewerPage_Loaded(object sender, RoutedEventArgs e)
        {
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
                PDFView.LoadDocument(stream);

            }
            catch (Exception e)
            {

            }
            finally
            {
                //BusyInidicator.Visibility = Visibility.Collapsed;
            }

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private async void FileOpen_Clicked(object sender, RoutedEventArgs e)
        {
            BusyInidicator.Visibility = Visibility.Visible;
            PickerUtil.PickFileFromPhone(new string[] { ".pdf" });
        }

        private async void LauchExternal(object sender, RoutedEventArgs e)
        {
            if (currentFile != null && !string.IsNullOrWhiteSpace(currentFile.Path))
            {
                await Windows.System.Launcher.LaunchFileAsync(currentFile);
            }
        }
    }
}
