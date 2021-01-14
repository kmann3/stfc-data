#requires -version 2
<#
.SYNOPSIS
  Script gets a list of officer, ship, and system JSON files.
  It converts them to raw format.
  Appends them into one massive variable.
  When loop is done, outputs to concatenated data to a file.
.DESCRIPTION
  Merge all useful JSON data into one massive JSON file for easy transport or parsing.
.INPUTS
  None
.OUTPUTS
  Creates a compressed JSON file for the data.
  Data is compressed because it will rarely, if ever, be read by a human.
.NOTES
  Version:        1.0
  Author:         Kenny Mann
  Creation Date:  2021-01-14
  Purpose/Change: Initial script development
  
.EXAMPLE
  > concat-json.ps1
#>


$allData = @()
$fileList = Get-ChildItem -Name -Include officer*.json,ship*,json,system*.json -Attributes !Directory
ForEach($file in $fileList) {
    $data = Get-Content -Path $file -Raw | ConvertFrom-Json
    Write-Output $data    
    $allData += $data
}

$allData | ConvertTo-Json -Depth 20 -compress | Out-File -FilePath combinedFiles.json