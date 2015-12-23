-----------------------------------------------------
Copyright (c) 2009 PayPal, Inc. All Rights Reserved
-----------------------------------------------------

The Payflow Pro .NET SDK can be used with classic ASP or other COM application once the .dll is
registered into the GAC.  You will need to make minor changes to your code which are documented
in the ASPCOMExample.asp file.

1. Pre-requisites

		a. Microsoft .NET Framework v1.1, v2.0 or v3+ installed.  For x64 systems, you'll need the
		   x64 version of the .NET Framework.		   

		b. Optional: Microsoft .NET SDK or Microsoft Visual Studio 2003/2005 installed.
	
		   Microsoft .NET Framework and SDK can be obtained at http://msdn.microsoft.com/netframework

2. Installing the new Payflow Pro .NET component

		Assumptions : 

		<PAYFLOW_DIR> = Directory where older version of PFProCOM.dll is installed.
			For example: C:\WINDOWS\System32
			
		<WINDOWS_DIR> = Directory where Windows is installed.
			For example: C:\WINDOWS
			
		%PAYPAL_HOME% = the installation path selected by the user during installation of the SDK.
		  Default is "C:\Program Files\Payflow SDK for .NET".

2.1	Uninstall old COM (PFProCOM) component, if installed.

		a.	Open the command prompt, do the following:
		
				1. Select Start-->Run
				2. Type Cmd
				3. Press Enter
				
		b. 	Stop IIS, do the following:
			
				1. From the command prompt, type: iisreset -stop
				
		c.	Change directory to <WINDOWS_DIR>\System32.

		d.	Unregister the old PFProCOM.dll.

				1. From the command prompt, type: regsvr32 /u "<PAYFLOW_DIR>\PFProCOM.dll"
					
				   Example: If <PAYFLOW_DIR> is C:\WINDOWS\System32 then at command prompt
				   the following line should work: C:\WINDOWS\system32\regsvr32 /u "C:\WINDOWS\System32\PFProCOM.dll"                 
				
		e.	Under <PAYFLOW_DIR>, delete or rename PFProCOM.dll and pfpro.dll.

2.2	Install new Payflow Pro .NET component.

		a. 	Stop IIS, do the following:
			
				1. From the command prompt, type: iisreset -stop

		b.	Copy files.
				
				1. From %PAYPAL_HOME%, copy payflow_dotNET.dll to the <WINDOWS_DIR>\SYSTEM32 directory.
				
				   Note: You will need to rename the Framework version of the DLL to Payflow_dotNET.dll.
				 
				   For Example: Payflow_dotNET_1.1 >> Payflow_dotNET.dll
			
		c.	Open a command prompt.
		
				If you are not using Visual Studio, do the following:
				
				1. Select Start-->Run.
				2. Type CMD.
				2. Press Enter.
			
				If you are using Visual Studio 2003 or 2005, do the following:
				
				1. 2003: Select Start-->All Programs-->Microsoft Visual Studio .NET 2003--> Visual Studio .NET Tools-->Visual studio .NET 2003 Command Prompt.
		   		   2005: Select Start-->All Programs-->Microsoft Visual Studio 2005--> Visual Studio Tools-->Visual Studio 2005 Command Prompt.
				2. Press Enter.

		d.	Change directory to <WINDOWS_DIR>\SYSTEM32.

		e.	To register Payflow_dotNET.dll, do the following:
		
			Important Notes:

				The path "<WINDOWS_DIR>\Microsoft.NET\Framework\v1.1.4322" may have to be replaced
				by the appropriate path to regasm & gacutil on your machine.
     			 			 
				For example, for v2.0 it might be "<WINDOWS_DIR>\Microsoft.NET\Framework\v2.0.50727".
				For x64, "<WINDOWS_DIR>\Microsoft.NET\Framework64\v2.0.50727"
				For Windows 2003 x64, you will need to use the 32-bit version of RegAsm.

    		1. Type "<WINDOWS_DIR>\Microsoft.NET\Framework\v1.1.4322\regasm" Payflow_dotNET.dll
    		
  				 This will register the types exported by the .NET assembly and expose them to the COM component.

     		2. Type "<WINDOWS_DIR>\Microsoft.NET\Framework\v1.1.4322\gacutil" /if Payflow_dotNET.dll
     			 
     			 This will add the pfpro_dotNET assembly to the Global Assembly cache.
     			 
     			 2.0 .NET SDK or Visual Studio 2005:  You can find "gacutil" at C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\bin\gacutil.exe
     			 
     			 NOTE: If you do not have "gacutil" on your server/workstation, you can drag the payflow_dotNET.dll into the 
     			 "assembly" directory under "Windows".  This "should" register the DLL and you should be able to see it via the .NET Framework
     		   	 Configuration.  Otherwise, you can copy "gacutil" from a workstation that does have it installed.
     		
     f. Start IIS, do the following:
			
				1. From the command prompt, type: iisreset -start

2.3	Set the necessary configuration details in your application.  Refer to ASPCOMExample.asp for more information.

2.4 Testing the COM component.

		1. Copy ASPCOMExample.htm and ASPCOMExample.asp to the root of your webserver.
		2. Open a browser and browse to http://localhost/ASPCOMExample.htm.
		3. Enter information requested, click Submit to verify functionality.

3. Uninstalling the new Payflow Pro .NET component.

		a.	Open the command prompt, do the following:
		
				1. Select Start-->Run
				2. Type Cmd
				3. Press Enter
		
		b. 	Stop IIS.
			
				1. From the command prompt, type: iisreset -stop

		c.	Change directory to <WINDOWS_DIR>\SYSTEM32.

		d.	Unregister Payflow_dotNET.dll, do the following:

     			 Note: The path "<WINDOWS_DIR>\Microsoft.NET\Framework\v1.1.4322" may have to be replaced
     			 			 by the appropriate path to regasm & gacutil on your machine.
     			 			 
				1. Type "<WINDOWS_DIR>\Microsoft.NET\Framework\v1.1.4322\regasm" Payflow_dotNET.dll -u

     		2. Type "<WINDOWS_DIR>\Microsoft.NET\Framework\v1.1.4322\gacutil" /u Payflow_dotNET.dll
     			 
     			 This will remove the Payflow_dotNET assembly to the Global Assembly cache.

		e.	Delete Payflow_dotNET.dll from the <WINDOWS_DIR>\SYSTEM32 directory.

----------------------------------------------------------------