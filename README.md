# Cybersecurity Awareness Chatbot

![ASCII Logo](logo.jpg)

A console-based chatbot designed to educate users about cybersecurity best practices and answer common security-related questions.

## Features

- **Interactive Chat Interface**: Engage in conversation about cybersecurity topics
- **Audio Welcome**: Plays a welcome sound on startup
- **ASCII Art Display**: Shows a cybersecurity-themed logo in ASCII art
- **Memory System**: Remembers previous conversations and questions
- **Comprehensive Knowledge Base**: Answers questions on various cybersecurity topics including:
  - Password security
  - Phishing attacks
  - Safe browsing practices
  - VPN usage
  - Social engineering
  - Malware protection
  - Computer security fundamentals

## Installation

1. **Prerequisites**:
   - .NET Core SDK (version 3.1 or later)
   - Windows OS (for audio playback functionality)

2. **Setup**:

https://github.com/snjili/POE-ChatBot-ST10450294
cd cybersecurity-chatbot


3. **Required Files**:
- Place `Welcome audio.wav` in the project root directory
- Place `logo.jpg` in the project root directory

## Usage

1. Run the application:
dotnet run


2. Follow the on-screen prompts:
- Enter your name when prompted
- Type your cybersecurity questions
- Use "exit" to end the session

3. Available commands:
- `password` - Get tips for creating strong passwords
- `phishing` - Learn how to identify phishing attempts
- `vpn` - Understand VPN benefits
- `malware` - Learn about malware protection
- `exit` - End the chat session

## File Structure
cybersecurity-chatbot/
├── Program.cs # Main application entry point
├── AudioPlayer.cs # Handles audio playback
├── AsciiLogo.cs # Generates ASCII art from image
├── Chatbot.cs # Main chatbot logic
├── memory_recall/ # Conversation memory system
│ ├── Check_writeFile.cs # File operations for memory
│ └── Program.cs # Memory system entry point
├── Welcome audio.wav # Welcome sound file
└── logo.jpg # Logo image for ASCII conversion



