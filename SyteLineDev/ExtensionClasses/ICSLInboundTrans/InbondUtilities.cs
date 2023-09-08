using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;


namespace InforCollect.ERP.SL.ICSLInboundTrans
{
    class InbondUtilities : ICSLCommonLibrary
    {//place holder for future methods

        public bool IsStringContainsNumericValue(string Value)
        {

            bool isNumeric = false;
            foreach (char c in Value)
            {
                if (Char.IsNumber(c))
                {
                    isNumeric = true;
                    break;
                }
            }
            return isNumeric;

        }
        public bool IsStringStartsWithNumEndsWithNonNumeric(string Value)
        {

            bool isNumeric = false;

            if (Char.IsNumber(Convert.ToChar(Value.Substring(0, 1))) == false)
            {
                return false;
            }

            foreach (char c in Value)
            {
                if (Char.IsNumber(c) == false)
                {
                    isNumeric = true;
                    break;
                }
            }
            return isNumeric;

        }

    }
}
