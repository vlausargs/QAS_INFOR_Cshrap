//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdGetAcctValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtdGetAcctValues : IArpmtdGetAcctValues
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtdGetAcctValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string Infobar,
		int? PIsControl) ArpmtdGetAcctValuesSp(decimal? PAmt,
		string PType,
		string PArpmtdType,
		string PCustCurrCode,
		int? PReapp,
		string POpenType,
		string PArpmtdSite,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string Infobar,
		int? PIsControl)
		{
			AmountType _PAmt = PAmt;
			LongListType _PType = PType;
			LongListType _PArpmtdType = PArpmtdType;
			CurrCodeType _PCustCurrCode = PCustCurrCode;
			FlagNyType _PReapp = PReapp;
			LongListType _POpenType = POpenType;
			SiteType _PArpmtdSite = PArpmtdSite;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PIsControl = PIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdGetAcctValuesSp";
				
				appDB.AddCommandParameter(cmd, "PAmt", _PAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdType", _PArpmtdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustCurrCode", _PCustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReapp", _PReapp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenType", _POpenType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdSite", _PArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PIsControl", _PIsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAcct = _PAcct;
				PAcctUnit1 = _PAcctUnit1;
				PAcctUnit2 = _PAcctUnit2;
				PAcctUnit3 = _PAcctUnit3;
				PAcctUnit4 = _PAcctUnit4;
				Infobar = _Infobar;
				PIsControl = _PIsControl;
				
				return (Severity, PAcct, PAcctUnit1, PAcctUnit2, PAcctUnit3, PAcctUnit4, Infobar, PIsControl);
			}
		}
	}
}
