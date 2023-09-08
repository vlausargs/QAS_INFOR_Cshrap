//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSRODCValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSRODCValid : ISSSFSSRODCValid
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSRODCValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? SROLine,
			int? SROOper,
			string BillCode,
			string SroDesc,
			string LineItem,
			string OperDesc,
			string Infobar) SSSFSSRODCValidSp(
			string Table,
			string Level,
			string PartnerID,
			string SRONum,
			int? SROLine,
			int? SROOper,
			DateTime? TransDate,
			string BillCode,
			string SroDesc,
			string LineItem,
			string OperDesc,
			string Infobar)
		{
			StringType _Table = Table;
			StringType _Level = Level;
			FSPartnerType _PartnerID = PartnerID;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			DateType _TransDate = TransDate;
			FSSROBillCodeType _BillCode = BillCode;
			DescriptionType _SroDesc = SroDesc;
			ItemType _LineItem = LineItem;
			DescriptionType _OperDesc = OperDesc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSRODCValidSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroDesc", _SroDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineItem", _LineItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperDesc", _OperDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SROLine = _SROLine;
				SROOper = _SROOper;
				BillCode = _BillCode;
				SroDesc = _SroDesc;
				LineItem = _LineItem;
				OperDesc = _OperDesc;
				Infobar = _Infobar;
				
				return (Severity, SROLine, SROOper, BillCode, SroDesc, LineItem, OperDesc, Infobar);
			}
		}
	}
}
