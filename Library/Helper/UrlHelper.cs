using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Library.Helper
{
    public static class UrlHelper
    {
        /// <summary>
        /// 物件轉換成RouteValueDictionary
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">物件</param>
        /// <returns></returns>
        public static RouteValueDictionary ObjectToRouteValueDictionary<T>(T obj)
        {
            var rvDic = new RouteValueDictionary();

            foreach (var property in obj.GetType().GetProperties())
            {
                //type符合集合類型(Array暫時沒有)
                if ((property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>)) ||
                       typeof(ICollection).IsAssignableFrom(property.PropertyType))
                {
                    IEnumerable t = (IEnumerable)property.GetValue(obj);
                    if (t != null)
                    {
                        var i = 0;
                        foreach (var item in t)
                        {
                            rvDic.Add(string.Concat(property.Name, "[", i, "]"), item);
                            i++;
                        }
                    }

                }
                else
                {
                    var value = property.GetGetMethod().Invoke(obj, null) == null ? "" : property.GetGetMethod().Invoke(obj, null);
                    if (!string.IsNullOrEmpty(value.ToString()))
                    {
                        rvDic.Add(property.Name, value);
                    }

                }
            }
            return rvDic;
        }
    }
}
