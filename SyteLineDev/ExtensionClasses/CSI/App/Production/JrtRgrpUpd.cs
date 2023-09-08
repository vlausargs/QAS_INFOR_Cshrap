//PROJECT NAME: Production
//CLASS NAME: JrtRgrpUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JrtRgrpUpd : IJrtRgrpUpd
	{
		readonly IApplicationDB appDB;
		
		
		public JrtRgrpUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JrtRgrpUpdSp(Guid? Rowp,
		string job,
		int? suffix,
		int? oper_num,
		string rgid,
		int? qty_resources,
		string resactn,
		int? sequence)
		{
			RowPointerType _Rowp = Rowp;
			JobType _job = job;
			SuffixType _suffix = suffix;
			OperNumType _oper_num = oper_num;
			ApsResgroupType _rgid = rgid;
			ResourcesType _qty_resources = qty_resources;
			ApsCodeType _resactn = resactn;
			ApsIntType _sequence = sequence;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JrtRgrpUpdSp";
				
				appDB.AddCommandParameter(cmd, "Rowp", _Rowp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "job", _job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "suffix", _suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oper_num", _oper_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rgid", _rgid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qty_resources", _qty_resources, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "resactn", _resactn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sequence", _sequence, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
