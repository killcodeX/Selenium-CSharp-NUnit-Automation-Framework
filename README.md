# Selenium-CSharp-NUnit-Automation-Framework

> **E-commerce Test Automation Framework** built with Selenium WebDriver, C#, and NUnit using Page Object Model (POM) design pattern.

[![.NET](https://img.shields.io/badge/.NET-6.0-blue.svg)](https://dotnet.microsoft.com/)
[![Selenium](https://img.shields.io/badge/Selenium-4.15-green.svg)](https://www.selenium.dev/)
[![NUnit](https://img.shields.io/badge/NUnit-3.14-orange.svg)](https://nunit.org/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## 📋 Table of Contents

- [About The Project](#about-the-project)
- [Built With](#built-with)
- [Project Architecture](#project-architecture)
- [Getting Started](#getting-started)
- [Test Cases](#test-cases)
- [Running Tests](#running-tests)
- [Test Reports](#test-reports)
- [Project Highlights](#project-highlights)
- [Contact](#contact)

---

## 🎯 About The Project

This is a robust test automation framework designed to demonstrate best practices in test automation for e-commerce applications. The framework tests the complete user registration flow on [AutomationExercise.com](http://automationexercise.com) including user signup, account creation, and account deletion.

**Key Features:**

- ✅ Page Object Model (POM) design pattern
- ✅ Reusable business flow components
- ✅ Data-driven testing with random test data generation
- ✅ Detailed HTML test reports with screenshots
- ✅ Cross-browser testing support (Chrome, Firefox, Edge)
- ✅ Parallel test execution capability
- ✅ Screenshot capture on test failures
- ✅ CI/CD ready with GitHub Actions

---

## 🛠️ Built With

**Core Technologies:**

- **Language:** C# (.NET 6.0)
- **Automation Tool:** Selenium WebDriver 4.15
- **Testing Framework:** NUnit 3.14
- **Build Tool:** MSBuild / Visual Studio 2022
- **Driver Management:** WebDriverManager 2.17
- **Reporting:** ExtentReports 5.0

---

## 🏗️ Project Architecture

```
AutomationExercise/
│
├── 📂 Pages/                        # Page Object classes
│   ├── BasePage.cs                  # Common page methods
│   ├── HomePage.cs                  # Home page interactions
│   ├── SignupLoginPage.cs           # Signup/Login page
│   ├── SignupPage.cs                # Registration form page
│   ├── AccountCreatedPage.cs        # Account success page
│   └── AccountDeletedPage.cs        # Account deletion page
│
├── 📂 Flows/                        # Business logic flows
│   ├── RegistrationFlow.cs         # Complete registration workflow
│   └── LoginFlow.cs                 # User login workflow
│
├── 📂 Tests/                        # Test cases
│   ├── BaseTest.cs                  # Test setup/teardown
│   ├── RegistrationTests.cs        # Registration test scenarios
│   └── AllTests.cs                  # Main test suite
│
├── 📂 Utils/                        # Utility classes
│   ├── DriverFactory.cs             # WebDriver initialization
│   ├── ConfigReader.cs              # Configuration management
│   ├── TestDataGenerator.cs        # Random test data
│   └── ScreenshotHelper.cs          # Screenshot utilities
│
├── 📂 TestData/                     # Test data models
│   └── UserData.cs                  # User data structure
│
├── 📂 Reports/                      # Generated test reports
├── 📂 Screenshots/                  # Failure screenshots
├── app.config                       # Application configuration
└── README.md                        # Project documentation
```

**Design Pattern:** Page Object Model (POM)

- Separates test logic from UI interactions
- Improves code reusability and maintainability
- Makes tests more readable and easier to maintain

---

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET 6.0 SDK or later
- Chrome/Firefox/Edge browser installed

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/YOUR_USERNAME/Selenium-CSharp-NUnit-Automation-Framework.git
   cd Selenium-CSharp-NUnit-Automation-Framework
   ```

2. **Open in Visual Studio**

   - Open `AutomationExercise.sln` in Visual Studio

3. **Restore NuGet Packages**

   ```bash
   dotnet restore
   ```

   Or in Visual Studio: `Tools > NuGet Package Manager > Restore NuGet Packages`

4. **Build the solution**
   ```bash
   dotnet build
   ```

### Configuration

Edit `app.config` to customize settings:

```xml
<configuration>
  <appSettings>
    <add key="BaseUrl" value="http://automationexercise.com" />
    <add key="Browser" value="Chrome" />
    <add key="ImplicitWait" value="10" />
    <add key="ExplicitWait" value="20" />
    <add key="TakeScreenshotOnFailure" value="true" />
  </appSettings>
</configuration>
```

---

## 📝 Test Cases

### Test Case 1: Register User

**Scenario:** Complete user registration flow

| Step | Action                                           | Expected Result               |
| ---- | ------------------------------------------------ | ----------------------------- |
| 1    | Launch browser                                   | Browser opens successfully    |
| 2    | Navigate to URL                                  | Website loads                 |
| 3    | Verify home page                                 | Home page is visible          |
| 4    | Click 'Signup / Login'                           | Navigation successful         |
| 5    | Verify 'New User Signup!'                        | Text is visible               |
| 6    | Enter name and email                             | Fields populated              |
| 7    | Click 'Signup' button                            | Form submits                  |
| 8    | Verify 'ENTER ACCOUNT INFORMATION'               | Page visible                  |
| 9    | Fill details (Title, Name, Email, Password, DOB) | All fields filled             |
| 10   | Select 'Sign up for newsletter!'                 | Checkbox selected             |
| 11   | Select 'Receive special offers!'                 | Checkbox selected             |
| 12   | Fill address details                             | All fields filled             |
| 13   | Click 'Create Account'                           | Account created               |
| 14   | Verify 'ACCOUNT CREATED!'                        | Success message shown         |
| 15   | Click 'Continue'                                 | Navigation to logged in state |
| 16   | Verify 'Logged in as username'                   | User is logged in             |
| 17   | Click 'Delete Account'                           | Account deletion initiated    |
| 18   | Verify 'ACCOUNT DELETED!'                        | Success message shown         |

---

## ▶️ Running Tests

### Run All Tests

```bash
dotnet test
```

### Run Specific Test

```bash
dotnet test --filter "FullyQualifiedName~RegistrationTests.TestCase1_RegisterUser"
```

### Run by Category

```bash
# Run smoke tests
dotnet test --filter TestCategory=Smoke

# Run regression tests
dotnet test --filter TestCategory=Regression
```

### Run with Specific Browser

Modify `app.config` or pass as parameter:

```csharp
// In code
DriverFactory.InitDriver("Firefox");
```

### Visual Studio Test Explorer

1. Open Test Explorer: `Test > Test Explorer`
2. Click `Run All` or right-click specific tests
3. View results in real-time

---

## 📊 Test Reports

### HTML Reports

After test execution, find reports in:

```
Reports/TestReport_YYYY-MM-DD_HH-MM-SS.html
```

**Report includes:**

- Test execution summary (Pass/Fail/Skip)
- Detailed step-by-step logs
- Screenshots for failed tests
- Execution time for each test
- Browser and environment details

### Screenshots

Failed test screenshots are saved in:

```
Screenshots/TestName_YYYY-MM-DD_HH-MM-SS.png
```

---

## ✨ Project Highlights

### Why This Framework Stands Out

1. **Industry-Standard Design Pattern**

   - Implements Page Object Model for maximum maintainability
   - Separates business logic from test logic

2. **Reusable Components**

   - Flow classes enable complex scenario testing
   - DRY (Don't Repeat Yourself) principle throughout

3. **Robust & Reliable**

   - Explicit waits prevent flaky tests
   - Screenshot capture for debugging
   - Comprehensive error handling

4. **Scalable Architecture**

   - Easy to add new test cases
   - Supports multiple browsers
   - Ready for parallel execution

5. **Professional Reporting**

   - Detailed HTML reports with ExtentReports
   - Visual evidence with screenshots
   - Easy to share with stakeholders

6. **CI/CD Ready**
   - Can integrate with GitHub Actions
   - Azure DevOps compatible
   - Jenkins pipeline ready

---

## 🔮 Future Enhancements

- [ ] Integrate with GitHub Actions for CI/CD
- [ ] Add API testing layer
- [ ] Implement Docker containerization
- [ ] Add database validation
- [ ] Cross-browser parallel execution
- [ ] Integrate with Allure reporting
- [ ] Add performance testing metrics
- [ ] Implement BDD with SpecFlow

---

## 📧 Contact

**Your Name**

- LinkedIn: [Aaquib Ahmad](https://www.linkedin.com/in/aaquib-ahmed/)
- Email: aaquib.ahmadus@example.com
- Portfolio: [aaquibahmad](https://aaquibahmad.com/)

**Project Link:** [https://github.com/YOUR_USERNAME/Selenium-CSharp-NUnit-Automation-Framework](https://github.com/YOUR_USERNAME/Selenium-CSharp-NUnit-Automation-Framework)

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 🙏 Acknowledgments

- Test scenarios from [AutomationExercise.com](http://automationexercise.com)
- Selenium WebDriver documentation
- NUnit framework documentation
- C# and .NET community

---

### ⭐ If you found this project helpful, please give it a star!

---

**Made with ❤️ by Aaquib Ahmad**
