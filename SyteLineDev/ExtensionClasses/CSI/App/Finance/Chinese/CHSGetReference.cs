//PROJECT NAME: Finance
//CLASS NAME: CHSGetReference.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGetReference : ICHSGetReference
	{
		readonly IApplicationDB appDB;
		
		public CHSGetReference(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string CHSGetReferenceFn(
			string Ref)
		{
			ReferenceType _Ref = Ref;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CHSGetReference](@Ref)";
				
				appDB.AddCommandParameter(cmd, "Ref", _Ref, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
