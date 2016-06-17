all: clean build test

clean:
	msbuild.exe /t:clean /p:Configuration=Release
	del smoke*


build:
	msbuild.exe /t:build /p:Configuration=Release

test:
	"c:\Program Files (x86)\NUnit 2.6.4\bin\nunit-console.exe" ParallelSelenium.sln /config:Release

ptest:
	"c:\Program Files (x86)\NUnit 2.6.4\bin\pnunit-launcher.exe" pnunit.conf
