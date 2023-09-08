//PROJECT NAME: Data
//CLASS NAME: DisplayShiptoAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayShiptoAddress : IDisplayShiptoAddress
	{
		readonly IApplicationDB appDB;
		
		public DisplayShiptoAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayShiptoAddressSp(
			string DropShipNo,
			int? DropSeq,
			string SiteRef)
		{
			DropShipNoType _DropShipNo = DropShipNo;
			DropSeqType _DropSeq = DropSeq;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayShiptoAddressSp](@DropShipNo, @DropSeq, @SiteRef)";
				
				appDB.AddCommandParameter(cmd, "DropShipNo", _DropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropSeq", _DropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
