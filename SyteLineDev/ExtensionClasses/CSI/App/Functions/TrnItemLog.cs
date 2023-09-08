//PROJECT NAME: Data
//CLASS NAME: TrnItemLog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TrnItemLog : ITrnItemLog
	{
		readonly IApplicationDB appDB;
		
		public TrnItemLog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TrnItemLogSp(
			string PTrnNum,
			int? PTrnLine,
			string PItem,
			string OldItem,
			decimal? POldQtyReqConv,
			decimal? PNewQtyReqConv,
			DateTime? POldSchShipDate,
			DateTime? PNewSchShipDate,
			DateTime? POldSchRcvDate,
			DateTime? PNewSchRcvDate,
			string POldTrnLoc,
			string PNewTrnLoc,
			string PAction,
			decimal? PUomConvFactor,
			string POldUM,
			string PNewUM,
			string Infobar)
		{
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			ItemType _PItem = PItem;
			ItemType _OldItem = OldItem;
			QtyUnitType _POldQtyReqConv = POldQtyReqConv;
			QtyUnitType _PNewQtyReqConv = PNewQtyReqConv;
			DateType _POldSchShipDate = POldSchShipDate;
			DateType _PNewSchShipDate = PNewSchShipDate;
			DateType _POldSchRcvDate = POldSchRcvDate;
			DateType _PNewSchRcvDate = PNewSchRcvDate;
			LocType _POldTrnLoc = POldTrnLoc;
			LocType _PNewTrnLoc = PNewTrnLoc;
			LongListType _PAction = PAction;
			UMConvFactorType _PUomConvFactor = PUomConvFactor;
			UMType _POldUM = POldUM;
			UMType _PNewUM = PNewUM;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrnItemLogSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldItem", _OldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQtyReqConv", _POldQtyReqConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewQtyReqConv", _PNewQtyReqConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldSchShipDate", _POldSchShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewSchShipDate", _PNewSchShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldSchRcvDate", _POldSchRcvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewSchRcvDate", _PNewSchRcvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldTrnLoc", _POldTrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewTrnLoc", _PNewTrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUomConvFactor", _PUomConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldUM", _POldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewUM", _PNewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
