$js1 = Get-Content -Path .\officer-one-of-ten.json -Raw |
    ConvertFrom-Json
$js2 = Get-Content -Path .\officer-TLaan.json -Raw |
    ConvertFrom-Json

$js1 + $js2 |
    ConvertTo-Json -Depth 5 |
    Out-File -FilePath .\combinedfiles.json