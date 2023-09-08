Public Class SLDefinition850


    ' setup definitions here
    ' 850
    Private Const EDI_LEVELS_850 = "850 100 110 115 120 140 145 150 170 300 305 310 320 370"

    Private Const EDI_DATASIZE_850_100 = "850 100 0 2 22 8 7 3 11 5 15 3 96 2 75 20 305 20 20 20 8 12 12 12 3 50 293"
    Private Const EDI_DATASIZE_850_110 = "850 110 0 2 22 15 3 130 40 40 772"
    Private Const EDI_DATASIZE_850_115 = "850 115 0 2 22 15 3 129 15 22 20 796"
    Private Const EDI_DATASIZE_850_120 = "850 120 0 2 22 15 3 127 2 2 6 845"
    Private Const EDI_DATASIZE_850_140 = "850 140 0 2 22 15 3 982"
    Private Const EDI_DATASIZE_850_145 = "850 145 0 2 22 15 3 130 40 40 772"
    Private Const EDI_DATASIZE_850_150 = "850 150 0 2 22 15 3 129 15 22 20 796"
    Private Const EDI_DATASIZE_850_170 = "850 170 0 2 22 15 3 130 40 40 772"
    Private Const EDI_DATASIZE_850_300 = "850 300 0 2 22 9 6 3 11 5 85 15 31 30 30 9 2 14 2 68 8 4 9 60 40 40 519"
    Private Const EDI_DATASIZE_850_305 = "850 305 0 2 22 15 3 578 3 8 393"
    Private Const EDI_DATASIZE_850_310 = "850 310 0 2 22 15 3 130 40 40 772"
    Private Const EDI_DATASIZE_850_320 = "850 320 0 2 22 15 3 131 6 845"
    Private Const EDI_DATASIZE_850_370 = "850 370 0 2 22 15 3 130 40 40 772"

    Private Const EDI_COLNAMES_850_100 = "850 100 tmp_edi_co_100 tp_code:SAVE cust_po order_date NA rec_type:LEVEL NA cust_tp_code:SAVE NA trx_code NA co_type NA phone NA charfld1 charfld2 charfld3 datefld decifld1 decifld2 decifld3 logifld AU_ext_payment_ref_num NA"
    Private Const EDI_COLNAMES_850_110 = "850 110 tmp_edi_co_100 tp_code:GET cust_po NA rec_type:LEVEL NA hdr_notes1 hdr_notes2 NA"
    Private Const EDI_COLNAMES_850_115 = "850 115 tmp_edi_co_100 tp_code:GET cust_po NA rec_type:LEVEL NA contact NA contact_phone NA"
    Private Const EDI_COLNAMES_850_120 = "850 120 tmp_edi_co_100 tp_code:GET cust_po NA rec_type:LEVEL NA terms_code NA disc NA"
    Private Const EDI_COLNAMES_850_140 = "850 140 tmp_edi_co_100 tp_code:GET cust_po NA rec_type:LEVEL NA"
    Private Const EDI_COLNAMES_850_145 = "850 145 tmp_edi_co_100 tp_code:GET cust_po NA rec_type:LEVEL NA hdr_notes1 hdr_notes2 NA"
    Private Const EDI_COLNAMES_850_150 = "850 150 tmp_edi_co_100 tp_code:GET cust_po NA rec_type:LEVEL NA contact NA contact_phone NA"
    Private Const EDI_COLNAMES_850_170 = "850 170 tmp_edi_co_100 tp_code:GET cust_po NA rec_type:LEVEL NA hdr_notes1 hdr_notes2 NA"
    Private Const EDI_COLNAMES_850_300 = "850 300 tmp_edi_co_300 tp_code:SAVE cust_po NA ext_ref rec_type:LEVEL NA cust_tp_code:SAVE NA alt_cust_tp_code NA cust_item item qty_ordered u_m price pricecode NA due_date NA blanket_qty NA line_notes1 line_notes2 NA"
    Private Const EDI_COLNAMES_850_305 = "850 305 tmp_edi_co_300 tp_code:GET cust_po NA rec_type:LEVEL NA date_qualifier exp_date NA"
    Private Const EDI_COLNAMES_850_310 = "850 310 tmp_edi_co_300 tp_code:GET cust_po NA rec_type:LEVEL NA order_line_notes1 order_line_notes2 NA"
    Private Const EDI_COLNAMES_850_320 = "850 320 tmp_edi_co_300 tp_code:GET cust_po NA rec_type:LEVEL NA discount NA"
    Private Const EDI_COLNAMES_850_370 = "850 370 tmp_edi_co_300 tp_code:GET cust_po NA rec_type:LEVEL NA order_line_notes1 order_line_notes2 NA"

    '830
    Private Const EDI_LEVELS_830 = "830 1 2"

    Private Const EDI_DATASIZE_830_100 = "830 1 0 8 2 30 22 6 5 30 1 506 2 153 10 50 212"
    Private Const EDI_DATASIZE_830_200 = "830 2 0 8 2 30 22 6 5 2 8 20 1 79 7 17 8 8 4 22 65 3 19 1 540"

    Private Const EDI_COLNAMES_830_100 = "830 1 tmp_edi_RSEQ_HDR file_ext tp_code item po_key NA dest_code cust_item record_type:LEVEL NA u_m NA co_num AU_ext_payment_ref_num NA"
    Private Const EDI_COLNAMES_830_200 = "830 2 tmp_edi_RSEQ_DTL file_ext tp_code item po_key NA dest_code rel_status1 due_date NA record_type:LEVEL NA qty_ordered NA release_date promised_date NA cust_po NA rec_type_code NA rel_status2 NA"

    '830_HDR
    Private Const EDI_LEVELS_830_HDR = "830_HDR 100"

    Private Const EDI_DATASIZE_830_HDR_100 = "830_HDR 100 0 3 8 2 30 22 6 5 30 1 506 2 153 10 50 212"

    Private Const EDI_COLNAMES_830_HDR_100 = "830_HDR 100 tmp_edi_RSEQ_HDR NA:LEVEL file_ext tp_code item po_key NA dest_code cust_item record_type NA u_m NA co_num AU_ext_payment_ref_num NA"

    '830_DTL
    Private Const EDI_LEVELS_830_DTL = "830_DTL 100"

    Private Const EDI_DATASIZE_830_DTL_100 = "830_DTL 100 0 3 8 2 30 22 6 5 2 8 20 1 79 7 17 8 8 4 22 65 3 19 1 540"

    Private Const EDI_COLNAMES_830_DTL_100 = "830_DTL 100 tmp_edi_RSEQ_DTL NA:LEVEL file_ext tp_code item po_key NA dest_code rel_status1 due_date NA record_type NA qty_ordered NA release_date promised_date NA cust_po NA rec_type_code NA rel_status2 NA"


    'SHIP_HDR
    Private Const EDI_LEVELS_SHIP_HDR = "SHIP_HDR 100"

    Private Const EDI_DATASIZE_SHIP_HDR_100 = "SHIP_HDR 100 0 3 1 8 2 30 60 8 4 223 10 686"

    Private Const EDI_COLNAMES_SHIP_HDR_100 = "SHIP_HDR 100 tmp_edi_ship_hdr NA:LEVEL trx_type company_code tp_desig ship_no NA ship_date ship_time NA co_num NA"

    'SHIP_DTL
    Private Const EDI_LEVELS_SHIP_DTL = "SHIP_DTL 100"

    Private Const EDI_DATASIZE_SHIP_DTL_100 = "SHIP_DTL 100 0 3 1 8 2 30 30 30 7 2 294 10 680"

    Private Const EDI_COLNAMES_SHIP_DTL_100 = "SHIP_DTL 100 tmp_edi_ship_dtl NA:LEVEL trx_type company_code tp_desig ship_no item NA qty_shipped u_m NA co_num NA"


    '810
    Private Const EDI_LEVELS_810 = "810 100 110 200"

    Private Const EDI_DATASIZE_810_100 = "810 100 0 7 3 22 3 7 3 8 10 14 14 14 30 40"
    Private Const EDI_DATASIZE_810_110 = "810 110 0 7 3 22 3 7 3 20 20 20 8 12 12 12 1 25"
    Private Const EDI_DATASIZE_810_200 = "810 200 0 7 3 22 3 7 3 4 4 30 13 3 14 62"

    Private Const EDI_COLNAMES_810_100 = "810 100 tmp_edi_vinv_100 tp_code rec_type:LEVEL vend_inv_num vend_inv_line_nbr site_id NA vend_inv_date po_num misc_chrg sales_tav freight_chrg grn_num NA"
    Private Const EDI_COLNAMES_810_110 = "810 110 tmp_edi_vinv_100 tp_code rec_type:LEVEL vend_inv_num vend_inv_line_nbr site_id NA charfld1 charfld2 charfld3 datefld decifld1 decifld2 decifld3 logifld NA"
    Private Const EDI_COLNAMES_810_200 = "810 200 tmp_edi_vinv_200 tp_code rec_type:LEVEL vend_inv_num vend_inv_line_nbr site_id NA po_line po_release po_item inv_qty u_m unit_cost"

    '855
    Private Const EDI_LEVELS_855 = "855 100 110 120 200 210 300 310"

    Private Const EDI_DATASIZE_855_100 = "855 100 0 7 3 10 4 4 7 5 22 3 4 81"
    Private Const EDI_DATASIZE_855_110 = "855 110 0 7 3 10 4 4 7 5 40 70"
    Private Const EDI_DATASIZE_855_120 = "855 120 0 7 3 10 4 4 7 5 20 20 20 8 12 12 12 1 5"
    Private Const EDI_DATASIZE_855_200 = "855 200 0 7 3 10 4 4 7 5 30 8 3 13 14 30 12"
    Private Const EDI_DATASIZE_855_210 = "855 210 0 7 3 10 4 4 7 5 40 70"
    Private Const EDI_DATASIZE_855_300 = "855 300 0 7 3 10 4 4 7 5 30 8 3 13 14 8 30 4"
    Private Const EDI_DATASIZE_855_310 = "855 310 0 7 3 10 4 4 7 5 40 70"

    Private Const EDI_COLNAMES_855_100 = "855 100 tmp_edi_poack_100 tp_code rec_type:LEVEL po_num pobl_line po_line_rel_num site_id NA vend_order terms_code ship_via_code NA"
    Private Const EDI_COLNAMES_855_110 = "855 110 tmp_edi_poack_100 tp_code rec_type:LEVEL po_num pobl_line po_line_rel_num site_id NA po_text NA"
    Private Const EDI_COLNAMES_855_120 = "855 120 tmp_edi_poack_100 tp_code rec_type:LEVEL po_num pobl_line po_line_rel_num site_id NA charfld1 charfld2 charfld3 datefld decifld1 decifld2 decifld3 logifld NA"
    Private Const EDI_COLNAMES_855_200 = "855 200 tmp_edi_poack_200 tp_code rec_type:LEVEL po_num pobl_line po_line_rel_num site_id NA item revision UM bl_ord_qty item_cost vend_part_num NA"
    Private Const EDI_COLNAMES_855_210 = "855 210 tmp_edi_poack_200 tp_code rec_type:LEVEL po_num pobl_line po_line_rel_num site_id NA po_text NA"
    Private Const EDI_COLNAMES_855_300 = "855 300 tmp_edi_poack_300 tp_code rec_type:LEVEL po_num pobl_line po_line_rel_num site_id NA item revision UM ord_qty item_cost promise_date vend_part_num NA"
    Private Const EDI_COLNAMES_855_310 = "855 310 tmp_edi_poack_300 tp_code rec_type:LEVEL po_num pobl_line po_line_rel_num site_id NA po_text NA"

    '856
    Private Const EDI_LEVELS_856 = "856 100 110 200 210"

    Private Const EDI_DATASIZE_856_100 = "856 100 0 7 3 30 3 7 5 8 6 4 14 3 10 14 56"
    Private Const EDI_DATASIZE_856_110 = "856 110 0 7 3 30 3 7 5 20 20 20 8 12 12 12 1 10"
    Private Const EDI_DATASIZE_856_200 = "856 200 0 7 3 30 3 7 5 4 4 30 13 3 10 30 21"
    Private Const EDI_DATASIZE_856_210 = "856 210 0 7 3 30 3 7 5 1 30 13 71"


    Private Const EDI_COLNAMES_856_100 = "856 100 tmp_edi_vsn_100 tp_code rec_type:LEVEL vend_ship_num ship_seq_nbr site_id NA ship_date ship_time ship_via tot_weight qty_packages po_num freight_chrg NA"
    Private Const EDI_COLNAMES_856_110 = "856 110 tmp_edi_vsn_100 tp_code rec_type:LEVEL vend_ship_num ship_seq_nbr site_id NA charfld1 charfld2 charfld3 datefld decifld1 decifld2 decifld3 logifld NA"
    Private Const EDI_COLNAMES_856_200 = "856 200 tmp_edi_vsn_200 tp_code rec_type:LEVEL vend_ship_num ship_seq_nbr site_id NA po_line po_release po_item qty_ship u_m po_num container NA"
    Private Const EDI_COLNAMES_856_210 = "856 210 tmp_edi_vsn_200 tp_code rec_type:LEVEL vend_ship_num ship_seq_nbr site_id NA ref_type ref_num ref_qty NA"

    Dim lineGroup As Integer
    Dim Seq100 As Integer
    Dim Seq300 As Integer

    Private ediLevels As Collection
    Private dataSizes As Collection
    Private columnNames As Collection

    Public Sub New()

        ediLevels = New Collection
        dataSizes = New Collection
        columnNames = New Collection

        ' initialize each collection
        ' start with EDI level definitions
        '850
        ediLevels.Add(EDI_LEVELS_850)
        '810
        ediLevels.Add(EDI_LEVELS_810)
        '855
        ediLevels.Add(EDI_LEVELS_855)
        '856
        ediLevels.Add(EDI_LEVELS_856)
        '830
        ediLevels.Add(EDI_LEVELS_830)
        ediLevels.Add(EDI_LEVELS_830_HDR)
        ediLevels.Add(EDI_LEVELS_830_DTL)

        'SHIP
        ediLevels.Add(EDI_LEVELS_SHIP_HDR)
        ediLevels.Add(EDI_LEVELS_SHIP_DTL)

        ' then initialize each size in a data file
        '850
        dataSizes.Add(EDI_DATASIZE_850_100)
        dataSizes.Add(EDI_DATASIZE_850_110)
        dataSizes.Add(EDI_DATASIZE_850_115)
        dataSizes.Add(EDI_DATASIZE_850_120)
        dataSizes.Add(EDI_DATASIZE_850_140)
        dataSizes.Add(EDI_DATASIZE_850_145)
        dataSizes.Add(EDI_DATASIZE_850_150)
        dataSizes.Add(EDI_DATASIZE_850_170)
        dataSizes.Add(EDI_DATASIZE_850_300)
        dataSizes.Add(EDI_DATASIZE_850_305)
        dataSizes.Add(EDI_DATASIZE_850_310)
        dataSizes.Add(EDI_DATASIZE_850_320)
        dataSizes.Add(EDI_DATASIZE_850_370)
        '810
        dataSizes.Add(EDI_DATASIZE_810_100)
        dataSizes.Add(EDI_DATASIZE_810_110)
        dataSizes.Add(EDI_DATASIZE_810_200)
        '855
        dataSizes.Add(EDI_DATASIZE_855_100)
        dataSizes.Add(EDI_DATASIZE_855_110)
        dataSizes.Add(EDI_DATASIZE_855_120)
        dataSizes.Add(EDI_DATASIZE_855_200)
        dataSizes.Add(EDI_DATASIZE_855_210)
        dataSizes.Add(EDI_DATASIZE_855_300)
        dataSizes.Add(EDI_DATASIZE_855_310)
        '856
        dataSizes.Add(EDI_DATASIZE_856_100)
        dataSizes.Add(EDI_DATASIZE_856_110)
        dataSizes.Add(EDI_DATASIZE_856_200)
        dataSizes.Add(EDI_DATASIZE_856_210)
        '830
        dataSizes.Add(EDI_DATASIZE_830_100)
        dataSizes.Add(EDI_DATASIZE_830_200)
        dataSizes.Add(EDI_DATASIZE_830_HDR_100)
        dataSizes.Add(EDI_DATASIZE_830_DTL_100)
        'SHIP
        dataSizes.Add(EDI_DATASIZE_SHIP_HDR_100)
        dataSizes.Add(EDI_DATASIZE_SHIP_DTL_100)


        ' define mapping column names
        '850
        columnNames.Add(EDI_COLNAMES_850_100)
        columnNames.Add(EDI_COLNAMES_850_110)
        columnNames.Add(EDI_COLNAMES_850_115)
        columnNames.Add(EDI_COLNAMES_850_120)
        columnNames.Add(EDI_COLNAMES_850_140)
        columnNames.Add(EDI_COLNAMES_850_145)
        columnNames.Add(EDI_COLNAMES_850_150)
        columnNames.Add(EDI_COLNAMES_850_170)
        columnNames.Add(EDI_COLNAMES_850_300)
        columnNames.Add(EDI_COLNAMES_850_305)
        columnNames.Add(EDI_COLNAMES_850_310)
        columnNames.Add(EDI_COLNAMES_850_320)
        columnNames.Add(EDI_COLNAMES_850_370)
        '810
        columnNames.Add(EDI_COLNAMES_810_100)
        columnNames.Add(EDI_COLNAMES_810_110)
        columnNames.Add(EDI_COLNAMES_810_200)
        '855
        columnNames.Add(EDI_COLNAMES_855_100)
        columnNames.Add(EDI_COLNAMES_855_110)
        columnNames.Add(EDI_COLNAMES_855_120)
        columnNames.Add(EDI_COLNAMES_855_200)
        columnNames.Add(EDI_COLNAMES_855_210)
        columnNames.Add(EDI_COLNAMES_855_300)
        columnNames.Add(EDI_COLNAMES_855_310)
        '856
        columnNames.Add(EDI_COLNAMES_856_100)
        columnNames.Add(EDI_COLNAMES_856_110)
        columnNames.Add(EDI_COLNAMES_856_200)
        columnNames.Add(EDI_COLNAMES_856_210)
        '830
        columnNames.Add(EDI_COLNAMES_830_100)
        columnNames.Add(EDI_COLNAMES_830_200)
        columnNames.Add(EDI_COLNAMES_830_HDR_100)
        columnNames.Add(EDI_COLNAMES_830_DTL_100)
        'SHIP
        columnNames.Add(EDI_COLNAMES_SHIP_HDR_100)
        columnNames.Add(EDI_COLNAMES_SHIP_DTL_100)


    End Sub

    Private Sub Dispose()
        ediLevels = Nothing
        dataSizes = Nothing
        columnNames = Nothing
    End Sub

    Public Function GetInsertStatements(ByVal FileType As String, ByVal processId As String, ByVal ediLines As Collection) As Collection
        Dim ediLevel As SLCmdLineParser
        Dim chunkData As Collection
        Dim savedValues As Collection
        Dim i As Long

        ' get the EDI levels for a give file type
        ediLevel = GetEDILevel(FileType)
        If ediLevel Is Nothing Then
            GoTo ExitFunction
        End If

        ' split data file into collection of collection of lines based on the
        ' first level in the file

        chunkData = SplitFileIntoChunks(ediLevel, ediLines)

        Dim InsertStatements = New Collection

        For i = 1 To chunkData.Count
            savedValues = New Collection()
            ProcessLevels(FileType, processId, chunkData(i), InsertStatements, savedValues, i)
            savedValues = Nothing
        Next i
        Return InsertStatements

