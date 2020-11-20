$headers = @{
  "Authorization" = "$Env:APPVEYOR_TOKEN"
  "Content-type" = "application/json"
}
$accountName = 'Yuriy-Pelekh'
$projectSlug = 'idf0-2'
$branch = $Env:APPVEYOR_REPO_BRANCH
$pullRequestHeadBranch = $Env:APPVEYOR_PULL_REQUEST_HEAD_REPO_BRANCH
$pullRequestId = $Env:APPVEYOR_PULL_REQUEST_NUMBER
Write-Output ">> pullRequestId = $pullRequestId branch = $branch pullRequestHeadBranch = $pullRequestHeadBranch <<"
$body = "{
  'accountName': '$accountName',
  'projectSlug': '$projectSlug',
  'branch': '$branch',
  'pullRequestHeadBranch': '$pullRequestHeadBranch',
  'pullRequestId': '$pullRequestId',
}"

Write-Output $body
Invoke-Restmethod -uri "https://ci.appveyor.com/api/builds" -Headers $headers -Method "Post" -Body $body
