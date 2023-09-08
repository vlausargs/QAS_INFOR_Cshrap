//PROJECT NAME: Production
//CLASS NAME: GetBATPRODID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class GetBATPRODID : IGetBATPRODID
	{
		readonly IApplicationDB appDB;
		
		
		public GetBATPRODID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? BatchedProdId) GetBATPRODIDSp(int? AltNo,
		int? BatchedProdId)
		{
			ApsAltNoType _AltNo = AltNo;
			ApsBatchNumberType _BatchedProdId = BatchedProdId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetBATPRODIDSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BatchedProdId", _BatchedProdId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BatchedProdId = _BatchedProdId;
				
				return (Severity, BatchedProdId);
			}
		}
	}
}
