#
# Gets the PSScriptRoot folder.
# When running through Powershell ISE $PSScriptRoot may be undefined, so this function works around that
#
function GetPSScriptRoot()
{
    $localScriptRoot = $PSScriptRoot
    if (!$localScriptRoot)
    {
        $localScriptRoot = (Get-Item -Path ".\" -Verbose).FullName    
    }

    return $localScriptRoot
}

$serviceName = "Demo Hello World Service"
$binaryFolder = GetPSScriptRoot
$binaryPathName = Join-Path $binaryFolder "Demo.HelloWorld.Service.exe"

Write-Host "Stopping service"
Stop-service $serviceName -ErrorAction SilentlyContinue

Write-Host "Deleting service"
& "$env:windir\System32\sc.exe" delete $serviceName

Write-Host "Creating service with binpath: $binaryPathName"
& "$env:windir\System32\sc.exe" create $serviceName binpath= $binaryPathName start= auto
if(!$?){ throw "Failed to create service $serviceName" }

Write-Host "Starting service"
Start-service $serviceName -Verbose