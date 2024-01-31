
<a name="readme-top"></a>



<!-- ABOUT THE PROJECT -->
## About The Project

This is a small project that uses C# code to find the longest incremental sequence of numbers in a large (or of any size really) list of numbers.
The project is split in 4 main parts:
* The .NET Core part with the maib logic
* The unit test project
* The API layer using ASP .NET Core
* The frontend layer written in Angular, to give a visual representation to this project


<!-- GETTING STARTED -->
## How to run
Clone the repo on your local machine.

# Test main logic only
Open the SequenceFinder solution in Visual Studio.
Enter the list of number in the Sample.txt file and run the application - the console will return the longest incremental sequence from the list you provided

# Run the web version
Right now the API needs to be ran locally.
Open the WebAPI solution and run it in visual studio. This will run the project under https://localhost:7186/
You can then navigate to the [web page](https://joss-fd.github.io/5eb4233e-d0b4-4ec5-9859-507281518e4f/) and use the application.

Alternatively you can choose to run the angular code locally. If so:

Open the WebView project
Run:
```sh
npm install
```
Followed by:
```sh
ng serve
```
Your web application should start running under http://localhost:4200/

## Roadmap
- [ ] Remove hardcoded URLs and variables
- [ ] Add more unit tests
- [ ] Allow for input file upload for the web version
- [ ] Deploy WebAPI with Github Actions to remove need to run API locally
