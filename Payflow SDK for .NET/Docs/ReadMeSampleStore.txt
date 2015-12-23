Copyright (c) 2006 PayPal, Inc. All Rights Reserved
---------------------------------------------------

This sample is designed to show all the functions available with this SDK; however, it is not designed to be used for code
examples.  It is suggested that you use the console sample especially the DoSaleComplete.xx example for code samples.

To register SampleStores into IIS
---------------------------------------------------
1. Go to Start > Run.

2. Type in inetmgr and click OK. The Internet Information Services screen appears.

3. Browse to your <hostname> > Default Web Site.

4. Right click Default Web Site > New > Virtual Directory. The Virtual Directory Creation Wizard screen appears.

5. Click Next. The Virtual Directory Alias Screen appears.

6. In the text box for Alias, type in SampleStoreCS for the C# Sample Store. For the VB.NET Sample Store, type in SampleStoreVB.

7. Click Next. The Web Site Content Directory screen appears.

8. Click Browse. The Browse for Folder screen appears.

9. Browse to the %PAYPAL_HOME%\SampleStoreCS directory for the C# Sample Store. 
For the VB.NET Sample Store, browse to %PAYPAL_HOME%\SampleStoreVB directory.
%PAYPAL_HOME% holds the installation path selected by the user during installation.
%PAYPAL_HOME% would by default point to "C:\Program Files\Payflow SDK for .NET".


10. Click OK to return to the Web Site Content Directory screen.

11. Click Next. The Access Permissions screen appears.

12. Leave the default permissions as-is (Read and Run scripts) and click Next. 
The Virtual Directory Creation Wizard – Completion screen appears.

13. Click Finish to complete the creation of the Virtual Directory.

14. Right-click the created Virtual Directory and select Properties.

15. In the property window select the Documents tab. On IIS 6.0, select the 'Enable default content page'. On IIS 5.0, select 'Enable Default document'.

16. Select each entry in the listbox one at a time and remove it by clicking Remove.

17. Click Add to open the Add Content Page dialog box on IIS 6.0 or the Add Default Page dialog box on IIS 5.0. Enter default.aspx in this dialog box and click OK.


To test the SDK using SampleStores
----------------------------------------------

C# SampleStore
---------------
Open your preferred Internet browser and browse to 
http://<ServerName.DomainName>/SampleStoreCS

VB.NET SampleStore
------------------
Open your preferred Internet browser and browse to 
http://<ServerName.DomainName>/SampleStoreVB
