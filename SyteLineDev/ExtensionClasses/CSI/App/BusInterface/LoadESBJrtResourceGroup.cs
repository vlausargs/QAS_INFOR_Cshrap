//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBJrtResourceGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBJrtResourceGroup
	{
		int LoadESBJrtResourceGroupSp(string job,
		                              short? Suffix,
		                              int? OperNum,
		                              string ActionExpression,
		                              string rgid,
		                              short? QtyResources,
		                              string Infobar);
	}
	
	public class LoadESBJrtResourceGroup : ILoadESBJrtResourceGroup
	{
		readonly IApplicationDB appDB;
		
		public LoadESBJrtResourceGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBJrtResourceGroupSp(string job,
		                                     short? Suffix,
		                                     int? OperNum,
		                                     string ActionExpression,
		                                     string rgid,
		                                     short? QtyResources,
		                                     string Infobar)
		{
			JobType _job = job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			StringType _ActionExpression = ActionExpression;
			ApsResgroupType _rgid = rgid;
			ResourcesType _QtyResources = QtyResources;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBJrtResourceGroupSp";
				
				appDB.AddCommandParameter(cmd, "job", _job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rgid", _rgid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyResources", _QtyResources, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