ExitFunction:
        chunkData = Nothing
        savedValues = Nothing

        Return New Collection()
    End Function

    Public Sub ProcessLevels(ByVal FileType As String, ByVal processId As String, _
    ByVal ediLines As Collection, ByVal statements As Collection, ByVal savedValues As Collection, _
    ByVal iImportSequence As Long)

        Dim dataSizes As SLCmdLineParser
        Dim dataDefs As SLCmdLineParser
        Dim insert As String
        Dim values As String
        Dim columnName As String
        Dim data As String
        Dim levelType As String = Nothing
        Dim ValueCustTpCode As String

        insert = ""
        ValueCustTpCode = ""

        Dim i As Long
        Dim j As Long
        Dim k As Long
        Dim pos As Integer
        Dim startPos As Integer
		Dim seq As Integer = 0
		' Process the incoming flat file in the same record order as in the flat
		' file itself.
		For k = 1 To ediLines.Count
            If FileType = "850" Then
                levelType = GetData(ediLines(k), 40, 3)
            ElseIf FileType = "830" Then
                levelType = GetData(ediLines(k), 104, 1)
            ElseIf FileType = "830_HDR" Then
                levelType = "100"
            ElseIf FileType = "830_DTL" Then
                levelType = "100"
            ElseIf FileType = "SHIP_HDR" Then
                levelType = "100"
            ElseIf FileType = "SHIP_DTL" Then
                levelType = "100"
            ElseIf FileType = "810" Then
                levelType = GetData(ediLines(k), 8, 3)
            ElseIf FileType = "855" Then
                levelType = GetData(ediLines(k), 8, 3)
            ElseIf FileType = "856" Then
                levelType = GetData(ediLines(k), 8, 3)
            End If

            ' get the EDI data sizes for a given file type, and level number
            dataSizes = GetEDIDataSize(FileType, levelType)
            If dataSizes Is Nothing Then
                GoTo ExitFunction
            End If

            ' get the EDI data definitions for a given file type, and level number
            dataDefs = GetEDIDataDefinitions(FileType, levelType)
            If dataDefs Is Nothing Then
                GoTo ExitFunction
            End If

            For i = 4 To dataDefs.Commands.Count
                columnName = dataDefs.Commands(i)
                If columnName <> "NA" Then
                    pos = InStr(columnName, ":")
                    If pos = 0 Then
                        insert = insert & "," & columnName
                    ElseIf Left(columnName, pos - 1) <> "NA" Then
                        insert = insert & "," & Left(columnName, pos - 1)
                    End If
                End If
            Next i

            If FileType = "850" Then
                If levelType = "100" Then
                    insert = "INSERT INTO " & dataDefs.Commands(3) & "(ProcessId, rec_type_100_sequence" & insert & ") values ("
                ElseIf levelType > "100" And levelType < "300" Then
                    insert = "INSERT INTO " & dataDefs.Commands(3) & "(ProcessId, rec_type_100_sequence, cust_tp_code" & insert & ") values ("
                ElseIf levelType = "300" Then
                    insert = "INSERT INTO " & dataDefs.Commands(3) & "(ProcessId, rec_type_300_group_sequence, rec_type_300_group" & insert & ") values ("
                Else
                    insert = "INSERT INTO " & dataDefs.Commands(3) & "(ProcessId, rec_type_300_group_sequence, rec_type_300_group, cust_tp_code" & insert & ") values ("
                End If
            ElseIf (FileType = "830" Or FileType = "855") Then
                insert = "INSERT INTO " & dataDefs.Commands(3) & "(ProcessId" & insert & ", import_sequence) values ("
            Else
                insert = "INSERT INTO " & dataDefs.Commands(3) & "(ProcessId" & insert & ") values ("
            End If

			If FileType = "856" Then
				If levelType = "200" Then
					seq = seq + 1
				End If
			End If

			startPos = 1
            values = ""

            For j = 4 To dataDefs.Commands.Count
                columnName = dataDefs.Commands(j)
                If columnName <> "NA" Then
                    pos = InStr(columnName, ":")
					If pos = 0 Then
						If FileType = "856" Then
							'If file type is 856 use ship_seq_nbr field in order to match serial numbers to correct GRN line
							If (columnName = "ship_seq_nbr") Then
								values = values & "," & seq
							Else
								values = values & "," & GetStringData(ediLines(k), startPos, CInt(dataSizes.Commands(j)))
							End If
						Else
							values = values & "," & GetStringData(ediLines(k), startPos, CInt(dataSizes.Commands(j)))
						End If
					ElseIf Right(columnName, Len(columnName) - pos) = "LEVEL" Then
						If GetData(ediLines(k), startPos, CInt(dataSizes.Commands(j))) <> levelType Then
							values = ""
							Exit For
						End If
						If Left(columnName, pos - 1) <> "NA" Then
							values = values & "," & GetStringData(ediLines(k), startPos, CInt(dataSizes.Commands(j)))
						End If
					ElseIf Mid(columnName, pos + 1, 4) = "SAVE" Then
						data = GetStringData(ediLines(k), startPos, CInt(dataSizes.Commands(j)))
						values = values & "," & data
						On Error Resume Next
						savedValues.Add(data, Left(columnName, pos - 1))
						Err.Clear()
						On Error GoTo 0
					ElseIf Mid(columnName, pos + 1, 3) = "GET" Then
						values = values & "," & savedValues(Left(columnName, pos - 1))
                    End If
                End If

                startPos = startPos + CInt(dataSizes.Commands(j))
            Next j

            If values <> "" Then
                If FileType = "850" Then
                    If levelType = "100" Then
                        lineGroup = 0
                        Seq100 = 1
                    End If

                    If levelType > "100" And levelType < "300" Then
                        Seq100 = Seq100 + 1
                        ValueCustTpCode = savedValues("cust_tp_code")
                    End If

                    If levelType = "300" Then
                        lineGroup = lineGroup + 1
                        Seq300 = 1
                    End If

                    If levelType > "300" Then
                        Seq300 = Seq300 + 1
                        ValueCustTpCode = savedValues("cust_tp_code")
                    End If

                    If levelType = "100" Then
                        values = processId & "," & Seq100 & values & ")"
                    ElseIf levelType > "100" And levelType < "300" Then
                        values = processId & "," & Seq100 & "," & ValueCustTpCode & values & ")"
                    ElseIf levelType = "300" Then
                        values = processId & "," & Seq300 & "," & lineGroup & values & ")"
                    Else
                        values = processId & "," & Seq300 & "," & lineGroup & "," & ValueCustTpCode & values & ")"
                    End If
                ElseIf (FileType = "830" Or FileType = "855") Then
                    values = processId & values & ", " + CStr(iImportSequence) & ")"
                Else
                    values = processId & values & ")"
                End If

                statements.Add(insert & values)
                values = ""
                insert = ""
            End If
