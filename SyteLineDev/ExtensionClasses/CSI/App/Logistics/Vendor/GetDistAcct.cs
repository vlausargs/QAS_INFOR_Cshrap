//PROJECT NAME: Logistics
//CLASS NAME: GetDistAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetDistAcct : IGetDistAcct
	{
		readonly IApplicationDB appDB;
		
		
		public GetDistAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DistAcct,
		string DistAcctUnit1,
		string DistAcctUnit2,
		string DistAcctUnit3,
		string DistAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Infobar,
		int? AcctIsControl) GetDistAcctSp(string Item,
		string Whse,
		string DistAcct,
		string DistAcctUnit1,
		string DistAcctUnit2,
		string DistAcctUnit3,
		string DistAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Infobar,
		string Site = null,
		int? AcctIsControl = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			AcctType _DistAcct = DistAcct;
			UnitCode1Type _DistAcctUnit1 = DistAcctUnit1;
			UnitCode2Type _DistAcctUnit2 = DistAcctUnit2;
			UnitCode3Type _DistAcctUnit3 = DistAcctUnit3;
			UnitCode4Type _DistAcctUnit4 = DistAcctUnit4;
			UnitCodeAccessType _AccessUnit1 = AccessUnit1;
			UnitCodeAccessType _AccessUnit2 = AccessUnit2;
			UnitCodeAccessType _AccessUnit3 = AccessUnit3;
			UnitCodeAccessType _AccessUnit4 = AccessUnit4;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			ListYesNoType _AcctIsControl = AcctIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDistAcctSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistAcct", _DistAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DistAcctUnit1", _DistAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DistAcctUnit2", _DistAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DistAcctUnit3", _DistAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DistAcctUnit4", _DistAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit1", _AccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit2", _AccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit3", _AccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit4", _AccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctIsControl", _AcctIsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DistAcct = _DistAcct;
				DistAcctUnit1 = _DistAcctUnit1;
				DistAcctUnit2 = _DistAcctUnit2;
				DistAcctUnit3 = _DistAcctUnit3;
				DistAcctUnit4 = _DistAcctUnit4;
				AccessUnit1 = _AccessUnit1;
				AccessUnit2 = _AccessUnit2;
				AccessUnit3 = _AccessUnit3;
				AccessUnit4 = _AccessUnit4;
				Infobar = _Infobar;
				AcctIsControl = _AcctIsControl;
				
				return (Severity, DistAcct, DistAcctUnit1, DistAcctUnit2, DistAcctUnit3, DistAcctUnit4, AccessUnit1, AccessUnit2, AccessUnit3, AccessUnit4, Infobar, AcctIsControl);
			}
		}
	}
}
