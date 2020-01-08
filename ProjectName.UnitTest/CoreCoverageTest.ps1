$testProjectPath = $PSScriptRoot
$testResultsFolder = "$PSScriptRoot\TestResults"
$coverageOutPutFile = "coverage.coveragexml"

<#
echo "Test Project Path" $testProjectPath
echo "Test Results Folder" $testResultsFolder
#>

try {
	dotnet test $testProjectPath /p:CollectCoverage=true --collect:"Code Coverage"
    $recentCoverageFile = Get-ChildItem -File -Filter *.coverage -Path $testResultsFolder -Name -Recurse | Select-Object -First 1;
    write-host 'Test Completed'  -ForegroundColor Green

    C:\Users\coder\.nuget\packages\microsoft.codecoverage\16.2.0\build\netstandard1.0\CodeCoverage\CodeCoverage.exe analyze  /output:$testResultsFolder\$coverageOutPutFile  $testResultsFolder'\'$recentCoverageFile
    write-host 'CoverageXML Generated'  -ForegroundColor Green

    reportgenerator "-reports:$testResultsFolder\$coverageOutPutFile" "-targetdir:$testResultsFolder\coveragereport"
    write-host 'CoverageReport Published'  -ForegroundColor Green

}
catch {

    write-host "Caught an exception:" -ForegroundColor Red
    write-host "Exception Type: $($_.Exception.GetType().FullName)" -ForegroundColor Red
    write-host "Exception Message: $($_.Exception.Message)" -ForegroundColor Red
}

Read-Host -Prompt "Press Enter to continue"