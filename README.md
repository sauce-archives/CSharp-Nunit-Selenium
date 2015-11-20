# SauceLabs_CSharp_NUnit3.0 Tutorial

NUnit is a unit-test framework for all .Net languages, written entirely in C# and designed to take advantage of many .NET language features, for example custom attributes and other reflection-related capabilities. With the latest version of the framework, NUnit 3.0, NUnit allows the ability of running tests in parallel without the need of adding the PNUnit extension. For more information and documentation about the framework, as well as how to use it in your testing, you can visit the [official NUnit website](http://www.nunit.org/index.php?p=home).

### Prerequisites

You’ll need to have these components installed to set up PNUnit testing on Sauce with C# .NET:

  1) Visual Studio
  
  2) Selenium DLLs for .NET installed and referenced by your project
  
  3) NUnit + PNUnit Bundle

####Create the Visual Studio Project:

1) Open a new project in Visual Studio. Make sure the .NET Framework is at least 3.5, 4.0, or 4.5

2) Select a C# class library template.

3) Give the project a name and click OK.

####Install the Selenium DLLs:

After you’ve set up your project in Visual Studio, you need to make sure that it references the required Selenium DLLs for .NET.

1) Download the Selenium DLLs for .NET from http://www.seleniumhq.org/download/

2) In the Solutions Explorer, select the project and right-click References.

3) Click Add Reference.

4) Click Browse and navigate to either the net35 or net40 folder of the directory where you saved the Selenium .NET DLLs.

5) Add all four .DLL references to your project.

#####Install NUnit + PNUnit and Import the Libraries into Your Project:

1) Download the latest version of NUnit(3.0) from http://www.nunit.org/index.php?p=download.

2) In the Solutions Explorer, select the project and right-click References.

3) Click Add Reference.

4) Click Browse, navigate to the directory where you saved NUnit on your machine and go to framework -> 3.0.5797.27534.

5) Click on the folder of the .Net Framework version that your Visual Studio is built on. For example, if you're using the .Net 4.0 Framework, you would select the net-40 folder.

6) Add the nunit.framework.dll reference to your project.

### Code Example

####SauceTest.cs:

Now let’s take a look at a simple C# .Net project. This example test opens Google, verifies that “Google” is the title of the page, and then searches for Sauce Labs. If you look at the code, you know notice several TestFixture objects, which are used to NUnit what browser/OS combinations we want to use in our Sauce job. How the parallel execution is done is with the use of the following ParallelizableAttribute:

[Parallelizable(ParallelScope.Fixtures)]

Inside the constructor, we give it an ParallelScope arugement, in this case we're telling that we want TestFixtures to run in parallel with one another. You can read more about the ParallelizableAttribute in the [NUnit documentation](http://www.nunit.com/index.php?p=parallelizable&r=3.0). 

NOTE: Currently, the ability to run methods in parallel within a class has not been implemented, so the only way to acheieve parallelism is with the use of different TestFixtures.

### Run the Test

1) In Visual Studio, install the NUnit Test Adaptor
  
  * Select Tools | Extension Manager.
  * In the left panel of the Extension Manager, select Online Extensions.
  * Locate the NUnit 3.0 Test Adapter in the center panel and highlight it.
  * Click 'Download' and follow the instructions.

2) To view the NUnit Test Adaptor, go to Test | Windows | Test Explorer. You should now see the Test Explorer tab on the left side of your project

3) Build the project by going Build > Build Solution, or use the CTRL-SHIFT-B shortcut. When you initially open a solution, no tests will be displayed. After compiling the assemblies in the solution, Visual Studio will interact with the NUnit Test Adapter to discover tests and a list of them will be shown in the Test Explorer.

4) Click Run All to launch your test to the Sauce Dashboard 
