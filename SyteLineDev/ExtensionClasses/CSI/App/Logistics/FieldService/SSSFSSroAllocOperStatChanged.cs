//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroAllocOperStatChanged.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroAllocOperStatChanged : ISSSFSSroAllocOperStatChanged
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroAllocOperStatChanged(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSroAllocOperStatChangedSp(
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			string iOldOpStat,
			string iOpStat,
			string Infobar)
		{
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			FSSROOperStatType _iOldOpStat = iOldOpStat;
			FSSROOperStatType _iOpStat = iOpStat;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroAllocOperStatChangedSp";
				
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldOpStat", _iOldOpStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOpStat", _iOpStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
