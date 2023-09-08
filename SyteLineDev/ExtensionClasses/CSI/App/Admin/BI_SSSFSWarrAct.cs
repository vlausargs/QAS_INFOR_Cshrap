//PROJECT NAME: Admin
//CLASS NAME: BI_SSSFSWarrAct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class BI_SSSFSWarrAct : IBI_SSSFSWarrAct
	{
		readonly IApplicationDB appDB;
		
		public BI_SSSFSWarrAct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BI_SSSFSWarrActFn(
			string iCompID,
			string iWarrCode = null,
			DateTime? iDate = null,
			int? iMeter = null,
			string site = null)
		{
			SerNumType _iCompID = iCompID;
			FSWarrCodeType _iWarrCode = iWarrCode;
			DateType _iDate = iDate;
			FSMeterAmtType _iMeter = iMeter;
			SiteType _site = site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BI_SSSFSWarrAct](@iCompID, @iWarrCode, @iDate, @iMeter, @site)";
				
				appDB.AddCommandParameter(cmd, "iCompID", _iCompID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWarrCode", _iWarrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDate", _iDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMeter", _iMeter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "site", _site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
