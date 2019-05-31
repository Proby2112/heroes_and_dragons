using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesAndDragons.Core.Helpers
{
    public static class DLExtensions
    {
        public static T Copy<T>(this T fromObj) where T : class, new()
        {
            if (fromObj == null)
            {
                return null;
            }

            var obj = new T();

            var fields1 = obj.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray();
            var fields2 = fromObj.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray();

            for (int i = 0; i < fields2.Length; i++)
            {
                var value = fields2[i].GetValue(fromObj);

                if (fields2[i].GetMethod.ReturnType.Name.Contains("ICollection"))
                {
                    continue;
                }

                var first = fields1.FirstOrDefault(x => x.Name == fields2[i].Name);
                var setMethod = first.GetSetMethod(false);

                if (setMethod != null)
                {
                    //setMethod.Invoke(obj, new[] { value });
                    first?.SetValue(obj, value);
                }
            }

            return obj;
        }

        public static bool Copy<T>(this T obj, T fromObj)
        {
            if (obj == null || fromObj == null)
            {
                return false;
            }

            bool isChanged = false;

            var fields1 = obj.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray();
            var fields2 = fromObj.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray();

            for (int i = 0; i < fields2.Length; i++)
            {
                var originValue = fields2[i].GetValue(obj);
                var value = fields2[i].GetValue(fromObj);

                if (fields2[i].GetMethod.ReturnType.Name.Contains("ICollection")
                    || fields2[i].Name == "Created")
                {
                    continue;
                }

                if ((value == null && originValue != null) || (originValue == null && value != null)
                    || (value != null && originValue != null && !value.Equals(originValue)))
                {
                    isChanged = true;
                }

                var first = fields1.FirstOrDefault(x => x.Name == fields2[i].Name);
                var setMethod = first.GetSetMethod(false);

                if (setMethod != null)
                {
                    //setMethod.Invoke(obj, new[] { value });
                    first?.SetValue(obj, value);
                }
            }

            return isChanged;
        }
    }
}
