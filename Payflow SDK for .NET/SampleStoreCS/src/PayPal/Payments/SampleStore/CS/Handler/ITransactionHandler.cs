using System.Collections;

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

namespace PayPal.Payments.SampleStore.CS.Handler
{
	/// <summary>
	/// This is an Interface with two functions SetDataObjects and SubmitTransaction.
	/// This is implemented by the transaction handlers for setting the data objects
	/// and submitting the transaction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	public interface ITransactionHandler
	{
		/// <summary>
		/// Submits Transaction
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns></returns>
		Hashtable SubmitTransaction(Hashtable RequestData);
		/// <summary>
		/// Sets data objects
		/// </summary>
		/// <param name="RequestData"></param>
		void SetDataObjects (Hashtable RequestData);
		
	}
	
}


