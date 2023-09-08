//PROJECT NAME: Reporting
//CLASS NAME: GetDropShipToAddrWithPhoneLang.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class GetDropShipToAddrWithPhoneLang : IGetDropShipToAddrWithPhoneLang
	{
		readonly IApplicationDB appDB;
		
		public GetDropShipToAddrWithPhoneLang(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ShipToAddress) GetDropShipToAddrWithPhoneLangSp(
			string ShipTo,
			string DropShipNo,
			int? DropSeqNo,
			string SiteRef,
			string MessageLanguage,
			string ShipToAddress)
		{
			StringType _ShipTo = ShipTo;
			DropShipNoType _DropShipNo = DropShipNo;
			DropSeqType _DropSeqNo = DropSeqNo;
			SiteType _SiteRef = SiteRef;
			MessageLanguageType _MessageLanguage = MessageLanguage;
			LongAddress _ShipToAddress = ShipToAddress;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDropShipToAddrWithPhoneLangSp";
				
				appDB.AddCommandParameter(cmd, "ShipTo", _ShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropShipNo", _DropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropSeqNo", _DropSeqNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ShipToAddress = _ShipToAddress;
				
				return (Severity, ShipToAddress);
			}
		}
	}
}
