$accountName = "Yuriy-Pelekh"
$projectSlug = "idf0-2"
$branch = $Env:APPVEYOR_REPO_BRANCH
$pullRequestHeadBranch = $Env:APPVEYOR_PULL_REQUEST_HEAD_REPO_BRANCH
$pullRequestId = $Env:APPVEYOR_PULL_REQUEST_NUMBER
$headers = @{
  "Authorization" = "$Env:APPVEYOR_TOKEN"
  "Content-type" = "application/json"
};
$body = @{
  accountName = "$accountName"
  projectSlug = "$projectSlug"
  branch = "$branch"
  pullRequestHeadBranch = "$pullRequestHeadBranch"
  pullRequestId = "$pullRequestId"
};
Write-Output $body
$bodyAsJson = $body | ConvertTo-json
Write-Output $bodyAsJson
Invoke-Restmethod -uri "https://ci.appveyor.com/api/builds" -Method "Post" -Headers $headers -Body $bodyAsJson
