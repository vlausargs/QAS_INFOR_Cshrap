//PROJECT NAME: Data
//CLASS NAME: RemoteSetArtranCorpCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RemoteSetArtranCorpCust : IRemoteSetArtranCorpCust
	{
		readonly IApplicationDB appDB;
		
		public RemoteSetArtranCorpCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RemoteSetArtranCorpCustSp(
			string CustNum,
			string CorpCust,
			string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustNumType _CorpCust = CorpCust;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteSetArtranCorpCustSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCust", _CorpCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
