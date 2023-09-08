//PROJECT NAME: CSICustomer
//CLASS NAME: GetParmReasonText.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetParmReasonText
	{
		int GetParmReasonTextSp(ref byte? ReasonText);
	}
	
	public class GetParmReasonText : IGetParmReasonText
	{
		readonly IApplicationDB appDB;
		
		public GetParmReasonText(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetParmReasonTextSp(ref byte? ReasonText)
		{
			ListYesNoType _ReasonText = ReasonText;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetParmReasonTextSp";
				
				appDB.AddCommandParameter(cmd, "ReasonText", _ReasonText, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReasonText = _ReasonText;
				
				return Severity;
			}
		}
	}
}
