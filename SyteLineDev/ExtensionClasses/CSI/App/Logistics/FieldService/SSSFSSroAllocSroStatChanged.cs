//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroAllocSroStatChanged.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroAllocSroStatChanged : ISSSFSSroAllocSroStatChanged
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroAllocSroStatChanged(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSroAllocSroStatChangedSp(
			string iSroNum,
			string iOldSroStat,
			string iSroStat,
			string Infobar)
		{
			FSSRONumType _iSroNum = iSroNum;
			FSSROStatType _iOldSroStat = iOldSroStat;
			FSSROStatType _iSroStat = iSroStat;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroAllocSroStatChangedSp";
				
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldSroStat", _iOldSroStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroStat", _iSroStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
