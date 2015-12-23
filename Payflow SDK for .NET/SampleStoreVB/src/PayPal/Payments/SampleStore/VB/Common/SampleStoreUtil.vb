Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Runtime.Serialization
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Common.Utility
Imports System.IO.MemoryStream
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Logging

#Region "Copyright"

'Unpublished Proprietary Program Material
'This material is proprietary to PayPal, Inc. and is not to be reproduced, 
'used or disclosed except in accordance with a written license agreement 
'with PayPal, Inc.. 
'(C) Copyright 2005  PayPal, Inc.   All Rights Reserved.
'PayPal, Inc. believes that this material furnished herewith is accurate 
'and reliable.  However, no responsibility, financial or otherwise, can be 
' accepted for any consequences arising out of the use of this material. 

'The copyright notice above does not evidence any actual or intended 
'publication of such source code. 

#End Region

Namespace PayPal.Payments.SampleStore.VB.Common
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' This class consists of utility functions that will be used by the SampleStore 
    ''' Application
    ''' </summary>
    ''' -----------------------------------------------------------------------------

    Public Class SampleStoreUtil


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets value in dropdown box
        ''' </summary>
        ''' <param name="DropDown"></param>
        ''' <param name="ValueToSet"></param>
        ''' -----------------------------------------------------------------------------
        Public Sub SetValueInDropDown(ByVal DropDown As System.Web.UI.WebControls.DropDownList, ByVal ValueToSet As String)
            If ValueToSet = "" Then
                DropDown.SelectedIndex = 0
                Exit Sub
            End If
            Dim Counter As Integer = 0
            For Counter = 0 To DropDown.Items.Count - 1
                If DropDown.Items(Counter).Text = ValueToSet Then
                    DropDown.SelectedIndex = Counter
                    Exit For
                End If
            Next
            If DropDown.Items(Counter).Text <> ValueToSet Then
                'LogMessage("Unable to set value in the drop down")
            End If
        End Sub


        'Public Function WriteRequestToFile(ByVal RequestData As Hashtable, ByVal FileName As String) As Boolean

        '    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Common.WriteRequestToFile(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG)

        '    Dim EncryptStatus As Boolean
        '    Dim DataToEncrypt As String

        '    'Convert the data in the hash table to string
        '    DataToEncrypt = ConvertHashTblDataToString(RequestData)
        '    'Encrypt the string
        '    EncryptStatus = EncryptDecrypt.EncryptData(DataToEncrypt, FileName)

        '    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Common.WriteRequestToFile(HashTable) : Exiting", PayflowConstants.SEVERITY_DEBUG)
        '    'Log the encryption status
        '    Return EncryptStatus
        'End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function puts the name value pairs data in the HttpRequest
        ''' as Key and Value pair in the hash table and returns the same.
        ''' </summary>
        ''' <param name="HttpRequest"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Function GetHashTableWithRequest(ByVal HttpRequest As HttpRequest) As Hashtable

            Dim NVColl As New System.Collections.Specialized.NameValueCollection
            Dim KeysColl As System.Collections.Specialized.NameObjectCollectionBase.KeysCollection
            Dim RequestData As New Hashtable
            Dim Index As Integer
            Dim Name As String
            Dim Value As String

            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Common.GetHashTableWithRequest(HttpRequest) : Entered", PayflowConstants.SEVERITY_DEBUG)

            'Get only the form data from the httprequest in name value pair collection
            NVColl = HttpRequest.Form
            'Get the object of the key collection in the name value pair collection
            KeysColl = NVColl.Keys()
            'Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Common.GetHashTableWithRequest(HttpRequest) : Following input values entered", PayflowConstants.SEVERITY_INFO)
            'Iterate through the keys in the name value pair collection and 
            'adds the same as key and value in the hashtable
            For Index = 0 To KeysColl.Count() - 1
                Name = KeysColl.Item(Index)
                Value = NVColl.Get(Index)
                RequestData.Add(Name, Value)

                'If Not (Object.Equals(Value, Nothing) Or Object.Equals(Value, EMPTY_STRING)) Then
                'Logger.Instance.Log("Input Param : " + Name + " , Input Value : " + Value, PayflowConstants.SEVERITY_INFO)
                'End If

            Next
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Common.GetHashTableWithRequest(HttpRequest) : Exiting", PayflowConstants.SEVERITY_DEBUG)
            Return RequestData

        End Function
       
        'Public Function ConvertHashTblDataToString(ByVal RequestData As Hashtable) As String

        '    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Common.ConvertHashTblDataToString(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG)

        '    Dim StringBuilder As New StringBuilder
        '    Dim KeysColl As System.Collections.ICollection
        '    Dim KeysEnum As System.Collections.IEnumerator

        '    KeysColl = RequestData.Keys()
        '    KeysEnum = KeysColl.GetEnumerator()

        '    While KeysEnum.MoveNext
        '        StringBuilder.Append(KeysEnum.Current().ToString)
        '        StringBuilder.Append("=")
        '        StringBuilder.Append(RequestData.Item(KeysEnum.Current().ToString))
        '        StringBuilder.Append(NV_DELIMITER)
        '    End While

        '    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Common.ConvertHashTblDataToString(HashTable) : The data in HashTable returned as String - " + StringBuilder.ToString, PayflowConstants.SEVERITY_DEBUG)
        '    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Common.ConvertHashTblDataToString(HashTable) : Exiting", PayflowConstants.SEVERITY_DEBUG)

        '    Return StringBuilder.ToString
        'End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function parses the input name vale delimited string and puts the name
        ''' and value pair from the string into a hashtable as key and value
        ''' </summary>
        ''' <param name="RequestStr"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[db2admin]	3/16/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConvertStringToHashTbl(ByVal RequestStr As String, ByVal OuterDelimiter As String) As Hashtable

            Dim RequestData As New Hashtable
            Dim InnerDelimiter As String = "="
            Dim OuterSplit As String() = Nothing
            Dim InnerSplit As String() = Nothing
            Dim Entry As String

            'Split the string with reference to the NV_DELIMITER
            OuterSplit = RequestStr.Split(OuterDelimiter.ToCharArray)

            For Each Entry In OuterSplit
                'Split each entry in the outer split with reference to the inner delimiter
                InnerSplit = Entry.Split(InnerDelimiter.ToCharArray)
                If (InnerSplit.Length = 2) Then
                    RequestData.Add(InnerSplit(0), InnerSplit(1))
                End If
            Next Entry
            Return RequestData
        End Function
       
        'Public Function ReadRequestFromFile(ByVal FileName As String) As Hashtable
        '    Try
        '        'Dim FileName As String = "C:/EncryptedData.txt"
        '        Dim RequestData As Hashtable
        '        Dim DecryptedData As String

        '        DecryptedData = EncryptDecrypt.DecryptData(FileName)
        '        RequestData = ConvertStringToHashTbl(DecryptedData, NV_DELIMITER)
        '        'If File.Exists("C:/EncryptedData.txt") Then
        '        'File.Delete("C:/EncryptedData.txt")
        '        'End If
        '        Return RequestData
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message, ex)
        '    End Try
        'End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function accepts a value as string and converts it into a currency value
        ''' and returns the same
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Function GetCurrencyFromString(ByVal Value As String) As Currency
            Dim DecimalVal As New Decimal
            Dim CurrencyVal As Currency
            DecimalVal = Decimal.Parse(Value)
            CurrencyVal = New Currency(DecimalVal)
            Return CurrencyVal
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  This function accepts a value as string and coverts it to Date value 
        '''  and returns the same
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        ''' -----------------------------------------------------------------------------
        Public Function GetDateFromString(ByVal Value As String) As Date

            Dim DateVal As Date
            Dim Month, Year, Day, HH, MM, SS As Integer

            Year = Integer.Parse(Value.Substring(0, 4))
            Month = Integer.Parse(Value.Substring(4, 2))
            Day = Integer.Parse(Value.Substring(6, 2))

            If (Value.Length = 8) Then
                DateVal = New Date(Year, Month, Day)
            ElseIf (Value.Length > 8) Then
                HH = Integer.Parse(Value.Substring(8, 2))
                MM = Integer.Parse(Value.Substring(10, 2))
                SS = Integer.Parse(Value.Substring(12, 2))
                DateVal = New Date(Year, Month, Day, HH, MM, SS)
            End If

            Return DateVal

        End Function

    End Class
End Namespace
