//PROJECT NAME: Config
//CLASS NAME: LoadProcessEQLinePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class LoadProcessEQLinePost : ILoadProcessEQLinePost
	{
		readonly IApplicationDB appDB;
		
		public LoadProcessEQLinePost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LoadProcessEQLinePostSp(
			string ExternalConfirmationRef,
			string CEP,
			string Infobar)
		{
			OrderConfirmationRefType _ExternalConfirmationRef = ExternalConfirmationRef;
			LongListType _CEP = CEP;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessEQLinePostSp";
				
				appDB.AddCommandParameter(cmd, "ExternalConfirmationRef", _ExternalConfirmationRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CEP", _CEP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
