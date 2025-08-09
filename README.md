# Blazor Calculator

A clean, recruiter-friendly Blazor WebAssembly app that demonstrates:

- Component-based UI with isolated CSS (`.razor.css`)
- State management via a reusable `CalculatorEngine` class library
- Two-way binding and event callbacks
- Unit tests (xUnit) for the calculation engine
- CI with GitHub Actions (.NET build & test)
- Accessibility basics and keyboard support

## Getting Started

```bash
# build & test the solution
dotnet build
dotnet test

# run the Blazor app
dotnet run --project Calculator.Web
# then open http://localhost:5173 (shown in terminal)
```

## Project Layout

```
BlazorCalculator/
├─ Calculator.Engine/           # Reusable calculation engine
├─ Calculator.Engine.Tests/     # xUnit tests for the engine
├─ Calculator.Web/              # Blazor WebAssembly UI
└─ .github/workflows/dotnet.yml # CI
```
