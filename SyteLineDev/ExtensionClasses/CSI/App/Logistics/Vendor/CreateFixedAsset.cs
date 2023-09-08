//PROJECT NAME: Logistics
//CLASS NAME: CreateFixedAsset.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CreateFixedAsset : ICreateFixedAsset
	{
		readonly IApplicationDB appDB;
		
		
		public CreateFixedAsset(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CreateFixedAssetSp(string FaNum,
		string FaClass,
		string Dept,
		string PoNum,
		string ManufacturerId,
		string Infobar,
		string FaDesc = null)
		{
			FaNumType _FaNum = FaNum;
			FaClassType _FaClass = FaClass;
			DeptType _Dept = Dept;
			PoNumType _PoNum = PoNum;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			InfobarType _Infobar = Infobar;
			DescriptionType _FaDesc = FaDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateFixedAssetSp";
				
				appDB.AddCommandParameter(cmd, "FaNum", _FaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaClass", _FaClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FaDesc", _FaDesc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
