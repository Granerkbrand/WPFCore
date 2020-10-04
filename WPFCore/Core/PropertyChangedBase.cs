using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFCore.Core
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyname = null)
        {
            if (Equals(storage, value))
                return false;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            return true;
        }
    }
}
