//PROJECT NAME: Data
//CLASS NAME: ConvTimeStrToInt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvTimeStrToInt : IConvTimeStrToInt
	{
		readonly IApplicationDB appDB;
		
		public ConvTimeStrToInt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ConvTimeStrToIntFn(
			string TimeStr)
		{
			ApsTimeStrType _TimeStr = TimeStr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvTimeStrToInt](@TimeStr)";
				
				appDB.AddCommandParameter(cmd, "TimeStr", _TimeStr, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
