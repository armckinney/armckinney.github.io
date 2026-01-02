.PHONY: all build clean restore watch test lint format publish

# Variables
SLN_FILE := portfolio.sln
PROJECT := Portfolio

all: build

build:
	dotnet build $(SLN_FILE)

clean:
	dotnet clean $(SLN_FILE)
	rm -rf $(PROJECT)/bin
	rm -rf $(PROJECT)/obj

restore:
	dotnet restore $(SLN_FILE)

# suppress browser refresh due to running in container
watch:	
	DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH=true dotnet watch run --project $(PROJECT)

test:
	dotnet test $(SLN_FILE)

lint:
	dotnet format $(SLN_FILE) --verify-no-changes

format:
	dotnet format $(SLN_FILE)

publish:
	dotnet publish $(SLN_FILE) -c Release -o release
