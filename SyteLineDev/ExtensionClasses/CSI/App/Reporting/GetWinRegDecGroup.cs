//PROJECT NAME: Reporting
//CLASS NAME: GetWinRegDecGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
    public class GetWinRegDecGroup : IGetWinRegDecGroup
    {
        IApplicationDB appDB;

        public GetWinRegDecGroup(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string GetWinRegDecGroupFn()
        {
            // SP hard code the value. Hard code in C# too.
            return "3;0";
        }
    }
}
