//PROJECT NAME: Data
//CLASS NAME: DisplayShiptoAddressWithPhone.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayShiptoAddressWithPhone : IDisplayShiptoAddressWithPhone
	{
		readonly IApplicationDB appDB;
		
		public DisplayShiptoAddressWithPhone(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayShiptoAddressWithPhoneSp(
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
				cmd.CommandText = "SELECT  dbo.[DisplayShiptoAddressWithPhoneSp](@DropShipNo, @DropSeq, @SiteRef)";
				
				appDB.AddCommandParameter(cmd, "DropShipNo", _DropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropSeq", _DropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