ExitFunction:
        Next k

        dataDefs = Nothing
        dataSizes = Nothing
    End Sub

    Private Function SplitFileIntoChunks(ByVal ediLevel As SLCmdLineParser, ByVal ediLines As Collection) As Collection
        Dim dataSizes As SLCmdLineParser
        Dim dataDefs As SLCmdLineParser
        Dim columnName As String
        Dim startPos As Integer
        Dim dataLen As Integer
        Dim pos As Integer
        Dim i As Long
        Dim index As Long
        SplitFileIntoChunks = New Collection
        ' get the EDI data sizes for a given file type, and level number
        ' (first level in a file)
        dataSizes = GetEDIDataSize(ediLevel.Commands(1), ediLevel.Commands(2))
        If dataSizes Is Nothing Then
            GoTo ExitFunction
        End If

        ' get the EDI data definitions for a given file type, and level number
        ' (first level in a file)
        dataDefs = GetEDIDataDefinitions(ediLevel.Commands(1), ediLevel.Commands(2))
        If dataDefs Is Nothing Then
            GoTo ExitFunction
        End If

        startPos = 1

        ' advance to the column containing level number
        For i = 4 To dataDefs.Commands.Count
            columnName = dataDefs.Commands(i)
            If columnName <> "NA" Then
                pos = InStr(columnName, ":")
                If Right(columnName, Len(columnName) - pos) = "LEVEL" Then
                    dataLen = CInt(dataSizes.Commands(i))
                    Exit For
                End If
            End If

            startPos = startPos + CInt(dataSizes.Commands(i))
        Next i

        SplitFileIntoChunks = New Collection
        index = 0

        ' loop through all of the lines and create chunks
        For i = 1 To ediLines.Count
            If ediLines(i) <> "" Then
                If GetData(ediLines(i), startPos, dataLen) = ediLevel.Commands(2) Then
                    SplitFileIntoChunks.Add(New Collection)
                    index = index + 1
                End If

                SplitFileIntoChunks.Item(index).Add(ediLines(i))
            End If
        Next i

