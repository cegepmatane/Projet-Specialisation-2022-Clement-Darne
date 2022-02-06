INITIAL_WORKING_DIRECTORY=$(pwd)
cd "$(dirname "$0")"

echo 'Installing .NET 5.0...'
../../vendor/dotnet/dotnet-install.sh -c 5.0 --install-dir ../../vendor/dotnet/dotnet-5.0/

echo 'Dependencies installation completed.'

cd "$INITIAL_WORKING_DIRECTORY"

