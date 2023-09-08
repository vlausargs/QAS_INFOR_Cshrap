//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListCust : IGenerateOrderPickListCust
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickListCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GenerateOrderPickListCustSp(
			string PCoCoNum,
			string PCoCustNum,
			int? PCoCustSeq,
			string PCoTermsCode,
			string PCoShipCode,
			int? PProcessBatchId,
			string PWhseWhse,
			string Infobar)
		{
			CoNumType _PCoCoNum = PCoCoNum;
			CustNumType _PCoCustNum = PCoCustNum;
			CustSeqType _PCoCustSeq = PCoCustSeq;
			TermsCodeType _PCoTermsCode = PCoTermsCode;
			ShipCodeType _PCoShipCode = PCoShipCode;
			BatchIdType _PProcessBatchId = PProcessBatchId;
			WhseType _PWhseWhse = PWhseWhse;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListCustSp";
				
				appDB.AddCommandParameter(cmd, "PCoCoNum", _PCoCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoCustNum", _PCoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoCustSeq", _PCoCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoTermsCode", _PCoTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoShipCode", _PCoShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessBatchId", _PProcessBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhseWhse", _PWhseWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
