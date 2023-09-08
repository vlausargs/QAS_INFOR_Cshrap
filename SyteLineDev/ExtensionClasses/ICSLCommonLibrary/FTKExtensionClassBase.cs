using Mongoose.IDO;
using System;
using System.Data;

namespace InforCollect.ERP.SL
{
    /// <summary>
    /// Extension base class for FTK
    /// </summary>
    public class FTKExtensionClassBase : ExtensionClassBase
    {
        /// <summary>
        /// Gets CSI Site Date-Time
        /// </summary>
        /// <param name="Date">Current Date-Time</param>
        /// <returns>CSI Site Date-Time</returns>
        public DateTime? GetSiteDate(DateTime? Date)
        {
            DateTime? _Date = Date;

            using (Mongoose.IDO.DataAccess.ApplicationDB appDB = this.CreateApplicationDB())
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT  dbo.[GetSiteDate](@Date)";

                    appDB.AddCommandParameterWithValue(cmd, "Date", _Date, ParameterDirection.Input);

                    var Output = appDB.ExecuteScalar<DateTime>(cmd);

                    return Output;
                }
            }
        }
        public DateTime? GetSiteDate(object Date, out string InforBar)
        {
            try
            {
                InforBar = string.Empty;
                return GetSiteDate(Convert.ToDateTime(Date));
            }
            catch (Exception)
            {
                InforBar = this.GetMessageProvider().GetMessage("E=OSInvalid", "@jobtran.trans_date", Date);
                return null;
            }           
        }
    }
}
