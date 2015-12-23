using Microsoft.VisualBasic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;
//using System.IO.MemoryStream;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Logging;


#region "Copyright"

//Unpublished Proprietary Program Material
//This material is proprietary to PayPal, Inc. and is not to be reproduced,
//used or disclosed except in accordance with a written license agreement
//with PayPal, Inc..
//(C) Copyright 2005  PayPal, Inc.   All Rights Reserved.
//PayPal, Inc. believes that this material furnished herewith is accurate
//and reliable.  However, no responsibility, financial or otherwise, can be
// accepted for any consequences arising out of the use of this material.

//The copyright notice above does not evidence any actual or intended
//publication of such source code.

#endregion

namespace PayPal.Payments.SampleStore.CS.Common
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This class consists of utility functions that will be used by the SampleStore
	/// Application
	/// </summary>
	/// -----------------------------------------------------------------------------
	
	public sealed class SampleStoreUtil
	{
		/// <summary>
		/// This function is used to set value in drop downs
		/// </summary>
		/// <param name="DropDown"></param>
		/// <param name="ValueToSet"></param>
		public static void SetValueInDropDown (System.Web.UI.WebControls.DropDownList DropDown, string ValueToSet)
		{
			if (ValueToSet.Length == 0)
			{
				DropDown.SelectedIndex = 0;
				return;
			}
			int mCounter = 0;
			for (mCounter = 0; mCounter <= DropDown.Items.Count - 1; mCounter++)
			{
				if (DropDown.Items[mCounter].Text == ValueToSet)
				{
					DropDown.SelectedIndex = mCounter;
					break;
				}
			}
			if (DropDown.Items[mCounter].Text != ValueToSet)
			{
				//LogMessage("Unable to set value in the drop down")
			}
		}
		
		
		//Public Function WriteRequestToFile(ByVal RequestData As Hashtable, ByVal FileName As String) As Boolean
		
		//    Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Common.WriteRequestToFile(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG)
		
		//    Dim mEncryptStatus As Boolean
		//    Dim mDataToEncrypt As String
		
		//    'Convert the data in the hash table to string
		//    mDataToEncrypt = ConvertHashTblDataToString(RequestData)
		//    'Encrypt the string
		//    mEncryptStatus = EncryptDecrypt.EncryptData(mDataToEncrypt, FileName)
		
		//    Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Common.WriteRequestToFile(HashTable) : Exiting", PayflowConstants.SEVERITY_DEBUG)
		//    'Log the encryption status
		//    Return mEncryptStatus
		//End Function
		
		
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function puts the name value pairs data in the HttpRequest
		/// as Key and Value pair in the hash table and returns the same.
		/// </summary>
		/// <param name="HttpRequest"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public static Hashtable GetHashTableWithRequest(HttpRequest HttpRequest)
		{
			
			System.Collections.Specialized.NameValueCollection mNVColl = new System.Collections.Specialized.NameValueCollection();
			System.Collections.Specialized.NameObjectCollectionBase.KeysCollection mKeysObj;
			Hashtable mRequestData = new Hashtable();
			int mIndex;
			string mName;
			string mValue;
			
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Common.GetHashTableWithRequest(HttpRequest) : Entered", PayflowConstants.SEVERITY_DEBUG);
			
			//Get only the form data from the httprequest in name value pair collection
			mNVColl = HttpRequest.Form;
			//Get the object of the key collection in the name value pair collection
			mKeysObj = mNVColl.Keys;
			//Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Common.GetHashTableWithRequest(HttpRequest) : Following input values entered", PayflowConstants.SEVERITY_INFO)
			//Iterate through the keys in the name value pair collection and
			//adds the same as key and value in the hashtable
			for (mIndex = 0; mIndex <= mKeysObj.Count - 1; mIndex++)
			{
				mName = mKeysObj[mIndex];
				mValue = mNVColl.Get(mIndex);
				mRequestData.Add(mName, mValue);
				
				//If Not (Object.Equals(mValue, Nothing) Or Object.Equals(mValue, EMPTY_STRING)) Then
				//Logger.Instance.Log("Input Param : " + mName + " , Input Value : " + mValue, PayflowConstants.SEVERITY_INFO)
				//End If
				
			}
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Common.GetHashTableWithRequest(HttpRequest) : Exiting", PayflowConstants.SEVERITY_DEBUG);
			return mRequestData;
			
		}
		
		//Public Function ConvertHashTblDataToString(ByVal RequestData As Hashtable) As String
		
		//    Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Common.ConvertHashTblDataToString(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG)
		
		//    Dim mStringBuilder As New StringBuilder
		//    Dim mKeysColl As System.Collections.ICollection
		//    Dim mKeysEnum As System.Collections.IEnumerator
		
		//    mKeysColl = RequestData.Keys()
		//    mKeysEnum = mKeysColl.GetEnumerator()
		
		//    While mKeysEnum.MoveNext
		//        mStringBuilder.Append(mKeysEnum.Current().ToString)
		//        mStringBuilder.Append("=")
		//        mStringBuilder.Append(RequestData.Item(mKeysEnum.Current().ToString))
		//        mStringBuilder.Append(NV_DELIMITER)
		//    End While
		
		//    Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Common.ConvertHashTblDataToString(HashTable) : The data in HashTable returned as String - " + mStringBuilder.ToString, PayflowConstants.SEVERITY_DEBUG)
		//    Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Common.ConvertHashTblDataToString(HashTable) : Exiting", PayflowConstants.SEVERITY_DEBUG)
		
		//    Return mStringBuilder.ToString
		//End Function

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function parses the input name vale delimited string and puts the name
		/// and value pair from the string into a hashtable as key and value
		/// </summary>
		/// <param name="RequestStr"></param>
		/// <param name="OuterDelimiter"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[db2admin]	3/16/2005	Created
		/// </history>
		/// -----------------------------------------------------------------------------
		public static Hashtable ConvertStringToHashTbl(string RequestStr, string OuterDelimiter)
		{
			
			Hashtable mRequestData = new Hashtable();
			string InnerDelimiter = "=";
			string[] OuterSplit = null;
			string[] InnerSplit = null;
			string Entry;
			
			//Split the string with reference to the NV_DELIMITER
			OuterSplit = RequestStr.Split(OuterDelimiter.ToCharArray());
			
			foreach (string tempLoopVar_Entry in OuterSplit)
			{
				Entry = tempLoopVar_Entry;
				//Split each entry in the outer split with reference to the inner delimiter
				InnerSplit = Entry.Split(InnerDelimiter.ToCharArray());
				if (InnerSplit.Length == 2)
				{
					mRequestData.Add(InnerSplit[0], InnerSplit[1]);
				}
			}
			return mRequestData;
		}
		
		//Public Function ReadRequestFromFile(ByVal FileName As String) As Hashtable
		//    Try
		//        'Dim mFileName As String = "C:/EncryptedData.txt"
		//        Dim mRequestData As Hashtable
		//        Dim mDecryptedData As String
		
		//        mDecryptedData = EncryptDecrypt.DecryptData(FileName)
		//        mRequestData = ConvertStringToHashTbl(mDecryptedData, NV_DELIMITER)
		//        'If File.Exists("C:/EncryptedData.txt") Then
		//        'File.Delete("C:/EncryptedData.txt")
		//        'End If
		//        Return mRequestData
		//    Catch ex As Exception
		//        Throw New Exception(ex.Message, ex)
		//    End Try
		//End Function

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function accepts a value as string and converts it into a currency value
		/// and returns the same
		/// </summary>
		/// <param name="Value"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public static Currency GetCurrencyFromString(string Value)
		{
			decimal mDecimal = new decimal();
			Currency mCurrency;
			mDecimal = decimal.Parse(Value);
			mCurrency = new Currency(mDecimal);
			return mCurrency;
		}
		/// <summary>
		/// Converts String to Date format
		/// </summary>
		/// <param name="Value"></param>
		/// <returns></returns>
		public static DateTime GetDateFromString(string Value)
		{
			
			DateTime mDate = Convert.ToDateTime(null);
			int mMonth;
			int mYear;
			int mDay;
			int mHH;
			int mMM;
			int mSS;
			
			mYear = int.Parse(Value.Substring(0, 4));
			mMonth = int.Parse(Value.Substring(4, 2));
			mDay = int.Parse(Value.Substring(6, 2));
			
			if (Value.Length == 8)
			{
				mDate = new DateTime(mYear, mMonth, mDay);
			}
			else if (Value.Length > 8)
			{
				mHH = int.Parse(Value.Substring(8, 2));
				mMM = int.Parse(Value.Substring(10, 2));
				mSS = int.Parse(Value.Substring(12, 2));
				mDate = new DateTime(mYear, mMonth, mDay, mHH, mMM, mSS);
			}
			
			return mDate;
			
		}
		
	}
}

