# 🎰 Toto Analyzer

Console application written in C# for analyzing Bulgarian Toto 2 (6/49) lottery draws.

The project downloads historical draw data, processes it with LINQ and visualizes statistics directly in the console using ASCII charts and heat maps.

---

# 📌 Features

## ✅ Data Loading

* Downloads historical Toto 6/49 results
* Supports both:

  * TXT files
  * DOCX files
* Parses and converts data into structured objects

---

## ✅ LINQ Statistics

The application provides several statistical analyses:

### 🔹 Top N Most Frequent Numbers

Shows the most commonly drawn numbers.

### 🔹 Hot Pairs

Finds which number pairs appear together most often.

### 🔹 Distribution by Tens

Groups numbers into:

* 1-10
* 11-20
* 21-30
* 31-40
* 41-49

---

## ✅ Console Visualizations

### 📊 ASCII Bar Charts

Displays statistics using `#` characters.

Example:

```text
7  | #################### 143
34 | ##################   128
21 | #################    119
```

### 🌡 Heat Map 7x7

Numbers from 1 to 49 are displayed in a colored grid.

Colors:

* 🔴 Red → hot numbers
* 🟡 Yellow → neutral
* 🔵 Cyan → cold numbers

---

## ✅ Interactive Menu

Users can:

* select period of analysis;
* choose different statistics;
* enter custom parameters.

---

# 🛠 Technologies Used

* C#
* .NET
* LINQ
* Regex
* HttpClient
* OpenXML SDK
* Console API

---

# 📂 Project Structure

```text
CourseProject/
│
├── DataLoader.cs
├── Statistics.cs
├── Visualizer.cs
├── Processor.cs
├── Draw.cs
└── Program.cs
```

---

# 🚀 How to Run

## 1. Clone the repository

```bash
git clone https://github.com/your-username/toto-analyzer.git
```

## 2. Open the project

Open the solution in:

* Visual Studio
* Rider
* VS Code

---

## 3. Install dependencies

Install OpenXML package:

```bash
Install-Package DocumentFormat.OpenXml
```

---

## 4. Run the project

```bash
dotnet run
```

---

# 📷 Screenshots

## Main Menu

(Add screenshot here)

---

## Top Numbers Bar Chart

(Add screenshot here)

---

## Hot Pairs

(Add screenshot here)

---

## Distribution by Tens

(Add screenshot here)

---

## Heat Map

(Add screenshot here)

---

# 📚 Educational Purpose

This project was created as a university/course assignment to demonstrate:

* LINQ usage;
* file processing;
* data parsing;
* console visualizations;
* clean project architecture.
