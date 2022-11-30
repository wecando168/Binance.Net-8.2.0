using Binance.Net.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceNetCoreDemo.WinFormSortableBindingList
{
    /// <summary>
    /// 币安线上获取的订单类
    /// </summary>
    public class OnlineInfo_Binance_Order : IEditableObject, IComparable<OnlineInfo_Binance_Order>
    {
        /// <summary>
        /// 每条订单返回的数据
        /// </summary>
        struct BinanceOnlineOrderData
        {
            internal long id;
            internal string? symbol;
            internal decimal price;
            internal decimal originalQuantity;
            internal decimal executedQuantity;
            internal OrderStatus orderStatus;
            internal OrderSide orderSide;
            internal SpotOrderType spotOrderType;
            internal DateTime time;
        }

        private SortableBindingList<OnlineInfo_Binance_Order>? parent;
        private BinanceOnlineOrderData srcData;
        private BinanceOnlineOrderData backupData;
        private bool inTxn = false;

        #region BinanceOnlineOrder里面值的赋值与读取的相关方法
        public long Id
        {
            get { return srcData.id; }
            set
            {
                srcData.id = value;
            }
        }

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


        public decimal OriginalQuantity
        {
            get { return srcData.originalQuantity; }
            set
            {
                srcData.originalQuantity = value;
            }
        }


        public decimal ExecutedQuantity
        {
            get { return srcData.executedQuantity; }
            set
            {
                srcData.executedQuantity = value;
            }
        }

        public string FullFilled
        {
            get { return ExecutedQuantity + "/" + OriginalQuantity; }
        }


        public OrderStatus OrderStatus
        {
            get { return srcData.orderStatus; }
            set
            {
                srcData.orderStatus = value;
            }
        }

        public OrderSide OrderSide
        {
            get { return srcData.orderSide; }
            set
            {
                srcData.orderSide = value;
            }
        }

        public SpotOrderType SpotOrderType
        {
            get { return srcData.spotOrderType; }
            set
            {
                srcData.spotOrderType = value;
            }
        }


        public DateTime Time
        {
            get { return srcData.time; }
            set
            {
                srcData.time = value;
            }
        }

        public bool CanCancel
        {
            get { return srcData.orderStatus == OrderStatus.New || srcData.orderStatus == OrderStatus.PartiallyFilled; }
        }

        /// <summary>
        /// 返回当前成交记录所在的成交记录列表
        /// </summary>
        internal SortableBindingList<OnlineInfo_Binance_Order> Parent
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
        #endregion

        #region 构造函数(无参构造、全参构造、列表构造、赋值构造)
        /// <summary>
        /// 无参构造：每条订单返回的数据字段的构造函数
        /// </summary>
        public OnlineInfo_Binance_Order() : base()
        {
            this.srcData = new BinanceOnlineOrderData();
            this.srcData.id = 0;
            this.srcData.symbol = null;
            this.srcData.price = 0;
            this.srcData.originalQuantity = 0;
            this.srcData.executedQuantity = 0;
            this.srcData.orderStatus = OrderStatus.Canceled;
            this.srcData.orderSide = OrderSide.Sell;
            this.srcData.spotOrderType = SpotOrderType.Limit;
            this.srcData.time = DateTime.Now;
        }


        /// <summary>
        /// 全参构造：每条订单返回的数据字段的构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="symbol"></param>
        /// <param name="price"></param>
        /// <param name="originalQuantity"></param>
        /// <param name="executedQuantity"></param>
        /// <param name="orderStatus"></param>
        /// <param name="orderSide"></param>
        /// <param name="spotOrderType"></param>
        /// <param name="time"></param>
        public OnlineInfo_Binance_Order(
             long id = 0, string? symbol = null, decimal price = 0, decimal originalQuantity = 0, decimal executedQuantity = 0,
             OrderStatus? orderStatus = null, OrderSide? orderSide = null, SpotOrderType? spotOrderType = null, DateTime? time = null
            ) : base()
        {
            this.srcData = new BinanceOnlineOrderData();
            this.srcData.id = id;
            this.srcData.symbol = symbol;
            this.srcData.price = price;
            this.srcData.originalQuantity = originalQuantity;
            this.srcData.executedQuantity = executedQuantity;
            this.srcData.orderStatus = (OrderStatus)orderStatus;
            this.srcData.orderSide = (OrderSide)orderSide;
            this.srcData.spotOrderType = (SpotOrderType)spotOrderType;
            this.srcData.time = (DateTime)time;
        }

        /// <summary>
        /// 列表构造：每条订单返回的数据字段的构造函数
        /// </summary>
        /// <param name="listBinanceOnlineOrder">每条订单返回的数据字段的List<string>结构信息</param>
        /// <param name="ignoreFirstColumn">如果是从DGV导入的List<string>结构通常首列是一个选择项，通过此参数忽略首行，保存正确的数据</param>
        /// <returns></returns>
        public OnlineInfo_Binance_Order(List<string> listBinanceOnlineOrder, bool ignoreFirstColumn = false) : base()
        {
            int iStart = (ignoreFirstColumn == true ? 1:0);
            this.srcData = new BinanceOnlineOrderData();
            this.srcData.id = long.Parse(listBinanceOnlineOrder[iStart].ToString().Trim());
            this.srcData.symbol = listBinanceOnlineOrder[iStart + 1].ToString().Trim();
            this.srcData.price = Convert.ToDecimal(listBinanceOnlineOrder[iStart + 2].ToString().Trim());
            this.srcData.originalQuantity = Convert.ToDecimal(listBinanceOnlineOrder[iStart + 3].ToString().Trim());
            this.srcData.executedQuantity = Convert.ToDecimal(listBinanceOnlineOrder[iStart + 4].ToString().Trim());
            this.srcData.orderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus),listBinanceOnlineOrder[iStart + 5].ToString().Trim());
            this.srcData.orderSide = (OrderSide)Enum.Parse(typeof(OrderSide), listBinanceOnlineOrder[iStart + 6].ToString().Trim());
            this.srcData.spotOrderType = (SpotOrderType)Enum.Parse(typeof(SpotOrderType), listBinanceOnlineOrder[iStart + 7].ToString().Trim());
            this.srcData.time = DateTime.Parse(listBinanceOnlineOrder[iStart + 8].ToString().Trim());
        }

        /// <summary>
        /// 赋值构造：每条订单返回的数据字段的构造函数
        /// </summary>
        /// <param name="BinanceOnlineOrder">用BinanceOnlineOrder的值来更新数据</param>
        public OnlineInfo_Binance_Order(OnlineInfo_Binance_Order binanceOnlineOrder) : base()
        {
            this.srcData = new BinanceOnlineOrderData();
            this.srcData.id = binanceOnlineOrder.Id;
            this.srcData.symbol = binanceOnlineOrder.Symbol;
            this.srcData.price = binanceOnlineOrder.Price;
            this.srcData.originalQuantity = binanceOnlineOrder.OriginalQuantity;
            this.srcData.executedQuantity = binanceOnlineOrder.ExecutedQuantity;
            this.srcData.orderStatus = binanceOnlineOrder.OrderStatus;
            this.srcData.orderSide = binanceOnlineOrder.OrderSide;
            this.srcData.spotOrderType = binanceOnlineOrder.SpotOrderType;
            this.srcData.time = binanceOnlineOrder.Time;
        }
        #endregion

        void IEditableObject.BeginEdit()
        {
            Console.WriteLine($"Start BeginEdit");
            if (!inTxn)
            {
                this.backupData = srcData;
                inTxn = true;
                Console.WriteLine($"BeginEdit - {this.backupData.id}");
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
                Console.WriteLine($"CancelEdit - {this.srcData.id}");
            }
            Console.WriteLine($"End CancelEdit");
        }

        void IEditableObject.EndEdit()
        {
            Console.WriteLine($"Start EndEdit {this.srcData.id}");
            if (inTxn)
            {
                backupData = new BinanceOnlineOrderData();
                inTxn = false;
                Console.WriteLine($"Done EndEdit - {this.srcData.id}");
            }
            Console.WriteLine($"End EndEdit");
        }

        public int CompareTo(OnlineInfo_Binance_Order? other)
        {
            int result = this.Id.CompareTo(other.Id);
            if (result == 0)
            {
                result = this.Id.CompareTo(other.Id);
            }
            return result;
        }
    }
}