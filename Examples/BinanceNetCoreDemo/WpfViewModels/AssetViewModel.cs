using BinanceNetCoreDemo.WpfMVVM;

//账户资产视图
namespace BinanceNetCoreDemo.WpfViewModels
{
    public class AssetViewModel : ObservableObject
    {
        private string? asset;
        public string? Asset
        {
            get { return asset; }
            set
            {
                asset = value;
                RaisePropertyChangedEvent("Asset");
            }
        }

        private decimal free;
        public decimal Free
        {
            get { return free; }
            set
            {
                free = value;
                RaisePropertyChangedEvent("Free");
            }
        }

        private decimal locked;
        public decimal Locked
        {
            get { return locked; }
            set
            {
                locked = value;
                RaisePropertyChangedEvent("Locked");
            }
        }
    }
}
