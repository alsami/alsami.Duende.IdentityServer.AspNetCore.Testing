function run_tests() {
  dotnet test -c Release -p:CoverletOutput="../../coverage/" -p:MergeWith="../../coverage/coverage.json" -p:CollectCoverage=true -p:CoverletOutputFormat=\"json,lcov,opencover\" -p:ThresholdType=line -p:ThresholdStat=total -p:Exclude=\"[Duende.IdentityServer.Api]*,[Duende.IdentityServer.Server]*\" | tee testoutput.txt
  return ${?}
}

function publish_coverage() {
  curl https://codecov.io/bash -o codecov.sh
  chmod +x codecov.sh
  ./codecov.sh
  return ${?}
}

run_tests
publish_coverage
exit ${?}
