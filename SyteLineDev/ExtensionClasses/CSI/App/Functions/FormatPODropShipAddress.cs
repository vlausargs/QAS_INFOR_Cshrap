//PROJECT NAME: Data
//CLASS NAME: FormatPODropShipAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatPODropShipAddress : IFormatPODropShipAddress
	{
		readonly IApplicationDB appDB;
		
		public FormatPODropShipAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FormatPODropShipAddressFn(
			string PoShipAddr,
			string PoDropShipNo,
			int? PoDropSeq,
			string PoWhse)
		{
			DropShipTypeType _PoShipAddr = PoShipAddr;
			DropShipNoType _PoDropShipNo = PoDropShipNo;
			DropSeqType _PoDropSeq = PoDropSeq;
			WhseType _PoWhse = PoWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatPODropShipAddress](@PoShipAddr, @PoDropShipNo, @PoDropSeq, @PoWhse)";
				
				appDB.AddCommandParameter(cmd, "PoShipAddr", _PoShipAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoDropShipNo", _PoDropShipNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoDropSeq", _PoDropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoWhse", _PoWhse, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
