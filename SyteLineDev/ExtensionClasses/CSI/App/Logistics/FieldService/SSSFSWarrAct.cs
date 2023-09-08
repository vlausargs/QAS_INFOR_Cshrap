//PROJECT NAME: Logistics
//CLASS NAME: SSSFSWarrAct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSWarrAct : ISSSFSWarrAct
	{
		readonly IApplicationDB appDB;
		
		public SSSFSWarrAct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSWarrActFn(
			string iCompID,
			string iWarrCode = null,
			DateTime? iDate = null,
			int? iMeter = null)
		{
			SerNumType _iCompID = iCompID;
			FSWarrCodeType _iWarrCode = iWarrCode;
			DateType _iDate = iDate;
			FSMeterAmtType _iMeter = iMeter;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSWarrAct](@iCompID, @iWarrCode, @iDate, @iMeter)";
				
				appDB.AddCommandParameter(cmd, "iCompID", _iCompID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWarrCode", _iWarrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDate", _iDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMeter", _iMeter, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
