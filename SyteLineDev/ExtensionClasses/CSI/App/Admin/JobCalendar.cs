//PROJECT NAME: CSIAdmin
//CLASS NAME: JobCalendar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IJobCalendar
    {
        DataTable JobCalendarSp(DateTimeType StartDate,
                                DateTimeType EndDate,
                                StringType JobAction);
    }

    public class JobCalendar : IJobCalendar
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;

        public JobCalendar(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable JobCalendarSp(DateTimeType StartDate,
                                       DateTimeType EndDate,
                                       StringType JobAction)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "JobCalendarSp";

                    appDB.AddCommandParameter(cmd, "StartDate", StartDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "EndDate", EndDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "JobAction", JobAction, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}

