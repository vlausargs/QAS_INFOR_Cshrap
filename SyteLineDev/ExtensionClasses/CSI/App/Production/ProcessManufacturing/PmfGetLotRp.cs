//PROJECT NAME: Production
//CLASS NAME: PmfGetLotRp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetLotRp
	{
		(int? ReturnCode, Guid? rp) PmfGetLotRpSp(string item,
		                                          string lot,
		                                          Guid? rp);
	}
	
	public class PmfGetLotRp : IPmfGetLotRp
	{
		readonly IApplicationDB appDB;
		
		public PmfGetLotRp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? rp) PmfGetLotRpSp(string item,
		                                                 string lot,
		                                                 Guid? rp)
		{
			ItemType _item = item;
			LotType _lot = lot;
			GuidType _rp = rp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetLotRpSp";
				
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "lot", _lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rp", _rp, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rp = _rp;
				
				return (Severity, rp);
			}
		}
	}
}
