//PROJECT NAME: Data
//CLASS NAME: DisplayShiptoAddressWithPhoneLang.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayShiptoAddressWithPhoneLang : IDisplayShiptoAddressWithPhoneLang
	{
		readonly IApplicationDB appDB;
		
		public DisplayShiptoAddressWithPhoneLang(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayShiptoAddressWithPhoneLangSp(
			string DropShipNo,
			int? DropSeq,
			string SiteRef,
			string MessageLanguage)
		{
			DropShipNoType _DropShipNo = DropShipNo;
			DropSeqType _DropSeq = DropSeq;
			SiteType _SiteRef = SiteRef;
			MessageLanguageType _MessageLanguage = MessageLanguage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayShiptoAddressWithPhoneLangSp](@DropShipNo, @DropSeq, @SiteRef, @MessageLanguage)";
				
				appDB.AddCommandParameter(cmd, "DropShipNo", _DropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropSeq", _DropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
