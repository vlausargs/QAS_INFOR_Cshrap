//PROJECT NAME: Data
//CLASS NAME: EdiInOrdVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiInOrdVal : IEdiInOrdVal
	{
		readonly IApplicationDB appDB;
		
		public EdiInOrdVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PCustSeq) EdiInOrdValSp(
			Guid? POrdRecid,
			Guid? PTpRecid,
			string PCallFrom,
			int? PCustSeq,
			string Site = null)
		{
			RowPointerType _POrdRecid = POrdRecid;
			RowPointerType _PTpRecid = PTpRecid;
			LongListType _PCallFrom = PCallFrom;
			GenericNoType _PCustSeq = PCustSeq;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiInOrdValSp";
				
				appDB.AddCommandParameter(cmd, "POrdRecid", _POrdRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTpRecid", _PTpRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCallFrom", _PCallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCustSeq = _PCustSeq;
				
				return (Severity, PCustSeq);
			}
		}
	}
}
