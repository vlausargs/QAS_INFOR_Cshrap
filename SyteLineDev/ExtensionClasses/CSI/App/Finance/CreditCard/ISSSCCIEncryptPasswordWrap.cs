//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIEncryptPasswordWrap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
    public interface ISSSCCIEncryptPasswordWrap
    {
        (int? ReturnCode,
        string EncryptedPassword,
        string Infobar) SSSCCIEncryptPasswordWrapSp(string Password,
        string EncryptedPassword,
        string Infobar);
    }
}


//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CSI.Finance.CreditCard
//{
//    interface ISSSCCIEncryptPasswordWrap
//    {
//    }
//}
