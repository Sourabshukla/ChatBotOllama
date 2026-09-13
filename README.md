<img width="1053" height="911" alt="image" src="https://github.com/user-attachments/assets/b0a12268-380c-4fe2-824b-a98030e38a51" />

# AI Chatbot - .NET, React & Ollama

A local AI chatbot application built using:

- .NET Web API
- React
- Ollama
- Llama 3.2 3B

The application uses Ollama to run the Llama 3.2 3B model locally and provides a .NET API that the React frontend communicates with.

## Architecture

The application follows this flow:

React Frontend
        |
        | HTTP POST
        v
.NET Web API
        |
        | HTTP Request
        v
Ollama
        |
        v
Llama 3.2 3B
        |
        v
.NET Web API
        |
        v
React Frontend


## Prerequisites

Before running the application, install the following:

- .NET SDK
- Node.js and npm
- Ollama
- Git

Make sure all of them are available from PowerShell/Command Prompt.

You can verify them using:

```powershell
dotnet --version
node --version
npm --version
git --version
ollama --version

