# Running Tests in Parallel with C# Using NUnit on Sauce Labs:

NUnit is a unit-test framework for all .Net languages, written entirely in C# and designed to take advantage of many .NET language features, for example custom attributes and other reflection-related capabilities.For more information and documentation about the framework, as well as how to use it in your testing, you can visit the [official NUnit website](http://www.nunit.org/index.php?p=home).

### Prerequisites

You’ll need to have these components installed to set up PNUnit testing on Sauce with C# .NET:

  1) Visual Studio
  
  2) Selenium DLLs for .NET installed and referenced by your project
  
  3) NUnit + PNUnit Bundle

####Create the Visual Studio Project:

1) Open a new project in Visual Studio. Make sure the .NET Framework is either 3.5 or 4.0

2) Select a C# class library template.

3) Give the project a name and click OK.

####Install the  Selenium DLLs:

After you’ve set up your project in Visual Studio, you need to make sure that it references the required Selenium DLLs for .NET.

1) Download the Selenium DLLs for .NET from http://selenium-release.storage.googleapis.com/index.html?path=2.47/

2) In the Solutions Explorer, select the project and right-click References.

3) Click Add Reference.

4) Click Browse and navigate to either the net35 or net40 folder of the directory where you saved the Selenium .NET DLLs.

5) Add all four .DLL references to your project.

#####Install NUnit + PNUnit and Import the Libraries into Your Project:

1) Download the current stable release of NUnit(2.6.4) from http://www.nunit.org/index.php?p=download.

2) In the Solutions Explorer, select the project and right-click References.

3) Click Add Reference.

4) Click Browse and navigate to the bin of the directory where you saved NUnit.

5)Add the nunit.framework.dll and pnunit.framework.dll reference to your project.

### Code Example

####SaucePNUnit_Test.cs:

Now let’s take a look at a simple C# .Net project. This example test opens Google, verifies that “Google” is the title of the page, and then searches for Sauce Labs.

####Constants.cs:

Use this class to set your Sauce Labs account name and access key as environment variables, as shown in the example test. You can find these in the User Profile menu of your Sauce Labs dashboard, under User Settings.
NOTE: If you prefer to hard-code your access credentials into your test, you would do so in the lines
 		caps.SetCapability("username", Constants.SAUCE_LABS_ACCOUNT_NAME);
 		caps.SetCapability("accessKey", Constants.SAUCE_LABS_ACCOUNT_KEY);

However, Sauce Labs recommends using environment variables for authentication as a best practice. This adds a layer of security to your tests, and allows other members of your team to share authentication credentials.

### Run the Test

1) In Visual Studio, install the NUnit Test Adaptor
  
  * Select Tools | Extension Manager.
  * In the left panel of the Extension Manager, select Online Extensions.
  * Locate the NUnit Test Adapter in the center panel and highlight it.
  * Click 'Download' and follow the instructions.

2) To view the NUnit Test Adaptor, go to Test | Windows | Test Explorer. You should now see the Test Explorer tab on the left side of your project

3) Build the project by going Build > Build Solution, or use the CTRL-SHIFT-B shortcut. When you initially open a solution, no tests will be displayed. After compiling the assemblies in the solution, Visual Studio will interact with the NUnit Test Adapter to discover tests and a list of them will be shown in the Test Explorer.

4) Click Run All to launch your test to the Sauce Dashboard 

