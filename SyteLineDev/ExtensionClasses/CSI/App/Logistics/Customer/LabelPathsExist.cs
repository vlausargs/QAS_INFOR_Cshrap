//PROJECT NAME: CSICustomer
//CLASS NAME: LabelPathsExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ILabelPathsExist
	{
		int LabelPathsExistSp(ref string UbTemplatePath,
		                      ref string UbOutputPath);
	}
	
	public class LabelPathsExist : ILabelPathsExist
	{
		readonly IApplicationDB appDB;
		
		public LabelPathsExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LabelPathsExistSp(ref string UbTemplatePath,
		                             ref string UbOutputPath)
		{
			OSLocationType _UbTemplatePath = UbTemplatePath;
			OSLocationType _UbOutputPath = UbOutputPath;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LabelPathsExistSp";
				
				appDB.AddCommandParameter(cmd, "UbTemplatePath", _UbTemplatePath, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UbOutputPath", _UbOutputPath, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UbTemplatePath = _UbTemplatePath;
				UbOutputPath = _UbOutputPath;
				
				return Severity;
			}
		}
	}
}
