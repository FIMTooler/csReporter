# Connector Space reporting tool for MIIS/ILM/FIM/MIM

## About
This is a Visual Studio C# project that provides a GUI for filtering and reporting on data within XML files generated using the csexport.exe utility that is included with FIM/MIM.  Reports can be made in HTML (quick and dirty HTML table), CSV, and recently Excel.

Although not required, it is capable of executing csexport on your behalf if ran on the server where FIM/MIM is installed.  It uses Registry Keys to determine the install location in order to locate csexport.exe.  

**NOTE:  csexport.exe is included with Azure AD Connect.  I haven't tested it, but am confident that most, if not all, of the XML structure is the same as that of FIM/MIM**

## Recent Updates

**\~\~Native Excel Reports\~\~**



**All report types no longer include non-changing attribute values. \*\*Possible decision via Checkbox in future\*\***
  - For instance, when generating a high level report that includes changes for different attributes, all attributes per object were included in the report even if the values were not being modifed.  This resulted in many "(No Change") values in the report.
  - **Example:**  Generating a report on pending-exports for all users.  User A has mail attribute change and user B has giveName attribute change.  In the reports, both User A and B would include values for both attributes.  User A would show "(No Change)" for giveName and user B would show "(No Change)" for mail.  Reports now only show values for changing attributes in this case.
