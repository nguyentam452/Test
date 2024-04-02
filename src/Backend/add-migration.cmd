pushd JokeApp
dotnet ef migrations add init -v --context JokeAppDbXontext
dotnet ef database update -v --context JokeAppDbXontext
pause
popd