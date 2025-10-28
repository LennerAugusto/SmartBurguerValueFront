using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartBurguerValueRCL.Helpers
{
    public static class EnumHelpers
    {
        public static string GetDescription<T>(this T enumValue)
       where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var displayAttr = fieldInfo.GetCustomAttribute<DisplayAttribute>();
                if (displayAttr != null)
                {
                    description = displayAttr.GetName();
                }
                else
                {
                    var descAttr = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
                    if (descAttr != null)
                        description = descAttr.Description;
                }
            }

            return description;
        }
    }
}
