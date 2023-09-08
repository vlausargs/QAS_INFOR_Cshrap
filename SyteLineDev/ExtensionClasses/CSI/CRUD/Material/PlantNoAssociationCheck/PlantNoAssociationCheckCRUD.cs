using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;

namespace CSI.CRUD.Material.PlantNoAssociationCheck
{
    public interface IPlantNoAssocationCheckCRUD    
    {
        (WhseType, IntType, IntType, IntType, IntType) GetPlantAssociationCounts(PlantType Plant);
    }

    public class PlantNoAssociationCheckCRUD : IPlantNoAssocationCheckCRUD
    {
        private readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        private readonly IApplicationDB appDB;

        public PlantNoAssociationCheckCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB)
        {   
            this.collectionLoadRequestFactory = collectionLoadRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadRequestFactory));
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public (WhseType, IntType, IntType, IntType, IntType) GetPlantAssociationCounts(PlantType Plant)
        {
            WhseType MfgWhse = DBNull.Value;
            IntType WhseCount = DBNull.Value;
            IntType WCCount = DBNull.Value;
            IntType RGRPCount = DBNull.Value;
            IntType RESRCCount = DBNull.Value;

            var request = collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {MfgWhse, "mfg_whse" },
                    {WhseCount, "whse_count" },
                    {WCCount, "wc_count" },
                    {RGRPCount, "rgrp_count" },
                    {RESRCCount, "resrc_count" }

                },
                tableName: "PlantAssociationCountsView",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause("WITH (READUNCOMMITTED)"),
                orderByClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("plant = {0}", Plant)
                );

            appDB.Load(request);

            return (MfgWhse, WhseCount, WCCount, RGRPCount, RESRCCount);
        }
    }
}
