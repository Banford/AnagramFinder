# Anagram Finder

This console app will take a single file path to a file containing a list of words. It will read the file line by line and process groups of words of the same length in a batch. Processing each batch of words will reveal the groups of anagrams in the batch of words.

## Prerequisites

This project was built using .Net SDK version 5.0.302.

## Building the Project

From the solution directory run:

`dotnet build`

This will build both the test project and main project.

## Testing the Project

Tests are written using xUnit and can be run from the dotnet command line, or via an IDE such as Rider or Visual Studio.

`dotnet test` - Run tests from the command line.

## Running the Project

From the solution directory run:

Example 1:

`dotnet run --project .\Banford.Anagrams\Banford.Anagrams.csproj ".\Data\example1.txt"`

Example 2:

`dotnet run --project .\Banford.Anagrams\Banford.Anagrams.csproj ".\Data\example2.txt"`

## Assumptions

* Assumption is that all input will be lowercase words. Code could be adapted to support mixed case.
* If the word is the same word, we wouldn't count this as an anagram, as it is a duplication.
* Only output groups of anagrams that have at least one matching word (2 versions of the anagram minimum).
* The input will always have a new word on each line without gaps.