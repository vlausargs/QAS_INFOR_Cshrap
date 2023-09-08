//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransDefs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROTransDefs : ISSSFSSROTransDefs
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransDefs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string BillCode,
			string Whse,
			string Dept,
			DateTime? PostDate,
			string Infobar,
			string PriceCode,
			int? ReimbMatl,
			string WorkCode,
			string MiscCode) SSSFSSROTransDefsSp(
			string Table,
			string SRONum,
			int? SROLine,
			int? SROOper,
			string PartnerId,
			DateTime? TransDate,
			string BillCode,
			string Whse,
			string Dept,
			DateTime? PostDate,
			string Infobar,
			string PriceCode = null,
			int? ReimbMatl = null,
			string WorkCode = null,
			string MiscCode = null)
		{
			StringType _Table = Table;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			FSPartnerType _PartnerId = PartnerId;
			DateType _TransDate = TransDate;
			FSSROBillCodeType _BillCode = BillCode;
			WhseType _Whse = Whse;
			DeptType _Dept = Dept;
			DateType _PostDate = PostDate;
			Infobar _Infobar = Infobar;
			PriceCodeType _PriceCode = PriceCode;
			ListYesNoType _ReimbMatl = ReimbMatl;
			FSWorkCodeType _WorkCode = WorkCode;
			FSMiscCodeType _MiscCode = MiscCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransDefsSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbMatl", _ReimbMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WorkCode", _WorkCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscCode", _MiscCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BillCode = _BillCode;
				Whse = _Whse;
				Dept = _Dept;
				PostDate = _PostDate;
				Infobar = _Infobar;
				PriceCode = _PriceCode;
				ReimbMatl = _ReimbMatl;
				WorkCode = _WorkCode;
				MiscCode = _MiscCode;
				
				return (Severity, BillCode, Whse, Dept, PostDate, Infobar, PriceCode, ReimbMatl, WorkCode, MiscCode);
			}
		}
	}
}
