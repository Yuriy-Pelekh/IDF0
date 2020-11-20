$accountName = "Yuriy-Pelekh"
$projectSlug = "idf0-2"
$branch = $Env:APPVEYOR_REPO_BRANCH
$headers = @{
  "Authorization" = "$Env:APPVEYOR_TOKEN"
  "Content-type" = "application/json"
};
$body = @{
  "accountName" = "$accountName"
  "projectSlug" = "$projectSlug"
  "branch" = "$branch"
};
$bodyAsJson = $body | ConvertTo-json
Invoke-Restmethod -uri "https://ci.appveyor.com/api/builds" -Method "Post" -Headers $headers -Body $bodyAsJson
