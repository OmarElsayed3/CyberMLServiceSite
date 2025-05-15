
# CyberMLServiceSite

CyberMLServiceSite is a web-based platform designed to register and track individuals interested in cybersecurity. The platform also collects and analyzes statistics related to preferences in various cybersecurity tools. It offers a structured and user-friendly interface that facilitates the collection and analysis of interest data for further research and development in the field.

## Team Members

- Omar Elsayed Mahmoud  
- Ahmed Kamal Abdelmageed  
- Omar Abdelaziz Mahmoud  
- Osama Ashraf Eid Saleh  
- Abdullah Ahmed Ragab  

## Key Features

- User registration and login functionality.
- A dynamic form to request cybersecurity-related services.
- Dashboard to track user interests in cybersecurity tools.
- Structured MVC codebase for maintainability and scalability.
- PostgreSQL as the primary relational database.
- Redis caching to enhance performance.
- Dockerized architecture for containerized deployment.
- CI/CD practices integrated via GitHub and Docker Hub.

## Technology Stack

- **Frontend**: HTML, CSS, Razor (ASP.NET MVC Views)  
- **Backend**: ASP.NET MVC (.NET 8, C#)  
- **Database**: PostgreSQL  
- **ORM**: Entity Framework  
- **Caching**: Redis  
- **Containerization**: Docker & Docker Compose  
- **Version Control**: Git & GitHub  
- **Deployment**: Docker Hub

## Pages Included

- **Login Page**: Secure login for returning users.  
- **Registration Page**: New users can sign up and provide cybersecurity interests.  
- **Service Request Form**: Allows users to request a specific cybersecurity-related service for evaluation or support.

## Running the Project Without Docker

### Requirements

- .NET 8 SDK  
- PostgreSQL  
- Redis (optional but recommended)

### Steps

1. Set up a PostgreSQL database and update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=CyberML;Username=postgres;Password=yourpassword"
   }
   ```

2. Apply database migrations if necessary:
   ```bash
   dotnet ef database update
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Open your browser and navigate to:
   ```
   http://localhost:5000
   ```

## Running the Project with Docker

### Requirements

- Docker  
- Docker Compose

### Steps

1. Build the Docker image:
   ```bash
   docker build -t cyberml-backend:latest .
   ```

2. Start all services using Docker Compose:
   ```bash
   docker-compose up
   ```

   This setup will launch:
   - ASP.NET MVC application  
   - PostgreSQL database  
   - Redis cache

3. Visit the application at:
   ```
   http://localhost:5000
   ```

## Repositories and Container Registry

- Docker Hub: [omarelsayed3 on Docker Hub](https://hub.docker.com/u/omarelsayed3)
