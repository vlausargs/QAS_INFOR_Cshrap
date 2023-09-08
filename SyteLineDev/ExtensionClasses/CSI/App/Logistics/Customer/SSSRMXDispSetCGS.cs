//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDispSetCGS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDispSetCGS : ISSSRMXDispSetCGS
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXDispSetCGS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CgsMatlAcct,
			string CgsMatlAcctUnit1,
			string CgsMatlAcctUnit2,
			string CgsMatlAcctUnit3,
			string CgsMatlAcctUnit4,
			string CgsLbrAcct,
			string CgsLbrAcctUnit1,
			string CgsLbrAcctUnit2,
			string CgsLbrAcctUnit3,
			string CgsLbrAcctUnit4,
			string CgsFovAcct,
			string CgsFovAcctUnit1,
			string CgsFovAcctUnit2,
			string CgsFovAcctUnit3,
			string CgsFovAcctUnit4,
			string CgsVovAcct,
			string CgsVovAcctUnit1,
			string CgsVovAcctUnit2,
			string CgsVovAcctUnit3,
			string CgsVovAcctUnit4,
			string CgsOutAcct,
			string CgsOutAcctUnit1,
			string CgsOutAcctUnit2,
			string CgsOutAcctUnit3,
			string CgsOutAcctUnit4,
			string Infobar) SSSRMXDispSetCGSSp(
			string EndUserType,
			string Whse,
			string Item,
			string CgsMatlAcct,
			string CgsMatlAcctUnit1,
			string CgsMatlAcctUnit2,
			string CgsMatlAcctUnit3,
			string CgsMatlAcctUnit4,
			string CgsLbrAcct,
			string CgsLbrAcctUnit1,
			string CgsLbrAcctUnit2,
			string CgsLbrAcctUnit3,
			string CgsLbrAcctUnit4,
			string CgsFovAcct,
			string CgsFovAcctUnit1,
			string CgsFovAcctUnit2,
			string CgsFovAcctUnit3,
			string CgsFovAcctUnit4,
			string CgsVovAcct,
			string CgsVovAcctUnit1,
			string CgsVovAcctUnit2,
			string CgsVovAcctUnit3,
			string CgsVovAcctUnit4,
			string CgsOutAcct,
			string CgsOutAcctUnit1,
			string CgsOutAcctUnit2,
			string CgsOutAcctUnit3,
			string CgsOutAcctUnit4,
			string Infobar)
		{
			EndUserTypeType _EndUserType = EndUserType;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			AcctType _CgsMatlAcct = CgsMatlAcct;
			UnitCode1Type _CgsMatlAcctUnit1 = CgsMatlAcctUnit1;
			UnitCode2Type _CgsMatlAcctUnit2 = CgsMatlAcctUnit2;
			UnitCode3Type _CgsMatlAcctUnit3 = CgsMatlAcctUnit3;
			UnitCode4Type _CgsMatlAcctUnit4 = CgsMatlAcctUnit4;
			AcctType _CgsLbrAcct = CgsLbrAcct;
			UnitCode1Type _CgsLbrAcctUnit1 = CgsLbrAcctUnit1;
			UnitCode2Type _CgsLbrAcctUnit2 = CgsLbrAcctUnit2;
			UnitCode3Type _CgsLbrAcctUnit3 = CgsLbrAcctUnit3;
			UnitCode4Type _CgsLbrAcctUnit4 = CgsLbrAcctUnit4;
			AcctType _CgsFovAcct = CgsFovAcct;
			UnitCode1Type _CgsFovAcctUnit1 = CgsFovAcctUnit1;
			UnitCode2Type _CgsFovAcctUnit2 = CgsFovAcctUnit2;
			UnitCode3Type _CgsFovAcctUnit3 = CgsFovAcctUnit3;
			UnitCode4Type _CgsFovAcctUnit4 = CgsFovAcctUnit4;
			AcctType _CgsVovAcct = CgsVovAcct;
			UnitCode1Type _CgsVovAcctUnit1 = CgsVovAcctUnit1;
			UnitCode2Type _CgsVovAcctUnit2 = CgsVovAcctUnit2;
			UnitCode3Type _CgsVovAcctUnit3 = CgsVovAcctUnit3;
			UnitCode4Type _CgsVovAcctUnit4 = CgsVovAcctUnit4;
			AcctType _CgsOutAcct = CgsOutAcct;
			UnitCode1Type _CgsOutAcctUnit1 = CgsOutAcctUnit1;
			UnitCode2Type _CgsOutAcctUnit2 = CgsOutAcctUnit2;
			UnitCode3Type _CgsOutAcctUnit3 = CgsOutAcctUnit3;
			UnitCode4Type _CgsOutAcctUnit4 = CgsOutAcctUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXDispSetCGSSp";
				
				appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CgsMatlAcct", _CgsMatlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsMatlAcctUnit1", _CgsMatlAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsMatlAcctUnit2", _CgsMatlAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsMatlAcctUnit3", _CgsMatlAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsMatlAcctUnit4", _CgsMatlAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsLbrAcct", _CgsLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsLbrAcctUnit1", _CgsLbrAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsLbrAcctUnit2", _CgsLbrAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsLbrAcctUnit3", _CgsLbrAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsLbrAcctUnit4", _CgsLbrAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsFovAcct", _CgsFovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsFovAcctUnit1", _CgsFovAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsFovAcctUnit2", _CgsFovAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsFovAcctUnit3", _CgsFovAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsFovAcctUnit4", _CgsFovAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsVovAcct", _CgsVovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsVovAcctUnit1", _CgsVovAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsVovAcctUnit2", _CgsVovAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsVovAcctUnit3", _CgsVovAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsVovAcctUnit4", _CgsVovAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsOutAcct", _CgsOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsOutAcctUnit1", _CgsOutAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsOutAcctUnit2", _CgsOutAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsOutAcctUnit3", _CgsOutAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CgsOutAcctUnit4", _CgsOutAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CgsMatlAcct = _CgsMatlAcct;
				CgsMatlAcctUnit1 = _CgsMatlAcctUnit1;
				CgsMatlAcctUnit2 = _CgsMatlAcctUnit2;
				CgsMatlAcctUnit3 = _CgsMatlAcctUnit3;
				CgsMatlAcctUnit4 = _CgsMatlAcctUnit4;
				CgsLbrAcct = _CgsLbrAcct;
				CgsLbrAcctUnit1 = _CgsLbrAcctUnit1;
				CgsLbrAcctUnit2 = _CgsLbrAcctUnit2;
				CgsLbrAcctUnit3 = _CgsLbrAcctUnit3;
				CgsLbrAcctUnit4 = _CgsLbrAcctUnit4;
				CgsFovAcct = _CgsFovAcct;
				CgsFovAcctUnit1 = _CgsFovAcctUnit1;
				CgsFovAcctUnit2 = _CgsFovAcctUnit2;
				CgsFovAcctUnit3 = _CgsFovAcctUnit3;
				CgsFovAcctUnit4 = _CgsFovAcctUnit4;
				CgsVovAcct = _CgsVovAcct;
				CgsVovAcctUnit1 = _CgsVovAcctUnit1;
				CgsVovAcctUnit2 = _CgsVovAcctUnit2;
				CgsVovAcctUnit3 = _CgsVovAcctUnit3;
				CgsVovAcctUnit4 = _CgsVovAcctUnit4;
				CgsOutAcct = _CgsOutAcct;
				CgsOutAcctUnit1 = _CgsOutAcctUnit1;
				CgsOutAcctUnit2 = _CgsOutAcctUnit2;
				CgsOutAcctUnit3 = _CgsOutAcctUnit3;
				CgsOutAcctUnit4 = _CgsOutAcctUnit4;
				Infobar = _Infobar;
				
				return (Severity, CgsMatlAcct, CgsMatlAcctUnit1, CgsMatlAcctUnit2, CgsMatlAcctUnit3, CgsMatlAcctUnit4, CgsLbrAcct, CgsLbrAcctUnit1, CgsLbrAcctUnit2, CgsLbrAcctUnit3, CgsLbrAcctUnit4, CgsFovAcct, CgsFovAcctUnit1, CgsFovAcctUnit2, CgsFovAcctUnit3, CgsFovAcctUnit4, CgsVovAcct, CgsVovAcctUnit1, CgsVovAcctUnit2, CgsVovAcctUnit3, CgsVovAcctUnit4, CgsOutAcct, CgsOutAcctUnit1, CgsOutAcctUnit2, CgsOutAcctUnit3, CgsOutAcctUnit4, Infobar);
			}
		}
	}
}
