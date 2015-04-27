﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace GMap.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<KeyValuePair<int, string>> GetEnumDataSource(this Type enumType)
        {
            if (!typeof(Enum).IsAssignableFrom(enumType)) throw new ArgumentException("Only Enums Types are allowed", "enumType");

            return (from object item in Enum.GetValues(enumType)
                    select new KeyValuePair<int, string>(Convert.ToInt32(item, CultureInfo.InvariantCulture), item.ToString())).ToList();
        }
    }
}
