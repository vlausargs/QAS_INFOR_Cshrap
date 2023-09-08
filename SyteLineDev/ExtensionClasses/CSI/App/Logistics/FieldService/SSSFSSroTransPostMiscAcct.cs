//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroTransPostMiscAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroTransPostMiscAcct : ISSSFSSroTransPostMiscAcct
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroTransPostMiscAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oCostCode,
			string oDeptUnit,
			string oProdcodeUnit,
			string oWipMatlAcct,
			string oWipMatlUnit1,
			string oWipMatlUnit2,
			string oWipMatlUnit3,
			string oWipMatlUnit4,
			string oWipLbrAcct,
			string oWipLbrUnit1,
			string oWipLbrUnit2,
			string oWipLbrUnit3,
			string oWipLbrUnit4,
			string oWipFovAcct,
			string oWipFovUnit1,
			string oWipFovUnit2,
			string oWipFovUnit3,
			string oWipFovUnit4,
			string oWipVovAcct,
			string oWipVovUnit1,
			string oWipVovUnit2,
			string oWipVovUnit3,
			string oWipVovUnit4,
			string oWipOutAcct,
			string oWipOutUnit1,
			string oWipOutUnit2,
			string oWipOutUnit3,
			string oWipOutUnit4,
			string oExpMatlAcct,
			string oExpMatlUnit1,
			string oExpMatlUnit2,
			string oExpMatlUnit3,
			string oExpMatlUnit4,
			string oExpLbrAcct,
			string oExpLbrUnit1,
			string oExpLbrUnit2,
			string oExpLbrUnit3,
			string oExpLbrUnit4,
			string oExpFovAcct,
			string oExpFovUnit1,
			string oExpFovUnit2,
			string oExpFovUnit3,
			string oExpFovUnit4,
			string oExpVovAcct,
			string oExpVovUnit1,
			string oExpVovUnit2,
			string oExpVovUnit3,
			string oExpVovUnit4,
			string oExpOutAcct,
			string oExpOutUnit1,
			string oExpOutUnit2,
			string oExpOutUnit3,
			string oExpOutUnit4,
			string oRevAcct,
			string oRevUnit1,
			string oRevUnit2,
			string oRevUnit3,
			string oRevUnit4,
			string oSaleDsAcct,
			string oSaleDsUnit1,
			string oSaleDsUnit2,
			string oSaleDsUnit3,
			string oSaleDsUnit4,
			string Infobar) SSSFSSroTransPostMiscAcctSp(
			string iMode,
			Guid? iRowPointer,
			string InSroNum,
			int? InSroLine,
			int? InSroOper,
			string InBillCode,
			string InPartnerId,
			string InMiscCode,
			string InWhse,
			string InDept,
			string oCostCode,
			string oDeptUnit,
			string oProdcodeUnit,
			string oWipMatlAcct,
			string oWipMatlUnit1,
			string oWipMatlUnit2,
			string oWipMatlUnit3,
			string oWipMatlUnit4,
			string oWipLbrAcct,
			string oWipLbrUnit1,
			string oWipLbrUnit2,
			string oWipLbrUnit3,
			string oWipLbrUnit4,
			string oWipFovAcct,
			string oWipFovUnit1,
			string oWipFovUnit2,
			string oWipFovUnit3,
			string oWipFovUnit4,
			string oWipVovAcct,
			string oWipVovUnit1,
			string oWipVovUnit2,
			string oWipVovUnit3,
			string oWipVovUnit4,
			string oWipOutAcct,
			string oWipOutUnit1,
			string oWipOutUnit2,
			string oWipOutUnit3,
			string oWipOutUnit4,
			string oExpMatlAcct,
			string oExpMatlUnit1,
			string oExpMatlUnit2,
			string oExpMatlUnit3,
			string oExpMatlUnit4,
			string oExpLbrAcct,
			string oExpLbrUnit1,
			string oExpLbrUnit2,
			string oExpLbrUnit3,
			string oExpLbrUnit4,
			string oExpFovAcct,
			string oExpFovUnit1,
			string oExpFovUnit2,
			string oExpFovUnit3,
			string oExpFovUnit4,
			string oExpVovAcct,
			string oExpVovUnit1,
			string oExpVovUnit2,
			string oExpVovUnit3,
			string oExpVovUnit4,
			string oExpOutAcct,
			string oExpOutUnit1,
			string oExpOutUnit2,
			string oExpOutUnit3,
			string oExpOutUnit4,
			string oRevAcct,
			string oRevUnit1,
			string oRevUnit2,
			string oRevUnit3,
			string oRevUnit4,
			string oSaleDsAcct,
			string oSaleDsUnit1,
			string oSaleDsUnit2,
			string oSaleDsUnit3,
			string oSaleDsUnit4,
			string Infobar)
		{
			UnusedCharType _iMode = iMode;
			RowPointerType _iRowPointer = iRowPointer;
			FSSRONumType _InSroNum = InSroNum;
			FSSROLineType _InSroLine = InSroLine;
			FSSROOperType _InSroOper = InSroOper;
			FSSROBillCodeType _InBillCode = InBillCode;
			FSPartnerType _InPartnerId = InPartnerId;
			FSMiscCodeType _InMiscCode = InMiscCode;
			WhseType _InWhse = InWhse;
			DeptType _InDept = InDept;
			CostCodeType _oCostCode = oCostCode;
			UnitCode1Type _oDeptUnit = oDeptUnit;
			UnitCode2Type _oProdcodeUnit = oProdcodeUnit;
			AcctType _oWipMatlAcct = oWipMatlAcct;
			UnitCode1Type _oWipMatlUnit1 = oWipMatlUnit1;
			UnitCode2Type _oWipMatlUnit2 = oWipMatlUnit2;
			UnitCode3Type _oWipMatlUnit3 = oWipMatlUnit3;
			UnitCode4Type _oWipMatlUnit4 = oWipMatlUnit4;
			AcctType _oWipLbrAcct = oWipLbrAcct;
			UnitCode1Type _oWipLbrUnit1 = oWipLbrUnit1;
			UnitCode2Type _oWipLbrUnit2 = oWipLbrUnit2;
			UnitCode3Type _oWipLbrUnit3 = oWipLbrUnit3;
			UnitCode4Type _oWipLbrUnit4 = oWipLbrUnit4;
			AcctType _oWipFovAcct = oWipFovAcct;
			UnitCode1Type _oWipFovUnit1 = oWipFovUnit1;
			UnitCode2Type _oWipFovUnit2 = oWipFovUnit2;
			UnitCode3Type _oWipFovUnit3 = oWipFovUnit3;
			UnitCode4Type _oWipFovUnit4 = oWipFovUnit4;
			AcctType _oWipVovAcct = oWipVovAcct;
			UnitCode1Type _oWipVovUnit1 = oWipVovUnit1;
			UnitCode2Type _oWipVovUnit2 = oWipVovUnit2;
			UnitCode3Type _oWipVovUnit3 = oWipVovUnit3;
			UnitCode4Type _oWipVovUnit4 = oWipVovUnit4;
			AcctType _oWipOutAcct = oWipOutAcct;
			UnitCode1Type _oWipOutUnit1 = oWipOutUnit1;
			UnitCode2Type _oWipOutUnit2 = oWipOutUnit2;
			UnitCode3Type _oWipOutUnit3 = oWipOutUnit3;
			UnitCode4Type _oWipOutUnit4 = oWipOutUnit4;
			AcctType _oExpMatlAcct = oExpMatlAcct;
			UnitCode1Type _oExpMatlUnit1 = oExpMatlUnit1;
			UnitCode2Type _oExpMatlUnit2 = oExpMatlUnit2;
			UnitCode3Type _oExpMatlUnit3 = oExpMatlUnit3;
			UnitCode4Type _oExpMatlUnit4 = oExpMatlUnit4;
			AcctType _oExpLbrAcct = oExpLbrAcct;
			UnitCode1Type _oExpLbrUnit1 = oExpLbrUnit1;
			UnitCode2Type _oExpLbrUnit2 = oExpLbrUnit2;
			UnitCode3Type _oExpLbrUnit3 = oExpLbrUnit3;
			UnitCode4Type _oExpLbrUnit4 = oExpLbrUnit4;
			AcctType _oExpFovAcct = oExpFovAcct;
			UnitCode1Type _oExpFovUnit1 = oExpFovUnit1;
			UnitCode2Type _oExpFovUnit2 = oExpFovUnit2;
			UnitCode3Type _oExpFovUnit3 = oExpFovUnit3;
			UnitCode4Type _oExpFovUnit4 = oExpFovUnit4;
			AcctType _oExpVovAcct = oExpVovAcct;
			UnitCode1Type _oExpVovUnit1 = oExpVovUnit1;
			UnitCode2Type _oExpVovUnit2 = oExpVovUnit2;
			UnitCode3Type _oExpVovUnit3 = oExpVovUnit3;
			UnitCode4Type _oExpVovUnit4 = oExpVovUnit4;
			AcctType _oExpOutAcct = oExpOutAcct;
			UnitCode1Type _oExpOutUnit1 = oExpOutUnit1;
			UnitCode2Type _oExpOutUnit2 = oExpOutUnit2;
			UnitCode3Type _oExpOutUnit3 = oExpOutUnit3;
			UnitCode4Type _oExpOutUnit4 = oExpOutUnit4;
			AcctType _oRevAcct = oRevAcct;
			UnitCode1Type _oRevUnit1 = oRevUnit1;
			UnitCode2Type _oRevUnit2 = oRevUnit2;
			UnitCode3Type _oRevUnit3 = oRevUnit3;
			UnitCode4Type _oRevUnit4 = oRevUnit4;
			AcctType _oSaleDsAcct = oSaleDsAcct;
			UnitCode1Type _oSaleDsUnit1 = oSaleDsUnit1;
			UnitCode2Type _oSaleDsUnit2 = oSaleDsUnit2;
			UnitCode3Type _oSaleDsUnit3 = oSaleDsUnit3;
			UnitCode4Type _oSaleDsUnit4 = oSaleDsUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroTransPostMiscAcctSp";
				
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iRowPointer", _iRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroNum", _InSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroLine", _InSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroOper", _InSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InBillCode", _InBillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InPartnerId", _InPartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InMiscCode", _InMiscCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InWhse", _InWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InDept", _InDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oCostCode", _oCostCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oDeptUnit", _oDeptUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oProdcodeUnit", _oProdcodeUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipMatlAcct", _oWipMatlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipMatlUnit1", _oWipMatlUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipMatlUnit2", _oWipMatlUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipMatlUnit3", _oWipMatlUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipMatlUnit4", _oWipMatlUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipLbrAcct", _oWipLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipLbrUnit1", _oWipLbrUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipLbrUnit2", _oWipLbrUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipLbrUnit3", _oWipLbrUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipLbrUnit4", _oWipLbrUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipFovAcct", _oWipFovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipFovUnit1", _oWipFovUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipFovUnit2", _oWipFovUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipFovUnit3", _oWipFovUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipFovUnit4", _oWipFovUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipVovAcct", _oWipVovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipVovUnit1", _oWipVovUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipVovUnit2", _oWipVovUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipVovUnit3", _oWipVovUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipVovUnit4", _oWipVovUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipOutAcct", _oWipOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipOutUnit1", _oWipOutUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipOutUnit2", _oWipOutUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipOutUnit3", _oWipOutUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oWipOutUnit4", _oWipOutUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpMatlAcct", _oExpMatlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpMatlUnit1", _oExpMatlUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpMatlUnit2", _oExpMatlUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpMatlUnit3", _oExpMatlUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpMatlUnit4", _oExpMatlUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpLbrAcct", _oExpLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpLbrUnit1", _oExpLbrUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpLbrUnit2", _oExpLbrUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpLbrUnit3", _oExpLbrUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpLbrUnit4", _oExpLbrUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpFovAcct", _oExpFovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpFovUnit1", _oExpFovUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpFovUnit2", _oExpFovUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpFovUnit3", _oExpFovUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpFovUnit4", _oExpFovUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpVovAcct", _oExpVovAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpVovUnit1", _oExpVovUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpVovUnit2", _oExpVovUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpVovUnit3", _oExpVovUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpVovUnit4", _oExpVovUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpOutAcct", _oExpOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpOutUnit1", _oExpOutUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpOutUnit2", _oExpOutUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpOutUnit3", _oExpOutUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oExpOutUnit4", _oExpOutUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oRevAcct", _oRevAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oRevUnit1", _oRevUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oRevUnit2", _oRevUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oRevUnit3", _oRevUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oRevUnit4", _oRevUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSaleDsAcct", _oSaleDsAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSaleDsUnit1", _oSaleDsUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSaleDsUnit2", _oSaleDsUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSaleDsUnit3", _oSaleDsUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSaleDsUnit4", _oSaleDsUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oCostCode = _oCostCode;
				oDeptUnit = _oDeptUnit;
				oProdcodeUnit = _oProdcodeUnit;
				oWipMatlAcct = _oWipMatlAcct;
				oWipMatlUnit1 = _oWipMatlUnit1;
				oWipMatlUnit2 = _oWipMatlUnit2;
				oWipMatlUnit3 = _oWipMatlUnit3;
				oWipMatlUnit4 = _oWipMatlUnit4;
				oWipLbrAcct = _oWipLbrAcct;
				oWipLbrUnit1 = _oWipLbrUnit1;
				oWipLbrUnit2 = _oWipLbrUnit2;
				oWipLbrUnit3 = _oWipLbrUnit3;
				oWipLbrUnit4 = _oWipLbrUnit4;
				oWipFovAcct = _oWipFovAcct;
				oWipFovUnit1 = _oWipFovUnit1;
				oWipFovUnit2 = _oWipFovUnit2;
				oWipFovUnit3 = _oWipFovUnit3;
				oWipFovUnit4 = _oWipFovUnit4;
				oWipVovAcct = _oWipVovAcct;
				oWipVovUnit1 = _oWipVovUnit1;
				oWipVovUnit2 = _oWipVovUnit2;
				oWipVovUnit3 = _oWipVovUnit3;
				oWipVovUnit4 = _oWipVovUnit4;
				oWipOutAcct = _oWipOutAcct;
				oWipOutUnit1 = _oWipOutUnit1;
				oWipOutUnit2 = _oWipOutUnit2;
				oWipOutUnit3 = _oWipOutUnit3;
				oWipOutUnit4 = _oWipOutUnit4;
				oExpMatlAcct = _oExpMatlAcct;
				oExpMatlUnit1 = _oExpMatlUnit1;
				oExpMatlUnit2 = _oExpMatlUnit2;
				oExpMatlUnit3 = _oExpMatlUnit3;
				oExpMatlUnit4 = _oExpMatlUnit4;
				oExpLbrAcct = _oExpLbrAcct;
				oExpLbrUnit1 = _oExpLbrUnit1;
				oExpLbrUnit2 = _oExpLbrUnit2;
				oExpLbrUnit3 = _oExpLbrUnit3;
				oExpLbrUnit4 = _oExpLbrUnit4;
				oExpFovAcct = _oExpFovAcct;
				oExpFovUnit1 = _oExpFovUnit1;
				oExpFovUnit2 = _oExpFovUnit2;
				oExpFovUnit3 = _oExpFovUnit3;
				oExpFovUnit4 = _oExpFovUnit4;
				oExpVovAcct = _oExpVovAcct;
				oExpVovUnit1 = _oExpVovUnit1;
				oExpVovUnit2 = _oExpVovUnit2;
				oExpVovUnit3 = _oExpVovUnit3;
				oExpVovUnit4 = _oExpVovUnit4;
				oExpOutAcct = _oExpOutAcct;
				oExpOutUnit1 = _oExpOutUnit1;
				oExpOutUnit2 = _oExpOutUnit2;
				oExpOutUnit3 = _oExpOutUnit3;
				oExpOutUnit4 = _oExpOutUnit4;
				oRevAcct = _oRevAcct;
				oRevUnit1 = _oRevUnit1;
				oRevUnit2 = _oRevUnit2;
				oRevUnit3 = _oRevUnit3;
				oRevUnit4 = _oRevUnit4;
				oSaleDsAcct = _oSaleDsAcct;
				oSaleDsUnit1 = _oSaleDsUnit1;
				oSaleDsUnit2 = _oSaleDsUnit2;
				oSaleDsUnit3 = _oSaleDsUnit3;
				oSaleDsUnit4 = _oSaleDsUnit4;
				Infobar = _Infobar;
				
				return (Severity, oCostCode, oDeptUnit, oProdcodeUnit, oWipMatlAcct, oWipMatlUnit1, oWipMatlUnit2, oWipMatlUnit3, oWipMatlUnit4, oWipLbrAcct, oWipLbrUnit1, oWipLbrUnit2, oWipLbrUnit3, oWipLbrUnit4, oWipFovAcct, oWipFovUnit1, oWipFovUnit2, oWipFovUnit3, oWipFovUnit4, oWipVovAcct, oWipVovUnit1, oWipVovUnit2, oWipVovUnit3, oWipVovUnit4, oWipOutAcct, oWipOutUnit1, oWipOutUnit2, oWipOutUnit3, oWipOutUnit4, oExpMatlAcct, oExpMatlUnit1, oExpMatlUnit2, oExpMatlUnit3, oExpMatlUnit4, oExpLbrAcct, oExpLbrUnit1, oExpLbrUnit2, oExpLbrUnit3, oExpLbrUnit4, oExpFovAcct, oExpFovUnit1, oExpFovUnit2, oExpFovUnit3, oExpFovUnit4, oExpVovAcct, oExpVovUnit1, oExpVovUnit2, oExpVovUnit3, oExpVovUnit4, oExpOutAcct, oExpOutUnit1, oExpOutUnit2, oExpOutUnit3, oExpOutUnit4, oRevAcct, oRevUnit1, oRevUnit2, oRevUnit3, oRevUnit4, oSaleDsAcct, oSaleDsUnit1, oSaleDsUnit2, oSaleDsUnit3, oSaleDsUnit4, Infobar);
			}
		}
	}
}
