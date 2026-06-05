# Full Stack Application CI/CD Deployment

## Prerequisites

* Docker
* Docker Compose
* Git
* GitHub Account
* Docker Hub Account

## Project Structure

project-root/

├── backend/

│ └── Dockerfile

├── frontend/

│ └── Dockerfile

├── docker-compose.yml

└── .github/

└── workflows/

└── deploy.yml

## Local Deployment

### Build and Run

docker compose up --build

### Verify Containers

docker ps

### Access Application

Frontend:
http://localhost:3000

Backend API:
http://localhost:5000

MongoDB:
mongodb://localhost:27017

## GitHub Secrets Required

Create the following repository secrets:

* DOCKER_USERNAME
* DOCKER_PASSWORD

## CI/CD Workflow

1. Push code to main branch.
2. GitHub Actions triggers automatically.
3. Backend tests execute.
4. Frontend tests execute.
5. Docker images are built.
6. Images are pushed to Docker Hub.
7. Application is deployed using Docker Compose.

## Troubleshooting

### Docker Compose Fails

docker compose down
docker compose up --build

### Check Logs

docker logs backend
docker logs frontend
docker logs mongodb

### Verify Running Containers

docker ps
