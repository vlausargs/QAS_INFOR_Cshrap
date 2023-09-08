//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetItemInfo
	{
		(int? ReturnCode, string oDescription, string oUM, string oProductCode, byte? oSerialTracked, byte? oLotTracked, string Revision) SSSFSGetItemInfoSp(string iItem,
		string oDescription = null,
		string oUM = null,
		string oProductCode = null,
		byte? oSerialTracked = null,
		byte? oLotTracked = null,
		string Revision = null);
	}
	
	public class SSSFSGetItemInfo : ISSSFSGetItemInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string oDescription, string oUM, string oProductCode, byte? oSerialTracked, byte? oLotTracked, string Revision) SSSFSGetItemInfoSp(string iItem,
		string oDescription = null,
		string oUM = null,
		string oProductCode = null,
		byte? oSerialTracked = null,
		byte? oLotTracked = null,
		string Revision = null)
		{
			ItemType _iItem = iItem;
			DescriptionType _oDescription = oDescription;
			UMType _oUM = oUM;
			ProductCodeType _oProductCode = oProductCode;
			ListYesNoType _oSerialTracked = oSerialTracked;
			ListYesNoType _oLotTracked = oLotTracked;
			RevisionType _Revision = Revision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oDescription", _oDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUM", _oUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oProductCode", _oProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSerialTracked", _oSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oLotTracked", _oLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oDescription = _oDescription;
				oUM = _oUM;
				oProductCode = _oProductCode;
				oSerialTracked = _oSerialTracked;
				oLotTracked = _oLotTracked;
				Revision = _Revision;
				
				return (Severity, oDescription, oUM, oProductCode, oSerialTracked, oLotTracked, Revision);
			}
		}
	}
}
