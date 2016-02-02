
# CSharp-NUnit-NMake

This code is provided on an "AS-IS” basis without warranty of any kind, either express or implied, including without limitation any implied warranties of condition, uninterrupted use, merchantability, fitness for a particular purpose, or non-infringement. Your tests and testing environments may require you to modify this framework. Issues regarding this framework should be submitted through GitHub. For questions regarding Sauce Labs integration, please see the Sauce Labs documentation at https://wiki.saucelabs.com/. This framework is not maintained by Sauce Labs Support.

Demonstrates how to use NUnit to run parallel tests on Sauce Labs platfrom using nmake as the build system. 

Uses [NuGet](http://docs.nuget.org/) as package manager.

###Dependencies:

* MS Visual Studio 2013 or later.
* [NUnit3.0](https://www.nunit.org/)
* [NuGet](https://dist.nuget.org/index.html) Plugin for Visual Studio
* [NuGet](https://dist.nuget.org/index.html) CLI executable installed in your path.


### Setup:

* Install NuGet packages for the project: <br>
```cd Packages```<br>
```nuget.exe install ..\ParallelSelenium\packages.config```<br>

* Clean and rebuild project:<br>
```nmake clean build```

### Set Credentials:<br>
```set SAUCE_USERNAME=<sauce-username>```<br>
```set SAUCE_ACCESS_KEY=<sauce-access-key>```

### Run Tests in parallel on [Sauce](https://saucelabs.com/beta/dashboard/tests) using a Developer Console:<br>
```nmake test``` <br>
**or**<br>
```nmake all```<br>

### Resources
##### [Sauce Labs Documentation](https://wiki.saucelabs.com/)

##### [SeleniumHQ Documentation](http://www.seleniumhq.org/docs/)

##### [NUnit Documentation](https://github.com/nunit/nunit/wiki)

##### [Stack Overflow](http://stackoverflow.com/)
* A great resource to search for issues not explicitly covered by documentation
