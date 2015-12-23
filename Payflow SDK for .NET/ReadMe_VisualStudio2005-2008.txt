Copyright (c) 2009 PayPal Inc. All Rights Reserved
--------------------------------------------------

How to use with Visual Studio 2005/2008 and .NET Framework 2.0/3.x
---------------------------------------------------------
This package is designed to work with Visual Studio 2003 and .NET Framework 1.1.
The enclosed samples use the 1.1 version of the payflow_dotNET.dll by default. To 
use with Visual Studio 2005+ and .NET Framework 2.0 or higher replace the payflow_dotNET.dll 
within the projects bin directory with the payflow_dotNET_2.0.dll (renamed to 
payflow_dotNET.dll) from the root directory of the SDK.

Remember: Rename the file from payflow_dotNET_2.0.dll to payflow_dotNET.dll replacing
the original v1.1 one.

Also, you will need to recompile the eStoreFront or SampleStore examples if you
change the DLL from 1.1 to 2.0.

For x64 Systems:
The payflow_dotNET_2.0.dll is the only DLL that is compiled for x64 systems.