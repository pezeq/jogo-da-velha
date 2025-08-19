# Tic Tac Toe - Console Game (C#)

This project was developed as part of an academic assignment during my **first semester** of the Computer Science course. The objective was to build a **two-player Tic Tac Toe game** using **methods, functions, and procedures**, focusing on the fundamentals of procedural programming.

## 📚 Project Context

**Course:** Computer Programming  
**Professor:** Lucas Schmidt  
**Language:** C#  
**Platform:** Console Application  
**Purpose:** Reinforce the use of:
- Repetition structures (`do-while`, `for`)
- Conditional logic (`if`, `switch`)
- Functions and methods
- Procedural decomposition
- Character arrays
- User input/output
- Console-based UI

## 🎮 How It Works

- At startup, the user is greeted with a menu to start or exit the game.
- The game prompts both players to enter their names.
- Player 1 plays with symbol `X`, Player 2 with symbol `O`.
- Each round:
  - The board is printed.
  - The current player is prompted to choose a position (1–9).
  - The board updates accordingly.
- The program checks for:
  - A win: rows, columns, or diagonals.
  - A draw: if all positions are filled with no winner.
- At the end, a message declares the winner or if it was a draw.
- The number of rounds is displayed.

## 🧠 Key Concepts Used

- **Functions/Procedures**: Code is organized into modular reusable methods like `Game()`, `PlayerMove()`, `WhoWon()`, `Draw()`, `EndScene()`, and more.
- **2D Win Conditions**: The win logic uses a 2D array of all possible winning index combinations.
- **Clean CLI UI**: The board is redrawn every turn using `Console.Clear()` for clarity.
- **Validation**: Input is validated to ensure positions are available before accepting moves.

## 🖥️ Running the Project

1. Open the project in an IDE like **Visual Studio** or use the **.NET CLI**.
2. Make sure you are using the correct **.NET SDK**.
3. Build and run the project:

```bash
dotnet build
dotnet run
```

## 🏁 Sample Gameplay

```
Insira o nome do jogador 1: João
Insira o nome do jogador 2: Marcos

João (X) e Marcos (O)

João, escolha sua posição:
 1 | 2 | 3
-----------
 4 | 5 | 6
-----------
 7 | 8 | 9

Marcos, escolha sua posição:
 1 | 2 | 3
-----------
 4 | X | 6
-----------
 7 | 8 | 9
```

## ✨ Credits

Developed by **Pedro Ezequiel**  
GitHub: [@pezeq](https://github.com/pezeq)  
Repository: `ezeq/softwares`

---

📌 *This was a purely didactic project. The use of classes and objects was intentionally avoided to reinforce the understanding of procedural programming principles.*