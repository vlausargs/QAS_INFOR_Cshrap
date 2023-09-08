//PROJECT NAME: Finance
//CLASS NAME: SSSVTXPOSGetKeys.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXPOSGetKeys : ISSSVTXPOSGetKeys
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXPOSGetKeys(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oHdrRef1,
			string oHdrRef2,
			int? oHdrRef3,
			string oLineRef1,
			int? oLineRef2,
			int? oLineRef3,
			string Infobar) SSSVTXPOSGetKeysSp(
			string pRefType,
			Guid? pHdrPtr,
			string pLineRefType,
			Guid? pLinePtr,
			string pLineType,
			string oHdrRef1,
			string oHdrRef2,
			int? oHdrRef3,
			string oLineRef1,
			int? oLineRef2,
			int? oLineRef3,
			string Infobar)
		{
			VTXRefTypeType _pRefType = pRefType;
			RowPointer _pHdrPtr = pHdrPtr;
			VTXLineRefType _pLineRefType = pLineRefType;
			RowPointer _pLinePtr = pLinePtr;
			VTXLineType _pLineType = pLineType;
			VTXHdrRef1Type _oHdrRef1 = oHdrRef1;
			VTXHdrRef2Type _oHdrRef2 = oHdrRef2;
			VTXHdrRef3Type _oHdrRef3 = oHdrRef3;
			VTXLineRef1Type _oLineRef1 = oLineRef1;
			VTXLineRef2Type _oLineRef2 = oLineRef2;
			VTXLineRef3Type _oLineRef3 = oLineRef3;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXPOSGetKeysSp";
				
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHdrPtr", _pHdrPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLineRefType", _pLineRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLinePtr", _pLinePtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLineType", _pLineType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oHdrRef1", _oHdrRef1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oHdrRef2", _oHdrRef2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oHdrRef3", _oHdrRef3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oLineRef1", _oLineRef1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oLineRef2", _oLineRef2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oLineRef3", _oLineRef3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oHdrRef1 = _oHdrRef1;
				oHdrRef2 = _oHdrRef2;
				oHdrRef3 = _oHdrRef3;
				oLineRef1 = _oLineRef1;
				oLineRef2 = _oLineRef2;
				oLineRef3 = _oLineRef3;
				Infobar = _Infobar;
				
				return (Severity, oHdrRef1, oHdrRef2, oHdrRef3, oLineRef1, oLineRef2, oLineRef3, Infobar);
			}
		}
	}
}
