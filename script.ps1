$headers = @{
  "Authorization" = "$Env:APPVEYOR_TOKEN"
  "Content-type" = "application/json"
}
$branch = $Env:APPVEYOR_REPO_BRANCH
$pullRequestHeadBranch = $Env:APPVEYOR_PULL_REQUEST_HEAD_REPO_BRANCH
$pullRequestId = $Env:APPVEYOR_PULL_REQUEST_NUMBER
#if ($pullRequestId) {
#  $branch = $NULL
#  $pullRequestHeadBranch = $NULL
#}
#pullRequestHeadBranch = "$pullRequestHeadBranch"
#pullRequestId = "$pullRequestId"
echo ">> pullRequestId = $pullRequestId branch = $branch pullRequestHeadBranch = $pullRequestHeadBranch <<"
$body = @{
  accountName = "Yuriy-Pelekh"
  projectSlug = "idf0-2"
  branch = "$branch"
}
$bodyAsJson = $body | ConvertTo-json
Invoke-Restmethod -uri "https://ci.appveyor.com/api/builds" -Headers $headers -Method "Post" -Body $bodyAsJson
