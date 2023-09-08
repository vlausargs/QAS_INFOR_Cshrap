Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.Core.DataAccess

Imports CSI.Data.SQL.UDDT
Imports CSI.Material
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Data.RecordSets

<IDOExtensionClass("SLEcnitems")>
Public Class SLEcnitems
    Inherits CSIExtensionClassBase
    Public Overrides Sub SetContext(ByVal context As Mongoose.IDO.IIDOExtensionClassContext)

        MyBase.SetContext(context)

        ' Add event handlers for pre and post UpdateCollection
        AddHandler Me.Context.IDO.PreUpdateCollection, AddressOf Me.PreUpdateCollection

    End Sub

    Public Function AdjustValuesPQ(ByRef EcnitemType As String, ByRef Job As String, ByRef Suffix As String) As Integer
        Dim vEcnitemTypeL As String
        Try
            vEcnitemTypeL = Left(EcnitemType, 1)
            If vEcnitemTypeL = "C" Then
                Job = ""
                Suffix = ""
            End If
            Exit Function
        Catch ex As Exception
            AdjustValuesPQ = 16
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
    End Function
    <IDOMethod(MethodFlags.CustomLoad)>
    Public Function EcnCpEcnCustomLoad(ByVal FromEcnType As String,
                                        ByVal FromEcnNum As Integer,
                                        ByVal FromEcnStat As String,
                                        ByVal FromEcnJobType As String,
                                        ByVal FromBeginEcnLine As String,
                                        ByVal FromEndEcnLine As String,
                                        ByVal ToEcnNum As Integer,
                                        ByVal EcnLineOption As String,
                                        ByVal RunMode As Integer,
                                        ByRef Infobar As String) As DataTable

        Dim result As New DataTable()
        Dim dr As IDataReader = Nothing
        Using txn As ITransactionScope = TransactionScopeFactory.Create(Transactions.TransactionScopeOption.Required, Transactions.IsolationLevel.ReadCommitted, Transactions.TransactionManager.MaximumTimeout)
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()


                Using cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandText = "EcnCpEcnSp"
                    cmd.CommandType = CommandType.StoredProcedure
                    appDB.AddCommandParameterWithValue(cmd, "FromEcnType", FromEcnType)
                    appDB.AddCommandParameterWithValue(cmd, "FromEcnNum", FromEcnNum)
                    appDB.AddCommandParameterWithValue(cmd, "FromEcnStat", FromEcnStat)
                    appDB.AddCommandParameterWithValue(cmd, "FromEcnJobType", FromEcnJobType)
                    appDB.AddCommandParameterWithValue(cmd, "FromBeginEcnLine", FromBeginEcnLine)
                    appDB.AddCommandParameterWithValue(cmd, "FromEndEcnLine", FromEndEcnLine)
                    appDB.AddCommandParameterWithValue(cmd, "ToEcnNum", ToEcnNum)
                    appDB.AddCommandParameterWithValue(cmd, "EcnLineOption", EcnLineOption)
                    appDB.AddCommandParameterWithValue(cmd, "RunMode", RunMode)
                    appDB.DataProvider.AddCommandParameterWithValue(Of String)(cmd, "Infobar", Infobar, ParameterDirection.Output).Size = 5000
                    dr = appDB.ExecuteReader(cmd)
                    result = ConvertDataReaderToDataTable(dr)

                    If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                    ' if this is not a preview commit the txn
                    If RunMode <> 0 Then txn.Complete()

                    ' NOTE: output parameters are not supported on custom load methods
                    ' so I don't think this will ever get back to the caller
                    If Not IDONull.IsNull(CType(cmd.Parameters(9), IDbDataParameter).Value) Then
                        Infobar = CType(cmd.Parameters(9), IDbDataParameter).Value.ToString()
                    End If
                End Using
            End Using
        End Using

        Return result
    End Function
    Private Sub PreUpdateCollection(ByVal sender As Object, ByVal args As IDOEventArgs)

        Dim updateArgs As IDOUpdateEventArgs
        Dim updateRequest As UpdateCollectionRequestData
        Dim updateResponse As UpdateCollectionResponseData
        Dim oResponse As InvokeResponseData
        Dim canEstView As Boolean
        Dim canStdView As Boolean
        Dim canJobView As Boolean
        Dim sEcnitemType As String
        Dim canView As Boolean
        Dim bEstInsPer, bStdInsPer, bJobInsPer As Boolean
        Dim bInsPer As Boolean
        Dim bEstUpdPer, bStdUpdPer, bJobUpdPer As Boolean
        Dim bUpdPer As Boolean

        'Cast the args parameter as an IDOUpdateEventArgs
        updateArgs = CType(args, IDOUpdateEventArgs)

        'Cast the RequestPayload arg as an UpdateCollectionRequestData
        updateRequest = CType(updateArgs.RequestPayload, UpdateCollectionRequestData)

        'Create and initialize the response from request
        ' This will copy the properties from the request that are also
        'part of the response
        updateResponse = New UpdateCollectionResponseData(updateRequest)

        'If the user is a SuperUser, then the user can update the costs.
        'However, if the user is a normal user, he can update the costs if and only if he has permissions.
        'Check the user view permissions
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Est - ViewCosts", "", "0")
        canEstView = oResponse.Parameters(2).GetValue(Of Boolean)()
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Std - ViewCosts", "", "0")
        canStdView = oResponse.Parameters(2).GetValue(Of Boolean)()
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Job - ViewCosts", "", "0")
        canJobView = oResponse.Parameters(2).GetValue(Of Boolean)()

        'check the user insert permissions
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Est - Insert", "", "0")
        bEstInsPer = oResponse.Parameters(2).GetValue(Of Boolean)()
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Std - Insert", "", "0")
        bStdInsPer = oResponse.Parameters(2).GetValue(Of Boolean)()
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Job - Insert", "", "0")
        bJobInsPer = oResponse.Parameters(2).GetValue(Of Boolean)()

        'check the user update permissions
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Est - Update", "", "0")
        bEstUpdPer = oResponse.Parameters(2).GetValue(Of Boolean)()
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Std - Update", "", "0")
        bStdUpdPer = oResponse.Parameters(2).GetValue(Of Boolean)()
        oResponse = Me.Context.Commands.Invoke("UserNames", "CanAny", "ECN - Job - Update", "", "0")
        bJobUpdPer = oResponse.Parameters(2).GetValue(Of Boolean)()


        For Each updateItem As IDOUpdateItem In updateRequest.Items
            canView = False
            bInsPer = False
            bUpdPer = False

            sEcnitemType = updateItem.Properties("EcnitemType").Value
            Select Case (sEcnitemType)
                Case "EM"
                    canView = canEstView
                Case "CM"
                    canView = canStdView
                Case "JM"
                    canView = canJobView
            End Select

            Select Case (sEcnitemType)
                Case "EM"
                    bInsPer = bEstInsPer
                Case "CM"
                    bInsPer = bStdInsPer
                Case "JM"
                    bInsPer = bJobInsPer
            End Select

            Select Case (sEcnitemType)
                Case "EM"
                    bUpdPer = bEstUpdPer
                Case "CM"
                    bUpdPer = bStdUpdPer
                Case "JM"
                    bUpdPer = bJobUpdPer
            End Select

            'if the user has view permissions then
            '   - 1) if the action is insert and the user has insert permissions or
            '   - 2) if the action is update and the user has update permissions then 
            'set the modified values back to the original cost properties and mark them as modified
            If (canView And ((CBool(updateArgs.ActionMask And UpdateAction.Insert And updateItem.Action) And (bInsPer)) Or
                    (CBool(updateArgs.ActionMask And UpdateAction.Update And updateItem.Action) And (bUpdPer)))) Then
                updateItem.Properties("MatlCostConv").SetValue(updateItem.Properties("DerMatlCostConv").GetValue(Of Decimal)(0))
                updateItem.Properties("MatlCostConv").Modified = True
                updateItem.Properties("LbrCostConv").SetValue(updateItem.Properties("DerLbrCostConv").GetValue(Of Decimal)(0))
                updateItem.Properties("LbrCostConv").Modified = True
                updateItem.Properties("FovhdCostConv").SetValue(updateItem.Properties("DerFovhdCostConv").GetValue(Of Decimal)(0))
                updateItem.Properties("FovhdCostConv").Modified = True
                updateItem.Properties("VovhdCostConv").SetValue(updateItem.Properties("DerVovhdCostConv").GetValue(Of Decimal)(0))
                updateItem.Properties("VovhdCostConv").Modified = True
                updateItem.Properties("OutCostConv").SetValue(updateItem.Properties("DerOutCostConv").GetValue(Of Decimal)(0))
                updateItem.Properties("OutCostConv").Modified = True
                updateItem.Properties("CostConv").SetValue(updateItem.Properties("DerCostConv").GetValue(Of Decimal)(0))
                updateItem.Properties("CostConv").Modified = True
            End If
        Next
    End Sub

    Public Function SelectData(ByVal sqlCommand As String) As DataTable
        Dim oDataReader As IDataReader = Nothing
        Dim results As DataTable = New DataTable()
        Dim ds As DataSet = New DataSet
        Try
            Dim dr As IDataReader = Nothing
            Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
                Try
                    Dim cmd As IDbCommand = appDB.CreateCommand()
                    cmd.CommandText = sqlCommand
                    dr = appDB.ExecuteReader(cmd)
                    results = ConvertDataReaderToDataTable(dr)
                Catch ex As Exception
                    MGException.Throw(MGException.ExtractMessages(ex))
                Finally
                    If Not dr Is Nothing AndAlso Not dr.IsClosed Then
                        dr.Close()
                    End If
                End Try
            End Using
        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
        Return results
    End Function

    Private Function ConvertDataReaderToDataTable(ByVal reader As IDataReader) As DataTable
        Dim objDataTable As New DataTable
        Dim intFieldCount As Integer = reader.FieldCount
        Dim intCounter As Integer
        For intCounter = 0 To intFieldCount - 1
            objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter))
        Next intCounter

        objDataTable.BeginLoadData()
        Dim objValues(intFieldCount - 1) As Object
        While reader.Read()
            reader.GetValues(objValues)
            objDataTable.LoadDataRow(objValues, True)
        End While
        reader.Close()
        objDataTable.EndLoadData()

        Return objDataTable

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CheckAlternateBOMExistSp(ByVal Item As String,
                                             ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCheckAlternateBOMExistExt As ICheckAlternateBOMExist = New CheckAlternateBOMExistFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iCheckAlternateBOMExistExt.CheckAlternateBOMExistSp(Item, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ChglstatSp(ByVal EcnitemFStat As String,
                               ByVal EcnitemTStat As String,
                               ByVal EcnFrom As Integer?,
                               ByVal EcnTo As Integer?,
                               ByVal EcnFromLine As Integer?,
                               ByVal EcnToLine As Integer?,
                               ByVal PProcess As Byte?,
                               ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iChglstatExt As IChglstat = New ChglstatFactory().Create(appDb, bunchedLoadCollection)

            Dim oInfobar As InfobarType = Infobar

            Dim dt As DataTable = iChglstatExt.ChglstatSp(EcnitemFStat, EcnitemTStat, EcnFrom, EcnTo, EcnFromLine, EcnToLine, PProcess, oInfobar)

            Infobar = oInfobar

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniBomMatlRefSp(ByVal InJob As String,
                                     ByVal InSuffix As String,
                                     ByVal InOperNum As String,
                                     ByVal InSequence As String,
                                     ByVal InRefSeq As String,
                                     ByRef OutRefExists As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniBomMatlRefExt As IEcniBomMatlRef = New EcniBomMatlRefFactory().Create(appDb)

            Dim oOutRefExists As FlagNyType = OutRefExists

            Dim Severity As Integer = iEcniBomMatlRefExt.EcniBomMatlRefSp(InJob, InSuffix, InOperNum, InSequence, InRefSeq, oOutRefExists)

            OutRefExists = oOutRefExists

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniBomMatlSp(ByVal InJob As String,
                                  ByVal InSuffix As String,
                                  ByVal InOperNum As String,
                                  ByVal InSequence As String,
                                  ByRef OutOperExists As Byte?,
                                  ByRef OutSeqExists As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniBomMatlExt As IEcniBomMatl = New EcniBomMatlFactory().Create(appDb)

            Dim oOutOperExists As FlagNyType = OutOperExists
            Dim oOutSeqExists As FlagNyType = OutSeqExists

            Dim Severity As Integer = iEcniBomMatlExt.EcniBomMatlSp(InJob, InSuffix, InOperNum, InSequence, oOutOperExists, oOutSeqExists)

            OutOperExists = oOutOperExists
            OutSeqExists = oOutSeqExists

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniBomSeqSp(ByVal InJob As String,
                                 ByVal InSuffix As String,
                                 ByVal InOperNum As String,
                                 ByVal InSequence As String,
                                 ByVal InBomSeq As String,
                                 ByRef OutExists As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniBomSeqExt As IEcniBomSeq = New EcniBomSeqFactory().Create(appDb)

            Dim oOutExists As FlagNyType = OutExists

            Dim Severity As Integer = iEcniBomSeqExt.EcniBomSeqSp(InJob, InSuffix, InOperNum, InSequence, InBomSeq, oOutExists)

            OutExists = oOutExists

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniConvCostSp(ByVal PNewUM As String,
                                   ByVal POldUM As String,
                                   ByVal PItem As String,
                                   ByVal PVendNum As String,
                                   ByVal PArea As String,
                                   ByRef PMatlCostConv As Decimal?,
                                   ByRef PLbrCostConv As Decimal?,
                                   ByRef PFovhdCostConv As Decimal?,
                                   ByRef PVovhdCostConv As Decimal?,
                                   ByRef POutCostConv As Decimal?,
                                   ByRef PIncPriceConv As Decimal?,
                                   ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniConvCostExt As IEcniConvCost = New EcniConvCostFactory().Create(appDb)

            Dim oPMatlCostConv As CostPrcType = PMatlCostConv
            Dim oPLbrCostConv As CostPrcType = PLbrCostConv
            Dim oPFovhdCostConv As CostPrcType = PFovhdCostConv
            Dim oPVovhdCostConv As CostPrcType = PVovhdCostConv
            Dim oPOutCostConv As CostPrcType = POutCostConv
            Dim oPIncPriceConv As CostPrcType = PIncPriceConv
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iEcniConvCostExt.EcniConvCostSp(PNewUM, POldUM, PItem, PVendNum, PArea, oPMatlCostConv, oPLbrCostConv, oPFovhdCostConv, oPVovhdCostConv, oPOutCostConv, oPIncPriceConv, oInfobar)

            PMatlCostConv = oPMatlCostConv
            PLbrCostConv = oPLbrCostConv
            PFovhdCostConv = oPFovhdCostConv
            PVovhdCostConv = oPVovhdCostConv
            POutCostConv = oPOutCostConv
            PIncPriceConv = oPIncPriceConv
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniDeleteGroupSp(ByVal InGroup As String, ByVal InDelStd As String, ByVal InDelJob As String, ByVal InDelEst As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iecniDeleteGroupExt As IEcniDeleteGroup = New EcniDeleteGroupFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iecniDeleteGroupExt.ecniDeleteGroupSp(InGroup, InDelStd, InDelJob, InDelEst)
            Return result.Value
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniGetRevisionAndItemDescSp(ByVal PRevision As String,
                                                 ByVal PItem As String,
                                                 ByVal PEcnitemType As String,
                                                 ByRef PJob As String,
                                                 ByVal PSuffix As Short?,
                                                 ByRef PDrawingNbr As String,
                                                 ByRef PItemDesc As String,
                                                 ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniGetRevisionAndItemDescExt As IEcniGetRevisionAndItemDesc = New EcniGetRevisionAndItemDescFactory().Create(appDb)

            Dim oPJob As LongListType = PJob
            Dim oPDrawingNbr As LongListType = PDrawingNbr
            Dim oPItemDesc As DescriptionType = PItemDesc
            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iEcniGetRevisionAndItemDescExt.EcniGetRevisionAndItemDescSp(PRevision, PItem, PEcnitemType, oPJob, PSuffix, oPDrawingNbr, oPItemDesc, oInfobar)

            PJob = oPJob
            PDrawingNbr = oPDrawingNbr
            PItemDesc = oPItemDesc
            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniMaterialValuesSp(ByVal InJob As String,
                                         ByVal InSuffix As Short?,
                                         ByVal InOperNum As Integer?,
                                         ByVal InSequence As Short?,
                                         ByRef OutWc As String,
                                         ByRef OutWcDesc As String,
                                         ByRef OutSequence As Short?,
                                         ByRef OutItem As String,
                                         ByRef OutItmDesc As String,
                                         ByRef OutMatlType As String,
                                         ByRef OutMatlQtyConv As Decimal?,
                                         ByRef OutUnits As String,
                                         ByRef OutUM As String,
                                         ByRef OutBomSeq As Short?,
                                         ByRef OutScrapFact As Decimal?,
                                         ByRef OutRefType As String,
                                         ByRef OutFeature As String,
                                         ByRef OutOptCode As String,
                                         ByRef OutProbable As Decimal?,
                                         ByRef OutIncPriceConv As Decimal?,
                                         ByRef OutEffectDate As DateTime?,
                                         ByRef OutObsDate As DateTime?,
                                         ByRef OutMatlCostConv As Decimal?,
                                         ByRef OutLbrCostConv As Decimal?,
                                         ByRef OutFovhdCostConv As Decimal?,
                                         ByRef OutVovhdCostConv As Decimal?,
                                         ByRef OutOutCostConv As Decimal?,
                                         ByRef OutCostConv As Decimal?,
                                         ByRef OutAltGroup As Short?,
                                         ByRef OutAltGroupRank As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniMaterialValuesExt As IEcniMaterialValues = New EcniMaterialValuesFactory().Create(appDb)

            Dim oOutWc As WcType = OutWc
            Dim oOutWcDesc As DescriptionType = OutWcDesc
            Dim oOutSequence As JobmatlSequenceType = OutSequence
            Dim oOutItem As ItemType = OutItem
            Dim oOutItmDesc As DescriptionType = OutItmDesc
            Dim oOutMatlType As MatlTypeType = OutMatlType
            Dim oOutMatlQtyConv As QtyPerType = OutMatlQtyConv
            Dim oOutUnits As JobmatlUnitsType = OutUnits
            Dim oOutUM As UMType = OutUM
            Dim oOutBomSeq As EcnBomSeqType = OutBomSeq
            Dim oOutScrapFact As ScrapFactorType = OutScrapFact
            Dim oOutRefType As RefTypeIJKPRTType = OutRefType
            Dim oOutFeature As FeatureType = OutFeature
            Dim oOutOptCode As OptCodeType = OutOptCode
            Dim oOutProbable As ProbableType = OutProbable
            Dim oOutIncPriceConv As CostPrcType = OutIncPriceConv
            Dim oOutEffectDate As DateType = OutEffectDate
            Dim oOutObsDate As DateType = OutObsDate
            Dim oOutMatlCostConv As CostPrcType = OutMatlCostConv
            Dim oOutLbrCostConv As CostPrcType = OutLbrCostConv
            Dim oOutFovhdCostConv As CostPrcType = OutFovhdCostConv
            Dim oOutVovhdCostConv As CostPrcType = OutVovhdCostConv
            Dim oOutOutCostConv As CostPrcType = OutOutCostConv
            Dim oOutCostConv As CostPrcType = OutCostConv
            Dim oOutAltGroup As JobmatlSequenceType = OutAltGroup
            Dim oOutAltGroupRank As JobmatlRankType = OutAltGroupRank

            Dim Severity As Integer = iEcniMaterialValuesExt.EcniMaterialValuesSp(InJob, InSuffix, InOperNum, InSequence, oOutWc, oOutWcDesc, oOutSequence, oOutItem, oOutItmDesc, oOutMatlType, oOutMatlQtyConv, oOutUnits, oOutUM, oOutBomSeq, oOutScrapFact, oOutRefType, oOutFeature, oOutOptCode, oOutProbable, oOutIncPriceConv, oOutEffectDate, oOutObsDate, oOutMatlCostConv, oOutLbrCostConv, oOutFovhdCostConv, oOutVovhdCostConv, oOutOutCostConv, oOutCostConv, oOutAltGroup, oOutAltGroupRank)

            OutWc = oOutWc
            OutWcDesc = oOutWcDesc
            OutSequence = oOutSequence
            OutItem = oOutItem
            OutItmDesc = oOutItmDesc
            OutMatlType = oOutMatlType
            OutMatlQtyConv = oOutMatlQtyConv
            OutUnits = oOutUnits
            OutUM = oOutUM
            OutBomSeq = oOutBomSeq
            OutScrapFact = oOutScrapFact
            OutRefType = oOutRefType
            OutFeature = oOutFeature
            OutOptCode = oOutOptCode
            OutProbable = oOutProbable
            OutIncPriceConv = oOutIncPriceConv
            OutEffectDate = oOutEffectDate
            OutObsDate = oOutObsDate
            OutMatlCostConv = oOutMatlCostConv
            OutLbrCostConv = oOutLbrCostConv
            OutFovhdCostConv = oOutFovhdCostConv
            OutVovhdCostConv = oOutVovhdCostConv
            OutOutCostConv = oOutOutCostConv
            OutCostConv = oOutCostConv
            OutAltGroup = oOutAltGroup
            OutAltGroupRank = oOutAltGroupRank

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniMatlItemSp(ByRef InItem As String, ByVal InJob As String, ByVal InSuffix As String, ByVal InOperNum As String, ByRef OutValidItm As Byte?, ByRef OutSerial As Byte?, ByRef OutMatlStat As String, ByRef OutSeq As String, ByRef OutDescription As String, ByRef OutMatlType As String, ByRef OutUM As String, ByRef OutStocked As Byte?, ByRef OutPmtCode As String, ByRef OutPreqJob As Byte?, ByRef OutMatlCost As String, ByRef OutLbrCost As String, ByRef OutFovhdCost As String, ByRef OutVovhdCost As String, ByRef OutOutCost As String, ByRef OutCost As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iecniMatlItemExt As IecniMatlItem = New ecniMatlItemFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, InItem As String, OutValidItm As Byte?, OutSerial As Byte?, OutMatlStat As String, OutSeq As String, OutDescription As String, OutMatlType As String, OutUM As String, OutStocked As Byte?, OutPmtCode As String, OutPreqJob As Byte?, OutMatlCost As String, OutLbrCost As String, OutFovhdCost As String, OutVovhdCost As String, OutOutCost As String, OutCost As String, Infobar As String) = iecniMatlItemExt.ecniMatlItemSp(InItem, InJob, InSuffix, InOperNum, OutValidItm, OutSerial, OutMatlStat, OutSeq, OutDescription, OutMatlType, OutUM, OutStocked, OutPmtCode, OutPreqJob, OutMatlCost, OutLbrCost, OutFovhdCost, OutVovhdCost, OutOutCost, OutCost, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            InItem = result.InItem
            OutValidItm = result.OutValidItm
            OutSerial = result.OutSerial
            OutMatlStat = result.OutMatlStat
            OutSeq = result.OutSeq
            OutDescription = result.OutDescription
            OutMatlType = result.OutMatlType
            OutUM = result.OutUM
            OutStocked = result.OutStocked
            OutPmtCode = result.OutPmtCode
            OutPreqJob = result.OutPreqJob
            OutMatlCost = result.OutMatlCost
            OutLbrCost = result.OutLbrCost
            OutFovhdCost = result.OutFovhdCost
            OutVovhdCost = result.OutVovhdCost
            OutOutCost = result.OutOutCost
            OutCost = result.OutCost
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniOperationValuesSp(ByVal InJob As String,
                                          ByVal InSuffix As String,
                                          ByVal InOperNum As String,
                                          ByRef OutWc As String,
                                          ByRef OutBflushType As String,
                                          ByRef OutRunMchHrs As Decimal?,
                                          ByRef OutRunLbrHrs As Decimal?,
                                          ByRef OutRunBasisMch As String,
                                          ByRef OutRunBasisLbr As String,
                                          ByRef OutEffDate As String,
                                          ByRef OutObsDate As String,
                                          ByRef OutMoveHrs As String,
                                          ByRef OutQueueHrs As String,
                                          ByRef OutSetupHrs As String,
                                          ByRef OutFinishHrs As String,
                                          ByRef OutOffsetHrs As String,
                                          ByRef OutSchedHrs As String,
                                          ByRef OutWcDesc As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniOperationValuesExt As IEcniOperationValues = New EcniOperationValuesFactory().Create(appDb)

            Dim oOutWc As LongListType = OutWc
            Dim oOutBflushType As LongListType = OutBflushType
            Dim oOutRunMchHrs As RunHoursPiecesType = OutRunMchHrs
            Dim oOutRunLbrHrs As RunHoursPiecesType = OutRunLbrHrs
            Dim oOutRunBasisMch As LongListType = OutRunBasisMch
            Dim oOutRunBasisLbr As LongListType = OutRunBasisLbr
            Dim oOutEffDate As LongListType = OutEffDate
            Dim oOutObsDate As LongListType = OutObsDate
            Dim oOutMoveHrs As LongListType = OutMoveHrs
            Dim oOutQueueHrs As LongListType = OutQueueHrs
            Dim oOutSetupHrs As LongListType = OutSetupHrs
            Dim oOutFinishHrs As LongListType = OutFinishHrs
            Dim oOutOffsetHrs As LongListType = OutOffsetHrs
            Dim oOutSchedHrs As LongListType = OutSchedHrs
            Dim oOutWcDesc As DescriptionType = OutWcDesc

            Dim Severity As Integer = iEcniOperationValuesExt.EcniOperationValuesSp(InJob, InSuffix, InOperNum, oOutWc, oOutBflushType, oOutRunMchHrs, oOutRunLbrHrs, oOutRunBasisMch, oOutRunBasisLbr, oOutEffDate, oOutObsDate, oOutMoveHrs, oOutQueueHrs, oOutSetupHrs, oOutFinishHrs, oOutOffsetHrs, oOutSchedHrs, oOutWcDesc)

            OutWc = oOutWc
            OutBflushType = oOutBflushType
            OutRunMchHrs = oOutRunMchHrs
            OutRunLbrHrs = oOutRunLbrHrs
            OutRunBasisMch = oOutRunBasisMch
            OutRunBasisLbr = oOutRunBasisLbr
            OutEffDate = oOutEffDate
            OutObsDate = oOutObsDate
            OutMoveHrs = oOutMoveHrs
            OutQueueHrs = oOutQueueHrs
            OutSetupHrs = oOutSetupHrs
            OutFinishHrs = oOutFinishHrs
            OutOffsetHrs = oOutOffsetHrs
            OutSchedHrs = oOutSchedHrs
            OutWcDesc = oOutWcDesc

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniOperNumSp(ByVal PEcnitemType As String,
                                      ByVal PJob As String,
                                      ByVal PSuffix As Short?,
                                      ByVal POperNum As Integer?,
                                      ByVal PActionCode As String,
                                      ByVal PItem As String,
                                      ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniOperNumExt As IEcniOperNum = New EcniOperNumFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iEcniOperNumExt.EcniOperNumSp(PEcnitemType, PJob, PSuffix, POperNum, PActionCode, PItem, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniReferenceValuesSp(ByVal InJob As String,
                                          ByVal InSuffix As Short?,
                                          ByVal InOperNum As Integer?,
                                          ByVal InSequence As Short?,
                                          ByVal InRefSeq As Short?,
                                          ByRef OutItem As String,
                                          ByRef OutDescription As String,
                                          ByRef OutWc As String,
                                          ByRef OutWcDesc As String,
                                          ByRef OutBubble As String,
                                          ByRef OutRefDes As String,
                                          ByRef OutAssySeq As String,
                                          ByRef OutValidOper As Byte?,
                                          ByRef OutValidSeq As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniReferenceValuesExt As IEcniReferenceValues = New EcniReferenceValuesFactory().Create(appDb)

            Dim oOutItem As ItemType = OutItem
            Dim oOutDescription As DescriptionType = OutDescription
            Dim oOutWc As WcType = OutWc
            Dim oOutWcDesc As DescriptionType = OutWcDesc
            Dim oOutBubble As BubbleType = OutBubble
            Dim oOutRefDes As RefDesignatorType = OutRefDes
            Dim oOutAssySeq As AssemblySeqType = OutAssySeq
            Dim oOutValidOper As FlagNyType = OutValidOper
            Dim oOutValidSeq As FlagNyType = OutValidSeq

            Dim Severity As Integer = iEcniReferenceValuesExt.EcniReferenceValuesSp(InJob, InSuffix, InOperNum, InSequence, InRefSeq, oOutItem, oOutDescription, oOutWc, oOutWcDesc, oOutBubble, oOutRefDes, oOutAssySeq, oOutValidOper, oOutValidSeq)

            OutItem = oOutItem
            OutDescription = oOutDescription
            OutWc = oOutWc
            OutWcDesc = oOutWcDesc
            OutBubble = oOutBubble
            OutRefDes = oOutRefDes
            OutAssySeq = oOutAssySeq
            OutValidOper = oOutValidOper
            OutValidSeq = oOutValidSeq

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniWcSp(ByVal InWc As String,
                             ByRef OutMoveHrs As String,
                             ByRef OutQueueHrs As String,
                             ByRef OutBflushType As String,
                             ByRef OutWcDesc As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iEcniWcExt As IEcniWc = New EcniWcFactory().Create(appDb)

            Dim oOutMoveHrs As LongListType = OutMoveHrs
            Dim oOutQueueHrs As LongListType = OutQueueHrs
            Dim oOutBflushType As LongListType = OutBflushType
            Dim oOutWcDesc As DescriptionType = OutWcDesc

            Dim Severity As Integer = iEcniWcExt.EcniWcSp(InWc, oOutMoveHrs, oOutQueueHrs, oOutBflushType, oOutWcDesc)

            OutMoveHrs = oOutMoveHrs
            OutQueueHrs = oOutQueueHrs
            OutBflushType = oOutBflushType
            OutWcDesc = oOutWcDesc

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetBomSequenceSp(ByVal Job As String, ByVal Suffix As Integer?, ByVal OperNum As Integer?, ByVal AltGroup As Integer?, ByVal Type As String, ByVal ItmItem As String,
<[Optional]> ByRef BomSequence As Integer?,
<[Optional]> ByRef Sequence As Integer?, ByRef IsExistRef As Integer?, ByRef AltGroupRank As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetBomSequenceExt As IGetBomSequence = New GetBomSequenceFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, BomSequence As Integer?, Sequence As Integer?, IsExistRef As Integer?, AltGroupRank As Integer?, Infobar As String) = iGetBomSequenceExt.GetBomSequenceSp(Job, Suffix, OperNum, AltGroup, Type, ItmItem, BomSequence, Sequence, IsExistRef, AltGroupRank, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            BomSequence = result.BomSequence
            Sequence = result.Sequence
            IsExistRef = result.IsExistRef
            AltGroupRank = result.AltGroupRank
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniCheckGroup(ByVal InGroup As String, ByRef OutError As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iecniCheckGroupExt As IecniCheckGroup = New ecniCheckGroupFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, OutError As Byte?) = iecniCheckGroupExt.ecniCheckGroupSp(InGroup, OutError)
            Dim Severity As Integer = result.ReturnCode.Value
            OutError = result.OutError
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPermissions(ByRef CanEstDel As Byte?, ByRef CanEstIns As Byte?, ByRef CanEstUpd As Byte?, ByRef CanEstViewCosts As Byte?, ByRef CanJobDel As Byte?, ByRef CanJobIns As Byte?, ByRef CanJobUpd As Byte?, ByRef CanJobViewCosts As Byte?, ByRef CanStdDel As Byte?, ByRef CanStdIns As Byte?, ByRef CanStdUpd As Byte?, ByRef CanStdViewCosts As Byte?, ByRef CanAnyDel As Byte?, ByRef CanAnyIns As Byte?, ByRef CanAnyUpd As Byte?, ByRef CanAnyViewCosts As Byte?, ByRef CanApprove As Byte?, ByRef CanItemUpd As Byte?, ByRef CanItemMfrIns As Byte?, ByRef CanItemMfrUpd As Byte?, ByRef CanItemMfrDel As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iecniPermissionsExt As IecniPermissions = New ecniPermissionsFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CanEstDel As Byte?, CanEstIns As Byte?, CanEstUpd As Byte?, CanEstViewCosts As Byte?, CanJobDel As Byte?, CanJobIns As Byte?, CanJobUpd As Byte?, CanJobViewCosts As Byte?, CanStdDel As Byte?, CanStdIns As Byte?, CanStdUpd As Byte?, CanStdViewCosts As Byte?, CanAnyDel As Byte?, CanAnyIns As Byte?, CanAnyUpd As Byte?, CanAnyViewCosts As Byte?, CanApprove As Byte?, CanItemUpd As Byte?, CanItemMfrIns As Byte?, CanItemMfrUpd As Byte?, CanItemMfrDel As Byte?) = iecniPermissionsExt.ecniPermissionsSp(CanEstDel, CanEstIns, CanEstUpd, CanEstViewCosts, CanJobDel, CanJobIns, CanJobUpd, CanJobViewCosts, CanStdDel, CanStdIns, CanStdUpd, CanStdViewCosts, CanAnyDel, CanAnyIns, CanAnyUpd, CanAnyViewCosts, CanApprove, CanItemUpd, CanItemMfrIns, CanItemMfrUpd, CanItemMfrDel)
            Dim Severity As Integer = result.ReturnCode.Value
            CanEstDel = result.CanEstDel
            CanEstIns = result.CanEstIns
            CanEstUpd = result.CanEstUpd
            CanEstViewCosts = result.CanEstViewCosts
            CanJobDel = result.CanJobDel
            CanJobIns = result.CanJobIns
            CanJobUpd = result.CanJobUpd
            CanJobViewCosts = result.CanJobViewCosts
            CanStdDel = result.CanStdDel
            CanStdIns = result.CanStdIns
            CanStdUpd = result.CanStdUpd
            CanStdViewCosts = result.CanStdViewCosts
            CanAnyDel = result.CanAnyDel
            CanAnyIns = result.CanAnyIns
            CanAnyUpd = result.CanAnyUpd
            CanAnyViewCosts = result.CanAnyViewCosts
            CanApprove = result.CanApprove
            CanItemUpd = result.CanItemUpd
            CanItemMfrIns = result.CanItemMfrIns
            CanItemMfrUpd = result.CanItemMfrUpd
            CanItemMfrDel = result.CanItemMfrDel
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EcnChgRevSp(ByVal SelectedItem As String, ByVal NewRev As String, ByVal NewDrawing As String, ByVal RunMode As Integer?, ByRef Infobar As String,
        <[Optional]> ByVal CalledFrom As String,
        <[Optional], DefaultParameterValue(0)> ByVal CopyUetValues As Integer?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEcnChgRevExt As IEcnChgRev = New EcnChgRevFactory().Create(Me, True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iEcnChgRevExt.EcnChgRevSp(SelectedItem, NewRev, NewDrawing, RunMode, Infobar, CalledFrom, CopyUetValues)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function EcnCpEcnSp(ByVal FromEcnType As String, ByVal FromEcnNum As Integer?, ByVal FromEcnStat As String, ByVal FromEcnJobType As String, ByVal FromBeginEcnLine As Integer?, ByVal FromEndEcnLine As Integer?, ByVal ToEcnNum As Integer?, ByVal EcnLineOption As String, ByVal RunMode As Byte?, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iEcnCpEcnExt As IEcnCpEcn = New EcnCpEcnFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iEcnCpEcnExt.EcnCpEcnSp(FromEcnType, FromEcnNum, FromEcnStat, FromEcnJobType, FromBeginEcnLine, FromEndEcnLine, ToEcnNum, EcnLineOption, RunMode, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniJobSp(ByVal InEcnitemType As String, ByVal InJob As String, ByVal InSuffix As String, ByVal InQuick As Byte?, ByRef OutType As String, ByRef OutStat As String, ByRef OutItem As String, ByRef OutRevision As String, ByRef OutDrawingNbr As String, ByRef OutDescription As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iecniJobExt As IEcniJob = New EcniJobFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, OutType As String, OutStat As String, OutItem As String, OutRevision As String, OutDrawingNbr As String, OutDescription As String, Infobar As String) = iecniJobExt.ecniJobSp(InEcnitemType, InJob, InSuffix, InQuick, OutType, OutStat, OutItem, OutRevision, OutDrawingNbr, OutDescription, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            OutType = result.OutType
            OutStat = result.OutStat
            OutItem = result.OutItem
            OutRevision = result.OutRevision
            OutDrawingNbr = result.OutDrawingNbr
            OutDescription = result.OutDescription
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function EcniRevisionSp(ByVal InRevision As String, ByVal InItem As String, ByRef OutJob As String, ByRef OutDrawingNbr As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iecniRevisionExt As IEcniRevision = New EcniRevisionFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, OutJob As String, OutDrawingNbr As String, Infobar As String) = iecniRevisionExt.ecniRevisionSp(InRevision, InItem, OutJob, OutDrawingNbr, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            OutJob = result.OutJob
            OutDrawingNbr = result.OutDrawingNbr
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function Rpt_SubItemRevisionECNItemsSp(
        <[Optional]> ByVal ItemItem As String,
        <[Optional]> ByVal ItemRevision As String,
        <[Optional]> ByVal ECNNumStarting As Integer?,
        <[Optional]> ByVal ECNNumEnding As Integer?,
        <[Optional]> ByVal PrintECNItemsNotes As Integer?,
        <[Optional]> ByVal PrintInternalNotes As Integer?,
        <[Optional]> ByVal PrintExternalNotes As Integer?,
        <[Optional]> ByVal pSite As String) As DataTable
        Dim iRpt_SubItemRevisionECNItemsExt As IRpt_SubItemRevisionECNItems = New Rpt_SubItemRevisionECNItemsFactory().Create(Me, True)
        Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iRpt_SubItemRevisionECNItemsExt.Rpt_SubItemRevisionECNItemsSp(ItemItem, ItemRevision, ECNNumStarting, ECNNumEnding, PrintECNItemsNotes, PrintInternalNotes, PrintExternalNotes, pSite)
        Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
        Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
        Return dt
    End Function
End Class
