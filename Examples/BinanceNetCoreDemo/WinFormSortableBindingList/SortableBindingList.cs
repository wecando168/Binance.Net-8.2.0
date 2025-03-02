﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace BinanceNetCoreDemo.WinFormSortableBindingList
{
    //SortableBindingList_Normal 支持DataGridView绑定排序的BindingList
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSortedCore = true;
        private ListSortDirection sortDirectionCore = ListSortDirection.Ascending;
        private PropertyDescriptor sortPropertyCore = null;
        private string defaultSortItem;

        public SortableBindingList() : base()
        {
        }

        public SortableBindingList(IList<T> list) : base(list)
        {
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }
        protected override bool IsSortedCore
        {
            get
            {
                return isSortedCore;
            }
        }
        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return sortDirectionCore;
            }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return sortPropertyCore;
            }
        }
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (Equals(prop.GetValue(this[i]), key))
                    return i;
            }
            return -1;
        }
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            isSortedCore = true;
            sortPropertyCore = prop;
            sortDirectionCore = direction; Sort();
        }
        protected override void RemoveSortCore()
        {
            if (isSortedCore)
            {
                isSortedCore = false; sortPropertyCore = null; sortDirectionCore = ListSortDirection.Ascending; Sort();
            }
        }

        public string DefaultSortItem
        {
            get
            {
                return defaultSortItem;
            }
            set
            {
                if (defaultSortItem != value)
                {
                    defaultSortItem = value; Sort();
                }
            }
        }

        private void Sort()
        {
            List<T> list = (this.Items as List<T>); list.Sort(CompareCore); ResetBindings();
        }

        private int CompareCore(T o1, T o2)
        {
            int ret = 0;
            if (SortPropertyCore != null)
            {
                ret = CompareValue(SortPropertyCore.GetValue(o1), SortPropertyCore.GetValue(o2), SortPropertyCore.PropertyType);
            }
            if (ret == 0 && DefaultSortItem != null)
            {
                PropertyInfo property = typeof(T).GetProperty(DefaultSortItem, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase, null, null, new Type[0], null);
                if (property != null)
                {
                    ret = CompareValue(property.GetValue(o1, null), property.GetValue(o2, null), property.PropertyType);
                }
            }
            if (SortDirectionCore == ListSortDirection.Descending)
                ret = -ret; return ret;
        }

        private static int CompareValue(object o1, object o2, Type type)
        {
            //这里改成自己定义的比较
            if (object.Equals(o1, null)) return object.Equals(o2, null) ? 0 : -1;
            else if (object.Equals(o2, null)) return 1;
            else if (type.IsPrimitive || type.IsEnum) return Convert.ToDouble(o1).CompareTo(Convert.ToDouble(o2));
            else if (type == typeof(DateTime)) return Convert.ToDateTime(o1).CompareTo(o2);
            else if (type == typeof(Decimal)) return Convert.ToDecimal(o1).CompareTo(o2);
            else if (type == typeof(Double)) return Convert.ToDouble(o1).CompareTo(o2);
            else if (type == typeof(int)) return Convert.ToInt64(o1).CompareTo(o2);
            else return String.Compare((string)o1, (string)o2);
        }
    }
}
