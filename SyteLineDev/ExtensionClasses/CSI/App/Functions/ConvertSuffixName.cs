//PROJECT NAME: Data
//CLASS NAME: ConvertSuffixName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertSuffixName : IConvertSuffixName
	{
		readonly IApplicationDB appDB;
		
		public ConvertSuffixName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ConvertSuffixNameFn(
			string Name,
			string FName,
			string MI,
			string LName)
		{
			NameType _Name = Name;
			GivenNameType _FName = FName;
			InitialType _MI = MI;
			SurnameType _LName = LName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertSuffixName](@Name, @FName, @MI, @LName)";
				
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FName", _FName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MI", _MI, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LName", _LName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
