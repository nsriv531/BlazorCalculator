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

## What to Look For (Recruiter Notes)

- Separation of concerns: UI layer is thin; business logic is tested in isolation.
- Clean components: `Calculator.razor` composes small `CalcButton` components.
- Accessibility: semantic buttons, labels, focus outlines, keyboard input.
- Robustness: input validation, division-by-zero guard, `C`/`AC` behavior.
- Maintainability: editorconfig, gitignore, unit tests, CI.

## Deploy

You can publish to static hosting (e.g., GitHub Pages, Netlify, Vercel):

```bash
dotnet publish Calculator.Web -c Release -o publish
```

Serve the `publish/wwwroot` folder with any static server.
