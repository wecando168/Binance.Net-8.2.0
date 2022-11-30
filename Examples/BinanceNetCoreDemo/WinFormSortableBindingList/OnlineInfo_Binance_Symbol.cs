using Binance.Net.Objects.Models.Spot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceNetCoreDemo.WinFormSortableBindingList
{
    /// <summary>
    /// 币安线上获取的交易代码类
    /// </summary>
    public class OnlineInfo_Binance_Symbol : IEditableObject, IComparable<OnlineInfo_Binance_Symbol>
    {
        /// <summary>
        /// 每个交易代码返回的数据
        /// </summary>
        struct OnlineInfo_Binance_SymbolData
        {
            internal string? symbol;
            internal decimal price;
            internal decimal priceChangePercent;
            internal decimal highPrice;
            internal decimal lowPrice;
            internal decimal volume;
            internal decimal tradeAmount;
            internal decimal tradePrice;
        }

        private SortableBindingList<OnlineInfo_Binance_Symbol>? parent;
        private OnlineInfo_Binance_SymbolData srcData;
        private OnlineInfo_Binance_SymbolData backupData;
        private bool inTxn = false;

        #region OnlineInfo_Binance_Symbol里面值的赋值与读取的相关方法
        public string Symbol
        {
            get { return srcData.symbol; }
            set
            {
                srcData.symbol = value;
            }
        }

        public decimal Price
        {
            get { return srcData.price; }
            set
            {
                srcData.price = value;
            }
        }

        public decimal PriceChangePercent
        {
            get { return srcData.priceChangePercent; }
            set
            {
                srcData.priceChangePercent = value;
            }
        }

        public decimal HighPrice
        {
            get { return srcData.highPrice; }
            set
            {
                srcData.highPrice = value;
            }
        }

        public decimal LowPrice
        {
            get { return srcData.lowPrice; }
            set
            {
                srcData.lowPrice = value;
            }
        }

        public decimal Volume
        {
            get { return srcData.volume; }
            set
            {
                srcData.volume = value;
            }
        }

        public decimal TradeAmount
        {
            get { return srcData.tradeAmount; }
            set
            {
                srcData.tradeAmount = value;
            }
        }

        public decimal TradePrice
        {
            get { return srcData.tradePrice; }
            set
            {
                srcData.tradePrice = value;
            }
        }

        #endregion

        #region 构造函数(无参构造、全参构造、列表构造、赋值构造)
        /// <summary>
        /// 无参构造：每个交易代码返回的数据字段的构造函数
        /// </summary>
        public OnlineInfo_Binance_Symbol() : base()
        {
            this.srcData = new OnlineInfo_Binance_SymbolData();
            this.srcData.symbol = string.Empty;
            this.srcData.price = 0;
            this.srcData.priceChangePercent = 0;
            this.srcData.highPrice = 0;
            this.srcData.lowPrice = 0;
            this.srcData.volume = 0;
            this.srcData.tradeAmount = 0;
            this.srcData.tradePrice = 0;
        }


        /// <summary>
        /// 全参构造：每个交易代码返回的数据字段的构造函数
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="price"></param>
        /// <param name="priceChangePercent"></param>
        /// <param name="highPrice"></param>
        /// <param name="lowPrice"></param>
        /// <param name="volume"></param>
        /// <param name="tradeAmount"></param>
        /// <param name="tradePrice"></param>
        /// <param name="orders"></param>
        public OnlineInfo_Binance_Symbol(
             string? symbol = null, decimal price = 0, decimal priceChangePercent = 0, decimal highPrice = 0, decimal lowPrice = 0,
        decimal volume = 0, decimal tradeAmount = 0, decimal tradePrice = 0) : base()
        {
            this.srcData = new OnlineInfo_Binance_SymbolData();
            this.srcData.symbol = symbol;
            this.srcData.price = price;
            this.srcData.priceChangePercent = priceChangePercent;
            this.srcData.highPrice = highPrice;
            this.srcData.lowPrice = lowPrice;
            this.srcData.volume = volume;
            this.srcData.tradeAmount = tradeAmount;
            this.srcData.tradePrice = tradePrice;
        }

        /// <summary>
        /// 列表构造：每个交易代码返回的数据字段的构造函数
        /// </summary>
        /// <param name="OnlineInfo_Binance_Symbol">每个交易代码返回的数据字段的List<string>结构信息</param>
        /// <param name="ignoreFirstColumn">如果是从DGV导入的List<string>结构通常首列是一个选择项，通过此参数忽略首行，保存正确的数据</param>
        /// <returns></returns>
        public OnlineInfo_Binance_Symbol(List<string> listOnlineInfo_Binance_Symbol, bool ignoreFirstColumn = false) : base()
        {
            int iStart = (ignoreFirstColumn == true ? 1 : 0);
            this.srcData = new OnlineInfo_Binance_SymbolData();
            this.srcData.symbol = listOnlineInfo_Binance_Symbol[iStart].ToString().Trim();  
            this.srcData.price = Convert.ToDecimal(listOnlineInfo_Binance_Symbol[iStart + 1].ToString().Trim());
            this.srcData.priceChangePercent = Convert.ToDecimal(listOnlineInfo_Binance_Symbol[iStart + 2].ToString().Trim());
            this.srcData.highPrice = Convert.ToDecimal(listOnlineInfo_Binance_Symbol[iStart + 3].ToString().Trim());
            this.srcData.lowPrice = Convert.ToDecimal(listOnlineInfo_Binance_Symbol[iStart + 4].ToString().Trim());
            this.srcData.volume = Convert.ToDecimal(listOnlineInfo_Binance_Symbol[iStart + 5].ToString().Trim());
            this.srcData.tradeAmount = Convert.ToDecimal(listOnlineInfo_Binance_Symbol[iStart + 6].ToString().Trim());
            this.srcData.tradePrice = Convert.ToDecimal(listOnlineInfo_Binance_Symbol[iStart + 7].ToString().Trim());
        }

        public OnlineInfo_Binance_Symbol(string symbol, decimal price)
        {
            this.srcData.symbol = symbol;
            this.srcData.price = price;
        }

        /// <summary>
        /// 赋值构造：每个交易代码返回的数据字段的构造函数
        /// </summary>
        /// <param name="OnlineInfo_Binance_Symbol">用OnlineInfo_Binance_Symbol的值来更新数据</param>
        public OnlineInfo_Binance_Symbol(OnlineInfo_Binance_Symbol onlineInfo_Binance_Symbol) : base()
        {
            this.srcData = new OnlineInfo_Binance_SymbolData();
            this.srcData.symbol = onlineInfo_Binance_Symbol.Symbol;
            this.srcData.price = onlineInfo_Binance_Symbol.Price;
            this.srcData.priceChangePercent = onlineInfo_Binance_Symbol.PriceChangePercent;
            this.srcData.highPrice = onlineInfo_Binance_Symbol.HighPrice;
            this.srcData.lowPrice = onlineInfo_Binance_Symbol.LowPrice;
            this.srcData.volume = onlineInfo_Binance_Symbol.Volume;
            this.srcData.tradeAmount = onlineInfo_Binance_Symbol.TradeAmount;
            this.srcData.tradePrice = onlineInfo_Binance_Symbol.TradePrice;
        }
        #endregion

        /// <summary>
        /// 返回当前交易代码列表
        /// </summary>
        internal SortableBindingList<OnlineInfo_Binance_Symbol> Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        void IEditableObject.BeginEdit()
        {
            Console.WriteLine($"Start BeginEdit");
            if (!inTxn)
            {
                this.backupData = srcData;
                inTxn = true;
                Console.WriteLine($"BeginEdit - {this.backupData.symbol}");
            }
            Console.WriteLine($"End BeginEdit");
        }

        void IEditableObject.CancelEdit()
        {
            Console.WriteLine($"Start CancelEdit");
            if (inTxn)
            {
                this.srcData = backupData;
                inTxn = false;
                Console.WriteLine($"CancelEdit - {this.srcData.symbol}");
            }
            Console.WriteLine($"End CancelEdit");
        }

        void IEditableObject.EndEdit()
        {
            Console.WriteLine($"Start EndEdit {this.srcData.symbol}");
            if (inTxn)
            {
                backupData = new OnlineInfo_Binance_SymbolData();
                inTxn = false;
                Console.WriteLine($"Done EndEdit - {this.srcData.symbol}");
            }
            Console.WriteLine($"End EndEdit");
        }

        public int CompareTo(OnlineInfo_Binance_Symbol? other)
        {
            int result = this.Symbol.CompareTo(other.Symbol);
            if (result == 0)
            {
                result = this.Symbol.CompareTo(other.Symbol);
            }
            return result;
        }
    }
}
