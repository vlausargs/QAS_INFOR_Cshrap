//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXRmaTPSetCGS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXRmaTPSetCGS : ISSSRMXRmaTPSetCGS
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXRmaTPSetCGS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TCgsMatlAcct,
			string TCgsMatlAcctUnit1,
			string TCgsMatlAcctUnit2,
			string TCgsMatlAcctUnit3,
			string TCgsMatlAcctUnit4,
			string TCgsLbrAcct,
			string TCgsLbrAcctUnit1,
			string TCgsLbrAcctUnit2,
			string TCgsLbrAcctUnit3,
			string TCgsLbrAcctUnit4,
			string TCgsFovhdAcct,
			string TCgsFovhdAcctUnit1,
			string TCgsFovhdAcctUnit2,
			string TCgsFovhdAcctUnit3,
			string TCgsFovhdAcctUnit4,
			string TCgsVovhdAcct,
			string TCgsVovhdAcctUnit1,
			string TCgsVovhdAcctUnit2,
			string TCgsVovhdAcctUnit3,
			string TCgsVovhdAcctUnit4,
			string TCgsOutAcct,
			string TCgsOutAcctUnit1,
			string TCgsOutAcctUnit2,
			string TCgsOutAcctUnit3,
			string TCgsOutAcctUnit4,
			string Infobar) SSSRMXRmaTPSetCGSSp(
			string RmaNum,
			int? RmaLine,
			string TCgsMatlAcct,
			string TCgsMatlAcctUnit1,
			string TCgsMatlAcctUnit2,
			string TCgsMatlAcctUnit3,
			string TCgsMatlAcctUnit4,
			string TCgsLbrAcct,
			string TCgsLbrAcctUnit1,
			string TCgsLbrAcctUnit2,
			string TCgsLbrAcctUnit3,
			string TCgsLbrAcctUnit4,
			string TCgsFovhdAcct,
			string TCgsFovhdAcctUnit1,
			string TCgsFovhdAcctUnit2,
			string TCgsFovhdAcctUnit3,
			string TCgsFovhdAcctUnit4,
			string TCgsVovhdAcct,
			string TCgsVovhdAcctUnit1,
			string TCgsVovhdAcctUnit2,
			string TCgsVovhdAcctUnit3,
			string TCgsVovhdAcctUnit4,
			string TCgsOutAcct,
			string TCgsOutAcctUnit1,
			string TCgsOutAcctUnit2,
			string TCgsOutAcctUnit3,
			string TCgsOutAcctUnit4,
			string Infobar)
		{
			RmaNumType _RmaNum = RmaNum;
			RmaLineType _RmaLine = RmaLine;
			AcctType _TCgsMatlAcct = TCgsMatlAcct;
			UnitCode1Type _TCgsMatlAcctUnit1 = TCgsMatlAcctUnit1;
			UnitCode2Type _TCgsMatlAcctUnit2 = TCgsMatlAcctUnit2;
			UnitCode3Type _TCgsMatlAcctUnit3 = TCgsMatlAcctUnit3;
			UnitCode4Type _TCgsMatlAcctUnit4 = TCgsMatlAcctUnit4;
			AcctType _TCgsLbrAcct = TCgsLbrAcct;
			UnitCode1Type _TCgsLbrAcctUnit1 = TCgsLbrAcctUnit1;
			UnitCode2Type _TCgsLbrAcctUnit2 = TCgsLbrAcctUnit2;
			UnitCode3Type _TCgsLbrAcctUnit3 = TCgsLbrAcctUnit3;
			UnitCode4Type _TCgsLbrAcctUnit4 = TCgsLbrAcctUnit4;
			AcctType _TCgsFovhdAcct = TCgsFovhdAcct;
			UnitCode1Type _TCgsFovhdAcctUnit1 = TCgsFovhdAcctUnit1;
			UnitCode2Type _TCgsFovhdAcctUnit2 = TCgsFovhdAcctUnit2;
			UnitCode3Type _TCgsFovhdAcctUnit3 = TCgsFovhdAcctUnit3;
			UnitCode4Type _TCgsFovhdAcctUnit4 = TCgsFovhdAcctUnit4;
			AcctType _TCgsVovhdAcct = TCgsVovhdAcct;
			UnitCode1Type _TCgsVovhdAcctUnit1 = TCgsVovhdAcctUnit1;
			UnitCode2Type _TCgsVovhdAcctUnit2 = TCgsVovhdAcctUnit2;
			UnitCode3Type _TCgsVovhdAcctUnit3 = TCgsVovhdAcctUnit3;
			UnitCode4Type _TCgsVovhdAcctUnit4 = TCgsVovhdAcctUnit4;
			AcctType _TCgsOutAcct = TCgsOutAcct;
			UnitCode1Type _TCgsOutAcctUnit1 = TCgsOutAcctUnit1;
			UnitCode2Type _TCgsOutAcctUnit2 = TCgsOutAcctUnit2;
			UnitCode3Type _TCgsOutAcctUnit3 = TCgsOutAcctUnit3;
			UnitCode4Type _TCgsOutAcctUnit4 = TCgsOutAcctUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXRmaTPSetCGSSp";
				
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCgsMatlAcct", _TCgsMatlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsMatlAcctUnit1", _TCgsMatlAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsMatlAcctUnit2", _TCgsMatlAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsMatlAcctUnit3", _TCgsMatlAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsMatlAcctUnit4", _TCgsMatlAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsLbrAcct", _TCgsLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsLbrAcctUnit1", _TCgsLbrAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsLbrAcctUnit2", _TCgsLbrAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsLbrAcctUnit3", _TCgsLbrAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsLbrAcctUnit4", _TCgsLbrAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsFovhdAcct", _TCgsFovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsFovhdAcctUnit1", _TCgsFovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsFovhdAcctUnit2", _TCgsFovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsFovhdAcctUnit3", _TCgsFovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsFovhdAcctUnit4", _TCgsFovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsVovhdAcct", _TCgsVovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsVovhdAcctUnit1", _TCgsVovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsVovhdAcctUnit2", _TCgsVovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsVovhdAcctUnit3", _TCgsVovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsVovhdAcctUnit4", _TCgsVovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsOutAcct", _TCgsOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsOutAcctUnit1", _TCgsOutAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsOutAcctUnit2", _TCgsOutAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsOutAcctUnit3", _TCgsOutAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCgsOutAcctUnit4", _TCgsOutAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TCgsMatlAcct = _TCgsMatlAcct;
				TCgsMatlAcctUnit1 = _TCgsMatlAcctUnit1;
				TCgsMatlAcctUnit2 = _TCgsMatlAcctUnit2;
				TCgsMatlAcctUnit3 = _TCgsMatlAcctUnit3;
				TCgsMatlAcctUnit4 = _TCgsMatlAcctUnit4;
				TCgsLbrAcct = _TCgsLbrAcct;
				TCgsLbrAcctUnit1 = _TCgsLbrAcctUnit1;
				TCgsLbrAcctUnit2 = _TCgsLbrAcctUnit2;
				TCgsLbrAcctUnit3 = _TCgsLbrAcctUnit3;
				TCgsLbrAcctUnit4 = _TCgsLbrAcctUnit4;
				TCgsFovhdAcct = _TCgsFovhdAcct;
				TCgsFovhdAcctUnit1 = _TCgsFovhdAcctUnit1;
				TCgsFovhdAcctUnit2 = _TCgsFovhdAcctUnit2;
				TCgsFovhdAcctUnit3 = _TCgsFovhdAcctUnit3;
				TCgsFovhdAcctUnit4 = _TCgsFovhdAcctUnit4;
				TCgsVovhdAcct = _TCgsVovhdAcct;
				TCgsVovhdAcctUnit1 = _TCgsVovhdAcctUnit1;
				TCgsVovhdAcctUnit2 = _TCgsVovhdAcctUnit2;
				TCgsVovhdAcctUnit3 = _TCgsVovhdAcctUnit3;
				TCgsVovhdAcctUnit4 = _TCgsVovhdAcctUnit4;
				TCgsOutAcct = _TCgsOutAcct;
				TCgsOutAcctUnit1 = _TCgsOutAcctUnit1;
				TCgsOutAcctUnit2 = _TCgsOutAcctUnit2;
				TCgsOutAcctUnit3 = _TCgsOutAcctUnit3;
				TCgsOutAcctUnit4 = _TCgsOutAcctUnit4;
				Infobar = _Infobar;
				
				return (Severity, TCgsMatlAcct, TCgsMatlAcctUnit1, TCgsMatlAcctUnit2, TCgsMatlAcctUnit3, TCgsMatlAcctUnit4, TCgsLbrAcct, TCgsLbrAcctUnit1, TCgsLbrAcctUnit2, TCgsLbrAcctUnit3, TCgsLbrAcctUnit4, TCgsFovhdAcct, TCgsFovhdAcctUnit1, TCgsFovhdAcctUnit2, TCgsFovhdAcctUnit3, TCgsFovhdAcctUnit4, TCgsVovhdAcct, TCgsVovhdAcctUnit1, TCgsVovhdAcctUnit2, TCgsVovhdAcctUnit3, TCgsVovhdAcctUnit4, TCgsOutAcct, TCgsOutAcctUnit1, TCgsOutAcctUnit2, TCgsOutAcctUnit3, TCgsOutAcctUnit4, Infobar);
			}
		}
	}
}
