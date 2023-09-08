//PROJECT NAME: Finance
//CLASS NAME: VendCustEmpNameFromRefType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class VendCustEmpNameFromRefType : IVendCustEmpNameFromRefType
	{
		readonly IApplicationDB appDB;
		
		
		public VendCustEmpNameFromRefType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Name,
		string Infobar) VendCustEmpNameFromRefTypeSp(string RefNum,
		string RefType,
		string Name,
		string Infobar)
		{
			EmpVendNumType _RefNum = RefNum;
			GlbankRefTypeType _RefType = RefType;
			NameType _Name = Name;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendCustEmpNameFromRefTypeSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Name = _Name;
				Infobar = _Infobar;
				
				return (Severity, Name, Infobar);
			}
		}

		public string VendCustEmpNameFromRefTypeFn(
			string RefNum,
			string RefType)
		{
			EmpVendNumType _RefNum = RefNum;
			GlbankRefTypeType _RefType = RefType;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[VendCustEmpNameFromRefType](@RefNum, @RefType)";

				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
