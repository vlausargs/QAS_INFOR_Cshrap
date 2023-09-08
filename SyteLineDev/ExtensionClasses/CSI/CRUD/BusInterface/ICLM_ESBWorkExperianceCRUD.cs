//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBWorkExperianceCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBWorkExperianceCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectEsbworkexperianceview(string EmpNum);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ESBWorkExperianceSp(string AltExtGenSp, string EmpNum);
	}
}

