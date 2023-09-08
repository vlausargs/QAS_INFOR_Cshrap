//PROJECT NAME: Finance
//CLASS NAME: SSSVTXGetHeaderTaxCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXGetHeaderTaxCode : ISSSVTXGetHeaderTaxCode
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXGetHeaderTaxCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oParentTaxCode,
			string Infobar) SSSVTXGetHeaderTaxCodeSp(
			string pRefType,
			Guid? pHdrPtr,
			string pLineRefType,
			Guid? pLinePtr,
			string pParentTaxCode,
			string oParentTaxCode,
			string Infobar)
		{
			VTXRefTypeType _pRefType = pRefType;
			RowPointerType _pHdrPtr = pHdrPtr;
			VTXLineRefType _pLineRefType = pLineRefType;
			RowPointer _pLinePtr = pLinePtr;
			TaxCodeType _pParentTaxCode = pParentTaxCode;
			TaxCodeType _oParentTaxCode = oParentTaxCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXGetHeaderTaxCodeSp";
				
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHdrPtr", _pHdrPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLineRefType", _pLineRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLinePtr", _pLinePtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pParentTaxCode", _pParentTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oParentTaxCode", _oParentTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oParentTaxCode = _oParentTaxCode;
				Infobar = _Infobar;
				
				return (Severity, oParentTaxCode, Infobar);
			}
		}
	}
}
