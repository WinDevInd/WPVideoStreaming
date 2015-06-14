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
using Windows.Storage.Pickers;
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
    public sealed partial class DocumentViewerPage : BasePage
    {
        Task<bool> loadAsync;
        StorageFile currentFile;
        public DocumentViewerPage()
        {
            this.InitializeComponent();
            this.Unloaded += DocumentViewerPage_Unloaded;
            this.Loaded += DocumentViewerPage_Loaded;

        }

        /// <summary>
        /// Invoke when current view gets loaded
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e"></param>
        async void DocumentViewerPage_Loaded(object sender, RoutedEventArgs e)
        {
            BusyInidicator.Visibility = Visibility.Visible;
            var docFile = await this.PickFromStorage();
            currentFile = docFile;
            await ViewDocument(docFile);
        }

        /// <summary>
        /// unloading of current view
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e"></param>
        private async void DocumentViewerPage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (loadAsync != null && !loadAsync.IsCompleted && !loadAsync.IsFaulted)
            {
                await loadAsync;
            }
            try
            {
                this.RichTextBoxDocViewer.Dispose();
                this.RichTextBoxDocViewer = null;
            }
            catch
            {

            }
            finally
            {
                this.Unloaded -= DocumentViewerPage_Unloaded;
            }

        }

        /// <summary>
        /// Get the documet file from Docs folder and render it in rich textbox
        /// </summary>
        /// <returns></returns>
        private async Task ViewDocument(StorageFile docFile)
        {
            try
            {
                if (docFile != null)
                {
                    loadAsync = this.RichTextBoxDocViewer.LoadAsync(docFile, new System.Threading.CancellationToken());
                    await loadAsync;
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error in loading content " + e.Message);
            }
            finally
            {
                BusyInidicator.Visibility = Visibility.Collapsed;
            }
        }

        private async Task<StorageFile> PickFromStorage()
        {
            StorageFile docFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
                    new Uri("ms-appx:///Docs/resume.docx", UriKind.RelativeOrAbsolute));
            return docFile;
        }

        private async Task<StorageFile> PickFromDevice()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".doc");
            filePicker.FileTypeFilter.Add(".docx");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.SettingsIdentifier = "Wooqer DocViewer";
            filePicker.CommitButtonText = "Open";
            return await filePicker.PickSingleFileAsync();
        }

        private async void FileOpen_Clicked(object sender, RoutedEventArgs e)
        {
            var docFile = await PickFromDevice();
            ViewDocument(docFile);
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
