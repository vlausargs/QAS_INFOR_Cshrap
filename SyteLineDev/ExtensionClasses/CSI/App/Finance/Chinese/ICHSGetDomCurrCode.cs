//PROJECT NAME: Finance
//CLASS NAME: ICHSGetDomCurrCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
    public interface ICHSGetDomCurrCode
    {
            (int? ReturnCode,
            string curr_code,
            string InfoBar) 
        CHSGetDomCurrCodeSp(
            string curr_code,
            string InfoBar);
    }
}

