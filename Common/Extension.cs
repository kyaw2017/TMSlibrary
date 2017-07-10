using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSLibrary.Common
{
    public static class Extension
    {
        public static String GetListAll<T, L>(
            this String cls, Func<T, L> lengthProvider)
        {
            return cls;
        }
        public static String GetListByQuery<T, L>(
            this String cls, Func<T, L> lengthProvider)
        {
            return cls;
        }
        public static String Insert<T, L>(
            this String cls, Func<T, L> lengthProvider)
        {
            return cls;
        }
        public static String Update<T, L>(
            this String cls, Func<T, L> lengthProvider)
        {
            return cls;
        }
        public static String Delete<T, L>(
            this String cls, Func<T, L> lengthProvider)
        {
            return cls;
        }
    }
}
