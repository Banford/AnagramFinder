# Anagram Finder

This console app will take a single file path to a file containing a list of words. It will read the 
file line by line and process groups of words of the same length in a batch. Processing each batch of 
words will reveal the groups of anagrams in the batch of words.

## Prerequisites

This project was built using .Net SDK version 5.0.302. You will need 
the [SDK](https://dotnet.microsoft.com/download) installed in order to build 
and run the project.

## Building the Project

From the solution directory run:

`dotnet build`

This will build both the test project and main project.

## Testing the Project

Tests are written using xUnit and can be run from the dotnet command line, or via an IDE such as Rider or Visual Studio.

`dotnet test` - Run tests from the command line.

Tests that run are a combination of unit and integration tests. The integration tests will spawn a process
in order to test the real application executable. There is a folder of test data included in the test project for use with
these tests.

## Running the Project

From the solution directory run:

Example 1:

`dotnet run --project .\Banford.Anagrams\Banford.Anagrams.csproj ".\Data\example1.txt"`

Example 2:

`dotnet run --project .\Banford.Anagrams\Banford.Anagrams.csproj ".\Data\example2.txt"`

## Logging

Logging has been configured using [Serilog](https://serilog.net/) to output to the standard out in the console. 
Additional Log sinks could be added to support logging to other places such as a file or 
APM system.

## Assumptions

* Assumption is that all input will be lowercase words. Code could be adapted to support mixed case.
* If the word is the same word, we wouldn't count this as an anagram, as it is a duplication.
* Only output groups of anagrams that have at least one matching word (2 versions of the anagram minimum).
* The input will always have a new word on each line without gaps.

## Language Choice

The application is written in C#, primarily because this is the language I am most familiar with, but it also offers some
advantages for this kind of solution. I can use static classes for the bulk of the algorithm reducing resources used by
the program. I also can easily write integration tests in C# by spawning the process of the application and running it 
with realistic input files. There is also the benefit of using third party packages like the logging library Serilog to 
add logging to the app. However, this problem could easily be tackled in other languages and I considered using TypeScript
instead.

## Computational Complexity

I haven't done an automated computational analysis of the algorithm here, however by doing an analysis of the code and 
considering the computation of each line or loop I can determine that the main algorithm finder should be `O(n)` and scale
linearly with the input to the function. 

Next steps would be to benchmark this using a tool like BenchmarkDotNet.

## Data Structures

I chose to use Lists and Dictionaries for gathering the anagrams as they are easier to manipulate than using an array and 
it provides clearer code to read than using arrays for example. I could have used a custom type rather than the Dictionary
to represent the grouped anagrams, this may have further improved readability of the code.

## With More Time

With more time to work on this program I would:

* Conduct benchmarking to prove my hypothesis about the computational complexity of the algorith.
* Conduct further integration testing with more sample files.
* Do some further passes of refactoring the code to apply clean code principles, see if some of the functionality would 
make sense to further split out into classes or functions.