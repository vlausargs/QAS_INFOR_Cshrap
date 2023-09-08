//PROJECT NAME: Production
//CLASS NAME: IPpJobExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
    public interface IPpJobExist
    {
        (int? ReturnCode, int? PpJobExist, string Infobar) PpJobExistSp(
            string PJob,
            int? PpJobExist,
            string Infobar);
    }
}