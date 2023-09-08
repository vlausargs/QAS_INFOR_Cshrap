//PROJECT NAME: Data
//CLASS NAME: GetAmtMasks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetAmtMasks : IGetAmtMasks
	{
		readonly IApplicationDB appDB;
		
		public GetAmtMasks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PAmtFormat,
			string PAmtTotFormat,
			string PCstPrcFormat) GetAmtMasksSp(
			string PCurrCode,
			string PAmtFormat = null,
			string PAmtTotFormat = null,
			string PCstPrcFormat = null)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			InputMaskType _PAmtFormat = PAmtFormat;
			InputMaskType _PAmtTotFormat = PAmtTotFormat;
			InputMaskType _PCstPrcFormat = PCstPrcFormat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAmtMasksSp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmtFormat", _PAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtTotFormat", _PAmtTotFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCstPrcFormat", _PCstPrcFormat, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAmtFormat = _PAmtFormat;
				PAmtTotFormat = _PAmtTotFormat;
				PCstPrcFormat = _PCstPrcFormat;
				
				return (Severity, PAmtFormat, PAmtTotFormat, PCstPrcFormat);
			}
		}
	}
}
