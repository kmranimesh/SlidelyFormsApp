# Slidely Forms App

## Description
Slidely Forms App is a Windows Desktop Application that replicates the basic functionality of Google Forms. It allows users to create new form submissions and view existing submissions. The application also features a stopwatch that can be started, paused, and resumed without resetting.

## Features
- **Create New Submission**: Allows users to input their Name, Email, Phone Number, and GitHub repo link, and submit the details to the backend.
- **View Submissions**: Allows users to navigate through submitted form entries one by one using "Previous" and "Next" buttons.
- **Stopwatch**: A stopwatch that can be started, paused, and resumed. The stopwatch time is included in the form submission.
- **Keyboard Shortcuts**: 
  - Ctrl + T: Toggle the stopwatch.
  - Ctrl + S: Submit the form.
  - Ctrl + P: View the previous submission.
  - Ctrl + N: View the next submission.

## Desktop App

### Prerequisites
- Visual Studio
- .NET Framework

### Running the Application
1. **Clone the repository**:
  
   git clone https://github.com/kmranimesh/slidely-forms-app.git
   cd slidely-forms-app
   

2. **Open the Solution in Visual Studio**:
   - Open `SlidelyFormsApp.sln` in Visual Studio.

3. **Build and Run the Project**:
   - Go to `Build > Build Solution` to build the project.
   - Press `F5` or go to `Debug > Start Debugging` to run the application.

### Project Structure
```
SlidelyFormsApp/
│
├── CreateSubmissionForm.vb       # Code for Create Submission form
├── CreateSubmissionForm.Designer.vb # Designer code for Create Submission form
├── MainForm.vb                   # Code for the Main form
├── MainForm.Designer.vb          # Designer code for the Main form
├── ViewSubmissionsForm.vb        # Code for View Submissions form
├── ViewSubmissionsForm.Designer.vb # Designer code for View Submissions form
└── ...                           # Other project files
```

## Backend Server

### Prerequisites
- Node.js
- npm

### Setting Up the Backend Server

1. **Clone the repository**:
   git clone https://github.com/kmranimesh/slidely-backend.git
   cd slidely-backend

2. **Install Dependencies**:
   npm install

3. **Run the Server**:
   npm start

### Project Structure
slidely-backend/
│
├── src/
│   ├── server.ts                  # Main server file
├── db.json                        # JSON file to store submissions
├── package.json                   # npm package configuration file
├── tsconfig.json                  # TypeScript configuration file
└── README.md                      # Project documentation

### API Endpoints
- **`/ping`**: 
  - **Method**: GET
  - **Description**: Returns `true` to indicate the server is running.

- **`/submit`**: 
  - **Method**: POST
  - **Parameters**:
    - `name`: string
    - `email`: string
    - `phone`: string
    - `github_link`: string
    - `stopwatch_time`: string
  - **Description**: Submits a new form entry.

- **`/read`**: 
  - **Method**: GET
  - **Query Parameters**:
    - `index`: number (0-based index)
  - **Description**: Retrieves the form entry at the specified index.

## Contribution
Feel free to fork this repository and submit pull requests. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)

Replace `kmranimesh` with your actual GitHub username in the URLs provided in the `README.md`.

This `README.md` file provides a comprehensive overview of the project, including setup instructions, project structure, API endpoints, and contribution guidelines. It should help users understand how to set up and use both the frontend and backend of the Slidely Forms App.
