$headers = @{
  "Authorization" = "$Env:APPVEYOR_TOKEN"
  "Content-type" = "application/json"
}
$accountName = "Yuriy-Pelekh"
$projectSlug = "idf0-2"
$branch = $Env:APPVEYOR_REPO_BRANCH
$pullRequestHeadBranch = $Env:APPVEYOR_PULL_REQUEST_HEAD_REPO_BRANCH
$pullRequestId = $Env:APPVEYOR_PULL_REQUEST_NUMBER

$body = @{
  "accountName" = "$accountName"
  "projectSlug" = "$projectSlug"
  "branch" = "$branch"
}

Write-Output $body

$bodyAsJson = $body | ConvertTo-json

Write-Output $bodyAsJson

Invoke-Restmethod -uri "https://ci.appveyor.com/api/builds" -Headers $headers -Method "Post" -Body $bodyAsJson
