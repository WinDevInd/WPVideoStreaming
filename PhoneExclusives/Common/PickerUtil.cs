using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace PhoneExclusives.Common
{
    public class PickerUtil
    {
        public static void PickFileFromPhone(string[] filters)
        {
            var filePicker = new FileOpenPicker();
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    filePicker.FileTypeFilter.Add(filter);
                }
            }

            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            filePicker.SettingsIdentifier = "Wooqer DocViewer";
            filePicker.CommitButtonText = "Open";
            filePicker.PickSingleFileAndContinue();
        }
    }
}
