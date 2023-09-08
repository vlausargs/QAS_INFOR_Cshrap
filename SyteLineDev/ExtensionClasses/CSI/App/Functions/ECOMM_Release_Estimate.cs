//PROJECT NAME: Data
//CLASS NAME: ECOMM_Release_Estimate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ECOMM_Release_Estimate : IECOMM_Release_Estimate
	{
		readonly IApplicationDB appDB;
		
		public ECOMM_Release_Estimate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string NewCoNum,
			int? SuccessFlag,
			string Infobar) ECOMM_Release_EstimateSp(
			string OrderNumber,
			string NewCoNum,
			int? SuccessFlag,
			string Infobar)
		{
			CoNumType _OrderNumber = OrderNumber;
			CoNumType _NewCoNum = NewCoNum;
			ListYesNoType _SuccessFlag = SuccessFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ECOMM_Release_EstimateSp";
				
				appDB.AddCommandParameter(cmd, "OrderNumber", _OrderNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCoNum", _NewCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuccessFlag", _SuccessFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewCoNum = _NewCoNum;
				SuccessFlag = _SuccessFlag;
				Infobar = _Infobar;
				
				return (Severity, NewCoNum, SuccessFlag, Infobar);
			}
		}
	}
}
