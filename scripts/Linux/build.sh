INITIAL_WORKING_DIRECTORY=$(pwd)
cd "$(dirname "$0")"

../../vendor/dotnet/dotnet-5.0/dotnet restore '../../Success History'
../../vendor/dotnet/dotnet-5.0/dotnet build '../../Success History'

cd "$INITIAL_WORKING_DIRECTORY"

