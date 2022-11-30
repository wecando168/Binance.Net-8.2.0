using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Binance.Net.Objects.Models.Spot;
using Binance.Net.Objects.Models.Spot.Socket;
using BinanceNetCoreDemo.WinFormSortableBindingList;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Sockets;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace BinanceNetCoreDemo
{
    public partial class Form_Demo : Form
    {
        //访问密钥(多客户，需要一个列表？）
        private string apiKey = string.Empty;

        //执行密钥(多客户，需要一个列表？）
        private string apiSecret = string.Empty;

        //币安客户端的设置项(公有跟私有不需要区分，每次启动的时候根据账户重新加载凭证信息即可）
        private BinanceClientOptions binanceClientOptions = new BinanceClientOptions();

        //币安公有WebSocket客户端(这个应该是一个长期保持连接状态的客户端用于获取交易所公共部分的数据）
        private BinanceSocketClient binancePublicSocketClient = new BinanceSocketClient();

        //币安私有WebSocket客户端(多客户，需要一个列表？）
        private BinanceSocketClient binancePrivateSocketClient = new BinanceSocketClient();

        //api访问证书(多客户，需要一个列表？）
        private ApiCredentials? apiCredentials;

        //集合：存放所有交易代码的集合
        private SortableBindingList<OnlineInfo_Binance_Symbol> symbolList = new SortableBindingList<OnlineInfo_Binance_Symbol>();

        //集合：存放所有交易代码订单的集合
        private SortableBindingList<OnlineInfo_Binance_Order> selectedSymbolOrderList = new SortableBindingList<OnlineInfo_Binance_Order>();

        //集合：存放账户资产的集合
        private SortableBindingList<OnlineInfo_Binance_Asset> assetList = new SortableBindingList<OnlineInfo_Binance_Asset>();

        private object orderLock = new object();

        /// <summary>
        /// 当前选择的交易代码
        /// </summary>
        private OnlineInfo_Binance_Symbol selectedSymbol = new OnlineInfo_Binance_Symbol();

        /// <summary>
        /// 读取或者设置当前选择的交易代码
        /// </summary>
        public OnlineInfo_Binance_Symbol SelectedSymbol
        {
            get { return selectedSymbol; }
            set
            {
                selectedSymbol = value;
                ChangeSymbol();
            }
        }

        /// <summary>
        /// 改变选择的交易代码
        /// </summary>
        private void ChangeSymbol()
        {
            if (selectedSymbol != null)
            {
                selectedSymbol.TradeAmount = 0;
                selectedSymbol.TradePrice = selectedSymbol.Price;
                Task.Run(async () => await Task.WhenAll(GetOrders(), Get24HourStats()));                
                showSelectedSymbolInfo();
            }
        }

        /// <summary>
        /// 获取选择交易代码的24小时成交状况（最高价、最低价、成交量等...）
        /// </summary>
        /// <returns></returns>
        private async Task Get24HourStats()
        {
            using (var client = new BinanceClient())
            {
                var result = await client.SpotApi.ExchangeData.GetTickerAsync(object.Equals(SelectedSymbol, null) ? "" : (string)SelectedSymbol.Symbol);
                if (result.Success)
                {
                    SelectedSymbol = new OnlineInfo_Binance_Symbol();
                    SelectedSymbol.PriceChangePercent = result.Data.PriceChangePercent;
                    SelectedSymbol.HighPrice = result.Data.HighPrice;
                    SelectedSymbol.LowPrice = result.Data.LowPrice;
                    SelectedSymbol.Volume = result.Data.Volume;
                    SelectedSymbol.TradePrice = result.Data.BestAskPrice;
                    SelectedSymbol.TradeAmount = 0;
                }
                else
                    MessageBox.Show($"Error requesting data: {(object.Equals(result.Error, null) ? "other error" : result.Error.Message)}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 显示所选择交易代码最新的交易信息
        /// </summary>
        private void showSelectedSymbolInfo()
        {
            if (SelectedSymbol != null)
            {
                this.Invoke(new EventHandler(delegate
                {
                    label_Symbol.Text = SelectedSymbol.Symbol;
                    label_change_in_24_hour.Text = SelectedSymbol.PriceChangePercent.ToString()+ "%";
                    label_highest_price.Text = SelectedSymbol.HighPrice.ToString();
                    label_lowest_price.Text = SelectedSymbol.LowPrice.ToString();
                    label_volume.Text = SelectedSymbol.Volume.ToString();
                    textBox_price.Text = SelectedSymbol.Price.ToString();
                    textBox_amount.Text = String.Format("{0:N8}", 0);
                }));
            }
        }

        private void showSelectedSymbolInfo_DataSetDemo()
        {
            // 新建数据源
            DataSet dataSetSelectedSymbol = new DataSet("myDataSet");

            // 数据表初始化
            DataTable table_SelectedSymbol = new DataTable("SelectedSymbol");

            // 新建数据表栏
            DataColumn columnSymbol = new DataColumn("Symbol", typeof(string));
            DataColumn columnPrice = new DataColumn("Price", typeof(decimal));
            DataColumn columnPriceChangePercent = new DataColumn("PriceChangePercent", typeof(decimal));
            DataColumn columnHighPrice = new DataColumn("HighPrice", typeof(decimal));
            DataColumn columnLowPrice = new DataColumn("LowPrice", typeof(decimal));
            DataColumn columnVolume = new DataColumn("Volume", typeof(decimal));
            DataColumn columnTradeAmount = new DataColumn("TradeAmount", typeof(decimal));
            DataColumn columnTradePrice = new DataColumn("TradePrice", typeof(decimal));

            // 数据表栏添加到数据表
            table_SelectedSymbol.Columns.Add(columnSymbol);
            table_SelectedSymbol.Columns.Add(columnPrice);
            table_SelectedSymbol.Columns.Add(columnPriceChangePercent);
            table_SelectedSymbol.Columns.Add(columnHighPrice);
            table_SelectedSymbol.Columns.Add(columnLowPrice);
            table_SelectedSymbol.Columns.Add(columnVolume);
            table_SelectedSymbol.Columns.Add(columnTradeAmount);
            table_SelectedSymbol.Columns.Add(columnTradePrice);

            // 数据表添加到数据源
            dataSetSelectedSymbol.Tables.Add(table_SelectedSymbol);

            // 新建数据表行
            DataRow dataRow = table_SelectedSymbol.NewRow();

            // 数据表行内容赋值并添加到数据表
            if (SelectedSymbol != null)
            {
                dataRow["Symbol"] = SelectedSymbol.Symbol;
                dataRow["Price"] = SelectedSymbol.Price;
                dataRow["PriceChangePercent"] = SelectedSymbol.PriceChangePercent;
                dataRow["HighPrice"] = SelectedSymbol.HighPrice;
                dataRow["LowPrice"] = SelectedSymbol.LowPrice;
                dataRow["Volume"] = SelectedSymbol.Volume;
                dataRow["TradeAmount"] = SelectedSymbol.TradeAmount;
                dataRow["TradePrice"] = SelectedSymbol.TradePrice;
                table_SelectedSymbol.Rows.Add(dataRow);
            }

            // 数据源绑定到控件
            label_Symbol.DataBindings.Add(new Binding("Text", dataSetSelectedSymbol, "SelectedSymbol.Symbol"));
            label_price.DataBindings.Add(new Binding("Text", dataSetSelectedSymbol, "SelectedSymbol.Price"));
            label_change_in_24_hour.DataBindings.Add(new Binding("Text", dataSetSelectedSymbol, "SelectedSymbol.PriceChangePercent"));
            label_highest_price.DataBindings.Add(new Binding("Text", dataSetSelectedSymbol, "SelectedSymbol.HighPrice"));
            label_lowest_price.DataBindings.Add(new Binding("Text", dataSetSelectedSymbol, "SelectedSymbol.Volume"));
            label_volume.DataBindings.Add(new Binding("Text", dataSetSelectedSymbol, "SelectedSymbol.Volume"));
            textBox_price.DataBindings.Add(new Binding("Text", dataSetSelectedSymbol, "SelectedSymbol.TradePrice"));
            textBox_amount.DataBindings.Add(new Binding("Text", dataSetSelectedSymbol, "SelectedSymbol.TradeAmount"));
        }

        ////提示输入证书的消息对话框
        //private bool _shownCredentailsMessage = false;

        ////打开设置窗口
        //private bool settingsOpen = true;

        ////选择的交易代码（买入，卖出，取消操作使用）
        //private BinanceSymbolViewModel selectedSymbol;

        ////买入操作命令
        //public ICommand BuyCommand { get; set; }

        ////卖出操作命令
        //public ICommand SellCommand { get; set; }

        ////取消操作命令
        //public ICommand CancelCommand { get; set; }


        public Form_Demo()
        {
            InitializeComponent();
        }

        private void Form_Demo_Load(object sender, EventArgs e)
        {
            setApiCredentials();

            richTextBox_log.AppendText(showApiCredentials());

            // Should be done with DI
            //messageBoxService = new MessageBoxService();
            //orderLock = new object();

            //BuyCommand = new DelegateCommand(async (o) => await Buy(o));
            //SellCommand = new DelegateCommand(async (o) => await Sell(o));
            //CancelCommand = new DelegateCommand(async (o) => await Cancel(o));

            //执行获取所有交易代码及行情价格
            Task.Run(() => GetSymbolList());
            //执行获取所选择的交易代码当前用户的历史交易记录
            Task.Run(() => GetOrders());
            //执行订阅用户数据流（使得资产、交易等发生变动的时候会推送消息到客户端）
            Task.Run(() => SubscribeUserStream());
        }

        private void buttonSetApiCredentials_Click(object sender, EventArgs e)
        {
            setApiCredentials();

            richTextBox_log.AppendText(showApiCredentials());
        }

        //初始化访问密钥、执行密钥、api证书、币安客户端默认证书
        private void setApiCredentials()
        {

            if (string.IsNullOrWhiteSpace(textBox_api_key.Text) || string.IsNullOrWhiteSpace(textBox_api_secret.Text))
            {
                richTextBox_log.Clear();
                richTextBox_log.AppendText($"To retrieve and manage orders enter your API credentials via the settings on the top right");
                return;
            }
            apiKey = textBox_api_key.Text.ToString().Trim();
            apiSecret = textBox_api_secret.Text.ToString().Trim();
            apiCredentials = new ApiCredentials(apiKey, apiSecret);
            ////对于访问公有数据的Client是不需要提供apiCredentials，访问私有数据的时候再做设置
            //binanceClientOptions.ApiCredentials = apiCredentials;
            //if (!string.IsNullOrWhiteSpace(apiKey) && !string.IsNullOrWhiteSpace(apiSecret))
            //{
            //    BinanceClient.SetDefaultOptions(binanceClientOptions);
            //}
        }

        //返回访问密钥、执行密钥、api证书、币安客户端默认设置
        private string showApiCredentials()
        {
            string strCredentialsInfo = 
                $"apiKey\r\n{apiKey}\r\n" +
                $"apiSecret\r\n{apiSecret}\r\n" +
                $"apiCredentials\r\n{apiCredentials}\r\n" +
                $"Binance Client DefaultOptions\r\n{binanceClientOptions.ToString().Trim().Replace(", ", "\r\n")}\r\n";
            return strCredentialsInfo;
        }

        /// <summary>
        /// 获取所有交易代码（启动执行一次）
        /// </summary>
        /// <returns></returns>
        private async Task GetSymbolList()
        {
            //获取当前行情是否已经成功
            bool bGetPricesAsyncSuccess = false;
            string strErrorInfo = string.Empty;

            DataGridView decDataGridView = dataGridView_Symbol;
            //先获取所有现货交易所有交易代码的当前市场价格，存入基础数据中
            using (var client = new BinanceClient())
            {
                var result = await client.SpotApi.ExchangeData.GetPricesAsync();
                if (result.Success)
                {
                    bGetPricesAsyncSuccess = true;
                    await Task.Factory.StartNew(() =>
                    {
                        symbolList = new SortableBindingList<OnlineInfo_Binance_Symbol>(result.Data.Select(r => new OnlineInfo_Binance_Symbol(r.Symbol, r.Price)).ToList());
                    });                    
                }
                else
                {
                    bGetPricesAsyncSuccess = false;
                    richTextBox_log.Clear();
                    strErrorInfo = (object.Equals(result.Error, null) ? "未知异常" : result.Error.Message);
                }
            }

            if (bGetPricesAsyncSuccess)
            {
                //绑定行情数据到DGV
                this.Invoke(new EventHandler(delegate
                {
                    decDataGridView.DataSource = symbolList;
                    if (decDataGridView.FirstDisplayedScrollingRowIndex >= 0)
                    {
                        decDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    }
                }));
            }
            else
            {
                //输出异常信息到RTB
                this.Invoke(new EventHandler(delegate
                {
                    richTextBox_log.Clear();
                    richTextBox_log.AppendText($"Error requesting data: { (string.IsNullOrWhiteSpace(strErrorInfo) ? "未知异常" : strErrorInfo)}");
                }));                
            }

            //在前面的基础上再进行订阅
            binancePublicSocketClient = new BinanceSocketClient();
            var subscribeResult = await binancePublicSocketClient.SpotStreams.SubscribeToAllTickerUpdatesAsync(data =>
            {
                foreach (var ud in data.Data)
                {
                    var symbol = symbolList.SingleOrDefault(p => p.Symbol == ud.Symbol);
                    if (symbol != null)
                    {
                        symbol.Price = ud.LastPrice;
                        symbol.HighPrice = ud.HighPrice;
                        symbol.LowPrice = ud.LowPrice;
                        symbol.Volume = ud.Volume;
                        symbol.PriceChangePercent = ud.PriceChangePercent;
                        symbol.TradeAmount = ud.TotalTrades;
                        symbol.TradePrice = ud.WeightedAveragePrice;
                    }
                }
                //刷新界面中的DGV表格显示的数据
                this.Invoke(new EventHandler(delegate
                {
                    if (!decDataGridView.IsDisposed)
                    {
                        decDataGridView.Refresh();
                    }
                    else
                    {
                        return;
                    }                        
                }));
            });

            //订阅失败返回提示
            if (!subscribeResult.Success)
            {
                this.Invoke(new EventHandler(delegate
                {
                    richTextBox_log.Clear();
                    richTextBox_log.AppendText($"Failed to subscribe to price updates: {subscribeResult.Error}");
                }));                
            }
        }

        /// <summary>
        /// 获取或者设置访问密钥
        /// </summary>
        public string ApiKey
        {
            get { return apiKey; }
            set
            {
                apiKey = value;
            }
        }

        /// <summary>
        /// 获取或者设置执行密钥
        /// </summary>
        public string ApiSecret
        {
            get { return apiSecret; }
            set
            {
                apiSecret = value;
            }
        }


        /// <summary>
        /// 获取选择交易代码的订单
        /// </summary>
        /// <returns></returns>
        private async Task GetOrders()
        {
            if (object.Equals(SelectedSymbol, null) || string.IsNullOrWhiteSpace(SelectedSymbol.Symbol))
                return;

            if (string.IsNullOrWhiteSpace(textBox_api_key.Text) || string.IsNullOrWhiteSpace(textBox_api_secret.Text))
            {
                richTextBox_log.Clear();
                richTextBox_log.AppendText($"To retrieve and manage orders enter your API credentials via the settings on the top right");
                return;
            }

            DataGridView decDataGridView = dataGridView_exchangeHistory;
            bool bGetOrdersAsyncSuccess = false;
            string strErrorInfo = string.Empty;

            // 生成新的凭证，使用带有凭证的客户端访问获取私人交易数据
            using (var apiCredentials = new ApiCredentials(apiKey, apiSecret))
            {
                binanceClientOptions.ApiCredentials = apiCredentials;
                if (!string.IsNullOrWhiteSpace(apiKey) && !string.IsNullOrWhiteSpace(apiSecret))
                {
                    BinanceClient.SetDefaultOptions(binanceClientOptions);
                }

                using (var binanceClient = new BinanceClient())
                {
                    var result = await binanceClient.SpotApi.Trading.GetOrdersAsync(SelectedSymbol.Symbol);
                    if (result.Success)
                    {
                        bGetOrdersAsyncSuccess = true;
                        SortableBindingList<OnlineInfo_Binance_Order> temp = new SortableBindingList<OnlineInfo_Binance_Order>();
                        foreach (BinanceOrder? item in result.Data)
                        {
                            OnlineInfo_Binance_Order onlineInfo_Binance_Order = new OnlineInfo_Binance_Order();
                            onlineInfo_Binance_Order.Id = item.Id;
                            onlineInfo_Binance_Order.Symbol = item.Symbol;
                            onlineInfo_Binance_Order.Price = item.Price;
                            onlineInfo_Binance_Order.OriginalQuantity = item.Quantity;
                            onlineInfo_Binance_Order.ExecutedQuantity = item.QuantityFilled;
                            onlineInfo_Binance_Order.OrderStatus = item.Status;
                            onlineInfo_Binance_Order.OrderSide = item.Side;
                            onlineInfo_Binance_Order.SpotOrderType = item.Type;
                            onlineInfo_Binance_Order.Time = item.CreateTime;
                            temp.Add(onlineInfo_Binance_Order);
                        }
                        selectedSymbolOrderList = new SortableBindingList<OnlineInfo_Binance_Order>(temp);
                    }
                    else
                    {
                        strErrorInfo = (object.Equals(result.Error, null) ? "未知异常" : result.Error.Message);
                    }
                }
            }            

            if (bGetOrdersAsyncSuccess)
            {
                //绑定行情数据到DGV
                this.Invoke(new EventHandler(delegate
                {
                    decDataGridView.DataSource = selectedSymbolOrderList;
                    if (decDataGridView.FirstDisplayedScrollingRowIndex >= 0)
                    {
                        decDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    }
                }));
            }
            else
            {
                //输出异常信息到RTB
                this.Invoke(new EventHandler(delegate
                {
                    richTextBox_log.Clear();
                    richTextBox_log.AppendText($"Error requesting data: {(string.IsNullOrWhiteSpace(strErrorInfo) ? "未知异常" : strErrorInfo)}");
                }));
            }
        }

        /// <summary>
        /// 订阅用户信息
        /// </summary>
        /// <returns></returns>
        private async Task SubscribeUserStream()
        {

            if (string.IsNullOrWhiteSpace(textBox_api_key.Text) || string.IsNullOrWhiteSpace(textBox_api_secret.Text))
            {
                richTextBox_log.Clear();
                richTextBox_log.AppendText($"To retrieve and manage orders enter your API credentials via the settings on the top right");
                return;
            }

            // 生成新的凭证，使用带有凭证的客户端访问获取私人交易数据
            using (var apiCredentials = new ApiCredentials(apiKey, apiSecret))
            {
                binanceClientOptions.ApiCredentials = apiCredentials;
                if (!string.IsNullOrWhiteSpace(apiKey) && !string.IsNullOrWhiteSpace(apiSecret))
                {
                    BinanceClient.SetDefaultOptions(binanceClientOptions);
                }

                using (var client = new BinanceClient())
                {
                    var startOkay = await client.SpotApi.Account.StartUserStreamAsync();
                    if (!startOkay.Success)
                    {
                        richTextBox_log.AppendText($"Error starting user stream:{(object.Equals(startOkay.Error, null) ? "未知异常" : startOkay.Error.Message)}");
                        return;
                    }

                    var subOkay = await binancePrivateSocketClient.SpotStreams.SubscribeToUserDataUpdatesAsync(startOkay.Data, OnOrderUpdate, null, OnAccountUpdate, null);
                    if (!subOkay.Success)
                    {
                        richTextBox_log.AppendText($"Error subscribing user stream:{(object.Equals(subOkay.Error, null) ? "未知异常" : subOkay.Error.Message)}");
                        return;
                    }

                    var accountResult = await client.SpotApi.Account.GetAccountInfoAsync();
                    if (accountResult.Success)
                    {
                        assetList = new SortableBindingList<OnlineInfo_Binance_Asset>();
                        foreach (var item in accountResult.Data.Balances)
                        {
                            OnlineInfo_Binance_Asset onlineInfo_Binance_Asset = new OnlineInfo_Binance_Asset();
                            if (item.Available != 0 || item.Locked != 0)
                            {
                                onlineInfo_Binance_Asset.Asset = item.Asset;
                                onlineInfo_Binance_Asset.Free = item.Available;
                                onlineInfo_Binance_Asset.Locked = item.Locked;
                            }
                            assetList.Add(onlineInfo_Binance_Asset);
                        }

                    }
                    else
                        richTextBox_log.AppendText($"Error requesting account info:{(object.Equals(accountResult.Error, null) ? "未知异常" : accountResult.Error.Message)}");
                }
            }
        }

        //当订单更新时候进行的相关处理
        private void OnOrderUpdate(DataEvent<BinanceStreamOrderUpdate> data)
        {
            var orderUpdate = data.Data;

            OnlineInfo_Binance_Symbol? symbol = null;
            foreach(OnlineInfo_Binance_Symbol item in symbolList)
            {
                if(item.Symbol == orderUpdate.Symbol)
                {
                    symbol = item;
                    break;
                }
            }
            if (object.Equals(symbol, null))
                return;

            lock (orderLock)
            {
                OnlineInfo_Binance_Order? order = null;
                foreach(OnlineInfo_Binance_Order item in selectedSymbolOrderList)
                {
                    if (item.Id == orderUpdate.Id)
                    {
                        order = item;
                        break;
                    }
                }
                if (object.Equals(order, null))
                {
                    if (orderUpdate.RejectReason != OrderRejectReason.None || orderUpdate.ExecutionType != ExecutionType.New)
                        // 订单被拒绝了，不需要出示
                        return;

                    this.Invoke(new EventHandler(delegate
                    {
                        selectedSymbolOrderList.Add(new OnlineInfo_Binance_Order()
                        {
                            ExecutedQuantity = orderUpdate.QuoteQuantityFilled,
                            Id = orderUpdate.Id,
                            OriginalQuantity = orderUpdate.Quantity,
                            Price = orderUpdate.Price,
                            OrderSide = orderUpdate.Side,
                            OrderStatus = orderUpdate.Status,
                            Symbol = orderUpdate.Symbol,
                            Time = orderUpdate.CreateTime,
                            SpotOrderType = orderUpdate.Type
                        });
                    }));

                }
                else
                {
                    order.ExecutedQuantity = orderUpdate.QuantityFilled;
                    order.OrderStatus = orderUpdate.Status;
                }
            }
        }

        //当账户更新的时候进行的相关操作
        private void OnAccountUpdate(DataEvent<BinanceStreamPositionsUpdate> data)
        {
            assetList = new SortableBindingList<OnlineInfo_Binance_Asset>();
            foreach(var item in data.Data.Balances)
            {
                OnlineInfo_Binance_Asset onlineInfo_Binance_Asset = new OnlineInfo_Binance_Asset();
                if (item.Available != 0 || item.Locked != 0)
                {
                    onlineInfo_Binance_Asset.Asset = item.Asset;
                    onlineInfo_Binance_Asset.Free = item.Available;
                    onlineInfo_Binance_Asset.Locked = item.Locked;
                }
                assetList.Add(onlineInfo_Binance_Asset);
            }
        }

        private void dataGridView_Symbol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //查询条件来源的DataGridView
            DataGridView? dataGridView = (DataGridView)sender;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();

            if (dataGridView != null && dataGridView.Rows.Count > e.RowIndex && e.RowIndex != -1)
            {
                dataGridViewRow = dataGridView.Rows[e.RowIndex];
                if (dataGridViewRow.Cells["Symbol"].Value != null)
                {
                    string strSymbol = (string)dataGridViewRow.Cells["Symbol"].Value;
                    foreach (OnlineInfo_Binance_Symbol onlineInfo_Binance_Symbol in symbolList)
                    {
                        if (onlineInfo_Binance_Symbol.Symbol == strSymbol)
                        {
                            SelectedSymbol = onlineInfo_Binance_Symbol;
                            break;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView srcDataGridView = dataGridView_Symbol;

            if (srcDataGridView != null && srcDataGridView.Rows.Count > 0)
            {
                string _strSymbol = textBox_search.Text.ToString().Trim();

                for (int i = 0; i < srcDataGridView.Rows.Count; i++)
                {
                    DataGridViewRow dataGridViewRow = srcDataGridView.Rows[i];
                    if (dataGridViewRow.Cells["Symbol"].Value != null)
                    {
                        string strCurrentCellValue = (string)dataGridViewRow.Cells["Symbol"].Value;
                        if (strCurrentCellValue.IndexOf(_strSymbol, StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            try
                            {
                                srcDataGridView.CurrentRow.Selected = false;
                            }
                            catch (Exception ex)
                            {
                                if (InvokeRequired)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        richTextBox_log.AppendText(ex.Message);
                                    }));
                                }
                                else
                                {
                                    richTextBox_log.AppendText(ex.Message);
                                }
                            }
                            dataGridViewRow.Selected = true;
                            srcDataGridView.FirstDisplayedScrollingRowIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        ///// <summary>
        ///// 买入操作
        ///// </summary>
        ///// <param name="o"></param>
        ///// <returns></returns>
        //public async Task Buy(object o)
        //{
        //    using (var client = new BinanceClient())
        //    {
        //        var result = await client.SpotApi.Trading.PlaceOrderAsync(SelectedSymbol.Symbol, OrderSide.Buy, SpotOrderType.Limit, SelectedSymbol.TradeAmount, price: SelectedSymbol.TradePrice, timeInForce: TimeInForce.GoodTillCanceled);
        //        if (result.Success)
        //            richTextBox_log.AppendText("Order placed!");
        //        else
        //            richTextBox_log.AppendText($"Order placing failed:{(object.Equals(result.Error, null) ? "未知异常" : result.Error.Message)}");
        //    }
        //}

        ///// <summary>
        ///// 卖出操作
        ///// </summary>
        ///// <param name="o"></param>
        ///// <returns></returns>
        //public async Task Sell(object o)
        //{
        //    using (var client = new BinanceClient())
        //    {
        //        var result = await client.SpotApi.Trading.PlaceOrderAsync(SelectedSymbol.Symbol, OrderSide.Sell, SpotOrderType.Limit, SelectedSymbol.TradeAmount, price: SelectedSymbol.TradePrice, timeInForce: TimeInForce.GoodTillCanceled);
        //        if (result.Success)
        //            richTextBox_log.AppendText("Order placed!");
        //        else
        //            richTextBox_log.AppendText($"Order placing failed:{(object.Equals(result.Error, null) ? "未知异常" : result.Error.Message)}");
        //    }
        //}

        ///// <summary>
        ///// 取消操作
        ///// </summary>
        ///// <param name="o"></param>
        ///// <returns></returns>
        //public async Task Cancel(object o)
        //{
        //    var order = (OrderViewModel)o;
        //    using (var client = new BinanceClient())
        //    {
        //        var result = await client.SpotApi.Trading.CancelOrderAsync(SelectedSymbol.Symbol, order.Id);
        //        if (result.Success)
        //            richTextBox_log.AppendText("Order canceled!");
        //        else
        //            richTextBox_log.AppendText($"Order canceling failed:{(object.Equals(result.Error, null) ? "未知异常" : result.Error.Message)}");
        //    }
        //}
    }
}