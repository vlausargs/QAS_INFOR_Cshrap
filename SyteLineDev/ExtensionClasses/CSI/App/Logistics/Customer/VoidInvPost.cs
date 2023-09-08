//PROJECT NAME: Logistics
//CLASS NAME: VoidInvPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class VoidInvPost : IVoidInvPost
	{
		readonly IApplicationDB appDB;
		
		
		public VoidInvPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VoidInvPostSp(string PArtranType,
		string PInvNum,
		string PReason,
		string Infobar = null)
		{
			ArtranTypeType _PArtranType = PArtranType;
			InvNumType _PInvNum = PInvNum;
			ReasonCodeType _PReason = PReason;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoidInvPostSp";
				
				appDB.AddCommandParameter(cmd, "PArtranType", _PArtranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReason", _PReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
