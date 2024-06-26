# AeroCheck - Streamlining Airline Check-in and Boarding Pass Issuance

## Description

AeroCheck is a software system designed to revolutionize the airline industry by simplifying the check-in process and boarding pass issuance for passengers. Developed as part of the Object-Oriented Modelling subject (DIT2123) in the Diploma in Information Technology program at Sunway Diploma Studies, AeroCheck aims to enhance efficiency, improve passenger experience, and ensure seamless operations for airlines.

## Justification for Using .NET with C#

When selecting the technology stack for AeroCheck, careful consideration was given to various factors to ensure the project's success and efficiency. Here are the reasons why .NET with C# was chosen over Java with Maven:

1. **Integrated Development Environment (IDE)**: Visual Studio offers a robust set of tools and features tailored for C# development, providing a seamless development experience with features like IntelliSense, debugging, and graphical interface design.

2. **Language and Framework Consistency**: .NET provides a unified framework for building different types of applications, ensuring consistency in language and framework across various project components. This consistency simplifies development, maintenance, and deployment processes.

3. **Performance**: .NET's Just-In-Time (JIT) compilation and optimized runtime environment offer competitive performance compared to Java applications. With advancements in .NET 8.0, developers can leverage performance enhancements to build fast and responsive applications like AeroCheck.

4. **Dependency Management**: .NET's NuGet package manager simplifies dependency management, making it easier to integrate third-party libraries and components into the project.

5. **Language Features**: C# offers modern language features such as async/await for asynchronous programming, LINQ for querying data, and powerful lambda expressions, enhancing developer productivity and code readability.

Considering these factors and the specific requirements outlined in the project description, .NET with C# emerges as the better framework for developing AeroCheck, ensuring efficient development, enhanced performance, and robust functionality even for a console application.

## Author

- Nathan G

## Date

Submission Deadline: June 21, 2024

## Folder Structure

- **Code**: Contains the C# code files for the AeroCheck project.
- **Documentation**: Contains all documentation files, including the project report and screenshots.

## How to Run

1. Clone this repository to your local machine.
2. Open the solution file (`AeroCheck.sln`) in Visual Studio or your preferred C# IDE.
3. Build the solution to ensure all dependencies are resolved.
4. Run the `Program.cs` file to execute the AeroCheck application.

## Features

- **Flight Generation**: Generate flights with random origin, destination, departure, and arrival times.
- **Passenger Generation**: Generate passengers with random names, passport numbers, and special needs details.
- **Group Generation**: Generate groups of passengers with varying sizes and representative selection.
- **Staff Generation**: Generate staff members with random names and positions.
- **Airlines Generation**: Generate airlines with associated codes, headquarters, founding dates, and websites.
- **Kiosk Generation**: Generate self-service kiosks for passenger check-in.
- **Interactive Menu**: Interactive menu system for user interaction and navigation.
- **Flight Operations**: Perform operations such as passenger check-in, printing boarding passes, and handling baggage.
- **Data Display**: Print information about kiosks, staff, passengers, groups, airlines, and flights.

## Additional Features

- **Error Handling**: Implemented error handling mechanisms to handle invalid inputs and prevent runtime crashes.
- **DateTime Management**: Utilized DateTime format to manage flight schedules and boarding times effectively.
- **Data Structures and Algorithms**: Employed data structures and algorithms to efficiently manage passenger information, baggage, and staff assignments.
- **Documentation**: Comprehensive documentation provided to enhance understanding and facilitate future maintenance.

## Additional Information

- Ensure that the .NET Core SDK is installed on your machine before running the project.
- The project leverages object-oriented principles to ensure modularity, extensibility, and maintainability.
- For any inquiries or assistance regarding the project, please contact the author, Nathan G.
