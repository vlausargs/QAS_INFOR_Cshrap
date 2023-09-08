//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSRODropShipName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSRODropShipName : ISSSFSSRODropShipName
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSRODropShipName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSSRODropShipNameFn(
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
				cmd.CommandText = "SELECT  dbo.[SSSFSSRODropShipName](@iDropType, @iDropNum, @iDropSeq)";
				
				appDB.AddCommandParameter(cmd, "iDropType", _iDropType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDropNum", _iDropNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDropSeq", _iDropSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
