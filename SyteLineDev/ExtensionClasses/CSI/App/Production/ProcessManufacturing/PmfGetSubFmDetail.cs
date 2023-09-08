//PROJECT NAME: Production
//CLASS NAME: PmfGetSubFmDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetSubFmDetail : IPmfGetSubFmDetail
	{
		readonly IApplicationDB appDB;
		
		public PmfGetSubFmDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string WipItem,
			string Um,
			string FmDesc) PmfGetSubFmDetailSp(
			Guid? SubFmRp,
			string WipItem,
			string Um,
			string FmDesc)
		{
			GuidType _SubFmRp = SubFmRp;
			ItemType _WipItem = WipItem;
			UMType _Um = Um;
			StringType _FmDesc = FmDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetSubFmDetailSp";
				
				appDB.AddCommandParameter(cmd, "SubFmRp", _SubFmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipItem", _WipItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Um", _Um, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FmDesc", _FmDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WipItem = _WipItem;
				Um = _Um;
				FmDesc = _FmDesc;
				
				return (Severity, WipItem, Um, FmDesc);
			}
		}
	}
}
