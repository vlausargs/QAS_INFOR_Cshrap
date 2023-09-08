//PROJECT NAME: Logistics
//CLASS NAME: AppmtdGetAcctDflts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtdGetAcctDflts : IAppmtdGetAcctDflts
	{
		readonly IApplicationDB appDB;
		
		public AppmtdGetAcctDflts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PAcctDesc,
			string Infobar,
			int? PAcctIsControl) AppmtdGetAcctDfltsSp(
			string PSite,
			string PType,
			string PVendNum,
			decimal? PDiscAmt,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PAcctDesc,
			string Infobar,
			int? PAcctIsControl)
		{
			SiteType _PSite = PSite;
			AppmtdTypeType _PType = PType;
			VendNumType _PVendNum = PVendNum;
			AmountType _PDiscAmt = PDiscAmt;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			LongListType _PAcctDesc = PAcctDesc;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PAcctIsControl = PAcctIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtdGetAcctDfltsSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiscAmt", _PDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctDesc", _PAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctIsControl", _PAcctIsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAcct = _PAcct;
				PAcctUnit1 = _PAcctUnit1;
				PAcctUnit2 = _PAcctUnit2;
				PAcctUnit3 = _PAcctUnit3;
				PAcctUnit4 = _PAcctUnit4;
				PAcctDesc = _PAcctDesc;
				Infobar = _Infobar;
				PAcctIsControl = _PAcctIsControl;
				
				return (Severity, PAcct, PAcctUnit1, PAcctUnit2, PAcctUnit3, PAcctUnit4, PAcctDesc, Infobar, PAcctIsControl);
			}
		}
	}
}
