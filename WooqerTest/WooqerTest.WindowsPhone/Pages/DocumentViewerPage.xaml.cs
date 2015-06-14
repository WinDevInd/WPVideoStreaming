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
        CoreApplicationView view;
        public DocumentViewerPage()
        {
            this.InitializeComponent();
            view = CoreApplication.GetCurrentView();

        }

        async void view_Activated(CoreApplicationView sender, Windows.ApplicationModel.Activation.IActivatedEventArgs args)
        {
            FileOpenPickerContinuationEventArgs fileOpenArgs = args as FileOpenPickerContinuationEventArgs;

            if (fileOpenArgs != null)
            {
                if (fileOpenArgs.Files.Count == 0) return;


                view.Activated -= view_Activated;
                var docFile = fileOpenArgs.Files[0];
                await this.ViewDocument(docFile);

            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Task.Run(async () =>
            {
                var docFile = await this.PickFromStorage();
                ViewDocument(docFile);
            });
        }

        /// <summary>
        /// Get the documet file from Docs folder and render it in rich textbox
        /// </summary>
        /// <returns></returns>
        private async Task ViewDocument(StorageFile docFile)
        {
            try
            {
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    if (docFile != null)
                    {
                        this.RichTextBoxDocViewer.LoadAsync(docFile);
                    }
                });
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error in loading content " + e.Message);
            }
        }

        private async Task<StorageFile> PickFromStorage()
        {
            StorageFile docFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
                    new Uri("ms-appx:///Docs/resume.docx", UriKind.RelativeOrAbsolute));
            return docFile;
        }

        private void PickFromPhone()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".doc");
            filePicker.FileTypeFilter.Add(".docx");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.SettingsIdentifier = "Wooqer DocViewer";
            filePicker.CommitButtonText = "Open";
            view.Activated += view_Activated;
            filePicker.PickSingleFileAndContinue();
        }

        private void FileOpen_Clicked(object sender, RoutedEventArgs e)
        {
            PickFromPhone();
        }
    }
}
