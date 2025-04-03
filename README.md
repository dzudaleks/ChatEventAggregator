# ChatEventAggregator

A simple console application that simulates a chat room where users can view chat history at varying levels of time-based aggregation.

## Features

- **Event types supported**:
  - User enters the room
  - User leaves the room
  - Comments
  - High-fives between users
- **Aggregation levels**:
  - `Chronologically` — View each event in the exact order it happened
  - `Hourly` — View summarized event counts per hour

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

### Running the App

```bash
cd ChatEventAggregator
dotnet run
```

You will be prompted to choose the granularity:
```
Please enter event granularity [Chronologically/Hourly]:
0 - Chronologically
1 - Hourly
```

Enter one of the options to see the output in your terminal.

## Example Output

**Chronologically**:
```
5:00 PM: Bob enters the room
5:05 PM: Kate enters the room
5:15 PM: Bob comments: "Hey, Kate - high five?"
5:17 PM: Kate high-fives Bob
```

**Hourly**:
```
5 PM:
 2 people entered
 1 person high-fived 1 other person
 1 comment
```

## How It Works
- Events are simulated and grouped using a service-oriented structure
- Dependency Injection is used via interfaces to allow flexibility in event aggregation logic

## Project Structure

```
ChatEventAggregator.sln
├── ChatEventAggregator/               # Console app entry point
├── ChatEventAggregator.Common/        # Shared domain models, enums, interfaces
├── ChatEventAggregator.Infrastructure # Services and repository implementations
├── ChatEventAggregator.Testing        # Unit tests using NUnit, FluentAssertions, and FakeItEasy
```

## Potential Improvements
- Properly implement repository layer. Suggestion is to go with EntityFramework DbContext that would map models to corresponding db tables.
- ILogger could be injected and used for logging.
- Currently, there is no authentication setup. In a real-world scenario user login system could be implemented.

## License
This project is for demonstration/interview purposes.

---
Made with love using C# and .NET

