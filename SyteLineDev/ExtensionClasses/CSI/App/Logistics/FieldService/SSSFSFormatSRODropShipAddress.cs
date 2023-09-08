//PROJECT NAME: Logistics
//CLASS NAME: SSSFSFormatSRODropShipAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSFormatSRODropShipAddress : ISSSFSFormatSRODropShipAddress
	{
		readonly IApplicationDB appDB;
		
		public SSSFSFormatSRODropShipAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSFormatSRODropShipAddressFn(
			string iDropType,
			string iDropNum,
			int? iDropSeq)
		{
			FSDropShipTypeType _iDropType = iDropType;
			FSPartnerType _iDropNum = iDropNum;
			DropSeqType _iDropSeq = iDropSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSFormatSRODropShipAddress](@iDropType, @iDropNum, @iDropSeq)";
				
				appDB.AddCommandParameter(cmd, "iDropType", _iDropType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDropNum", _iDropNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDropSeq", _iDropSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
