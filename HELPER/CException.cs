using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HELPER
{
    public class CError
    {
        public enum ErrorType
        {
            Duplicate,InUse, Unidentified
        }
        public static ErrorType Parse(String p_message) {
            if (p_message.IndexOf("duplicate key") > 0)
            {
                return ErrorType.Duplicate;
            }
            return ErrorType.Unidentified;
        }
    }
}
