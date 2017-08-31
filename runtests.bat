packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:testrunner.bat -register:user -filter:"+[PixelFlow]* +[Utilities]*"
packages\ReportGenerator.2.5.6\tools\reportgenerator.exe -reports:results.xml -targetdir:CoverageResults
packages\ReportUnit.1.2.1\tools\ReportUnit.exe TestResult.xml TestResults.html
move /y results.xml .\CoverageResults
if not exist ".\TestResults\" mkdir .\TestResults\
move /y TestResult.xml .\TestResults\
move /y TestResults.html .\TestResults\