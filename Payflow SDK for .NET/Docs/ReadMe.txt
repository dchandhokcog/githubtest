Copyright (c) 2007 PayPal Inc. All Rights Reserved
--------------------------------------------------

How to use with Visual Studio 2005 and .NET Framework 2.0
---------------------------------------------------------
This package is designed to work with Visual Studio 2003 and .NET Framework 1.1.
The enclosed samples use the 1.1 version of the payflow_dotNET.dll by default. To 
use with Visual Studio 2005 and .NET Framework 2.0 replace the payflow_dotNET.dll 
within the projects bin directory with the payflow_dotNET_2.0.dll (renamed to 
payflow_dotNET.dll) from the root directory of the SDK.

Remember: Rename the file from payflow_dotNET_2.0.dll to payflow_dotNET.dll replacing
the original v1.1 one.

Also, you will need to recompile the eStoreFront or SampleStore examples if you
change the DLL from 1.1 to 2.0.

For x64 Systems:
The payflow_dotNET_2.0.dll is the only DLL that is compiled for x64 systems.

To enable logging in the .NET SDK
---------------------------------
1. Open App.config for console samples (SamplesCS and SamplesVB) and Web.config for web samples (SampleStoreCS and SampleStoreVB).

2. To switch on logging change the LOG_LEVEL key from "OFF" to any of the following:
		a. DEBUG
		b. INFO
		c. WARN
		d. ERROR
		e. FATAL
		
3. To set your log file name and location you modify LOG_FILE key in config file. 
	
	e.g.
	<add key="LOG_FILE" value="Logs\PayflowSDK.LOG"/>
	For SamplesCS this will create log file PayflowSDK.LOG in SamplesCS\bin\Debug\logs folder.

4. To set your log file size you need to modify LOGFILE_SIZE key in config file. 

	e.g.
	<add key="LOGFILE_SIZE" value="10230000" /> 
	This will create log file of size 10000KB.


5. Save and close the file.


6. When running a transaction, depending on the configuration settings, the log files are created in folders respectively. 

To enable exception trace messages in the .NET SDK
--------------------------------------------------
1. Open App.config for console samples (SamplesCS and SamplesVB) and Web.config for web samples (SampleStoreCS and SampleStoreVB).

2. Set TRACE to ON.

3. Save and close the file.

4. When running a transaction, if an exception is thrown the exception stack trace would be available in the RESPONSE parameter of the transaction response.
