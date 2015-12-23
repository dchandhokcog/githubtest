Copyright (c) 2005 PayPal Inc. All Rights Reserved
----------------------------------------------

Some Important points to remember while setting up the  CS and VB sample store for BuyerAuth and Express checkout
--------------------------------------------------------------------------------------------------
1. Register SampleStores For BuyerAuth and Express checkout into IIS.
2. Open the project eStoreFront.csproj for CS or eStoreFrontVB.vbproj.
3. Modify  User Information in Constant.cs or Constant.vb
4. Modify  PayflowConnection information in Constant.cs or Constant.vb
5. Modify LocalHostName and your site name in the config file.
6. Save all the files and build(Compile) the project.
7. Save the solution file.
8. Make sure cookies are enabled.
9. Provide write access for "orders" folder.
10. Run the project.

To register SampleStores For BuyerAuth and Express checkout into IIS
----------------------------------------------
1. Go to Start > Run.

2. Type in inetmgr and click OK. The Internet Information Services screen appears.

3. Browse to your <hostname> > Default Web Site.

4. Right click Default Web Site > New > Virtual Directory. The Virtual Directory Creation Wizard screen appears.

5. Click Next. The Virtual Directory Alias Screen appears.

6. In the text box for Alias, type in eStoreFrontCS for CS or eStoreFrontVB for VB eStoreFront. 

7. Click Next. The Web Site Content Directory screen appears.

8. Click Browse. The Browse for Folder screen appears.

9. Browse to the %PAYPAL_HOME%\eStoreFrontCS for CS eStoreFront or %PAYPAL_HOME%\eStoreFrontCSVB for VB eStoreFront directory
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

17. Click Add to open the Add Content Page dialog box on IIS 6.0 or the Add Default Page dialog box on IIS 5.0. Enter PurchaseDescription.aspx in this dialog box and click OK.


To test the SDK using eStoreFront
----------------------------------------------

Open your preferred Internet browser and browse to 
http://<ServerName.DomainName>/eStoreFrontCS for CS eStoreFront
OR
http://<ServerName.DomainName>/eStoreFrontVB for VB eStoreFront

Do not use localhost.If you give localhost/eStoreFront you may get a cookie related error.

