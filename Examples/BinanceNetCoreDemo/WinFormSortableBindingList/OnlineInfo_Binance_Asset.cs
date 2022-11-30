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
    /// 币安线上获取的账户资产类
    /// </summary>
    public class OnlineInfo_Binance_Asset : IEditableObject, IComparable<OnlineInfo_Binance_Asset>
    {
        /// <summary>
        /// 每个账户资产返回的数据
        /// </summary>
        struct BinanceOnlineAssetData
        {
            internal string? asset;
            internal decimal free;
            internal decimal locked;
        }

        #region BinanceOnlineAsset里面值的赋值与读取的相关方法
        public string? Asset
        {
            get { return srcData.asset; }
            set
            {
                srcData.asset = value;
            }
        }

        public decimal Free
        {
            get { return srcData.free; }
            set
            {
                srcData.free = value;
            }
        }

        public decimal Locked
        {
            get { return srcData.locked; }
            set
            {
                srcData.locked = value;
            }
        }

        public OnlineInfo_Binance_Asset(string asset)
        {
            this.srcData.asset = asset;
        }

        /// <summary>
        /// 返回当前账户资产列表
        /// </summary>
        internal SortableBindingList<OnlineInfo_Binance_Asset> Parent
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

        private SortableBindingList<OnlineInfo_Binance_Asset>? parent;
        private BinanceOnlineAssetData srcData;
        private BinanceOnlineAssetData backupData;
        private bool inTxn = false;

        #region 构造函数(无参构造、全参构造、列表构造、赋值构造)
        /// <summary>
        /// 无参构造：每个账户资产返回的数据字段的构造函数
        /// </summary>
        public OnlineInfo_Binance_Asset() : base()
        {
            this.srcData = new BinanceOnlineAssetData();
            this.srcData.asset = null;
            this.srcData.free = 0;
            this.srcData.locked = 0;
        }


        /// <summary>
        /// 全参构造：每个账户资产返回的数据字段的构造函数
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="free"></param>
        /// <param name="locked"></param>
        public OnlineInfo_Binance_Asset(
             string? asset = null, decimal free = 0, decimal locked = 0
            ) : base()
        {
            this.srcData = new BinanceOnlineAssetData();
            this.srcData.asset = asset;
            this.srcData.free = free;
            this.srcData.locked = locked;
        }

        /// <summary>
        /// 列表构造：每个账户资产返回的数据字段的构造函数
        /// </summary>
        /// <param name="listBinanceOnlineAsset">每个账户资产返回的数据字段的List<string>结构信息</param>
        /// <param name="ignoreFirstColumn">如果是从DGV导入的List<string>结构通常首列是一个选择项，通过此参数忽略首行，保存正确的数据</param>
        /// <returns></returns>
        public OnlineInfo_Binance_Asset(List<string> listBinanceOnlineAsset, bool ignoreFirstColumn = false) : base()
        {
            int iStart = (ignoreFirstColumn == true ? 1 : 0);
            this.srcData = new BinanceOnlineAssetData();
            this.srcData.asset = listBinanceOnlineAsset[iStart].ToString().Trim();
            this.srcData.free = Convert.ToDecimal(listBinanceOnlineAsset[iStart + 1].ToString().Trim());
            this.srcData.locked = Convert.ToDecimal(listBinanceOnlineAsset[iStart + 2].ToString().Trim());
        }

        /// <summary>
        /// 赋值构造：每个账户资产返回的数据字段的构造函数
        /// </summary>
        /// <param name="BinanceOnlineAsset">用BinanceOnlineAsset的值来更新数据</param>
        public OnlineInfo_Binance_Asset(OnlineInfo_Binance_Asset BinanceOnlineAsset) : base()
        {
            this.srcData = new BinanceOnlineAssetData();
            this.srcData.asset = BinanceOnlineAsset.Asset;
            this.srcData.free = BinanceOnlineAsset.Free;
            this.srcData.locked = BinanceOnlineAsset.Locked;
        }
        #endregion

        void IEditableObject.BeginEdit()
        {
            Console.WriteLine($"Start BeginEdit");
            if (!inTxn)
            {
                this.backupData = srcData;
                inTxn = true;
                Console.WriteLine($"BeginEdit - {this.backupData.asset}");
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
                Console.WriteLine($"CancelEdit - {this.srcData.asset}");
            }
            Console.WriteLine($"End CancelEdit");
        }

        void IEditableObject.EndEdit()
        {
            Console.WriteLine($"Start EndEdit {this.srcData.asset}");
            if (inTxn)
            {
                backupData = new BinanceOnlineAssetData();
                inTxn = false;
                Console.WriteLine($"Done EndEdit - {this.srcData.asset}");
            }
            Console.WriteLine($"End EndEdit");
        }

        public int CompareTo(OnlineInfo_Binance_Asset? other)
        {
            int result = this.Asset.CompareTo(other.Asset);
            if (result == 0)
            {
                result = this.Asset.CompareTo(other.Asset);
            }
            return result;
        }
    }
}
