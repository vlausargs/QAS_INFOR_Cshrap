//PROJECT NAME: Finance
//CLASS NAME: ICHSCheckBookName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
    public interface ICHSCheckBookName
    {
        (int? ReturnCode,
        string Infobar) CHSCheckBookNameSp(
            string BookName,
            string Infobar);
    }
}

