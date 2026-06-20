$RootDir = Resolve-Path (Join-Path $PSScriptRoot "..")
$RootUri = $RootDir.Path.Replace('\','/').Replace(' ','%20')
Get-ChildItem -Path (Join-Path $RootDir "learning-paths") -Filter presentation.html -Recurse | Where-Object { $_.FullName -like "*presentation*" } | ForEach-Object {
    $Out = Join-Path $_.Directory.FullName "presentation.local.html"
    $Text = Get-Content $_.FullName -Raw
    $Escaped = $RootUri.Replace("'", "\'")
    $Text = $Text.Replace("window.localRootUri='';", "window.localRootUri='$Escaped';")
    Set-Content -Path $Out -Value $Text -Encoding UTF8
    Write-Host "Generated $Out"
}
