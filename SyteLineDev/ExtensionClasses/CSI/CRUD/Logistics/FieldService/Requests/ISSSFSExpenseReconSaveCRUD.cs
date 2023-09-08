//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSExpenseReconSaveCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSExpenseReconSaveCRUD
	{
		bool CheckOptional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_Module();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool CheckTv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectFs_Tmp_Recon(Guid? RowPointer);
		void InsertFs_Tmp_Recon(ICollectionLoadResponse nonTable1LoadResponse);
		ICollectionLoadResponse SelectFs_Tmp_ReconForDelete(Guid? RowPointer);
		void DeleteFs_Tmp_Recon(ICollectionLoadResponse fs_tmp_reconLoadResponse);
		int? AltExtGen_SSSFSExpenseReconSaveSp(string AltExtGenSp, Guid? RowPointer, int? Selected);
	}
}

