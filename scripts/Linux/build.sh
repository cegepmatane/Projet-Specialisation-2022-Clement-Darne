INITIAL_WORKING_DIRECTORY=$(pwd)
cd "$(dirname "$0")"

YELLOW="\033[0;33m"
NONE="\033[0m"

DOTNET="../../vendor/dotnet/dotnet-5.0/dotnet"
"$DOTNET" --info || {
	echo -e "${YELLOW}.NET is not locally installed. Trying to find it globally...${NONE}"
	DOTNET="dotnet"
}

"$DOTNET" restore "../../Success History"
"$DOTNET" build "../../Success History"

cd "$INITIAL_WORKING_DIRECTORY"

