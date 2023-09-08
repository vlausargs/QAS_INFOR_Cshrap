//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_ResourceGroupOEE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_ResourceGroupOEE
    {
        DataTable Homepage_ResourceGroupOEESp(short? Altno,
                                              DateTime? StartDate,
                                              DateTime? EndDate);
    }

    public class Homepage_ResourceGroupOEE : IHomepage_ResourceGroupOEE
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Homepage_ResourceGroupOEE(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Homepage_ResourceGroupOEESp(short? Altno,
                                                     DateTime? StartDate,
                                                     DateTime? EndDate)
        {
            ApsAltNoType _Altno = Altno;
            DateType _StartDate = StartDate;
            DateType _EndDate = EndDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_ResourceGroupOEESp";

                appDB.AddCommandParameter(cmd, "Altno", _Altno, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
