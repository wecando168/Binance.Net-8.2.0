using System.ComponentModel;

namespace BinanceNetCoreDemo.WpfMVVM
{
    /// <summary>
    /// 可以被监控的对象
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
