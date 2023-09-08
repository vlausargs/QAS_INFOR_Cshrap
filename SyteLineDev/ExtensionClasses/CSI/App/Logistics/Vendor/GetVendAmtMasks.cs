//PROJECT NAME: CSIVendor
//CLASS NAME: GetVendAmtMasks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetVendAmtMasks
	{
		(int? ReturnCode, string PAmtFormat, string PAmtTotFormat, string PCstPrcFormat) GetVendAmtMasksSp(string PVendNum,
		string PAmtFormat = null,
		string PAmtTotFormat = null,
		string PCstPrcFormat = null);
	}
	
	public class GetVendAmtMasks : IGetVendAmtMasks
	{
		readonly IApplicationDB appDB;
		
		public GetVendAmtMasks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PAmtFormat, string PAmtTotFormat, string PCstPrcFormat) GetVendAmtMasksSp(string PVendNum,
		string PAmtFormat = null,
		string PAmtTotFormat = null,
		string PCstPrcFormat = null)
		{
			VendNumType _PVendNum = PVendNum;
			InputMaskType _PAmtFormat = PAmtFormat;
			InputMaskType _PAmtTotFormat = PAmtTotFormat;
			InputMaskType _PCstPrcFormat = PCstPrcFormat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVendAmtMasksSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
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
