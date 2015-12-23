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
	/// Class handler for Weak assembly request
	/// </summary>
	public class WeakAssemblyRequestHandler
	{
		/// ------------------------------------------------------
		/// <summary>
		/// This function creates object of WeakAssemblyTransHandler class
		/// and passes to WeakAssemblyTransHandler class
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns></returns>
		/// --------------------------------------------------------
		public string SubmitRequestToHandler(Hashtable RequestData)
		{
			
			string Response;
			
			WeakAssemblyTransHandler WeakAssemblyHdlr = new WeakAssemblyTransHandler();
			Response = WeakAssemblyHdlr.SubmitTransaction(RequestData);
			
			return Response;
		}
	}
}


