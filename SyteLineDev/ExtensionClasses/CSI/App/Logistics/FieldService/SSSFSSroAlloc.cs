//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroAlloc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroAlloc : ISSSFSSroAlloc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroAlloc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSroAllocSp(
			string iOldSroNum,
			int? iOldSroLine,
			int? iOldSroOper,
			string iOldWhse,
			string iOldItem,
			decimal? iOldMatlQty,
			string iOldSroStat,
			string iOldOpStat,
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			string iWhse,
			string iItem,
			decimal? iMatlQty,
			string iSroStat,
			string iOpStat,
			int? iNotUsed,
			string Infobar)
		{
			FSSRONumType _iOldSroNum = iOldSroNum;
			FSSROLineType _iOldSroLine = iOldSroLine;
			FSSROOperType _iOldSroOper = iOldSroOper;
			WhseType _iOldWhse = iOldWhse;
			ItemType _iOldItem = iOldItem;
			QtyUnitType _iOldMatlQty = iOldMatlQty;
			FSSROStatType _iOldSroStat = iOldSroStat;
			FSSROOperStatType _iOldOpStat = iOldOpStat;
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			WhseType _iWhse = iWhse;
			ItemType _iItem = iItem;
			QtyUnitType _iMatlQty = iMatlQty;
			FSSROStatType _iSroStat = iSroStat;
			FSSROOperStatType _iOpStat = iOpStat;
			ListYesNoType _iNotUsed = iNotUsed;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroAllocSp";
				
				appDB.AddCommandParameter(cmd, "iOldSroNum", _iOldSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldSroLine", _iOldSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldSroOper", _iOldSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldWhse", _iOldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldItem", _iOldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldMatlQty", _iOldMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldSroStat", _iOldSroStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOldOpStat", _iOldOpStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatlQty", _iMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroStat", _iSroStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOpStat", _iOpStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iNotUsed", _iNotUsed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
