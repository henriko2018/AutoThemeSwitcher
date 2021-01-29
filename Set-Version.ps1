param (
    [Parameter(Mandatory)]$csprojFile,
	[Parameter(Mandatory)]$buildNumber
)

$content = Get-Content $csprojFile
$regex = "<Version>(?<version>\d+\.\d+\.\d+)<\/Version>"
$content | foreach { if ($_ -match $regex) { $version = $Matches.version } }
$parts = $version -split "\."
$version = "$($parts[0]).$($parts[1]).$buildNumber"
$content -replace $regex, "<Version>$version</Version>" | Set-Content -Path $csprojFile -Encoding utf8
echo "::set-output name=version::$version"