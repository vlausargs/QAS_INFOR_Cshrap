//PROJECT NAME: Logistics
//CLASS NAME: GetCoNonInvAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCoNonInvAcct : IGetCoNonInvAcct
	{
		readonly IApplicationDB appDB;
		
		
		public GetCoNonInvAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string NonInvAcct,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		int? PostJour,
		string Infobar,
		int? IsControl) GetCoNonInvAcctSp(string CoNum,
		string CustNum,
		string Item,
		string Whse,
		string NonInvAcct,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		int? PostJour,
		string Infobar,
		string Site = null,
		int? IsControl = null)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			AcctType _NonInvAcct = NonInvAcct;
			UnitCode1Type _NonInvAcctUnit1 = NonInvAcctUnit1;
			UnitCode2Type _NonInvAcctUnit2 = NonInvAcctUnit2;
			UnitCode3Type _NonInvAcctUnit3 = NonInvAcctUnit3;
			UnitCode4Type _NonInvAcctUnit4 = NonInvAcctUnit4;
			UnitCodeAccessType _AccessUnit1 = AccessUnit1;
			UnitCodeAccessType _AccessUnit2 = AccessUnit2;
			UnitCodeAccessType _AccessUnit3 = AccessUnit3;
			UnitCodeAccessType _AccessUnit4 = AccessUnit4;
			ListYesNoType _PostJour = PostJour;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			ListYesNoType _IsControl = IsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCoNonInvAcctSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonInvAcct", _NonInvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit1", _NonInvAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit2", _NonInvAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit3", _NonInvAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit4", _NonInvAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit1", _AccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit2", _AccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit3", _AccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit4", _AccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostJour", _PostJour, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsControl", _IsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NonInvAcct = _NonInvAcct;
				NonInvAcctUnit1 = _NonInvAcctUnit1;
				NonInvAcctUnit2 = _NonInvAcctUnit2;
				NonInvAcctUnit3 = _NonInvAcctUnit3;
				NonInvAcctUnit4 = _NonInvAcctUnit4;
				AccessUnit1 = _AccessUnit1;
				AccessUnit2 = _AccessUnit2;
				AccessUnit3 = _AccessUnit3;
				AccessUnit4 = _AccessUnit4;
				PostJour = _PostJour;
				Infobar = _Infobar;
				IsControl = _IsControl;
				
				return (Severity, NonInvAcct, NonInvAcctUnit1, NonInvAcctUnit2, NonInvAcctUnit3, NonInvAcctUnit4, AccessUnit1, AccessUnit2, AccessUnit3, AccessUnit4, PostJour, Infobar, IsControl);
			}
		}
	}
}