ExitFunction:
        dataSizes = Nothing
        dataDefs = Nothing
    End Function

    Private Function GetEDILevel(ByVal FileType As String) As SLCmdLineParser
        Dim i As Long
        For i = 1 To ediLevels.Count
            GetEDILevel = New SLCmdLineParser
            GetEDILevel.ParseCommandLine(ediLevels.Item(i))

            If FileType = GetEDILevel.Commands(1) Then
                Exit Function
            End If

            GetEDILevel = Nothing
        Next i
        GetEDILevel = Nothing
    End Function

    Private Function GetEDIDataSize(ByVal FileType As String, ByVal levelType As String) As SLCmdLineParser
        Dim i As Integer

        For i = 1 To dataSizes.Count
            GetEDIDataSize = New SLCmdLineParser
            GetEDIDataSize.ParseCommandLine(dataSizes.Item(i))

            If FileType = GetEDIDataSize.Commands(1) _
              And levelType = GetEDIDataSize.Commands(2) Then
                Exit Function
            End If

            GetEDIDataSize = Nothing
        Next i
        GetEDIDataSize = Nothing
    End Function

    Private Function GetEDIDataDefinitions(ByVal FileType As String, ByVal levelType As String) As SLCmdLineParser
        Dim i As Integer

        For i = 1 To columnNames.Count
            GetEDIDataDefinitions = New SLCmdLineParser
            GetEDIDataDefinitions.ParseCommandLine(columnNames.Item(i))

            If FileType = GetEDIDataDefinitions.Commands(1) _
              And levelType = GetEDIDataDefinitions.Commands(2) Then
                Exit Function
            End If

            GetEDIDataDefinitions = Nothing
        Next i
        GetEDIDataDefinitions = Nothing
    End Function

    Private Function GetData(ByVal line As String, ByVal startPos As Integer, ByVal length As Integer) As String
        Dim iLen As Integer
        iLen = length

        If Len(line) < startPos + iLen Then
            iLen = Len(line) - startPos + 1
        End If

        'GetData = RTrim(LTrim(Mid(line, startPos, length)))
        If iLen > 0 Then
            GetData = Mid(line, startPos, iLen)
        Else
            GetData = Space(length)
        End If
    End Function

    Private Function GetStringData(ByVal line As String, ByVal startPos As Integer, ByVal length As Integer) As String
        ' need to check for ' in a string and replace it with ''
        GetStringData = "'" & Replace(GetData(line, startPos, length), "'", "''") & "'"
    End Function
End Class

