using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumStatic
{
     public struct EnumStatic
     {
          public static string GetInstructionByEnum<Tenum>()
          {
               int indexItem = 0;
               Type enumType = typeof(Tenum);
               string[] eNumNames = Enum.GetNames(enumType);
               string res = string.Empty;
               foreach (var eName in eNumNames)
               {
                    res += string.Format("{0}. {1}{2}", indexItem + 1, CreateStringFromEnumStr(eNumNames[indexItem]), "\n");
                    indexItem++;
               }

               return res;
          }

          public static string CreateStringFromEnumStr(string enumStr)
          {
               string newStr = string.Empty;
               newStr += enumStr[0];
               for (int i = 1; i < enumStr.Length; i++)
               {
                    if (enumStr[i] >= 'A' && enumStr[i] <= 'Z')
                    {
                         newStr += " " + enumStr[i];
                    }
                    else
                    {
                         newStr += enumStr[i];
                    }
               }

               return newStr;
          }
     }
}
