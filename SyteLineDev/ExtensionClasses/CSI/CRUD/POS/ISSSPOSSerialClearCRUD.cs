using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.CRUD.POS
{
    public interface ISSSPOSSerialClearCRUD
    {
		bool CheckOptional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_Module1();
		void InsertOptional_Module1(ICollectionLoadResponse optional_module1LoadResponse);
		bool CheckTv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN1(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGEN2(string ALTGEN_SpName);
		void DeleteTv_ALTGEN2(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectPosm_Serial(string POSNum, int? TransNum, string Item);
		void DeletePosm_Serial(ICollectionLoadResponse posm_serialLoadResponse);
		int? AltExtGen_SSSPOSSerialClearSp(string AltExtGenSp, string POSNum, int? TransNum, string Item);
	}
}
