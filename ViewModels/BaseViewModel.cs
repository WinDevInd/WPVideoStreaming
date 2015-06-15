using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ViewModels.Utils;

namespace ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //public double Width
        //{
        //    get;
        //    set;
        //}

        //public double Height
        //{
        //    get;
        //    set;
        //}

        public BaseViewModel()
        {
            //Width = SharedLib.Essentials.Instance.DeviceInfoParams.GetWindowWidth();
            //Height = SharedLib.Essentials.Instance.DeviceInfoParams.GetWindowHeight();
            _ItemTapped_WithAction = new RelayCommand(OnItemTapped_NavigateUsingAction);
        }
        private object _BindableObject;

        public object BindableObject
        {
            get { return _BindableObject; }
            set
            {
                _BindableObject = value;
                OnPropertyChanged();
            }
        }

        private void OnItemTapped_NavigateUsingAction(object Parameter)
        {
            
        }
        private RelayCommand _ItemTapped_WithAction;

        public RelayCommand ItemTapped
        {
            get { return _ItemTapped_WithAction; }
            set { _ItemTapped_WithAction = value; }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public bool SetFieldAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
