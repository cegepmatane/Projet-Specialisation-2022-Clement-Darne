INITIAL_WORKING_DIRECTORY=$(pwd)
cd "$(dirname "$0")"

GREEN="\033[0;32m"
CYAN="\033[0;36m"
NONE="\033[0m"

echo -e "${CYAN}Installing .NET 5.0...${NONE}"
../../vendor/dotnet/dotnet-install.sh -c 5.0 --install-dir ../../vendor/dotnet/dotnet-5.0/

echo -e "${GREEN}Dependencies installation completed.${NONE}"

cd "$INITIAL_WORKING_DIRECTORY"

