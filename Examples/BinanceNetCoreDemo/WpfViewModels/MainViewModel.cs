using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Binance.Net.Objects.Models.Spot.Socket;
using BinanceNetCoreDemo.WpfMVVM;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Sockets;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BinanceNetCoreDemo.WpfViewModels
{
    public class MainViewModel : ObservableObject
    {
        /// <summary>
        /// 访问密钥
        /// </summary>
        private string? apiKey;

        /// <summary>
        /// 执行密钥
        /// </summary>
        private string? apiSecret;

        /// <summary>
        /// 数据集合：所有交易代码的价格信息
        /// </summary>
        private ObservableCollection<BinanceSymbolViewModel>? allPrices;
        
        /// <summary>
        /// 当前选择的交易代码
        /// </summary>
        private BinanceSymbolViewModel? selectedSymbol;

        /// <summary>
        /// 账户资产
        /// </summary>
        private ObservableCollection<AssetViewModel>? assets;

        /// <summary>
        /// 读取或设置访问密钥
        /// </summary>
        public string? ApiKey
        {
            get { return apiKey; }
            set
            {
                apiKey = value;
                RaisePropertyChangedEvent("ApiKey");
                RaisePropertyChangedEvent("CredentialsEntered");
            }
        }

        /// <summary>
        /// 读取或设置执行密钥
        /// </summary>
        public string? ApiSecret
        {
            get { return apiSecret; }
            set
            {
                apiSecret = value;
                RaisePropertyChangedEvent("ApiSecret");
                RaisePropertyChangedEvent("CredentialsEntered");
            }
        }

        /// <summary>
        /// 读取或设置所有交易代码的价格
        /// </summary>
        public ObservableCollection<BinanceSymbolViewModel>? AllPrices
        {
            get { return allPrices; }
            set
            {
                allPrices = value;
                RaisePropertyChangedEvent("AllPrices");
            }
        }
        
        /// <summary>
        /// 读取或者设置当前选择的交易代码
        /// </summary>
        public BinanceSymbolViewModel? SelectedSymbol
        {
            get { return selectedSymbol; }
            set
            {
                selectedSymbol = value;
                RaisePropertyChangedEvent("SymbolIsSelected");
                RaisePropertyChangedEvent("SelectedSymbol");
                ChangeSymbol();
            }
        }

        /// <summary>
        /// 读取或者设置账户资产
        /// </summary>
        public ObservableCollection<AssetViewModel>? Assets
        {
            get { return assets; }
            set
            {
                assets = value;
                RaisePropertyChangedEvent("Assets");
            }
        }

        private bool _shownCredentailsMessage = false;

        private bool settingsOpen = true;
        public bool SettingsOpen
        {
            get { return settingsOpen; }
            set
            {
                settingsOpen = value;
                RaisePropertyChangedEvent("SettingsOpen");
            }
        }

        public bool SymbolIsSelected
        {
            get { return SelectedSymbol != null; }
        }

        public bool CredentialsEntered => !string.IsNullOrWhiteSpace(ApiKey);

        public ICommand BuyCommand { get; set; }
        public ICommand SellCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand CloseSettingsCommand { get; set; }

        private MessageBox? messageBoxService;
        private SettingsWindow? settings;
        private object orderLock;
        private BinanceSocketClient socketClient;

        public MainViewModel()
        {
            // Should be done with DI
            orderLock = new object();

            BuyCommand = new DelegateCommand(async (o) => await Buy(o));
            SellCommand = new DelegateCommand(async (o) => await Sell(o));
            CancelCommand = new DelegateCommand(async (o) => await Cancel(o));
            SettingsCommand = new DelegateCommand(Settings);
            CloseSettingsCommand = new DelegateCommand(async (o) => await CloseSettings(o));

            Task.Run(() => GetAllSymbols());
        }

        /// <summary>
        /// 执行取消订单操作
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public async Task Cancel(object o)
        {
            var order = (OrderViewModel)o;
            using (var client = new BinanceClient())
            {
                if (SelectedSymbol != null)
                {
                    var result = await client.SpotApi.Trading.CancelOrderAsync(SelectedSymbol.Symbol, order.Id);
                    if (result.Success)
                        MessageBox.Show("Order canceled!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Order canceling failed: {(object.Equals(result.Error, null) ? "other error" : result.Error.Message)}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 执行买入操作
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public async Task Buy(object o)
        {
            using (var client = new BinanceClient())
            {
                if (SelectedSymbol != null)
                {
                    var result = await client.SpotApi.Trading.PlaceOrderAsync(SelectedSymbol.Symbol, OrderSide.Buy, SpotOrderType.Limit, SelectedSymbol.TradeAmount, price: SelectedSymbol.TradePrice, timeInForce: TimeInForce.GoodTillCanceled);
                    if (result.Success)
                        MessageBox.Show("Order placed!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Order placing failed: {(object.Equals(result.Error, null) ? "other error" : result.Error.Message)}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 执行卖出操作
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public async Task Sell(object o)
        {
            using (var client = new BinanceClient())
            {
                if (SelectedSymbol != null)
                {
                    var result = await client.SpotApi.Trading.PlaceOrderAsync(SelectedSymbol.Symbol, OrderSide.Sell, SpotOrderType.Limit, SelectedSymbol.TradeAmount, price: SelectedSymbol.TradePrice, timeInForce: TimeInForce.GoodTillCanceled);
                    if (result.Success)
                        MessageBox.Show("Order placed!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Order placing failed: {(object.Equals(result.Error, null) ? "other error" : result.Error.Message)}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 执行打开消息对话框操作
        /// </summary>
        /// <param name="o"></param>
        private void Settings(object o)
        {
            settings = new SettingsWindow();
            settings.Show();
        }

        /// <summary>
        /// 执行关闭设置对话框操作
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private async Task CloseSettings(object o)
        {
            if(settings != null)
            {
                settings.Dispose();
            }            

            if (!string.IsNullOrWhiteSpace(apiKey) && !string.IsNullOrWhiteSpace(apiSecret))
                BinanceClient.SetDefaultOptions(new BinanceClientOptions() { ApiCredentials = new ApiCredentials(apiKey, apiSecret) });

            await GetOrders();
            await SubscribeUserStream();
        }

        /// <summary>
        /// 执行获取所有交易代码操作
        /// </summary>
        /// <returns></returns>
        private async Task GetAllSymbols()
        {
            using (var client = new BinanceClient())
            {
                var result = await client.SpotApi.ExchangeData.GetPricesAsync();
                if (result.Success)
                    AllPrices = new ObservableCollection<BinanceSymbolViewModel>(result.Data.Select(r => new BinanceSymbolViewModel(r.Symbol, r.Price)).ToList());
                else
                    MessageBox.Show($"Error requesting data: {(object.Equals(result.Error, null) ? "other error" : result.Error.Message)}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            socketClient = new BinanceSocketClient();
            var subscribeResult = await socketClient.SpotStreams.SubscribeToAllTickerUpdatesAsync(data =>
            {
                foreach (var ud in data.Data)
                {
                    var symbol = AllPrices.SingleOrDefault(p => p.Symbol == ud.Symbol);
                    if (symbol != null)
                        symbol.Price = ud.LastPrice;
                }
            });

            if (!subscribeResult.Success)
                MessageBox.Show($"Failed to subscribe to price updates: {(object.Equals(subscribeResult.Error, null) ? "other error" : subscribeResult.Error.Message)}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 执行获取24小时交易代码状态操作
        /// </summary>
        /// <returns></returns>
        private async Task Get24HourStats()
        {
            using (var client = new BinanceClient())
            {
                var result = await client.SpotApi.ExchangeData.GetTickerAsync(SelectedSymbol.Symbol);
                if (result.Success)
                {
                    SelectedSymbol.HighPrice = result.Data.HighPrice;
                    SelectedSymbol.LowPrice = result.Data.LowPrice;
                    SelectedSymbol.Volume = result.Data.Volume;
                    SelectedSymbol.PriceChangePercent = result.Data.PriceChangePercent;
                }
                else
                    MessageBox.Show($"Error requesting data: {(object.Equals(result.Error, null) ? "other error" : result.Error.Message)}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 执行获取订单操作
        /// </summary>
        /// <returns></returns>
        private async Task GetOrders()
        {
            if (object.Equals(SelectedSymbol, null))
                return;

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                if (!_shownCredentailsMessage)
                {
                    _shownCredentailsMessage = true;
                    MessageBox.Show($"To retrieve and manage orders enter your API credentials via the settings on the top right", "Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            using (var client = new BinanceClient())
            {
                var result = await client.SpotApi.Trading.GetOrdersAsync(SelectedSymbol.Symbol);
                if (result.Success)
                {
                    SelectedSymbol.Orders = new ObservableCollection<OrderViewModel>(result.Data.OrderByDescending(d => d.CreateTime).Select(o => new OrderViewModel()
                    {
                        Id = o.Id,
                        ExecutedQuantity = o.QuantityFilled,
                        OriginalQuantity = o.Quantity,
                        Price = o.Price,
                        Side = o.Side,
                        Status = o.Status,
                        Symbol = o.Symbol,
                        Time = o.CreateTime,
                        Type = o.Type
                    }));
                }
                else
                    MessageBox.Show($"Error requesting data: {(object.Equals(result.Error, null) ? "other error" : result.Error.Message)}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 订阅用户数据流
        /// </summary>
        /// <returns></returns>
        private async Task SubscribeUserStream()
        {
            if (string.IsNullOrWhiteSpace(ApiKey) || string.IsNullOrWhiteSpace(ApiSecret))
                return;

            using (var client = new BinanceClient())
            {
                var startOkay = await client.SpotApi.Account.StartUserStreamAsync();
                if (!startOkay.Success)
                {
                    MessageBox.Show($"Error starting user stream: {(object.Equals(startOkay.Error, null) ? "other error" : startOkay.Error.Message)}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var subOkay = await socketClient.SpotStreams.SubscribeToUserDataUpdatesAsync(startOkay.Data, OnOrderUpdate, null, OnAccountUpdate, null);
                if (!subOkay.Success)
                {
                    MessageBox.Show($"Error subscribing to user stream: {(object.Equals(subOkay.Error, null) ? "other error" : subOkay.Error.Message)}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var accountResult = await client.SpotApi.Account.GetAccountInfoAsync();
                if (accountResult.Success)
                    Assets = new ObservableCollection<AssetViewModel>(accountResult.Data.Balances.Where(b => b.Available != 0 || b.Locked != 0).Select(b => new AssetViewModel() { Asset = b.Asset, Free = b.Available, Locked = b.Locked }).ToList());
                else
                    MessageBox.Show($"Error requesting account info: {(object.Equals(accountResult.Error, null) ? "other error" : accountResult.Error.Message)}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 更换交易代码
        /// </summary>
        private void ChangeSymbol()
        {
            if (SelectedSymbol != null)
            {
                if(selectedSymbol != null)
                {
                    selectedSymbol.TradeAmount = 0;
                    selectedSymbol.TradePrice = selectedSymbol.Price;
                    Task.Run(async () => await Task.WhenAll(GetOrders(), Get24HourStats()));
                }

            }

        }

        /// <summary>
        /// 当账户信息发生变动，变更用户资产
        /// </summary>
        /// <param name="data"></param>
        private void OnAccountUpdate(DataEvent<BinanceStreamPositionsUpdate> data)
        {
            Assets = new ObservableCollection<AssetViewModel>(data.Data.Balances.Where(b => b.Available != 0 || b.Locked != 0).Select(b => new AssetViewModel() { Asset = b.Asset, Free = b.Available, Locked = b.Locked }).ToList());
        }

        /// <summary>
        /// 当订单状态发生变动
        /// </summary>
        /// <param name="data"></param>
        private void OnOrderUpdate(DataEvent<BinanceStreamOrderUpdate> data)
        {
            var orderUpdate = data.Data;

            var symbol = AllPrices.SingleOrDefault(a => a.Symbol == orderUpdate.Symbol);
            if (object.Equals(symbol, null))
                return;

            lock (orderLock)
            {
                var order = symbol.Orders.SingleOrDefault(o => o.Id == orderUpdate.Id);
                if (object.Equals(order, null))
                {
                    if (orderUpdate.RejectReason != OrderRejectReason.None || orderUpdate.ExecutionType != ExecutionType.New)
                    {
                        // Order got rejected, no need to show
                        return;
                    }
                    else
                    {
                        symbol.AddOrder(new OrderViewModel()
                        {
                            ExecutedQuantity = orderUpdate.QuoteQuantityFilled,
                            Id = orderUpdate.Id,
                            OriginalQuantity = orderUpdate.Quantity,
                            Price = orderUpdate.Price,
                            Side = orderUpdate.Side,
                            Status = orderUpdate.Status,
                            Symbol = orderUpdate.Symbol,
                            Time = orderUpdate.CreateTime,
                            Type = orderUpdate.Type
                        });
                    }
                }
                else
                {
                    order.ExecutedQuantity = orderUpdate.QuantityFilled;
                    order.Status = orderUpdate.Status;
                }
            }
        }
    }
}
