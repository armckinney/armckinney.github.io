.PHONY: watch

watch:
	DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH=true dotnet watch run --project Portfolio
