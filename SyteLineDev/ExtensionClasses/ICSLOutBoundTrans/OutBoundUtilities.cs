using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;


namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class OutBoundUtilities : ICSLCommonLibrary
    {
        //place holder for future methods   

        public bool GenerateGUID(ref string GUID,ref string errorMessage)
        {
            object[] inputParams = new object[]{
                                                ""
                                               };
            InvokeResponseData responseData = InvokeIDO("SLCos", "GenerateGUIDSp", inputParams);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = "Failed to Generate GUID";
                return false;
            }
            GUID = responseData.Parameters.ElementAt(0).ToString();
            return true;
        }
    }
}
