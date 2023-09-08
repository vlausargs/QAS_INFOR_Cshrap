//PROJECT NAME: Material
//CLASS NAME: istkrGetValLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IistkrGetValLoc
	{
		(int? ReturnCode, byte? EnableNonNet, string InvAcct, string InvAcctUnit1, string InvAcctUnit2, string InvAcctUnit3, string InvAcctUnit4, string InvAcctAccessUnit1, string InvAcctAccessUnit2, string InvAcctAccessUnit3, string InvAcctAccessUnit4, string InvAcctDesc, string LbrAcct, string LbrAcctUnit1, string LbrAcctUnit2, string lbrAcctUnit3, string LbrAcctUnit4, string LbrAcctAccessUnit1, string LbrAcctAccessUnit2, string LbrAcctAccessUnit3, string LbrAcctAccessUnit4, string LbrAcctDesc, string FovhdAcct, string FovhdAcctUnit1, string FovhdAcctUnit2, string FovhdAcctUnit3, string FovhdAcctUnit4, string FovhdAcctAccessUnit1, string FovhdAcctAccessUnit2, string FovhdAcctAccessUnit3, string FovhdAcctAccessUnit4, string FovhdAcctDesc, string VovhdAcct, string VovhdAcctUnit1, string VovhdAcctUnit2, string VovhdAcctUnit3, string VovhdAcctUnit4, string VovhdAcctAccessUnit1, string VovhdAcctAccessUnit2, string VovhdAcctAccessUnit3, string VovhdAcctAccessUnit4, string VovhdAcctDesc, string OutAcct, string OutAcctUnit1, string OutAcctUnit2, string OutAcctUnit3, string OutAcctUnit4, string OutAcctAccessUnit1, string OutAcctAccessUnit2, string OutAcctAccessUnit3, string OutAcctAccessUnit4, string OutAcctDesc, string Infobar, string IPInvAcct, string IPInvAcctUnit1, string IPInvAcctUnit2, string IPInvAcctUnit3, string IPInvAcctUnit4, string IPInvAcctAccessUnit1, string IPInvAcctAccessUnit2, string IPInvAcctAccessUnit3, string IPInvAcctAccessUnit4, string IPInvAcctDesc, string IPLbrAcct, string IPLbrAcctUnit1, string IPLbrAcctUnit2, string IPLbrAcctUnit3, string IPLbrAcctUnit4, string IPLbrAcctAccessUnit1, string IPLbrAcctAccessUnit2, string IPLbrAcctAccessUnit3, string IPLbrAcctAccessUnit4, string IPLbrAcctDesc, string IPFovhdAcct, string IPFovhdAcctUnit1, string IPFovhdAcctUnit2, string IPFovhdAcctUnit3, string IPFovhdAcctUnit4, string IPFovhdAcctAccessUnit1, string IPFovhdAcctAccessUnit2, string IPFovhdAcctAccessUnit3, string IPFovhdAcctAccessUnit4, string IPFovhdAcctDesc, string IPVovhdAcct, string IPVovhdAcctUnit1, string IPVovhdAcctUnit2, string IPVovhdAcctUnit3, string IPVovhdAcctUnit4, string IPVovhdAcctAccessUnit1, string IPVovhdAcctAccessUnit2, string IPVovhdAcctAccessUnit3, string IPVovhdAcctAccessUnit4, string IPVovhdAcctDesc, string IPOutAcct, string IPOutAcctUnit1, string IPOutAcctUnit2, string IPOutAcctUnit3, string IPOutAcctUnit4, string IPOutAcctAccessUnit1, string IPOutAcctAccessUnit2, string IPOutAcctAccessUnit3, string IPOutAcctAccessUnit4, string IPOutAcctDesc) istkrGetValLocSp(string Whse = null,
		string Item = null,
		string LocType = null,
		string Loc = null,
		byte? EnableNonNet = null,
		string InvAcct = null,
		string InvAcctUnit1 = null,
		string InvAcctUnit2 = null,
		string InvAcctUnit3 = null,
		string InvAcctUnit4 = null,
		string InvAcctAccessUnit1 = null,
		string InvAcctAccessUnit2 = null,
		string InvAcctAccessUnit3 = null,
		string InvAcctAccessUnit4 = null,
		string InvAcctDesc = null,
		string LbrAcct = null,
		string LbrAcctUnit1 = null,
		string LbrAcctUnit2 = null,
		string lbrAcctUnit3 = null,
		string LbrAcctUnit4 = null,
		string LbrAcctAccessUnit1 = null,
		string LbrAcctAccessUnit2 = null,
		string LbrAcctAccessUnit3 = null,
		string LbrAcctAccessUnit4 = null,
		string LbrAcctDesc = null,
		string FovhdAcct = null,
		string FovhdAcctUnit1 = null,
		string FovhdAcctUnit2 = null,
		string FovhdAcctUnit3 = null,
		string FovhdAcctUnit4 = null,
		string FovhdAcctAccessUnit1 = null,
		string FovhdAcctAccessUnit2 = null,
		string FovhdAcctAccessUnit3 = null,
		string FovhdAcctAccessUnit4 = null,
		string FovhdAcctDesc = null,
		string VovhdAcct = null,
		string VovhdAcctUnit1 = null,
		string VovhdAcctUnit2 = null,
		string VovhdAcctUnit3 = null,
		string VovhdAcctUnit4 = null,
		string VovhdAcctAccessUnit1 = null,
		string VovhdAcctAccessUnit2 = null,
		string VovhdAcctAccessUnit3 = null,
		string VovhdAcctAccessUnit4 = null,
		string VovhdAcctDesc = null,
		string OutAcct = null,
		string OutAcctUnit1 = null,
		string OutAcctUnit2 = null,
		string OutAcctUnit3 = null,
		string OutAcctUnit4 = null,
		string OutAcctAccessUnit1 = null,
		string OutAcctAccessUnit2 = null,
		string OutAcctAccessUnit3 = null,
		string OutAcctAccessUnit4 = null,
		string OutAcctDesc = null,
		string Action = null,
		string Infobar = null,
		string IPInvAcct = null,
		string IPInvAcctUnit1 = null,
		string IPInvAcctUnit2 = null,
		string IPInvAcctUnit3 = null,
		string IPInvAcctUnit4 = null,
		string IPInvAcctAccessUnit1 = null,
		string IPInvAcctAccessUnit2 = null,
		string IPInvAcctAccessUnit3 = null,
		string IPInvAcctAccessUnit4 = null,
		string IPInvAcctDesc = null,
		string IPLbrAcct = null,
		string IPLbrAcctUnit1 = null,
		string IPLbrAcctUnit2 = null,
		string IPLbrAcctUnit3 = null,
		string IPLbrAcctUnit4 = null,
		string IPLbrAcctAccessUnit1 = null,
		string IPLbrAcctAccessUnit2 = null,
		string IPLbrAcctAccessUnit3 = null,
		string IPLbrAcctAccessUnit4 = null,
		string IPLbrAcctDesc = null,
		string IPFovhdAcct = null,
		string IPFovhdAcctUnit1 = null,
		string IPFovhdAcctUnit2 = null,
		string IPFovhdAcctUnit3 = null,
		string IPFovhdAcctUnit4 = null,
		string IPFovhdAcctAccessUnit1 = null,
		string IPFovhdAcctAccessUnit2 = null,
		string IPFovhdAcctAccessUnit3 = null,
		string IPFovhdAcctAccessUnit4 = null,
		string IPFovhdAcctDesc = null,
		string IPVovhdAcct = null,
		string IPVovhdAcctUnit1 = null,
		string IPVovhdAcctUnit2 = null,
		string IPVovhdAcctUnit3 = null,
		string IPVovhdAcctUnit4 = null,
		string IPVovhdAcctAccessUnit1 = null,
		string IPVovhdAcctAccessUnit2 = null,
		string IPVovhdAcctAccessUnit3 = null,
		string IPVovhdAcctAccessUnit4 = null,
		string IPVovhdAcctDesc = null,
		string IPOutAcct = null,
		string IPOutAcctUnit1 = null,
		string IPOutAcctUnit2 = null,
		string IPOutAcctUnit3 = null,
		string IPOutAcctUnit4 = null,
		string IPOutAcctAccessUnit1 = null,
		string IPOutAcctAccessUnit2 = null,
		string IPOutAcctAccessUnit3 = null,
		string IPOutAcctAccessUnit4 = null,
		string IPOutAcctDesc = null);
	}
	
	public class istkrGetValLoc : IistkrGetValLoc
	{
		readonly IApplicationDB appDB;
		
		public istkrGetValLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? EnableNonNet, string InvAcct, string InvAcctUnit1, string InvAcctUnit2, string InvAcctUnit3, string InvAcctUnit4, string InvAcctAccessUnit1, string InvAcctAccessUnit2, string InvAcctAccessUnit3, string InvAcctAccessUnit4, string InvAcctDesc, string LbrAcct, string LbrAcctUnit1, string LbrAcctUnit2, string lbrAcctUnit3, string LbrAcctUnit4, string LbrAcctAccessUnit1, string LbrAcctAccessUnit2, string LbrAcctAccessUnit3, string LbrAcctAccessUnit4, string LbrAcctDesc, string FovhdAcct, string FovhdAcctUnit1, string FovhdAcctUnit2, string FovhdAcctUnit3, string FovhdAcctUnit4, string FovhdAcctAccessUnit1, string FovhdAcctAccessUnit2, string FovhdAcctAccessUnit3, string FovhdAcctAccessUnit4, string FovhdAcctDesc, string VovhdAcct, string VovhdAcctUnit1, string VovhdAcctUnit2, string VovhdAcctUnit3, string VovhdAcctUnit4, string VovhdAcctAccessUnit1, string VovhdAcctAccessUnit2, string VovhdAcctAccessUnit3, string VovhdAcctAccessUnit4, string VovhdAcctDesc, string OutAcct, string OutAcctUnit1, string OutAcctUnit2, string OutAcctUnit3, string OutAcctUnit4, string OutAcctAccessUnit1, string OutAcctAccessUnit2, string OutAcctAccessUnit3, string OutAcctAccessUnit4, string OutAcctDesc, string Infobar, string IPInvAcct, string IPInvAcctUnit1, string IPInvAcctUnit2, string IPInvAcctUnit3, string IPInvAcctUnit4, string IPInvAcctAccessUnit1, string IPInvAcctAccessUnit2, string IPInvAcctAccessUnit3, string IPInvAcctAccessUnit4, string IPInvAcctDesc, string IPLbrAcct, string IPLbrAcctUnit1, string IPLbrAcctUnit2, string IPLbrAcctUnit3, string IPLbrAcctUnit4, string IPLbrAcctAccessUnit1, string IPLbrAcctAccessUnit2, string IPLbrAcctAccessUnit3, string IPLbrAcctAccessUnit4, string IPLbrAcctDesc, string IPFovhdAcct, string IPFovhdAcctUnit1, string IPFovhdAcctUnit2, string IPFovhdAcctUnit3, string IPFovhdAcctUnit4, string IPFovhdAcctAccessUnit1, string IPFovhdAcctAccessUnit2, string IPFovhdAcctAccessUnit3, string IPFovhdAcctAccessUnit4, string IPFovhdAcctDesc, string IPVovhdAcct, string IPVovhdAcctUnit1, string IPVovhdAcctUnit2, string IPVovhdAcctUnit3, string IPVovhdAcctUnit4, string IPVovhdAcctAccessUnit1, string IPVovhdAcctAccessUnit2, string IPVovhdAcctAccessUnit3, string IPVovhdAcctAccessUnit4, string IPVovhdAcctDesc, string IPOutAcct, string IPOutAcctUnit1, string IPOutAcctUnit2, string IPOutAcctUnit3, string IPOutAcctUnit4, string IPOutAcctAccessUnit1, string IPOutAcctAccessUnit2, string IPOutAcctAccessUnit3, string IPOutAcctAccessUnit4, string IPOutAcctDesc) istkrGetValLocSp(string Whse = null,
		string Item = null,
		string LocType = null,
		string Loc = null,
		byte? EnableNonNet = null,
		string InvAcct = null,
		string InvAcctUnit1 = null,
		string InvAcctUnit2 = null,
		string InvAcctUnit3 = null,
		string InvAcctUnit4 = null,
		string InvAcctAccessUnit1 = null,
		string InvAcctAccessUnit2 = null,
		string InvAcctAccessUnit3 = null,
		string InvAcctAccessUnit4 = null,
		string InvAcctDesc = null,
		string LbrAcct = null,
		string LbrAcctUnit1 = null,
		string LbrAcctUnit2 = null,
		string lbrAcctUnit3 = null,
		string LbrAcctUnit4 = null,
		string LbrAcctAccessUnit1 = null,
		string LbrAcctAccessUnit2 = null,
		string LbrAcctAccessUnit3 = null,
		string LbrAcctAccessUnit4 = null,
		string LbrAcctDesc = null,
		string FovhdAcct = null,
		string FovhdAcctUnit1 = null,
		string FovhdAcctUnit2 = null,
		string FovhdAcctUnit3 = null,
		string FovhdAcctUnit4 = null,
		string FovhdAcctAccessUnit1 = null,
		string FovhdAcctAccessUnit2 = null,
		string FovhdAcctAccessUnit3 = null,
		string FovhdAcctAccessUnit4 = null,
		string FovhdAcctDesc = null,
		string VovhdAcct = null,
		string VovhdAcctUnit1 = null,
		string VovhdAcctUnit2 = null,
		string VovhdAcctUnit3 = null,
		string VovhdAcctUnit4 = null,
		string VovhdAcctAccessUnit1 = null,
		string VovhdAcctAccessUnit2 = null,
		string VovhdAcctAccessUnit3 = null,
		string VovhdAcctAccessUnit4 = null,
		string VovhdAcctDesc = null,
		string OutAcct = null,
		string OutAcctUnit1 = null,
		string OutAcctUnit2 = null,
		string OutAcctUnit3 = null,
		string OutAcctUnit4 = null,
		string OutAcctAccessUnit1 = null,
		string OutAcctAccessUnit2 = null,
		string OutAcctAccessUnit3 = null,
		string OutAcctAccessUnit4 = null,
		string OutAcctDesc = null,
		string Action = null,
		string Infobar = null,
		string IPInvAcct = null,
		string IPInvAcctUnit1 = null,
		string IPInvAcctUnit2 = null,
		string IPInvAcctUnit3 = null,
		string IPInvAcctUnit4 = null,
		string IPInvAcctAccessUnit1 = null,
		string IPInvAcctAccessUnit2 = null,
		string IPInvAcctAccessUnit3 = null,
		string IPInvAcctAccessUnit4 = null,
		string IPInvAcctDesc = null,
		string IPLbrAcct = null,
		string IPLbrAcctUnit1 = null,
		string IPLbrAcctUnit2 = null,
		string IPLbrAcctUnit3 = null,
		string IPLbrAcctUnit4 = null,
		string IPLbrAcctAccessUnit1 = null,
		string IPLbrAcctAccessUnit2 = null,
		string IPLbrAcctAccessUnit3 = null,
		string IPLbrAcctAccessUnit4 = null,
		string IPLbrAcctDesc = null,
		string IPFovhdAcct = null,
		string IPFovhdAcctUnit1 = null,
		string IPFovhdAcctUnit2 = null,
		string IPFovhdAcctUnit3 = null,
		string IPFovhdAcctUnit4 = null,
		string IPFovhdAcctAccessUnit1 = null,
		string IPFovhdAcctAccessUnit2 = null,
		string IPFovhdAcctAccessUnit3 = null,
		string IPFovhdAcctAccessUnit4 = null,
		string IPFovhdAcctDesc = null,
		string IPVovhdAcct = null,
		string IPVovhdAcctUnit1 = null,
		string IPVovhdAcctUnit2 = null,
		string IPVovhdAcctUnit3 = null,
		string IPVovhdAcctUnit4 = null,
		string IPVovhdAcctAccessUnit1 = null,
		string IPVovhdAcctAccessUnit2 = null,
		string IPVovhdAcctAccessUnit3 = null,
		string IPVovhdAcctAccessUnit4 = null,
		string IPVovhdAcctDesc = null,
		string IPOutAcct = null,
		string IPOutAcctUnit1 = null,
		string IPOutAcctUnit2 = null,
		string IPOutAcctUnit3 = null,
		string IPOutAcctUnit4 = null,
		string IPOutAcctAccessUnit1 = null,
		string IPOutAcctAccessUnit2 = null,
		string IPOutAcctAccessUnit3 = null,
		string IPOutAcctAccessUnit4 = null,
		string IPOutAcctDesc = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocTypeType _LocType = LocType;
			LocType _Loc = Loc;
			ListYesNoType _EnableNonNet = EnableNonNet;
			AcctType _InvAcct = InvAcct;
			UnitCode1Type _InvAcctUnit1 = InvAcctUnit1;
			UnitCode2Type _InvAcctUnit2 = InvAcctUnit2;
			UnitCode3Type _InvAcctUnit3 = InvAcctUnit3;
			UnitCode4Type _InvAcctUnit4 = InvAcctUnit4;
			UnitCodeAccessType _InvAcctAccessUnit1 = InvAcctAccessUnit1;
			UnitCodeAccessType _InvAcctAccessUnit2 = InvAcctAccessUnit2;
			UnitCodeAccessType _InvAcctAccessUnit3 = InvAcctAccessUnit3;
			UnitCodeAccessType _InvAcctAccessUnit4 = InvAcctAccessUnit4;
			DescriptionType _InvAcctDesc = InvAcctDesc;
			AcctType _LbrAcct = LbrAcct;
			UnitCode1Type _LbrAcctUnit1 = LbrAcctUnit1;
			UnitCode2Type _LbrAcctUnit2 = LbrAcctUnit2;
			UnitCode3Type _lbrAcctUnit3 = lbrAcctUnit3;
			UnitCode4Type _LbrAcctUnit4 = LbrAcctUnit4;
			UnitCodeAccessType _LbrAcctAccessUnit1 = LbrAcctAccessUnit1;
			UnitCodeAccessType _LbrAcctAccessUnit2 = LbrAcctAccessUnit2;
			UnitCodeAccessType _LbrAcctAccessUnit3 = LbrAcctAccessUnit3;
			UnitCodeAccessType _LbrAcctAccessUnit4 = LbrAcctAccessUnit4;
			DescriptionType _LbrAcctDesc = LbrAcctDesc;
			AcctType _FovhdAcct = FovhdAcct;
			UnitCode1Type _FovhdAcctUnit1 = FovhdAcctUnit1;
			UnitCode1Type _FovhdAcctUnit2 = FovhdAcctUnit2;
			UnitCode1Type _FovhdAcctUnit3 = FovhdAcctUnit3;
			UnitCode1Type _FovhdAcctUnit4 = FovhdAcctUnit4;
			UnitCodeAccessType _FovhdAcctAccessUnit1 = FovhdAcctAccessUnit1;
			UnitCodeAccessType _FovhdAcctAccessUnit2 = FovhdAcctAccessUnit2;
			UnitCodeAccessType _FovhdAcctAccessUnit3 = FovhdAcctAccessUnit3;
			UnitCodeAccessType _FovhdAcctAccessUnit4 = FovhdAcctAccessUnit4;
			DescriptionType _FovhdAcctDesc = FovhdAcctDesc;
			AcctType _VovhdAcct = VovhdAcct;
			UnitCode1Type _VovhdAcctUnit1 = VovhdAcctUnit1;
			UnitCode2Type _VovhdAcctUnit2 = VovhdAcctUnit2;
			UnitCode3Type _VovhdAcctUnit3 = VovhdAcctUnit3;
			UnitCode4Type _VovhdAcctUnit4 = VovhdAcctUnit4;
			UnitCodeAccessType _VovhdAcctAccessUnit1 = VovhdAcctAccessUnit1;
			UnitCodeAccessType _VovhdAcctAccessUnit2 = VovhdAcctAccessUnit2;
			UnitCodeAccessType _VovhdAcctAccessUnit3 = VovhdAcctAccessUnit3;
			UnitCodeAccessType _VovhdAcctAccessUnit4 = VovhdAcctAccessUnit4;
			DescriptionType _VovhdAcctDesc = VovhdAcctDesc;
			AcctType _OutAcct = OutAcct;
			UnitCode1Type _OutAcctUnit1 = OutAcctUnit1;
			UnitCode2Type _OutAcctUnit2 = OutAcctUnit2;
			UnitCode3Type _OutAcctUnit3 = OutAcctUnit3;
			UnitCode4Type _OutAcctUnit4 = OutAcctUnit4;
			UnitCodeAccessType _OutAcctAccessUnit1 = OutAcctAccessUnit1;
			UnitCodeAccessType _OutAcctAccessUnit2 = OutAcctAccessUnit2;
			UnitCodeAccessType _OutAcctAccessUnit3 = OutAcctAccessUnit3;
			UnitCodeAccessType _OutAcctAccessUnit4 = OutAcctAccessUnit4;
			DescriptionType _OutAcctDesc = OutAcctDesc;
			StringType _Action = Action;
			InfobarType _Infobar = Infobar;
			AcctType _IPInvAcct = IPInvAcct;
			UnitCode1Type _IPInvAcctUnit1 = IPInvAcctUnit1;
			UnitCode2Type _IPInvAcctUnit2 = IPInvAcctUnit2;
			UnitCode3Type _IPInvAcctUnit3 = IPInvAcctUnit3;
			UnitCode4Type _IPInvAcctUnit4 = IPInvAcctUnit4;
			UnitCodeAccessType _IPInvAcctAccessUnit1 = IPInvAcctAccessUnit1;
			UnitCodeAccessType _IPInvAcctAccessUnit2 = IPInvAcctAccessUnit2;
			UnitCodeAccessType _IPInvAcctAccessUnit3 = IPInvAcctAccessUnit3;
			UnitCodeAccessType _IPInvAcctAccessUnit4 = IPInvAcctAccessUnit4;
			DescriptionType _IPInvAcctDesc = IPInvAcctDesc;
			AcctType _IPLbrAcct = IPLbrAcct;
			UnitCode1Type _IPLbrAcctUnit1 = IPLbrAcctUnit1;
			UnitCode2Type _IPLbrAcctUnit2 = IPLbrAcctUnit2;
			UnitCode3Type _IPLbrAcctUnit3 = IPLbrAcctUnit3;
			UnitCode4Type _IPLbrAcctUnit4 = IPLbrAcctUnit4;
			UnitCodeAccessType _IPLbrAcctAccessUnit1 = IPLbrAcctAccessUnit1;
			UnitCodeAccessType _IPLbrAcctAccessUnit2 = IPLbrAcctAccessUnit2;
			UnitCodeAccessType _IPLbrAcctAccessUnit3 = IPLbrAcctAccessUnit3;
			UnitCodeAccessType _IPLbrAcctAccessUnit4 = IPLbrAcctAccessUnit4;
			DescriptionType _IPLbrAcctDesc = IPLbrAcctDesc;
			AcctType _IPFovhdAcct = IPFovhdAcct;
			UnitCode1Type _IPFovhdAcctUnit1 = IPFovhdAcctUnit1;
			UnitCode1Type _IPFovhdAcctUnit2 = IPFovhdAcctUnit2;
			UnitCode1Type _IPFovhdAcctUnit3 = IPFovhdAcctUnit3;
			UnitCode1Type _IPFovhdAcctUnit4 = IPFovhdAcctUnit4;
			UnitCodeAccessType _IPFovhdAcctAccessUnit1 = IPFovhdAcctAccessUnit1;
			UnitCodeAccessType _IPFovhdAcctAccessUnit2 = IPFovhdAcctAccessUnit2;
			UnitCodeAccessType _IPFovhdAcctAccessUnit3 = IPFovhdAcctAccessUnit3;
			UnitCodeAccessType _IPFovhdAcctAccessUnit4 = IPFovhdAcctAccessUnit4;
			DescriptionType _IPFovhdAcctDesc = IPFovhdAcctDesc;
			AcctType _IPVovhdAcct = IPVovhdAcct;
			UnitCode1Type _IPVovhdAcctUnit1 = IPVovhdAcctUnit1;
			UnitCode2Type _IPVovhdAcctUnit2 = IPVovhdAcctUnit2;
			UnitCode3Type _IPVovhdAcctUnit3 = IPVovhdAcctUnit3;
			UnitCode4Type _IPVovhdAcctUnit4 = IPVovhdAcctUnit4;
			UnitCodeAccessType _IPVovhdAcctAccessUnit1 = IPVovhdAcctAccessUnit1;
			UnitCodeAccessType _IPVovhdAcctAccessUnit2 = IPVovhdAcctAccessUnit2;
			UnitCodeAccessType _IPVovhdAcctAccessUnit3 = IPVovhdAcctAccessUnit3;
			UnitCodeAccessType _IPVovhdAcctAccessUnit4 = IPVovhdAcctAccessUnit4;
			DescriptionType _IPVovhdAcctDesc = IPVovhdAcctDesc;
			AcctType _IPOutAcct = IPOutAcct;
			UnitCode1Type _IPOutAcctUnit1 = IPOutAcctUnit1;
			UnitCode2Type _IPOutAcctUnit2 = IPOutAcctUnit2;
			UnitCode3Type _IPOutAcctUnit3 = IPOutAcctUnit3;
			UnitCode4Type _IPOutAcctUnit4 = IPOutAcctUnit4;
			UnitCodeAccessType _IPOutAcctAccessUnit1 = IPOutAcctAccessUnit1;
			UnitCodeAccessType _IPOutAcctAccessUnit2 = IPOutAcctAccessUnit2;
			UnitCodeAccessType _IPOutAcctAccessUnit3 = IPOutAcctAccessUnit3;
			UnitCodeAccessType _IPOutAcctAccessUnit4 = IPOutAcctAccessUnit4;
			DescriptionType _IPOutAcctDesc = IPOutAcctDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrGetValLocSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocType", _LocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EnableNonNet", _EnableNonNet, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcct", _InvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctUnit1", _InvAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctUnit2", _InvAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctUnit3", _InvAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctUnit4", _InvAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctAccessUnit1", _InvAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctAccessUnit2", _InvAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctAccessUnit3", _InvAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctAccessUnit4", _InvAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAcctDesc", _InvAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcct", _LbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcctUnit1", _LbrAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcctUnit2", _LbrAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "lbrAcctUnit3", _lbrAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcctUnit4", _LbrAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcctAccessUnit1", _LbrAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcctAccessUnit2", _LbrAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcctAccessUnit3", _LbrAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcctAccessUnit4", _LbrAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrAcctDesc", _LbrAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcct", _FovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctUnit1", _FovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctUnit2", _FovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctUnit3", _FovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctUnit4", _FovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctAccessUnit1", _FovhdAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctAccessUnit2", _FovhdAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctAccessUnit3", _FovhdAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctAccessUnit4", _FovhdAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdAcctDesc", _FovhdAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcct", _VovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctUnit1", _VovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctUnit2", _VovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctUnit3", _VovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctUnit4", _VovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctAccessUnit1", _VovhdAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctAccessUnit2", _VovhdAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctAccessUnit3", _VovhdAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctAccessUnit4", _VovhdAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdAcctDesc", _VovhdAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcct", _OutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctUnit1", _OutAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctUnit2", _OutAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctUnit3", _OutAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctUnit4", _OutAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctAccessUnit1", _OutAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctAccessUnit2", _OutAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctAccessUnit3", _OutAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctAccessUnit4", _OutAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutAcctDesc", _OutAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcct", _IPInvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctUnit1", _IPInvAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctUnit2", _IPInvAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctUnit3", _IPInvAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctUnit4", _IPInvAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctAccessUnit1", _IPInvAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctAccessUnit2", _IPInvAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctAccessUnit3", _IPInvAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctAccessUnit4", _IPInvAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPInvAcctDesc", _IPInvAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcct", _IPLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctUnit1", _IPLbrAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctUnit2", _IPLbrAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctUnit3", _IPLbrAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctUnit4", _IPLbrAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctAccessUnit1", _IPLbrAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctAccessUnit2", _IPLbrAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctAccessUnit3", _IPLbrAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctAccessUnit4", _IPLbrAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPLbrAcctDesc", _IPLbrAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcct", _IPFovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctUnit1", _IPFovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctUnit2", _IPFovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctUnit3", _IPFovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctUnit4", _IPFovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctAccessUnit1", _IPFovhdAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctAccessUnit2", _IPFovhdAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctAccessUnit3", _IPFovhdAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctAccessUnit4", _IPFovhdAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPFovhdAcctDesc", _IPFovhdAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcct", _IPVovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctUnit1", _IPVovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctUnit2", _IPVovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctUnit3", _IPVovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctUnit4", _IPVovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctAccessUnit1", _IPVovhdAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctAccessUnit2", _IPVovhdAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctAccessUnit3", _IPVovhdAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctAccessUnit4", _IPVovhdAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPVovhdAcctDesc", _IPVovhdAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcct", _IPOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctUnit1", _IPOutAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctUnit2", _IPOutAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctUnit3", _IPOutAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctUnit4", _IPOutAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctAccessUnit1", _IPOutAcctAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctAccessUnit2", _IPOutAcctAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctAccessUnit3", _IPOutAcctAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctAccessUnit4", _IPOutAcctAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IPOutAcctDesc", _IPOutAcctDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EnableNonNet = _EnableNonNet;
				InvAcct = _InvAcct;
				InvAcctUnit1 = _InvAcctUnit1;
				InvAcctUnit2 = _InvAcctUnit2;
				InvAcctUnit3 = _InvAcctUnit3;
				InvAcctUnit4 = _InvAcctUnit4;
				InvAcctAccessUnit1 = _InvAcctAccessUnit1;
				InvAcctAccessUnit2 = _InvAcctAccessUnit2;
				InvAcctAccessUnit3 = _InvAcctAccessUnit3;
				InvAcctAccessUnit4 = _InvAcctAccessUnit4;
				InvAcctDesc = _InvAcctDesc;
				LbrAcct = _LbrAcct;
				LbrAcctUnit1 = _LbrAcctUnit1;
				LbrAcctUnit2 = _LbrAcctUnit2;
				lbrAcctUnit3 = _lbrAcctUnit3;
				LbrAcctUnit4 = _LbrAcctUnit4;
				LbrAcctAccessUnit1 = _LbrAcctAccessUnit1;
				LbrAcctAccessUnit2 = _LbrAcctAccessUnit2;
				LbrAcctAccessUnit3 = _LbrAcctAccessUnit3;
				LbrAcctAccessUnit4 = _LbrAcctAccessUnit4;
				LbrAcctDesc = _LbrAcctDesc;
				FovhdAcct = _FovhdAcct;
				FovhdAcctUnit1 = _FovhdAcctUnit1;
				FovhdAcctUnit2 = _FovhdAcctUnit2;
				FovhdAcctUnit3 = _FovhdAcctUnit3;
				FovhdAcctUnit4 = _FovhdAcctUnit4;
				FovhdAcctAccessUnit1 = _FovhdAcctAccessUnit1;
				FovhdAcctAccessUnit2 = _FovhdAcctAccessUnit2;
				FovhdAcctAccessUnit3 = _FovhdAcctAccessUnit3;
				FovhdAcctAccessUnit4 = _FovhdAcctAccessUnit4;
				FovhdAcctDesc = _FovhdAcctDesc;
				VovhdAcct = _VovhdAcct;
				VovhdAcctUnit1 = _VovhdAcctUnit1;
				VovhdAcctUnit2 = _VovhdAcctUnit2;
				VovhdAcctUnit3 = _VovhdAcctUnit3;
				VovhdAcctUnit4 = _VovhdAcctUnit4;
				VovhdAcctAccessUnit1 = _VovhdAcctAccessUnit1;
				VovhdAcctAccessUnit2 = _VovhdAcctAccessUnit2;
				VovhdAcctAccessUnit3 = _VovhdAcctAccessUnit3;
				VovhdAcctAccessUnit4 = _VovhdAcctAccessUnit4;
				VovhdAcctDesc = _VovhdAcctDesc;
				OutAcct = _OutAcct;
				OutAcctUnit1 = _OutAcctUnit1;
				OutAcctUnit2 = _OutAcctUnit2;
				OutAcctUnit3 = _OutAcctUnit3;
				OutAcctUnit4 = _OutAcctUnit4;
				OutAcctAccessUnit1 = _OutAcctAccessUnit1;
				OutAcctAccessUnit2 = _OutAcctAccessUnit2;
				OutAcctAccessUnit3 = _OutAcctAccessUnit3;
				OutAcctAccessUnit4 = _OutAcctAccessUnit4;
				OutAcctDesc = _OutAcctDesc;
				Infobar = _Infobar;
				IPInvAcct = _IPInvAcct;
				IPInvAcctUnit1 = _IPInvAcctUnit1;
				IPInvAcctUnit2 = _IPInvAcctUnit2;
				IPInvAcctUnit3 = _IPInvAcctUnit3;
				IPInvAcctUnit4 = _IPInvAcctUnit4;
				IPInvAcctAccessUnit1 = _IPInvAcctAccessUnit1;
				IPInvAcctAccessUnit2 = _IPInvAcctAccessUnit2;
				IPInvAcctAccessUnit3 = _IPInvAcctAccessUnit3;
				IPInvAcctAccessUnit4 = _IPInvAcctAccessUnit4;
				IPInvAcctDesc = _IPInvAcctDesc;
				IPLbrAcct = _IPLbrAcct;
				IPLbrAcctUnit1 = _IPLbrAcctUnit1;
				IPLbrAcctUnit2 = _IPLbrAcctUnit2;
				IPLbrAcctUnit3 = _IPLbrAcctUnit3;
				IPLbrAcctUnit4 = _IPLbrAcctUnit4;
				IPLbrAcctAccessUnit1 = _IPLbrAcctAccessUnit1;
				IPLbrAcctAccessUnit2 = _IPLbrAcctAccessUnit2;
				IPLbrAcctAccessUnit3 = _IPLbrAcctAccessUnit3;
				IPLbrAcctAccessUnit4 = _IPLbrAcctAccessUnit4;
				IPLbrAcctDesc = _IPLbrAcctDesc;
				IPFovhdAcct = _IPFovhdAcct;
				IPFovhdAcctUnit1 = _IPFovhdAcctUnit1;
				IPFovhdAcctUnit2 = _IPFovhdAcctUnit2;
				IPFovhdAcctUnit3 = _IPFovhdAcctUnit3;
				IPFovhdAcctUnit4 = _IPFovhdAcctUnit4;
				IPFovhdAcctAccessUnit1 = _IPFovhdAcctAccessUnit1;
				IPFovhdAcctAccessUnit2 = _IPFovhdAcctAccessUnit2;
				IPFovhdAcctAccessUnit3 = _IPFovhdAcctAccessUnit3;
				IPFovhdAcctAccessUnit4 = _IPFovhdAcctAccessUnit4;
				IPFovhdAcctDesc = _IPFovhdAcctDesc;
				IPVovhdAcct = _IPVovhdAcct;
				IPVovhdAcctUnit1 = _IPVovhdAcctUnit1;
				IPVovhdAcctUnit2 = _IPVovhdAcctUnit2;
				IPVovhdAcctUnit3 = _IPVovhdAcctUnit3;
				IPVovhdAcctUnit4 = _IPVovhdAcctUnit4;
				IPVovhdAcctAccessUnit1 = _IPVovhdAcctAccessUnit1;
				IPVovhdAcctAccessUnit2 = _IPVovhdAcctAccessUnit2;
				IPVovhdAcctAccessUnit3 = _IPVovhdAcctAccessUnit3;
				IPVovhdAcctAccessUnit4 = _IPVovhdAcctAccessUnit4;
				IPVovhdAcctDesc = _IPVovhdAcctDesc;
				IPOutAcct = _IPOutAcct;
				IPOutAcctUnit1 = _IPOutAcctUnit1;
				IPOutAcctUnit2 = _IPOutAcctUnit2;
				IPOutAcctUnit3 = _IPOutAcctUnit3;
				IPOutAcctUnit4 = _IPOutAcctUnit4;
				IPOutAcctAccessUnit1 = _IPOutAcctAccessUnit1;
				IPOutAcctAccessUnit2 = _IPOutAcctAccessUnit2;
				IPOutAcctAccessUnit3 = _IPOutAcctAccessUnit3;
				IPOutAcctAccessUnit4 = _IPOutAcctAccessUnit4;
				IPOutAcctDesc = _IPOutAcctDesc;
				
				return (Severity, EnableNonNet, InvAcct, InvAcctUnit1, InvAcctUnit2, InvAcctUnit3, InvAcctUnit4, InvAcctAccessUnit1, InvAcctAccessUnit2, InvAcctAccessUnit3, InvAcctAccessUnit4, InvAcctDesc, LbrAcct, LbrAcctUnit1, LbrAcctUnit2, lbrAcctUnit3, LbrAcctUnit4, LbrAcctAccessUnit1, LbrAcctAccessUnit2, LbrAcctAccessUnit3, LbrAcctAccessUnit4, LbrAcctDesc, FovhdAcct, FovhdAcctUnit1, FovhdAcctUnit2, FovhdAcctUnit3, FovhdAcctUnit4, FovhdAcctAccessUnit1, FovhdAcctAccessUnit2, FovhdAcctAccessUnit3, FovhdAcctAccessUnit4, FovhdAcctDesc, VovhdAcct, VovhdAcctUnit1, VovhdAcctUnit2, VovhdAcctUnit3, VovhdAcctUnit4, VovhdAcctAccessUnit1, VovhdAcctAccessUnit2, VovhdAcctAccessUnit3, VovhdAcctAccessUnit4, VovhdAcctDesc, OutAcct, OutAcctUnit1, OutAcctUnit2, OutAcctUnit3, OutAcctUnit4, OutAcctAccessUnit1, OutAcctAccessUnit2, OutAcctAccessUnit3, OutAcctAccessUnit4, OutAcctDesc, Infobar, IPInvAcct, IPInvAcctUnit1, IPInvAcctUnit2, IPInvAcctUnit3, IPInvAcctUnit4, IPInvAcctAccessUnit1, IPInvAcctAccessUnit2, IPInvAcctAccessUnit3, IPInvAcctAccessUnit4, IPInvAcctDesc, IPLbrAcct, IPLbrAcctUnit1, IPLbrAcctUnit2, IPLbrAcctUnit3, IPLbrAcctUnit4, IPLbrAcctAccessUnit1, IPLbrAcctAccessUnit2, IPLbrAcctAccessUnit3, IPLbrAcctAccessUnit4, IPLbrAcctDesc, IPFovhdAcct, IPFovhdAcctUnit1, IPFovhdAcctUnit2, IPFovhdAcctUnit3, IPFovhdAcctUnit4, IPFovhdAcctAccessUnit1, IPFovhdAcctAccessUnit2, IPFovhdAcctAccessUnit3, IPFovhdAcctAccessUnit4, IPFovhdAcctDesc, IPVovhdAcct, IPVovhdAcctUnit1, IPVovhdAcctUnit2, IPVovhdAcctUnit3, IPVovhdAcctUnit4, IPVovhdAcctAccessUnit1, IPVovhdAcctAccessUnit2, IPVovhdAcctAccessUnit3, IPVovhdAcctAccessUnit4, IPVovhdAcctDesc, IPOutAcct, IPOutAcctUnit1, IPOutAcctUnit2, IPOutAcctUnit3, IPOutAcctUnit4, IPOutAcctAccessUnit1, IPOutAcctAccessUnit2, IPOutAcctAccessUnit3, IPOutAcctAccessUnit4, IPOutAcctDesc);
			}
		}
	}
}
